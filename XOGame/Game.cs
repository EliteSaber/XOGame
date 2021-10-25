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
        public static void Start()
        {
            Symbols symbol = ChooseSymbol();
            Player player1 = new Player("Player 1", symbol);
            symbol = symbol == Symbols.X ? Symbols.O : Symbols.X;
            Player player2 = new Player("Player 2", symbol);
            Console.WriteLine($"{player1.Name} - {player1.Symbol}");
            Console.WriteLine($"{player2.Name} - {player2.Symbol}");
            bool gameContinue = true;
            do
            {
                gameContinue = !Result(player1);
                if (gameContinue)
                    gameContinue = !Result(player2);
            } while (gameContinue); // победа или ничья - выход
            GameField.ClearField();
        }
        private static bool Result(Player player)
        {
            Console.Clear();
            GameField.GetField();
            Step(player);
            bool isVictory = GameField.IsVictory(player.Symbol);
            if (isVictory)
            {
                Console.Clear();
                GameField.GetField();
                Console.WriteLine($"{player.Name} победил!");
            }
            else
            {
                if(GameField.IsDraw())
                {
                    Console.Clear();
                    GameField.GetField();
                    Console.WriteLine("Ничья!");
                    return true;
                }
            }    
            return isVictory;
        }
        private static void Step(Player player)
        {
            bool success;
            do
            {
                Console.WriteLine($"Ходит {player.Name}");
                Console.Write("Строка: ");
                int line = int.Parse(Console.ReadLine());
                Console.Write("Столбец: ");
                int col = int.Parse(Console.ReadLine());
                success = GameField.SetSymbol(line, col, player.Symbol);
            } while (!success);
        }
        private static Symbols ChooseSymbol()
        {
            Console.WriteLine("Выберите символ");
            Console.WriteLine($"{(int)Symbols.X} - X");
            Console.WriteLine($"{(int)Symbols.O} - O");
            int symbol = ReadLine();
            return (Symbols)symbol;
        }
        private static int ReadLine()
        {
            char symbol;
            bool CorrectSymbol;
            do
            {
                Console.Write("Введите цифру: ");
                symbol = Console.ReadLine().ToString().FirstOrDefault();
                CorrectSymbol = char.IsDigit(symbol);
                if (CorrectSymbol)
                    CorrectSymbol = int.Parse(symbol.ToString()) == (int)Symbols.X || int.Parse(symbol.ToString()) == (int)Symbols.O;
            } while (!CorrectSymbol);
            return int.Parse(symbol.ToString());
        }
    }
}
