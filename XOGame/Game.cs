using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class Game
    {
        private static readonly Field s_gameField = new Field();
        private const ConsoleKey _downKey = ConsoleKey.DownArrow;
        private const ConsoleKey _upKey = ConsoleKey.UpArrow;
        private const ConsoleKey _leftKey = ConsoleKey.LeftArrow;
        private const ConsoleKey _rightKey = ConsoleKey.RightArrow;
        private const ConsoleKey _enterKey = ConsoleKey.Enter;
        private const ConsoleKey _escKey = ConsoleKey.Escape;
        public static void Start()
        {
            Symbols symbol = ChooseSymbol();
            Player player1 = new Player("Player 1", symbol);
            if(symbol == Symbols.Empty)
            {
                Console.WriteLine("Выход");
                return;
            }
            symbol = symbol == Symbols.X ? Symbols.O : Symbols.X;
            Player player2 = new Player("Player 2", symbol);
            bool gameContinue = true;
            while (gameContinue)
            {
                gameContinue = !Result(player1);
                if (gameContinue)
                    gameContinue = !Result(player2);
            }
            s_gameField.ClearField();
        }
        public static void GetField()
        {
            const int Size = Field.Size;
            GraphicalField graphicalField = new GraphicalField(s_gameField.GameField, Size);
            graphicalField.PrintField(-1, -1);
        }
        private static bool Result(Player player)
        {
            Step(player);
            bool isVictory = s_gameField.IsVictory(player.Symbol);
            if (isVictory)
            {
                Console.Clear();
                GetField();
                Console.WriteLine($"{player.Name} победил!");
            }
            else
            {
                if(s_gameField.IsDraw())
                {
                    Console.Clear();
                    GetField();
                    Console.WriteLine("Ничья!");
                    return true;
                }
            }    
            return isVictory;
        }
        private static void Step(Player player)
        {
            const int Size = Field.Size;
            GraphicalField graphicalField = new GraphicalField(s_gameField.GameField, Size);
            int chosenLine = 0,
                chosenColumn = 0;
            bool isEndOfTurn = false;
            while (!isEndOfTurn)
            {
                Console.Clear();
                Console.WriteLine($"Ходит {player.Name}");
                Console.WriteLine("(Enter - принять, Esc - заново)");
                graphicalField.PrintField(chosenLine, chosenColumn);
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case _downKey:
                        chosenLine = CheckOutOfRange(Size, ++chosenLine);
                        break;
                    case _upKey:
                        chosenLine = CheckOutOfRange(Size, --chosenLine);
                        break;
                    case _leftKey:
                        chosenColumn = CheckOutOfRange(Size, --chosenColumn);
                        break;
                    case _rightKey:
                        chosenColumn = CheckOutOfRange(Size, ++chosenColumn);
                        break;
                    case _enterKey:
                        isEndOfTurn = s_gameField.SetSymbol(chosenLine, chosenColumn, player.Symbol);
                        break;
                    case _escKey:
                        s_gameField.ClearField();
                        isEndOfTurn = true;
                        break;
                }
            }
        }
        private static Symbols ChooseSymbol()
        {
            string[] arraySymbols = new string[] { "X", "O" };
            GraphicalMenu menu = new GraphicalMenu(arraySymbols);
            int chosenName = 0;
            bool isContinue = true;
            while (isContinue)
            {
                Console.Clear();
                Console.WriteLine("Выберите символ:");
                Console.WriteLine("(Enter - принять, Esc - выйти)");
                menu.PrintMenu(chosenName);
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case _downKey:
                        chosenName = CheckOutOfRange(arraySymbols.Length, ++chosenName);
                        break;
                    case _upKey:
                        chosenName = CheckOutOfRange(arraySymbols.Length, --chosenName);
                        break;
                    case _enterKey:
                        chosenName++;
                        isContinue = false;
                        break;
                    case _escKey:
                        chosenName = 0;
                        isContinue = false;
                        break;
                }
            }
            return (Symbols)chosenName;
        }
        private static int CheckOutOfRange(int length, int index)
        {
            if (index < 0)
                return length - 1;
            if (index >= length)
                return 0;
            return index;
        }
    }
}
