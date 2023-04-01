using PacketDotNet;
using PacketDotNet.Ieee80211;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MonitoringPacket
{
    public partial class Form1 : Form
    {
        List<LibPcapLiveDevice> interfaceList = new List<LibPcapLiveDevice>();
        string gwipAddress { get; set; }
        string gwMac { get; set; }
        List<IPandHostMap> listHostIPMap = new List<IPandHostMap>();

        int selectedIntIndex;
        LibPcapLiveDevice wifi_device;
        CaptureFileWriterDevice captureFileWriter;
        Dictionary<int, Packet> capturedPackets_list = new Dictionary<int, Packet>();
        bool isAttacking = false;

        SpoofARP ArpSpoofer { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            progressBar1.Maximum = 254;
            progressBar1.Value = 1;

            LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;

            btnStop.Enabled = false;
            btnAttack.Enabled = true;

            foreach (LibPcapLiveDevice device in devices)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var name = devInterface.Name;
                var description = devInterface.Description;

                interfaceList.Add(device);
                dropdownNIC.Items.Add(description);
            }
        }

        private async void btnStart_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 1;
            dataGridView1.Rows.Clear();
            this.Cursor = Cursors.WaitCursor; btnScan.Enabled = false;
            dataGridView1.Enabled = false;

            string currentIP = "";
            var selectedIntIndex = dropdownNIC.SelectedItem.ToString();

            
            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.Description == selectedIntIndex)
                {
                    IPInterfaceProperties ipProps = netInterface.GetIPProperties();

                    foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            currentIP = addr.Address.ToString();
                        }
                    }
                }
            }

            var lastDot = currentIP.LastIndexOf('.');
            string subnet = currentIP.Substring(0, lastDot);

            

            List<Task> tasks = new List<Task>();
            for (int i = 2; i < 255; i++)
            {
                string ip = $"{subnet}.{i}";
                tasks.Add(PingAddress(ip));
            }
            await Task.WhenAll(tasks);

            var listIPandMacPair = GetAllMacAddressesAndIppairs();
            foreach(var item in listIPandMacPair)
            {
                var index = dataGridView1.Rows.Add();
                var tempIP = item.IpAddress;
                var tempMac = item.MacAddress;
                string hostname = "";
                var temphostname = listHostIPMap.Where(m => m.IPAddress == tempIP).FirstOrDefault();
                if(temphostname != null) { hostname = temphostname.Hostname; }

                //var mac = getMacByIp(ip);
                dataGridView1.Rows[index].Cells["GridIPAddress"].Value = tempIP;
                dataGridView1.Rows[index].Cells["GridMacAddress"].Value = tempMac;
                dataGridView1.Rows[index].Cells["GridHostname"].Value = hostname;
            }

            string gwIP = subnet + ".1";
            gwipAddress = gwIP;
            gwMac = getMacByIp(gwIP);

            btnScan.Enabled = true;
            this.Cursor = Cursors.Default;
            dataGridView1.Enabled = true;
        }

        private Task PingAddress(string ip)
        {
            return Task.Run(() =>
            {
                LocalPing(ip);
            });
            
        }

        private void LocalPing(string ip)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(ip, 1000);
            if (reply.Status == IPStatus.Success)
            {
                progressBar1.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        var host = GetHostName(ip);
                        listHostIPMap.Add(new IPandHostMap { Hostname = host, IPAddress = ip });
                    }
                    catch
                    {

                    }
                }));
            }
            progressBar1.BeginInvoke(new Action(() =>
            {
                progressBar1.Value += 1;
            }));
        }

        

        private void dropdownNIC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selectedNIC = dropdownNIC.SelectedItem.ToString();
            //var devInterface = interfaceList.FirstOrDefault(m => m.Description == dropdownNIC.SelectedItem.ToString());
            //txtIP.Text = devInterface.Addresses[0].Addr.ipAddress.ToString();
            //txtGateway.Text = devInterface.Interface.GatewayAddresses[1].AddressFamily.ToString();
        }

        //private void AddLog(string log, DateTime dateLog)
        //{
        //    txtLog.Invoke(new Action(() =>
        //    {
        //        txtLog.Text += Environment.NewLine + log;
        //    }));
        //    listLog.Add(new Log { dateLog = dateLog, log = log });
        //}

        public string getMacByIp(string ip)
        {
            var macIpPairs = GetAllMacAddressesAndIppairs();
            int index = macIpPairs.FindIndex(x => x.IpAddress == ip);
            if (index >= 0)
            {
                return macIpPairs[index].MacAddress.ToUpper();
            }
            else
            {
                return null;
            }
        }

        public List<MacIpPair> GetAllMacAddressesAndIppairs()
        {
            List<MacIpPair> mip = new List<MacIpPair>();
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a ";
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string cmdOutput = pProcess.StandardOutput.ReadToEnd();
            string pattern = @"(?<ip>([0-9]{1,3}\.?){4})\s*(?<mac>([a-f0-9]{2}-?){6})";

            foreach (Match m in Regex.Matches(cmdOutput, pattern, RegexOptions.IgnoreCase))
            {
                mip.Add(new MacIpPair()
                {
                    MacAddress = m.Groups["mac"].Value,
                    IpAddress = m.Groups["ip"].Value
                });
            }

            return mip;
        }
        public struct MacIpPair
        {
            public string MacAddress;
            public string IpAddress;
        }

        public string GetHostName(string ipAddress)
        {
            try
            {
                IPHostEntry entry = Dns.GetHostEntry(ipAddress);
                if (entry != null)
                {
                    return entry.HostName;
                }
            }
            catch (SocketException ex)
            {
                return "Unknown";
            }

            return "Unknown";
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ip = dataGridView1.Rows[e.RowIndex].Cells["GridIPAddress"].Value.ToString().ToLower();
            string mac = dataGridView1.Rows[e.RowIndex].Cells["GridMacAddress"].Value.ToString().ToLower();
            //Default def = new Default(ip, mac.ToUpper(), gwipAddress, gwMac);
            //def.Show();
            //string ip = dataGridView1.Rows[e.RowIndex].Cells["IPAddress"].Value.ToString().ToLower();
            //string ip = dataGridView1.Rows[e.RowIndex].Cells["IPAddress"].Value.ToString().ToLower();
            txtTargetIP.Text = ip;
            txtTargetMac.Text = mac.ToUpper();

            txtSourceIP.Text = gwipAddress;
            txtSourceMac.Text = gwMac;
        }

        private void btnAttack_Click(object sender, EventArgs e)
        {
            var targetIP = txtTargetIP.Text;
            var targetMacAddr = txtTargetMac.Text;

            var sourceIP = txtSourceIP.Text;
            var sourceMac = txtSourceMac.Text;
            if (String.IsNullOrEmpty(targetIP) || String.IsNullOrEmpty(targetMacAddr) || String.IsNullOrEmpty(sourceIP) || String.IsNullOrEmpty(sourceMac))
            {
                MessageBox.Show("Target IP&Mac, source IP&Mac cannot be empty!", "Error");
            }
            else
            {
                btnAttack.Enabled = false;
                btnStop.Enabled = true;
                btnAttack.Text = "Attacking...";

                txtTargetIP.Enabled = false;
                txtTargetMac.Enabled = false;
                txtSourceIP.Enabled = false; txtSourceMac.Enabled = false;
                selectedIntIndex = dropdownNIC.SelectedIndex;

                wifi_device = interfaceList[selectedIntIndex];


                IPAddress target = IPAddress.Parse(txtTargetIP.Text);

                PhysicalAddress targetMac = PhysicalAddress.Parse(txtTargetMac.Text.ToUpper());

                IPAddress gatway = IPAddress.Parse(sourceIP);

                PhysicalAddress gatwayMac = PhysicalAddress.Parse(sourceMac.ToUpper());


                if (target == null || gatway == null || targetMac == null || gatwayMac == null)
                    throw new Exception("target device or gatway must be not null");

                ArpSpoofer = new SpoofARP(wifi_device, target, targetMac, gatway, gatwayMac);
                if (ArpSpoofer != null)
                {
                    //wifi_device.Open();
                    wifi_device.Open();
                    try
                    {
                        ArpSpoofer.SendArpResponsesAsync();
                        if (ArpSpoofer.Error)
                            throw new Exception("error while running the Arp Spoofing Thread");
                    }
                    catch (Exception ex)
                    {
                        //wifi_device.Close();
                        throw new Exception(ex.Message);

                    }
                }
            }
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            wifi_device.Close();
            //captureFileWriter.Close();
            ArpSpoofer.StopAsync();
            btnAttack.Enabled = true;
            //txtFilter.Enabled = true;
            btnStop.Enabled = false;
            btnAttack.Text = "Attack";
            txtTargetIP.Enabled = true;
            txtTargetMac.Enabled = true;
            txtSourceIP.Enabled = true; txtSourceMac.Enabled = true;
        }

        private void btnGetPCAP_Click(object sender, EventArgs e)
        {
            var passValue = String.IsNullOrEmpty(txtTargetIP.Text) == true ? "" : txtTargetIP.Text;
            Default def = new Default(passValue);
            def.Show();
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you really want to exit app?", "Confirmation", MessageBoxButtons.OKCancel);
            if (dialogResult == DialogResult.OK)
            {
                //do something
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }

        
    }
}
