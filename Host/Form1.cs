using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Airport_WCF_Service;

namespace Host
{
    public partial class Form1 : Form
    {
        ServiceHost host;

        public Form1()
        {
            InitializeComponent();



             HostInitialization();
        }

        private void HostInitialization()
        {
            host = new ServiceHost(typeof(Service1));

            host.Closed += new EventHandler(HostState);
            host.Closing += new EventHandler(HostState);
            host.Opened += new EventHandler(HostState);
            host.Opening += new EventHandler(HostState);
            host.Faulted += new EventHandler(HostState);
        }

        private void HostState(object sender, EventArgs e)
        {
            label.Text = "SERVER STATUS : " + host.State.ToString();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (host.State == CommunicationState.Opened)
            {
                host.Close();
                button.Text = "OPEN";
            }
            else if (host.State == CommunicationState.Closed)
            {
                HostInitialization();
                host.Open();
                button.Text = "CLOSE";
            }
            else if (host.State == CommunicationState.Created)
            {
                host.Open();
                button.Text = "CLOSE";
            }
        }
    }
}
