using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;
using System.Net;

namespace WindowsFormsApp
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string Start(string value);

        [OperationContract]
        List<string> GetPoints();

        [OperationContract]
        int GetSize();

        [OperationContract]
        string MoveUP(string value);

        [OperationContract]
        string MoveDOWN(string value);

        [OperationContract]
        string MoveLeft(string value);

        [OperationContract]
        string MoveRight(string value);
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        private IService1 Connect()
        {
            Uri uri = new Uri("http://localhost:50250/Service1.svc");
            EndpointAddress endpointAddress = new EndpointAddress(uri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IService1> channelFactory = new ChannelFactory<IService1>(binding, endpointAddress);
            IService1 service = channelFactory.CreateChannel();
            return service;
        }

        private string GetIp()
        {
            String host = Dns.GetHostName();
            IPAddress ip = Dns.GetHostByName(host).AddressList[0];
            return ip.ToString();
        }

        private void setCoor(string value)
        {
            //string[] result = value.Split(':');
            //label1.Location = new Point(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label1.Text = "Player";
            Connect().Start(GetIp());
            //string[] result = Connect().Start($"{GetIp()}").Split(':');
            //label1.Location = new Point(Convert.ToInt32(result[0]), Convert.ToInt32(result[1]));
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    setCoor(Connect().MoveUP(GetIp()));
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    setCoor(Connect().MoveDOWN(GetIp()));
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    setCoor(Connect().MoveLeft(GetIp()));
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    setCoor(Connect().MoveRight(GetIp()));
        //}

        private void SetPossTank(string value)
        {
            string[] result = value.Split(':');
            //this.Controls.Add(new Label() {
            //    Location = new Point(Convert.ToInt32(result[0]),
            //    Convert.ToInt32(result[1])),
            //    Text = result[2],
            //    Name = result[2],
            //    BackColor = result[2] == GetIp() ? Color.Green : Color.Red
            //});

            this.Controls.Add(new PictureBox()
            {
                Location = new Point(Convert.ToInt32(result[0]), Convert.ToInt32(result[1])),
                Name = result[2],
                Size = new Size(Connect().GetSize(), Connect().GetSize()),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Image.FromFile("tank.png"),
                BackColor = result[2] == GetIp() ? Color.Green : Color.Red
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Controls.Clear();


            foreach (var point in Connect().GetPoints())
            {
                SetPossTank(point);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
            {
                setCoor(Connect().MoveUP(GetIp()));
            }
            else if(e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                setCoor(Connect().MoveDOWN(GetIp()));
            }
            else if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                setCoor(Connect().MoveLeft(GetIp()));
            }
            else if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                setCoor(Connect().MoveRight(GetIp()));
            }
        }
    }
}
