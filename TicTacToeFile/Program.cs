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
            bool val = true;
            while (val)
            {
                if (!(pLetter.Equals('X') || pLetter.Equals('O')))
                {
                    pLetter = t.ChooseLetter();
                }
                else
                {
                    val = false;
                }
            }
            char cLetter = 'X';
            if (pLetter.Equals('X'))
            {
                cLetter = 'O';
            }
            t.PrintBoard(board);
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
            return pLetter;
        }

        public void PrintBoard(char[] board)
        {
            for (int i = 1; i < 10;)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i] + "\t");
                    i++;
                }
                Console.Write("\n");
            }
        }
    }



}