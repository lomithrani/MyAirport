using System;
using System.ServiceModel;
using System.Windows.Forms;
using MyAirport.Entities;
using MyAirport.Service;

namespace HostMyAirport
{
    public partial class Form1 : Form
    {
        private readonly ServiceHost host;

        public Form1()
        {
            InitializeComponent();
            var type = typeof (AirportService);
            host = new ServiceHost(type);
            label2.Text = host.State.ToString();

            linkLabel1.Text = host.BaseAddresses[0].ToString();
            listBox1.Items.Add(linkLabel1.Text = host.BaseAddresses[0].ToString());
            host.Closed += host_StateChanged;
            host.Closing += host_StateChanged;
            host.Faulted += host_StateChanged;
            host.Opening += host_StateChanged;
            host.Opened += host_StateChanged;
//            host.UnknownMessageReceived += host_UnknownMessageReceived;
        }

        private void host_UnknownMessageReceived(object sender, UnknownMessageReceivedEventArgs e)
        {
            MessageBox.Show("Message non correct");
        }

        private void host_StateChanged(object sender, EventArgs e)
        {
            label2.Text = host.State.ToString();
            listBox1.Items.Add("Changement d'état du host :" +
                               host.State);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            host.Open();

            foreach (var v in host.Description.Endpoints)
            {
                listBox2.Items.Add(v.Name + ":" + v.ListenUri);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
            label5.Text = AirportService.NbInstance.ToString();
        }
    }
}