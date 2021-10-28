using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class GraphicalMenu
    {
        private const ConsoleKey DownKey = ConsoleKey.DownArrow;
        private const ConsoleKey UpKey = ConsoleKey.UpArrow;
        private const ConsoleKey EnterKey = ConsoleKey.Enter;
        private const ConsoleKey EscKey = ConsoleKey.Escape;
        private const ConsoleColor DefaultBgColor = ConsoleColor.Black;
        private const ConsoleColor DefaultFontColor = ConsoleColor.White;
        private const ConsoleColor ChoosenBgColor = ConsoleColor.White;
        private const ConsoleColor ChoosenFontColor = ConsoleColor.Black;
        private string[] Names;
        public GraphicalMenu(string[] names)
        {
            Names = names;
        }
        public void PrintMenu(int choosenName)
        {
            for(int i = 0; i < Names.Length; i++)
            {
                if (i == choosenName)
                {
                    Console.BackgroundColor = ChoosenBgColor;
                    Console.ForegroundColor = ChoosenFontColor;
                    Console.WriteLine(" > " + Names[i]);
                    Console.BackgroundColor = DefaultBgColor;
                    Console.ForegroundColor = DefaultFontColor;
                }
                else
                {
                    Console.WriteLine("   " + Names[i]);
                }
            }
        }
    }
}
