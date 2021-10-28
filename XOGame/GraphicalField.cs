using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class GraphicalField
    {
        private string[,] Field;
        private readonly int Size;
        public GraphicalField(Symbols[,] field, int size)
        {
            Size = size;
            SymbolsToString(field);
        }
        private void SymbolsToString(Symbols[,] field)
        {
            Field = new string[Size, Size];
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    switch(field[i,j])
                    {
                        case Symbols.e:
                            Field[i, j] = "*";
                            break;
                        case Symbols.X:
                            Field[i, j] = "X";
                            break;
                        case Symbols.O:
                            Field[i, j] = "O";
                            break;
                    }
                }
            }
        }
       public void PrintField(int choosenLine, int choosenColumn)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == choosenLine && j == choosenColumn)
                        Console.Write(" > " + Field[i, j]);
                    else
                        Console.Write("   " + Field[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
