using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public abstract class ForexBroker : IForexBroker
    {
        public Action<bool> OnConnected;

        public abstract void Connect();

        public abstract void Disconnect();

        public abstract void SetControl(BrokerControl control);

        public abstract void Subscribe(string symboll);
    }
}
