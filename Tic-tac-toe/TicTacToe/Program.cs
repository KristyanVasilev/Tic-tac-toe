using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Tic-tac-toe is a game for two players who take turns marking the spaces in a three-by-three grid with X or O. The player who succeeds in placing three of their marks in a horizontal, vertical, or diagonal row is the winner. It is a solved game, with a forced draw assuming best play from both players.");
            Console.WriteLine("...");
            Console.WriteLine("Please note that the starting symbol is X!");
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            char[,] board = new char[3, 3];
            Initialize(board);
            char player = 'X';
            int movesPlayed = 0;
            bool playAgain = true;

            while (playAgain)
            {
                Console.Clear();
                Print(board);

                Console.Write("Insert row: ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Insert col: ");
                int col = int.Parse(Console.ReadLine());

                if (row > 2 || col > 2)
                {
                    Console.WriteLine("THAT SPOT DOES NOT EXIST!");
                    Thread.Sleep(700);
                    continue;
                }
                if (board[row, col] == 'X' || board[row, col] == 'O')
                {
                    Console.WriteLine("ILLEGAL MOVE!");
                    Thread.Sleep(700);
                    continue;
                }

                board[row, col] = player;
                movesPlayed++;

                //Horizontal
                if (player == board[0, 0] && player == board[0, 1] && player == board[0, 2]

                    || player == board[1, 0] && player == board[1, 1] && player == board[1, 2]

                    || player == board[2, 0] && player == board[2, 1] && player == board[2, 2]

                    //Vertical
                    || player == board[0, 0] && player == board[1, 0] && player == board[2, 0]

                    || player == board[0, 1] && player == board[1, 1] && player == board[2, 1]

                    || player == board[0, 2] && player == board[1, 2] && player == board[2, 2]

                    //Diagonal
                    || player == board[0, 0] && player == board[1, 1] && player == board[2, 2]
                    || player == board[0, 2] && player == board[1, 1] && player == board[2, 0])
                {
                    Console.Clear();
                    Print(board);
                    Console.WriteLine($"{player} has won!");
                    Console.WriteLine("Play again? Y/N");

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Y)
                    {
                        playAgain = true;
                        movesPlayed = 0;
                        Initialize(board);
                        Print(board);
                    }
                    else if (keyInfo.Key == ConsoleKey.N)
                    {
                        playAgain = false;
                    }
                }

                if (movesPlayed == 9)
                {
                    Console.Clear();
                    Print(board);
                    Console.WriteLine("Is a Draw!");
                    break;
                }
                player = ChangeTurn(player);
            }
        }

        private static char ChangeTurn(char currPlayer)
        {
            if (currPlayer == 'X')
            {
                return 'O';
            }
            else
            {
                return 'X';
            }
        }
        private static void Initialize(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
        private static void Print(char[,] board)
        {
            Console.WriteLine("    0   1   2 ");
            for (int row = 0; row < 3; row++)
            {
                Console.Write($"{row} | ");
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
    }
}
