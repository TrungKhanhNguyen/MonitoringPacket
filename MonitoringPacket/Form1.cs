﻿using PacketDotNet;
using PacketDotNet.Ieee80211;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MonitoringPacket
{
    public partial class Form1 : Form
    {
        List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
        int selectedIntIndex;
        LibPcapLiveDevice wifi_device;
        CaptureFileWriterDevice captureFileWriter;
        Dictionary<int, Packet> capturedPackets_list = new Dictionary<int, Packet>();

        int packetNumber = 1;
        string time_str = "", sourceIP = "", destinationIP = "", protocol_type = "", length = "";

        bool startCapturingAgain = false;

        Thread sniffing;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnStop_Click(object sender, EventArgs e)
        {
            sniffing.Abort();
            wifi_device.StopCapture();
            wifi_device.Close();
            captureFileWriter.Close();

            btnStart.Enabled = true;
            textBox1.Enabled = true;
            btnStop.Enabled = false;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string protocol = dataGridView1.Rows[e.RowIndex].Cells["Protocol"].Value.ToString().ToLower();
            int key = Int32.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Packet packet;
            bool getPacket = capturedPackets_list.TryGetValue(key, out packet);

            switch (protocol)
            {
                case "tcp":
                    if (getPacket)
                    {
                        var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
                        if (tcpPacket != null)
                        {
                            int srcPort = tcpPacket.SourcePort;
                            int dstPort = tcpPacket.DestinationPort;
                            var checksum = tcpPacket.Checksum;

                            textBox2.Text = "";
                            textBox2.Text = "Packet number: " + key +
                                            ", Type: TCP" +
                                            "\r\nSource port:" + srcPort +
                                            "\r\nDestination port: " + dstPort +
                                            "\r\nTCP header size: " + tcpPacket.DataOffset +
                                            "\r\nWindow size: " + tcpPacket.WindowSize + // bytes that the receiver is willing to receive
                                            "\r\nChecksum:" + checksum.ToString() + (tcpPacket.ValidChecksum ? ",valid" : ",invalid") +
                                            "\r\nTCP checksum: " + (tcpPacket.ValidTcpChecksum ? ",valid" : ",invalid") +
                                            "\r\nSequence number: " + tcpPacket.SequenceNumber.ToString() +
                                            "\r\nAcknowledgment number: " + tcpPacket.AcknowledgmentNumber + (tcpPacket.Acknowledgment ? ",valid" : ",invalid") +
                                            // flags
                                            "\r\nUrgent pointer: " + (tcpPacket.Urgent ? "valid" : "invalid") +
                                            "\r\nACK flag: " + (tcpPacket.Acknowledgment ? "1" : "0") + // indicates if the AcknowledgmentNumber is valid
                                            "\r\nPSH flag: " + (tcpPacket.Push ? "1" : "0") + // push 1 = the receiver should pass the data to the app immidiatly, don't buffer it
                                            "\r\nRST flag: " + (tcpPacket.Reset ? "1" : "0") + // reset 1 is to abort existing connection
                                                                                             // SYN indicates the sequence numbers should be synchronized between the sender and receiver to initiate a connection
                                            "\r\nSYN flag: " + (tcpPacket.Synchronize ? "1" : "0") +
                                            // closing the connection with a deal, host_A sends FIN to host_B, B responds with ACK
                                            // FIN flag indicates the sender is finished sending
                                            "\r\nFIN flag: " + (tcpPacket.Finished ? "1" : "0") +
                                            "\r\nECN flag: " + (tcpPacket.ExplicitCongestionNotificationEcho ? "1" : "0") +
                                            "\r\nCWR flag: " + (tcpPacket.CongestionWindowReduced ? "1" : "0") +
                                            "\r\nNS flag: " + (tcpPacket.NonceSum ? "1" : "0");
                        }
                    }
                    break;
                case "udp":
                    if (getPacket)
                    {
                        var udpPacket = packet.Extract<PacketDotNet.UdpPacket>();
                        if (udpPacket != null)
                        {
                            int srcPort = udpPacket.SourcePort;
                            int dstPort = udpPacket.DestinationPort;
                            var checksum = udpPacket.Checksum;

                            textBox2.Text = "";
                            textBox2.Text = "Packet number: " + key +
                                            ", Type: UDP" +
                                            "\r\nSource port:" + srcPort +
                                            "\r\nDestination port: " + dstPort +
                                            "\r\nChecksum:" + checksum.ToString() + " valid: " + udpPacket.ValidChecksum +
                                            "\r\nValid UDP checksum: " + udpPacket.ValidUdpChecksum;
                        }
                    }
                    break;
                case "arp":
                    if (getPacket)
                    {
                        var arpPacket = packet.Extract<PacketDotNet.ArpPacket>();
                        
                        if (arpPacket != null)
                        {
                            System.Net.IPAddress senderAddress = arpPacket.SenderProtocolAddress;
                            System.Net.IPAddress targerAddress = arpPacket.TargetProtocolAddress;
                            System.Net.NetworkInformation.PhysicalAddress senderHardwareAddress = arpPacket.SenderHardwareAddress;
                            System.Net.NetworkInformation.PhysicalAddress targerHardwareAddress = arpPacket.TargetHardwareAddress;

                            textBox2.Text = "";
                            textBox2.Text = "Packet number: " + key +
                                            ", Type: ARP" +
                                            "\r\nHardware address length:" + arpPacket.HardwareAddressLength +
                                            "\r\nProtocol address length: " + arpPacket.ProtocolAddressLength +
                                            "\r\nOperation: " + arpPacket.Operation.ToString() + // ARP request or ARP reply ARP_OP_REQ_CODE, ARP_OP_REP_CODE
                                            "\r\nSender protocol address: " + senderAddress +
                                            "\r\nTarget protocol address: " + targerAddress +
                                            "\r\nSender hardware address: " + senderHardwareAddress +
                                            "\r\nTarget hardware address: " + targerHardwareAddress;
                        }
                    }
                    break;
                case "icmp":
                    if (getPacket)
                    {
                        var icmpPacket = packet.Extract<PacketDotNet.IcmpV4Packet>();
                        if (icmpPacket != null)
                        {
                            textBox2.Text = "";
                            textBox2.Text = "Packet number: " + key +
                                            ", Type: ICMP v4" +
                                            "\r\nType Code: 0x" + icmpPacket.TypeCode.ToString("x") +
                                            "\r\nChecksum: " + icmpPacket.Checksum.ToString("x") +
                                            "\r\nID: 0x" + icmpPacket.Id.ToString("x") +
                                            "\r\nSequence number: " + icmpPacket.Sequence.ToString("x");
                        }
                    }
                    break;
                case "igmp":
                    if (getPacket)
                    {
                        var igmpPacket = packet.Extract<PacketDotNet.IgmpV2Packet>();
                        if (igmpPacket != null)
                        {
                            textBox2.Text = "";
                            textBox2.Text = "Packet number: " + key +
                                            " Type: IGMP v2" +
                                            "\r\nType: " + igmpPacket.Type +
                                            "\r\nGroup address: " + igmpPacket.GroupAddress +
                                            "\r\nMax response time" + igmpPacket.MaxResponseTime;
                        }
                    }
                    break;
                default:
                    textBox2.Text = "";
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;

            foreach (LibPcapLiveDevice device in devices)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var name = devInterface.Name;
                var description = devInterface.Description;

                interfaceList.Add(device);
                comboBox1.Items.Add(description);

                
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string mac = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                {
                    if (nic.GetPhysicalAddress().ToString() != "")
                    {
                        mac = nic.GetPhysicalAddress().ToString();
                        textBox2.Text += mac;
                    }
                }
            }
            //MessageBox.Show(mac);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            selectedIntIndex = comboBox1.SelectedIndex;
            wifi_device = interfaceList[selectedIntIndex];

            if (startCapturingAgain == false) //first time 
            {
                System.IO.File.Delete(Environment.CurrentDirectory + "capture.pcap");
                wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
                sniffing = new Thread(new ThreadStart(sniffing_Proccess));
                sniffing.Start();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                textBox1.Enabled = false;

            }
            else if (startCapturingAgain)
            {
                if (MessageBox.Show("Your packets are captured in a file. Starting a new capture will override existing ones.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    // user clicked ok
                    System.IO.File.Delete(Environment.CurrentDirectory + "capture.pcap");

                    dataGridView1.Rows.Clear();

                    capturedPackets_list.Clear();
                    packetNumber = 1;
                    textBox2.Text = "";
                    wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
                    sniffing = new Thread(new ThreadStart(sniffing_Proccess));
                    sniffing.Start();
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    textBox1.Enabled = false;
                }
            }
            startCapturingAgain = true;
        }

        private void sniffing_Proccess()
        {
            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            wifi_device.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

            // Start the capturing process
            if (wifi_device.Opened)
            {
                if (textBox1.Text != "")
                {
                    wifi_device.Filter = textBox1.Text;
                }
                captureFileWriter = new CaptureFileWriterDevice("capture.pcap");
                captureFileWriter.Open(wifi_device);

                wifi_device.Capture();
            }
        }

        public void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            // dump to a file
            var rawPacket = e.GetPacket();
            captureFileWriter.Write(rawPacket);


            // start extracting properties for the listview 
            DateTime time = rawPacket.Timeval.Date;
            //time_str = time.ToString("yyyy-MM-dd HH:mm:ss");
            time_str =  (time.Hour + 1) + ":" + time.Minute + ":" + time.Second + ":" + time.Millisecond;
            length = rawPacket.Data.Length.ToString();


            var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            // add to the list

            
            var ethernetPacket = (EthernetPacket)packet;
            
            //var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
            var ipPacket = packet.Extract<PacketDotNet.IPPacket>();

            var arpPacket = packet.Extract<PacketDotNet.ArpPacket>();

            if(arpPacket!= null)
            {
                
                    System.Net.IPAddress senderAddress = arpPacket.SenderProtocolAddress;
                    System.Net.IPAddress targetAddress = arpPacket.TargetProtocolAddress;
                    System.Net.NetworkInformation.PhysicalAddress senderHardwareAddress = arpPacket.SenderHardwareAddress;
                    System.Net.NetworkInformation.PhysicalAddress targerHardwareAddress = arpPacket.TargetHardwareAddress;

                    dataGridView1.Invoke(new Action(() => {
                        //dataGridView1.Rows.Add();
                        capturedPackets_list.Add(packetNumber, packet);

                        int rowId = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[rowId];

                        // Add the data
                        row.Cells["Number"].Value = packetNumber;
                        row.Cells["Time"].Value = time_str;
                        row.Cells["Source"].Value = senderAddress;
                        row.Cells["Destination"].Value = targetAddress;
                        row.Cells["Protocol"].Value = "ARP";
                        row.Cells["PacketLength"].Value = length;
                        row.Cells["SourceMac"].Value = getMacAddress(senderHardwareAddress.ToString());
                        row.Cells["DestinationMac"].Value = getMacAddress(targerHardwareAddress.ToString());
                        packetNumber++;
                    }));
            }

            if (ipPacket != null && ethernetPacket != null)
            {
                //var ipPacket = (PacketDotNet.IPPacket)tcpPacket.ParentPacket;

                System.Net.IPAddress srcIp = ipPacket.SourceAddress;
                System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
                protocol_type = ipPacket.Protocol.ToString();
                sourceIP = srcIp.ToString();
                destinationIP = dstIp.ToString();

                var sourceMac = ethernetPacket.SourceHardwareAddress;
                var destinationMac = ethernetPacket.DestinationHardwareAddress;


                dataGridView1.Invoke(new Action(() => {
                    //dataGridView1.Rows.Add();
                    capturedPackets_list.Add(packetNumber, packet);

                    int rowId = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowId];

                    // Add the data
                    row.Cells["Number"].Value = packetNumber;
                    row.Cells["Time"].Value = time_str;
                    row.Cells["Source"].Value = sourceIP;
                    row.Cells["Destination"].Value = destinationIP;
                    row.Cells["Protocol"].Value = protocol_type.ToUpper();
                    row.Cells["PacketLength"].Value = length;
                    row.Cells["SourceMac"].Value = getMacAddress(sourceMac.ToString());
                    row.Cells["DestinationMac"].Value = getMacAddress(destinationMac.ToString());
                    packetNumber++;
                }));
            }
        }

        private string getMacAddress(string originalStr)
        {
            try
            {
                var regex = String.Concat(Enumerable.Repeat("([a-fA-F0-9]{2})", 6));
                var replace = "$1:$2:$3:$4:$5:$6";
                var newformat = Regex.Replace(originalStr, regex, replace);
                return newformat;
            }
            catch
            {
                return originalStr;
            }
        }
    }
}
