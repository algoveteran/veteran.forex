using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Websocket.Client;

namespace RealTimeMarketData
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prg = new Program();

            prg.Initialize();
        }

        private void Initialize()
        {
            Console.CursorVisible = false;

            try
            {
                var exitEvent = new ManualResetEvent(false);
                var url = new Uri("wss://marketdata.tradermade.com/feedadv");

                using (var client = new WebsocketClient(url))
                {
                    client.ReconnectTimeout = TimeSpan.FromSeconds(10);


                    client.ReconnectionHappened.Subscribe(info =>
                    {
                        Console.WriteLine("Reconnection happened, type: " + info.Type);
                    });


                    client.MessageReceived.Subscribe(msg =>
                    {
                        Console.WriteLine("Message received: " + msg);

                        if (msg.ToString().ToLower() == "connected")
                        {
                            string apiKey = "ws65-9T1z2umDi2CrlUw";
                            string data = "{\"userKey\":\""+ apiKey + "\", \"symbol\":\"EURUSD\"}";
                            client.Send(data);
                        }
                    });

                    client.Start();


                    //Task.Run(() => client.Send("{ message }"));


                    exitEvent.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
