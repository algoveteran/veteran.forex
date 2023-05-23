using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public class Manager : Singleton<Manager>
    {
        ConcurrentDictionary<string, Symbol> symbols = new ConcurrentDictionary<string, Symbol>();

        public ConcurrentDictionary<string, Symbol> GetSymbols()
        {
            return symbols;
        }

        public Symbol GetSymbol(string key)
        {
            Symbol symbol;
            bool res = symbols.TryGetValue(key, out symbol);
            if (!res)
            {
                symbol = new Symbol();
                symbols.TryAdd(key, symbol);
            }
            return symbol;
        }

        public bool RemoveSymbol(string key)
        {
            Symbol symbol;
            return symbols.TryRemove(key, out symbol);
        }
    }
}
