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
                    Console.WriteLine("Please choose among the given options");
                    pLetter = ChooseLetter();
                }
                else
                {
                    val = false;
                }
            }
            return pLetter;
        }

    }



}