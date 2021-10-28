using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGame
{
    class Game
    {
        private static readonly Field GameField = new Field();
        private const ConsoleKey DownKey = ConsoleKey.DownArrow;
        private const ConsoleKey UpKey = ConsoleKey.UpArrow;
        private const ConsoleKey LeftKey = ConsoleKey.LeftArrow;
        private const ConsoleKey RightKey = ConsoleKey.RightArrow;
        private const ConsoleKey EnterKey = ConsoleKey.Enter;
        private const ConsoleKey EscKey = ConsoleKey.Escape;
        public static void Start()
        {
            Symbols symbol = ChooseSymbol();
            Player player1 = new Player("Player 1", symbol);
            if(symbol == Symbols.e)
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
            GameField.ClearField();
        }
        public static void GetField()
        {
            const int Size = Field.Size;
            GraphicalField graphicalField = new GraphicalField(GameField.GameField, Size);
            graphicalField.PrintField(-1, -1);
        }
        private static bool Result(Player player)
        {
            Step(player);
            bool isVictory = GameField.IsVictory(player.Symbol);
            if (isVictory)
            {
                Console.Clear();
                GetField();
                Console.WriteLine($"{player.Name} победил!");
            }
            else
            {
                if(GameField.IsDraw())
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
            GraphicalField graphicalField = new GraphicalField(GameField.GameField, Size);
            int choosenLine = 0,
                choosenColumn = 0;
            bool isEndOfTurn = false;
            while (!isEndOfTurn)
            {
                Console.Clear();
                Console.WriteLine($"Ходит {player.Name}");
                Console.WriteLine("(Enter - принять, Esc - заново)");
                graphicalField.PrintField(choosenLine, choosenColumn);
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case DownKey:
                        choosenLine = CheckOutOfRange(Size, ++choosenLine);
                        break;
                    case UpKey:
                        choosenLine = CheckOutOfRange(Size, --choosenLine);
                        break;
                    case LeftKey:
                        choosenColumn = CheckOutOfRange(Size, --choosenColumn);
                        break;
                    case RightKey:
                        choosenColumn = CheckOutOfRange(Size, ++choosenColumn);
                        break;
                    case EnterKey:
                        isEndOfTurn = GameField.SetSymbol(choosenLine, choosenColumn, player.Symbol);
                        break;
                    case EscKey:
                        GameField.ClearField();
                        isEndOfTurn = true;
                        break;
                }
            }
        }
        private static Symbols ChooseSymbol()
        {
            string[] arraySymbols = new string[] { "X", "O" };
            GraphicalMenu menu = new GraphicalMenu(arraySymbols);
            int choosenName = 0;
            bool IsContinue = true;
            while (IsContinue)
            {
                Console.Clear();
                Console.WriteLine("Выберите символ:");
                Console.WriteLine("(Enter - принять, Esc - выйти)");
                menu.PrintMenu(choosenName);
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case DownKey:
                        choosenName = CheckOutOfRange(arraySymbols.Length, ++choosenName);
                        break;
                    case UpKey:
                        choosenName = CheckOutOfRange(arraySymbols.Length, --choosenName);
                        break;
                    case EnterKey:
                        choosenName++;
                        IsContinue = false;
                        break;
                    case EscKey:
                        choosenName = 0;
                        IsContinue = false;
                        break;
                }
            }
            return (Symbols)choosenName;
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
