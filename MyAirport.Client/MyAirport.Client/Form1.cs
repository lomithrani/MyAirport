using MyAirport.Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAirport.Client
{
    public partial class Form1 : Form
    {
        ServiceReference1.Service1Client proxy = null;
        public Form1()
        {
            InitializeComponent();
            this.proxy = new ServiceReference1.Service1Client("EPBasicHttpUserCredential");
            //this.proxy.ClientCredentials.Windows.ClientCredential.Password = "";
            //this.proxy.ClientCredentials.Windows.ClientCredential.UserName = @"cagnetc";
            //this.proxy.ClientCredentials.Windows.ClientCredential.Domain = @"infopb.com";

            proxy.ClientCredentials.UserName.UserName = "CDG1User2";
            proxy.ClientCredentials.UserName.Password = "User2CDG1$";

//            this.proxy = new ServiceReference1.Service1Client("EpBasicHttp");

            var obj = this.proxy.ChannelFactory.Credentials;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
//            MessageBox.Show("UserName:"+Thread.CurrentPrincipal.Identity.Name, "Authentification");
            try
            {
                VolDefinition res = proxy.DetailVol2((int)this.numericUpDown1.Value);
//                proxy.CreateVol(new VolDefinition());
            }
            catch (FaultException<PersoFaultException>val)
            {
                MessageBox.Show(val.Detail.Message);
            }
            catch (FaultException exp)
            {
                this.textBox1.Text = exp.Reason.ToString();
                this.textBox2.Text = exp.Code.Name;
                this.textBox3.Text = exp.Message;
            }
            ServiceReference1.VolDefinition vol = proxy.DetailVol2(Convert.ToInt32(this.numericUpDown1.Value));
            if (vol != null)
            {
                this.textBox1.Text = vol.CIE;
                this.textBox2.Text = vol.Ligne;
                this.textBox3.Text = vol.Date.ToString();
                this.listBox1.Items.Clear();

                if (vol.Banques != null)
                {
                    foreach (var b in vol.Banques)
                    {
                        this.listBox1.Items.Add(b);
                    }
                }
            }
        }

        private void identificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthentificationForm dlg = new AuthentificationForm();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //TransportClientCredentialType = None

                //TransportClientCredentialType = Basic
                proxy.ClientCredentials.UserName.UserName = dlg.Domaine + @"\\" + dlg.UserName;
                proxy.ClientCredentials.UserName.Password = dlg.Password;

                ////TransportClientCredentialType = Windows
                //proxy.ClientCredentials.Windows.ClientCredential.Domain = dlg.Domaine;
                //proxy.ClientCredentials.Windows.ClientCredential.UserName = dlg.UserName;
                //proxy.ClientCredentials.Windows.ClientCredential.Password = dlg.Password;
            }

 
        }
    }
}
