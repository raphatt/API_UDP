using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace API_UDP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            API APIData = new API();
            UdpClient udpClient = new UdpClient(5606);
            while (true)
            {
                IPEndPoint RemoteIPEndpoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] receiveBytes = udpClient.Receive(ref RemoteIPEndpoint);
                Stream stream = new MemoryStream(receiveBytes);
                BinaryReader binaryReader = new BinaryReader(stream);
                APIData.LerDados(stream, binaryReader);
                label2.Text = APIData.sSpeed.ToString("00");
                label3.Text = APIData.sRpm.ToString();
                label5.Text = APIData.sMarcha.ToString();
                Application.DoEvents();
            }
        }
    }
}
