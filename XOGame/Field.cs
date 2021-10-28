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
        public Symbols[,] GameField { get; private set; } = new Symbols[Size, Size];
        public bool SetSymbol(int line, int column, Symbols symbol)
        {
            bool IsCorrectCoordinates = IsCorrectCoordinate(line) && IsCorrectCoordinate(column);
            if (IsCorrectCoordinates)
                if (GameField[line, column] == Symbols.e)
                    GameField[line, column] = symbol;
                else
                    IsCorrectCoordinates = false;
            return IsCorrectCoordinates;
        }
        private bool IsCorrectCoordinate(int coordinate) => coordinate >= 0 && coordinate < Size;
        public void ClearField()
        {
            for(int i = 0; i < Size; i++)
                for(int j = 0; j < Size; j++)
                    GameField[i, j] = Symbols.e;
        }
        public bool IsDraw()
        {
            foreach(Symbols s in GameField)
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
                if (GameField[line, j] != symbol)
                    return false;
            return true;
        }
        private bool IsVictoryCol(int col, Symbols symbol)
        {
            for (int j = 0; j < Size; j++)
                if (GameField[j, col] != symbol)
                    return false;
            return true;
        }
        private bool IsVictoryMainDia(Symbols symbol)
        {
            for (int i = 0; i < Size; i++)
                if (GameField[i, i] != symbol)
                    return false;
            return true;
        }
        private bool IsVictoryCounterDia(Symbols symbol)
        {
            for (int i = 0; i < Size; i++)
                if (GameField[i, Size - 1 - i] != symbol)
                    return false;
            return true;
        }
    }
}
