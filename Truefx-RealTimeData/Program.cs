using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using H.Socket.IO;
using H.WebSockets;
using Newtonsoft.Json.Linq;
using Websocket.Client;

namespace Truefx_RealTimeData
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static HttpResponseMessage CreateRestClient(Uri requestUri, HttpMethod method, HttpContent content = null)
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = requestUri,
                Headers =
                {
                    { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/113.0.0.0 Safari/537.36" },
                    { "Sec-Ch-Ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not - A.Brand\";v=\"24\"" },
                    { "Sec-Ch-Ua", "\"Google Chrome\";v=\"113\", \"Chromium\";v=\"113\", \"Not - A.Brand\";v=\"24\"" },
                    { "Sec-Ch-Ua-Mobile", "?0" },
                    { "Sec-Ch-Ua-Platform", "Windows" },
                    { "Sec-Fetch-Dest", "empty" },
                    { "Sec-Fetch-Mode", "cors" },
                    { "Sec-Fetch-Site", "cross-site" },
                    { "Origin", "https://www.truefx.com" },
                },
                Content = content
            };
            return client.SendAsync(request).Result;
        }

        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            var exitEvent = new ManualResetEvent(false);

            HttpResponseMessage response = CreateRestClient(new Uri("https://www99.integral.com/socket.io/?EIO=3&transport=polling&t=OWgMWn0"), HttpMethod.Get);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                log.Error("Error is occurred.");
                return;
            }

            string res = response.Content.ReadAsStringAsync().Result.Replace("97:0", "").Replace("2:40", "");
            JObject @object = JObject.Parse(res);

            if (!@object.ContainsKey("sid"))
            {
                log.Error("Not found sid.");
                return;
            }

            string sid = @object.GetValue("sid").ToString();
            log.Info(String.Format("Get sid successfully. sid={0}", sid));

            response = CreateRestClient(new Uri("https://www99.integral.com/socket.io/?EIO=3&transport=polling&t=OWg9nTSs&sid=" + sid), HttpMethod.Post, new StringContent("8:40/rate,"));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                log.Error("Error is occurred.");
                return;
            }

            res = response.Content.ReadAsStringAsync().Result;

            if (!res.ToLower().Equals("ok"))
            {
                log.Error("Error is occurred.");
                return;
            }

            Uri uri = new UriBuilder("wss://www99.integral.com/socket.io/?EIO=3&transport=websocket&sid=" + sid).Uri;
            long count = 0;
            using (var wsClient = new WebsocketClient(uri))
            {
                wsClient.ReconnectTimeout = TimeSpan.FromSeconds(10);

                wsClient.ReconnectionHappened.Subscribe(info =>
                {
                    wsClient.Send("2probe");
                    count = 0;
                });


                wsClient.MessageReceived.Subscribe(msg =>
                {
                    log.Info(msg);

                    if (count > 1000)
                    {
                        wsClient.Send("2probe");
                        count = 0;
                    }

                    if (msg.ToString().ToLower() == "3probe")
                    {
                        wsClient.Send("5");
                    }

                    count++;
                });

                wsClient.DisconnectionHappened.Subscribe(info =>
                {
                    Console.WriteLine(info.Exception.Message);
                });

                wsClient.Start();

                exitEvent.WaitOne();
            }
                /*WebSocketClient webSocket = new WebSocketClient();
                webSocket.Connected += (s, e) =>
                {
                    ((WebSocketClient)s).SendTextAsync("2probe");
                    Console.WriteLine("Connected.");
                };
                webSocket.Disconnected += (s, e) =>
                {
                    Console.WriteLine(e.Reason);
                };

                webSocket.ExceptionOccurred += (s, e) =>
                {
                    Console.WriteLine(e.Exception.Message);
                };

                webSocket.TextReceived += (s, e) =>
                {
                    //Console.WriteLine(e.Text);
                    log.Info(e.Text);
                    if (e.Text.ToLower().Equals("3probe")) webSocket.SendTextAsync("5");
                };
                webSocket.ConnectAsync(new UriBuilder("wss://www99.integral.com/socket.io/?EIO=3&transport=websocket&sid=" + sid).Uri).Wait();*/



        Console.ReadKey();

        }
    }
}
