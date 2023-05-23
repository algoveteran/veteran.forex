using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Dashboard
{
    public partial class Dashboard : Form
    {
        private Config config;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Guna2GradientButton2_Click(object sender, EventArgs e)
        {
            int count = brokerContainer.Controls.Count;
            int capacity = brokerContainer.ColumnCount * brokerContainer.RowCount;
            if (count >= capacity)
            {
                return;
            }

            BrokerControl brokerControl = new BrokerControl();
            AddBroker dialog = new AddBroker(brokerControl, config.server);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MT5Broker broker = dialog.broker as MT5Broker;
                brokerControl.UpdateBrokerName(broker?.name, broker?.host, broker.account, broker?.symbol);
                broker.SetControl(brokerControl);
                brokerContainer.Controls.Add(brokerControl);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            string configT = File.ReadAllText("config.json");
            config = JsonConvert.DeserializeObject<Config>(configT);
        }

        // Show Console Window.
        private void Guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Chart chart = new Chart();
            chart.Show();
        }

        // Show chart panel.
        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ForexBroker broker = new RTMarketDataBroker();
            broker.Subscribe("EUR/USD");
            BrokerControl brokerControl = new BrokerControl();
            brokerControl.UpdateBrokerName("marketdata.tradermade.com", "18.132.128.118", 777, "EUR/USD");
            broker.SetControl(brokerControl);
            brokerContainer.Controls.Add(brokerControl);
            broker.OnConnected += (b) =>
            {
            };
            broker.Connect();
        }
    }
}
