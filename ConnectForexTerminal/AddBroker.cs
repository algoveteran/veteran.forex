using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class AddBroker : Form
    {
        public ForexBroker broker;
        private List<BrokerConfig> config;

        private string name;
        private string host;
        private string symbol;
        
        public AddBroker(BrokerControl brokerControl, List<BrokerConfig> config)
        {
            InitializeComponent();
            this.config = config;
        }

        private void OnAddBtn_Click(object sender, EventArgs e)
        {
            broker.Subscribe(symbol);
            this.DialogResult = DialogResult.OK;
        }

        private void Guna2CBServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selIdx = ((ComboBox)sender).SelectedIndex;
            name = config[selIdx].server_name;
            guna2TBAccount.Text = config[selIdx].account.ToString();
            guna2TBPassword.Text = config[selIdx].password;
            guna2CBIP.DataSource = config[selIdx].server_ips;
            guna2CBIP.Refresh();
        }

        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            broker?.Disconnect();
            broker = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            UInt64 account = Convert.ToUInt64(guna2TBAccount.Text);
            string password = guna2TBPassword.Text;
            broker = new MT5Broker(name, host, account, password);
            broker.OnConnected += (b) =>
            {
                Invoke((Action)(() =>
                {
                    if (b)
                    {
                        guna2CBCurrency.DataSource = (broker as MT5Broker).GetSymbols().Where(s => (s.Contains("EURUSD") || s.Contains("EUR/USD"))).ToList();
                        guna2CBCurrency.Refresh();
                    }
                    connect.Enabled = true;
                }));
            };
            connect.Enabled = false;
            broker.Connect();
        }

        private void AddBroker_Load(object sender, EventArgs e)
        {
            guna2CBServer.DataSource = config.Select(s => s.server_name).ToList();
            guna2CBServer.Refresh();
        }

        private void Guna2CBIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            host = ((ComboBox)sender).SelectedItem.ToString();
        }

        private void Guna2CBCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            symbol = ((ComboBox)sender).SelectedItem.ToString();
        }
    }
}
