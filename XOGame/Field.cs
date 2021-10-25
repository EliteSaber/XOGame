using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    enum Symbols { e, X, O};
    class Field
    {
        public const int Size = 3;
        private Symbols[,] Matrix = new Symbols[Size, Size];
        public void GetField()
        {
            Console.Write(" | ");
            for (int i = 0; i < Size; i++)
                Console.Write($"{i + 1} ");
            Console.WriteLine();
            Console.WriteLine(new string('-', (Size + 1) * 2));
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"{i + 1}| ");
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"{Matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public bool SetSymbol(int line, int column, Symbols symbol)
        {
            bool IsCorrectCoordinates = IsCorrectCoordinate(line) && IsCorrectCoordinate(column);
            if (IsCorrectCoordinates)
                if (Matrix[line - 1, column - 1] == Symbols.e)
                    Matrix[line - 1, column - 1] = symbol;
                else
                    IsCorrectCoordinates = false;
            return IsCorrectCoordinates;
        }
        private bool IsCorrectCoordinate(int coordinate) => coordinate > 0 && coordinate <= Size;
        public void ClearField()
        {
            Array.Clear(Matrix, 0, Matrix.Length);
        }
        public bool IsDraw()
        {
            foreach(Symbols s in Matrix)
                if (s == Symbols.e)
                    return false;
            return true;
        }
        public bool IsVictory(Symbols symbol)
        {
            //главная диагональ
            if (IsVictoryMainDia(symbol))
                return true;
            //побочная диагональ
            if (IsVictoryCounterDia(symbol))
                return true;
            //строка или столбец
            for(int i = 0; i < Size; i++)
                if (IsVictoryLine(i, symbol) || IsVictoryCol(i, symbol))
                    return true;
            return false;
        }
        private bool IsVictoryLine(int line, Symbols symbol)
        {
            for (int j = 0; j < Size; j++)
                if (Matrix[line, j] != symbol)
                    return false;
            return true;
        }
        private bool IsVictoryCol(int col, Symbols symbol)
        {
            for (int j = 0; j < Size; j++)
                if (Matrix[j, col] != symbol)
                    return false;
            return true;
        }
        private bool IsVictoryMainDia(Symbols symbol)
        {
            for (int i = 0; i < Size; i++)
                if (Matrix[i, i] != symbol)
                    return false;
            return true;
        }
        private bool IsVictoryCounterDia(Symbols symbol)
        {
            for (int i = 0; i < Size; i++)
                if (Matrix[i, Size - 1 - i] != symbol)
                    return false;
            return true;
        }
    }
}
