using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Numerics;

namespace SwiftRatServer
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            console.ReadOnly = true;
            // start the server
            int port = 3000;
            UdpClient receiver = new UdpClient(port, AddressFamily.InterNetwork);
            string address = GetLocalIPAddress();
            receiver.BeginReceive(DataReceived, receiver);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Log("Server started on address: " + address + " port: " + port);
        }

        private string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }

        public void Log(string msg)
        {
            console.Text += "[+] " + msg + Environment.NewLine;
        }

        public async void DataReceived(IAsyncResult ar)
        {
            await Task.Run(() =>
            {
                UdpClient c = (UdpClient)ar.AsyncState;
                IPEndPoint client = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receivedBytes = c.EndReceive(ar, ref client);
                string data = ASCIIEncoding.ASCII.GetString(receivedBytes);
                HandleData(data, c, client);

                c.BeginReceive(DataReceived, ar.AsyncState);
            });
        }


        public async Task HandleData(string data, UdpClient c, IPEndPoint endpoint)
        {
            try
            {
                await Task.Run(async () =>
                {
                    var parse = data.Trim();
                    if (parse.Contains("Client:Connected"))
                    {
                        List<Object> info = new List<Object>();
                        info.Add(endpoint.Address.ToString()); // 0 = IP
                        info.Add(endpoint.Port); // 1 = Port
                    }

                });
            }
            catch (Exception ex) { Log(ex.Message); }

        }


        private void console_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
