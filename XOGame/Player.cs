using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class Player
    {
        public string Name { get; private set; }
        public Symbols Symbol { get; private set; }
        public Player(string name, Symbols symbol)
        {
            Name = name;
            Symbol = symbol;
        }
    }
}
