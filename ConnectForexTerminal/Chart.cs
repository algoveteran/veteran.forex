using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;

namespace Dashboard
{
    public partial class Chart : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private bool stop = false;

        public Chart()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {

        }

        public void DrawChart()
        {
        }

        private void GunaChart1_Load(object sender, EventArgs e)
        {
            GunaChart chart = sender as GunaChart;
            chart.YAxes.Ticks.BeginAtZero = false;
            foreach(KeyValuePair<string, Symbol> symbol in Manager.GetInstance().GetSymbols())
            {
                GunaLineDataset dataset = new GunaLineDataset();
                dataset.Label = symbol.Key;
                dataset.BorderWidth = 0;
                dataset.PointBorderWidth = 0;
                chart.Datasets.Add(dataset);
            }
        }

        private void UpdateRealtimeData()
        {
            stop = false;
            btn_start.Enabled = false;
            btn_stop.Enabled = true;
            btn_clear.Enabled = false;
            Task.Factory.StartNew(() =>
            {
                while (!stop)
                {

                    Invoke((Action)(() =>
                    {
                        int i = 0;
                        foreach (KeyValuePair<string, Symbol> symbol in Manager.GetInstance().GetSymbols())
                        {
                            GunaLineDataset dataset = gunaChart1.Datasets[i] as GunaLineDataset;
                            //dataset?.DataPoints.Add(new LPoint("", (symbol.Value.ask + symbol.Value.bid) / 2.0));
                            dataset?.DataPoints.Add(new LPoint("", symbol.Value.ask));
                            i++;
                            //log.InfoFormat("{0}", (symbol.Value.ask + symbol.Value.bid) / 2.0);
                        }
                        gunaChart1.Refresh();
                    }));
                    Thread.Sleep(200);
                }
            });
            /*Task.Run(() =>
            {

            });*/
        }

        private void Btn_start_Click(object sender, EventArgs e)
        {
            UpdateRealtimeData();
        }

        private void Btn_stop_Click(object sender, EventArgs e)
        {
            stop = true;
            btn_start.Enabled = true;
            btn_stop.Enabled = false;
            btn_clear.Enabled = true;
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            foreach (GunaLineDataset dataset in gunaChart1.Datasets)
            {
                dataset.DataPoints.Clear();
            }
            gunaChart1.Refresh();
        }
    }
}
