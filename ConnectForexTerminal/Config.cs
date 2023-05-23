using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class BrokerConfig
    {
        public string server_name;
        public List<string> server_ips;
        public ulong account;
        public string password;
    }

    public class Config
    {
        public List<BrokerConfig> server;
    }
}
