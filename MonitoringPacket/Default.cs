using Bunifu.Framework.UI;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MonitoringPacket
{
    public partial class Default : Form
    {
        List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
        int selectedIntIndex;
        LibPcapLiveDevice wifi_device;
        CaptureFileWriterDevice captureFileWriter;
        Dictionary<int, Packet> capturedPackets_list = new Dictionary<int, Packet>();

        int packetNumber = 1;
        string time_str = "", sourceIP = "", destinationIP = "", protocol_type = "", length = "";

        
        //SpoofARP ArpSpoofer { get; set; }


        bool startCapturingAgain = false;
        string targetIP { get; set; }

        Thread sniffing;
        public Default(string ip)
        {
            targetIP = ip;
            InitializeComponent();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            if (!String.IsNullOrEmpty(targetIP))
            {
                txtFilters.Text = "host " +  targetIP;
            }
            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;

            foreach (LibPcapLiveDevice device in devices)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var name = devInterface.Name;
                var description = devInterface.Description;

                interfaceList.Add(device);
                dropdownNIC.Items.Add(description);
            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        //private void radCapture_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        //{
        //    btnStart.Enabled = btnStop.Enabled = txtFilter.Enabled = radCapture.Checked;
        //    btnBrowse.Enabled = btnImport.Enabled = radRead.Checked;
        //}

        //private void radRead_CheckedChanged2(object sender, Bunifu.UI.WinForms.BunifuRadioButton.CheckedChangedEventArgs e)
        //{
        //    if (radRead.Checked)
        //    {
        //        if(wifi_device!= null)
        //        {
        //            wifi_device.StopCapture();
        //            wifi_device.Close();
        //        }
        //        if(captureFileWriter != null)
        //            captureFileWriter.Close();
        //        if (sniffing != null)
        //            sniffing.Abort();

        //        dataGridView1.Rows.Clear();
        //        capturedPackets_list.Clear();
        //    }
        //        //btnStop.PerformClick();

        //    btnStart.Enabled = btnStop.Enabled = txtFilter.Enabled = radCapture.Checked;
        //    btnBrowse.Enabled = btnImport.Enabled = radRead.Checked;
            
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string protocol = dataGridView1.Rows[e.RowIndex].Cells["Protocol"].Value.ToString().ToLower();
            string sourceIP = dataGridView1.Rows[e.RowIndex].Cells["Source"].Value.ToString().ToLower();
            string destinationIP = dataGridView1.Rows[e.RowIndex].Cells["Destination"].Value.ToString().ToLower();
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

                            txtInfo.Text = "";
                            txtInfo.Text = "Packet number: " + key +
                                            ", Type: TCP" +
                                            "\r\nSource port:" + srcPort +
                                            ", Destination port: " + dstPort +
                                            "\r\nTCP header size: " + tcpPacket.DataOffset +
                                            ", Window size: " + tcpPacket.WindowSize + // bytes that the receiver is willing to receive
                                            "\r\nChecksum:" + checksum.ToString() + (tcpPacket.ValidChecksum ? ",valid" : ",invalid") +
                                            ", TCP checksum: " + (tcpPacket.ValidTcpChecksum ? ",valid" : ",invalid") +
                                            ", Sequence number: " + tcpPacket.SequenceNumber.ToString() +
                                            ", Acknowledgment number: " + tcpPacket.AcknowledgmentNumber + (tcpPacket.Acknowledgment ? ",valid" : ",invalid") +
                                            // flags
                                            "\r\nUrgent pointer: " + (tcpPacket.Urgent ? "valid" : "invalid") +
                                            ", ACK flag: " + (tcpPacket.Acknowledgment ? "1" : "0") + // indicates if the AcknowledgmentNumber is valid
                                            ", PSH flag: " + (tcpPacket.Push ? "1" : "0") + // push 1 = the receiver should pass the data to the app immidiatly, don't buffer it
                                            ", RST flag: " + (tcpPacket.Reset ? "1" : "0") + // reset 1 is to abort existing connection
                                                                                               // SYN indicates the sequence numbers should be synchronized between the sender and receiver to initiate a connection
                                            ", SYN flag: " + (tcpPacket.Synchronize ? "1" : "0") +
                                            // closing the connection with a deal, host_A sends FIN to host_B, B responds with ACK
                                            // FIN flag indicates the sender is finished sending
                                            "\r\nFIN flag: " + (tcpPacket.Finished ? "1" : "0") +
                                            ", ECN flag: " + (tcpPacket.ExplicitCongestionNotificationEcho ? "1" : "0") +
                                            ", CWR flag: " + (tcpPacket.CongestionWindowReduced ? "1" : "0") +
                                            ", NS flag: " + (tcpPacket.NonceSum ? "1" : "0");
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

                            txtInfo.Text = "";
                            txtInfo.Text = "Packet number: " + key +
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

                            txtInfo.Text = "";
                            txtInfo.Text = "Packet number: " + key +
                                            ", Type: ARP" +
                                            "\r\nHardware address length:" + arpPacket.HardwareAddressLength +
                                            "\r\nProtocol address length: " + arpPacket.ProtocolAddressLength +
                                            ", Operation: " + arpPacket.Operation.ToString() + // ARP request or ARP reply ARP_OP_REQ_CODE, ARP_OP_REP_CODE
                                            "\r\nSender protocol address: " + senderAddress +
                                            ", Target protocol address: " + targerAddress +
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
                            txtInfo.Text = "";
                            txtInfo.Text = "Packet number: " + key +
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
                            txtInfo.Text = "";
                            txtInfo.Text = "Packet number: " + key +
                                            " Type: IGMP v2" +
                                            "\r\nType: " + igmpPacket.Type +
                                            "\r\nGroup address: " + igmpPacket.GroupAddress +
                                            "\r\nMax response time" + igmpPacket.MaxResponseTime;
                        }
                    }
                    break;
                default:
                    txtInfo.Text = "";
                    break;
            }

            //txtInfo.Text += "\r\n Source hostname:" + getHostNameFromIP(sourceIP);
            //txtInfo.Text += "\r\n Destination hostname:" + getHostNameFromIP(destinationIP);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            sniffing.Abort();
            wifi_device.StopCapture();
            wifi_device.Close();
            captureFileWriter.Close();
            //ArpSpoofer.StopAsync();
            btnStart.Enabled = true;
            txtFilters.Enabled = true;
            btnStop.Enabled = false;

            DialogResult dialogResult = MessageBox.Show("Do you want to save pcap file?", "Save file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    string dummyFileName = "sniffer-" + DateTime.Now.ToString("yyyyMMdd-HHmm");

                    SaveFileDialog sf = new SaveFileDialog();
                    // Feed the dummy name to the save dialog
                    sf.FileName = dummyFileName;
                    sf.Filter = "Pcap (*.pcap)|*.pcap";
                    //sf.DefaultExt = "pcap";

                    if (sf.ShowDialog() == DialogResult.OK)
                    {

                        // Now here's our save folder
                        string savePath = Path.GetFullPath(sf.FileName);
                        //var fullPath = savePath + 
                        System.IO.File.Copy("capture.pcap", savePath);
                        // Do whatever
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Unhandled error: " + ex.Message, "Errors");
                }
                //do something
               
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private string getHostNameFromIP(string ip)
        {
            try{
                IPAddress addr = IPAddress.Parse(ip);
                IPHostEntry entry = Dns.GetHostEntry(addr);
                return entry.HostName;
            }
            catch
            {
                return "Unknown";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;

            selectedIntIndex = dropdownNIC.SelectedIndex;
            wifi_device = interfaceList[selectedIntIndex];

            if (startCapturingAgain == false) //first time 
            {
                System.IO.File.Delete("capture.pcap");
                wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
                sniffing = new Thread(new ThreadStart(sniffing_Proccess));
                sniffing.Start();
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                txtFilters.Enabled = false;

                dataGridView1.Rows.Clear();
                capturedPackets_list.Clear();
            }
            //else if (startCapturingAgain)
            //{
            //    if (MessageBox.Show("Your packets are captured in a file. Starting a new capture will override existing ones.", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            //    {
            //        // user clicked ok
            //        System.IO.File.Delete("capture.pcap");

            //        dataGridView1.Rows.Clear();
            //        capturedPackets_list.Clear();
            //        packetNumber = 1;
            //        txtInfo.Text = "";
            //        wifi_device.OnPacketArrival += new PacketArrivalEventHandler(Device_OnPacketArrival);
            //        sniffing = new Thread(new ThreadStart(sniffing_Proccess));
            //        sniffing.Start();
            //        btnStart.Enabled = false;
            //        btnStop.Enabled = true;
            //        txtFilters.Enabled = false;
            //    }
            //}
            //startCapturingAgain = true;

        }

        private void sniffing_Proccess()
        {
            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            wifi_device.Open(mode: DeviceModes.Promiscuous | DeviceModes.DataTransferUdp | DeviceModes.NoCaptureLocal, read_timeout: readTimeoutMilliseconds);

            // Start the capturing process
            if (wifi_device.Opened)
            {
                if (txtFilters.Text != "")
                {
                    wifi_device.Filter = txtFilters.Text;
                }
                captureFileWriter = new CaptureFileWriterDevice("capture.pcap");
                captureFileWriter.Open(wifi_device);

                wifi_device.Capture();
            }
        }

        public void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            //MessageBox.Show("Done");
            // dump to a file
            var rawPacket = e.GetPacket();
            captureFileWriter.Write(rawPacket);

            // start extracting properties for the listview 
            DateTime time = rawPacket.Timeval.Date.AddHours(7);
            //time_str = time.ToString("yyyy-MM-dd HH:mm:ss");
            time_str = time.ToString("yyyy-MM-dd HH:mm:ss:fff");
            length = rawPacket.Data.Length.ToString();

            var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            // add to the list

            var ethernetPacket = (EthernetPacket)packet;

            //var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
            var ipPacket = packet.Extract<PacketDotNet.IPPacket>();

            var arpPacket = packet.Extract<PacketDotNet.ArpPacket>();

            //var icmpPacket = packet.Extract<PacketDotNet.Packet>();

            if (arpPacket != null)
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

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuPanel1.Dock = DockStyle.None; // Un-dock
                this.WindowState = FormWindowState.Minimized;
                isMinimized = true;
                //this.WindowState = FormWindowState.Minimized;
            }
            catch { }
            
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
        public bool isMinimized = false;
        private void Default_Resize(object sender, EventArgs e)
        {
            if (isMinimized == true)
            {
                bunifuPanel1.Dock = DockStyle.Top;    // Re-dock
                //bunifuPanel1.Width = Default. ; // maintain desired width
                isMinimized = false;
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

        //private void btnBrowse_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog fdlg = new OpenFileDialog();
        //    fdlg.Title = "Select pcap file";
        //    fdlg.InitialDirectory = @"c:\";
        //    fdlg.Filter = "All files (*.*)|*.pcap";
        //    fdlg.FilterIndex = 2;
        //    fdlg.RestoreDirectory = true;
        //    if (fdlg.ShowDialog() == DialogResult.OK)
        //    {
        //        txtFilePath.Text = fdlg.FileName;
        //    }
        //}

        //private void btnImport_Click(object sender, EventArgs e)
        //{
        //    ICaptureDevice device;
        //    var capFile = txtFilePath.Text;
        //    try
        //    {
        //        capturedPackets_list.Clear();
        //        dataGridView1.Rows.Clear();
        //        // Get an offline device
        //        device = new CaptureFileReaderDevice(capFile);

        //        device.Open();

        //        device.OnPacketArrival +=
        //        new PacketArrivalEventHandler(IDevice_OnPacketArrival);
        //        // Open the device
        //        if (txtReadFilter.Text != "")
        //        {
        //            device.Filter = txtReadFilter.Text;
        //        }
        //        device.Capture();
        //        device.Close();
        //        MessageBox.Show("Finish loaded file");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Caught exception when opening file" + ex.ToString());
        //        return;
        //    }
        //}

        public void IDevice_OnPacketArrival(object sender, PacketCapture e)
        {
            // dump to a file
            var rawPacket = e.GetPacket();

            DateTime time = rawPacket.Timeval.Date.AddHours(7);
            //time_str = time.ToString("yyyy-MM-dd HH:mm:ss");
            //time_str = time.Minute + ":" + time.Second + ":" + time.Millisecond;
            time_str = time.ToString("yyyy-MM-dd HH:mm:ss:fff");
            length = rawPacket.Data.Length.ToString();

            var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

            // add to the list


            var ethernetPacket = (EthernetPacket)packet;

            //var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
            var ipPacket = packet.Extract<PacketDotNet.IPPacket>();

            var arpPacket = packet.Extract<PacketDotNet.ArpPacket>();

            if (arpPacket != null)
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
    }
}
