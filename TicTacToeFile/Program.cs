using System;
using System.Globalization;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to TicTacToeGame");
            TicTacToe t = new TicTacToe();
            char[] board = t.CreateBoard();
            char pLetter = t.ChooseLetter();
            char cLetter = 'X';
            if (pLetter.Equals('X'))
            {
                cLetter = 'O';
            }
            Console.WriteLine("Player's Letter = " + pLetter);
            Console.WriteLine("Computer's Letter = " + cLetter);
            t.PrintBoard(board);
            bool playVal = true;
            while (playVal)
            {
                Console.WriteLine("Choose a position among 1 to 9");
                int choice = Convert.ToInt32(Console.ReadLine());
                bool check_if_empty = t.check_Availability(board, choice);
                if (check_if_empty == false)
                {
                    Console.WriteLine("The position you chose is full, Please choose another position");
                }
                else
                {
                    board[choice] = pLetter;
                    t.PrintBoard(board);
                }
                Console.WriteLine("Want to play again? (Y/N)");
                char playAgain = Convert.ToChar(Console.ReadLine());
                if (playAgain == 'N')
                {
                    playVal = false;
                }
            }
        }
    }

    class TicTacToe
    {
        public char[] CreateBoard()
        {
            char[] board = new char[10];
            for (int i = 1; i < 10; i++)
            {
                board[i] = '0';
            }
            return board;
        }

        public char ChooseLetter()
        {
            Console.WriteLine("Choose a letter among X and O");
            char pLetter = Convert.ToChar(Console.ReadLine());
            bool val = true;
            while (val)
            {
                if (!(pLetter.Equals('X') || pLetter.Equals('O')))
                {
                    pLetter = ChooseLetter();
                }
                else
                {
                    val = false;
                }
            }
            return pLetter;
        }

        public void PrintBoard(char[] board)
        {
            for (int i = 1; i < 10;)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|\t" + board[i] + "\t ");
                    i++;
                }
                Console.Write("\n");
                Console.WriteLine("------------------------------------------------");
            }
        }

        public bool check_Availability(char[] board, int k)
        {
            bool val = false;
            if (board[k].Equals('0'))
            {
                val = true;
            }
            return val;
        }




    }



}
