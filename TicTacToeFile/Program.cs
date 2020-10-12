using System;
using System.Globalization;

namespace TicTacToeGame
{
    public enum Player { USER, COMPUTER };
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


            Player p = t.FirstPlayToss();
            if (p == Player.USER)
            {
                t.MakeAMove(board, pLetter, p);
                //   t.PrintBoard(board);
                t.MakeAMove(board, cLetter, Player.COMPUTER);
                //   t.PrintBoard(board);
            }
            else
            {
                t.MakeAMove(board, cLetter, p);
                //    t.PrintBoard(board);
                t.MakeAMove(board, pLetter, Player.USER);
                //  t.PrintBoard(board);
            }
            // t.PrintBoard(board);
            /* bool playVal = true;
             while (playVal)
             {
                 playVal = t.MakeAMove(board,pLetter);

             }
             t.WhoWon(board,pLetter,cLetter);*/

        }
    }

    class TicTacToe
    {
        public char[] CreateBoard()
        {
            char[] board = new char[10];
            for (int i = 1; i < 10; i++)
            {
                board[i] = ' ';
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

            Console.WriteLine("\n\n");
        }

        public bool check_Availability(char[] board, int k)
        {
            bool val = false;
            if (board[k].Equals(' '))
            {
                val = true;
            }
            return val;
        }

        public void MakeAMove(char[] board, char pLetter, Player k)
        {
            if (k == Player.USER)
            {
                Console.WriteLine("Choose a position among 1 to 9");
                int choice = Convert.ToInt32(Console.ReadLine());
                bool check_if_empty = check_Availability(board, choice);
                if (check_if_empty == false)
                {
                    Console.WriteLine("The position you chose is full, Please choose another position");
                }
                else
                {
                    Play(board, pLetter, choice);
                    PrintBoard(board);
                }
            }
            else
            {
                int pos = GetWinningMove(board, pLetter);
                Console.WriteLine("pos =" + pos);
                if (pos == 0)
                {
                    Random rn = new Random();
                    pos = rn.Next(1, 10);
                    if (check_Availability(board, pos))
                    {
                        Play(board, pLetter, pos);
                        PrintBoard(board);
                    }
                    else
                    {
                        MakeAMove(board, pLetter, k);
                    }
                }
                else
                {
                    Play(board, pLetter, pos);
                    PrintBoard(board);
                }
            }
        }

        public void Play(char[] board, char pLetter, int pos)
        {
            board[pos] = pLetter;
        }

        public Player FirstPlayToss()
        {
            string choice = null;
            bool val = true;
            while (val)
            {
                Console.WriteLine("What will you choose -- heads(1)/tails(0)?");
                choice = (Console.ReadLine());
                if (choice[0].Equals('1') || choice[0].Equals('0'))
                {
                    val = false;
                }
                else
                {
                    Console.WriteLine("Please provide valid input(0/1).");
                    val = true;
                }
            }
            int choice2 = Convert.ToInt32(choice);
            Random rn = new Random();
            if (rn.Next(0, 2) == choice2)
            {
                Console.WriteLine("You got your desired side.So, will play first");
                return Player.USER;
            }
            else
            {
                Console.WriteLine("Computer will play first");
                return Player.COMPUTER;
            }
        }

        public bool CheckIsWinner(char[] board, char playLetter)
        {
            bool isWinner = false;
            for (int i = 1; i < 8;)
            {
                if (board[i].Equals(playLetter) && board[i + 1].Equals(playLetter) && board[i + 2].Equals(playLetter))
                {
                    isWinner = true;
                }
                i += 3;
            }
            for (int i = 1; i < 4; i++)
            {
                if (board[i].Equals(playLetter) && board[i + 3].Equals(playLetter) && board[i + 3].Equals(playLetter))
                {
                    isWinner = true;
                }
            }
            if (board[1].Equals(playLetter) && board[5].Equals(playLetter) && board[9].Equals(playLetter))
            {
                isWinner = true;
            }
            if (board[3].Equals(playLetter) && board[5].Equals(playLetter) && board[7].Equals(playLetter))
            {
                isWinner = true;
            }

            return isWinner;
        }

        public void WhoWon(char[] board, char pLetter, char cLetter)
        {
            bool checkPlayerWinner = CheckIsWinner(board, pLetter);
            bool checkComputerWinner = CheckIsWinner(board, cLetter);
            if (checkPlayerWinner == true)
            {
                Console.WriteLine("YOU WON!!!");
            }
            if (checkComputerWinner == true)
            {
                Console.WriteLine("Computer Won!");
            }
            else if (checkComputerWinner == false && checkPlayerWinner == false)
            {
                Console.WriteLine("This is a Tie");
            }

        }

        public int GetComputerMove(char[] board, char cLetter)
        {
            return (GetWinningMove(board, cLetter));
        }

        public int GetWinningMove(char[] board, char playLetter)
        {
            Console.WriteLine("Winning move called");
            bool won = false;
            int pos = 0;
            for (int i = 1; i < 10; i++)
            {
                char[] board2 = BoardCopy(board);
                if (check_Availability(board2, i))
                {
                    board2[i] = playLetter;
                    won = CheckIsWinner(board2, playLetter);
                    if (won == true)
                    {
                        pos = i;
                        break;
                    }
                    else
                    {
                        pos = 0;
                    }
                }
            }
            return pos;
        }


        public char[] BoardCopy(char[] board)
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, 0, boardCopy, 0, board.Length);

            return boardCopy;
        }

    }
}

