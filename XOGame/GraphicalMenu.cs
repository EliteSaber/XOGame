using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class GraphicalMenu
    {
        private const ConsoleColor _defaultBgColor = ConsoleColor.Black;
        private const ConsoleColor _defaultFontColor = ConsoleColor.White;
        private const ConsoleColor _chosenBgColor = ConsoleColor.White;
        private const ConsoleColor _chosenFontColor = ConsoleColor.Black;
        private readonly string[] _names;
        public GraphicalMenu(string[] names)
        {
            _names = names;
        }
        public void PrintMenu(int chosenName)
        {
            for(int i = 0; i < _names.Length; i++)
            {
                if (i == chosenName)
                {
                    Console.BackgroundColor = _chosenBgColor;
                    Console.ForegroundColor = _chosenFontColor;
                    Console.WriteLine(" > " + _names[i]);
                    Console.BackgroundColor = _defaultBgColor;
                    Console.ForegroundColor = _defaultFontColor;
                }
                else
                {
                    Console.WriteLine("   " + _names[i]);
                }
            }
        }
    }
}
