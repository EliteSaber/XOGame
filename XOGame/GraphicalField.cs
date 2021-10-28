using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class GraphicalField
    {
        private string[,] _field;
        private readonly int _size;
        public GraphicalField(Symbols[,] field, int size)
        {
            _size = size;
            ToString(field);
        }
        public void PrintField(int chosenLine, int chosenColumn)
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (i == chosenLine && j == chosenColumn)
                        Console.Write(" > " + _field[i, j]);
                    else
                        Console.Write("   " + _field[i, j]);
                }
                Console.WriteLine();
            }
        }
        private void ToString(Symbols[,] field)
        {
            _field = new string[_size, _size];
            for(int i = 0; i < _size; i++)
            {
                for(int j = 0; j < _size; j++)
                {
                    switch(field[i,j])
                    {
                        case Symbols.Empty:
                            _field[i, j] = "*";
                            break;
                        case Symbols.X:
                            _field[i, j] = "X";
                            break;
                        case Symbols.O:
                            _field[i, j] = "O";
                            break;
                    }
                }
            }
        }
    }
}
