using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mtapi.mt5;

namespace Dashboard
{
    public class MT5Broker : ForexBroker
    {
        public MT5API api;

        public string symbol;
        public string name;
        public string host;
        public ulong account;
        public int port;

        private BrokerControl control;

        public MT5Broker(String name, String host, ulong account, String password, int port = 443)
        {
            this.name = name;
            this.host = host;
            this.account = account;
            this.port = port;
            api = new MT5API(account, password, host, port);
            api.OnConnectProgress += (s, e) => {
                if (e.Progress == ConnectProgress.Connected)
                {
                    OnConnected(true);
                }

                if (e.Progress == ConnectProgress.Disconnect)
                {
                    OnConnected(false);
                }
            };
        }

        public override void Connect()
        {
            api.Connect();
        }

        public List<string> GetSymbols()
        {
            return api.Symbols.Infos.Keys.ToList();
        }

        public override void Subscribe(string symbol)
        {
            Symbol store = Manager.GetInstance().GetSymbol(String.Format("{0}-{1}-{2}", name, host, account));
            store.symbol = symbol;
            this.symbol = symbol;
            api.OnQuote += (MT5API s, Quote quote) => {
                store.bid = quote.Bid;
                store.ask = quote.Ask;
                store.time = (ulong)quote.Time.Ticks;
                control?.UpdateRate(quote.Bid, quote.Ask, quote.Time);
            };
            api.Subscribe(symbol);
        }

        public override void Disconnect()
        {
            api.Disconnect();
        }

        public override void SetControl(BrokerControl control)
        {
            this.control = control;
            control.OnClose += () =>
            {
                Manager.GetInstance().RemoveSymbol(String.Format("{0}-{1}-{2}", name, host, account));
                Disconnect();
            };
        }
    }
}
