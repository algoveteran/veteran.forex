using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class BrokerControl : UserControl
    {

        public Action OnClose;
        public BrokerControl()
        {
            InitializeComponent();
        }

        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            OnClose?.Invoke();
        }

        public void WriteLog()
        {

        }

        public void UpdateBrokerName(string brokerName, string host, UInt64 account, string symbol)
        {
            this.lbl_broker.Text = brokerName;
            this.lbl_info.Text = String.Format("{0}, {1}, {2}", host, account, symbol);
        }

        // This method is called by external thread.
        public void UpdateRate(double bid, double ask, DateTime time)
        {
            Invoke((Action)(() => {
                this.lbl_bid_rate.Text = bid.ToString();
                this.lbl_ask_rate.Text = ask.ToString();
                this.lbl_spread.Text = String.Format("{0}", ask - bid);
                this.lbl_time.Text = String.Format("{0:hh-mm-ss}", time);
            }));
        }
    }
}
