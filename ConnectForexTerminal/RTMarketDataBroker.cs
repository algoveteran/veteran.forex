using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Websocket.Client;

namespace Dashboard
{
    public class RTMarketDataBroker : ForexBroker
    {
        private BrokerControl control;

        private WebsocketClient client;

        public string id;

        public RTMarketDataBroker()
        {
            id = String.Format("{0}-{1}", "marketdata.tradermade.com", "18.132.128.118");

            Uri url = new Uri("wss://marketdata.tradermade.com/feedadv");
            client = new WebsocketClient(url);
            client.ReconnectTimeout = TimeSpan.FromSeconds(10);

            client.ReconnectionHappened.Subscribe(info =>
            {
                // Console.WriteLine("Reconnection happened, type: " + info.Type);
                OnConnected(true);
            });
        }

        public override void Connect()
        {
            client.Start();
        }

        public override void Disconnect()
        {
            client.StopOrFail(WebSocketCloseStatus.Empty, "Close Socket");
        }

        public override void SetControl(BrokerControl control)
        {
            this.control = control;
            control.OnClose += () =>
            {
                Manager.GetInstance().RemoveSymbol(id);
                Disconnect();
            };
        }

        public override void Subscribe(string symboll)
        {
            Symbol store = Manager.GetInstance().GetSymbol(id);
            client.MessageReceived.Subscribe(msg =>
            {
                try
                {
                    Symbol symbol = JsonConvert.DeserializeObject<Symbol>(msg.Text);
                    store.bid = symbol.bid;
                    store.ask = symbol.ask;
                    store.time = (ulong)DateTime.Now.Ticks;
                    control.UpdateRate(symbol.bid, symbol.ask, DateTime.Now);
                } catch {}

                if (msg.ToString().ToLower() == "connected")
                {
                    string apiKey = "ws65-9T1z2umDi2CrlUw";
                    string data = "{\"userKey\":\"" + apiKey + "\", \"symbol\":\"EURUSD\"}";
                    client.Send(data);
                }
            });
        }
    }
}
