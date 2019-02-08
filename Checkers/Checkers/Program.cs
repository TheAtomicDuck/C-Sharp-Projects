using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Drawing.Text;
namespace Checkers
{
    enum Colors
    {
        White=ConsoleColor.White,
        Grey = ConsoleColor.Gray,
        Red = ConsoleColor.Red,
        Green = ConsoleColor.Green,
        Cyan=ConsoleColor.Cyan,
        Magenta=ConsoleColor.Magenta
    }//The colors that exist in the board.
    enum Figures
    {
        RedPawn,
        MagentaPawn,
        RedQueen,
        MagentaQueen,
        EmptyField
    }//All the figures in the game.

    class Program
    {
        public static void DisplayStalemateMessage()
        {
            Console.Clear();
            int leftOffSet = (Console.WindowWidth / 2 - 8);
            int topOffSet = (Console.WindowHeight / 2);
            Console.SetCursorPosition(leftOffSet, topOffSet);
            Console.Write("Stalemate!");
            Console.SetCursorPosition(leftOffSet, topOffSet + 1);
            Console.WriteLine("play again?");
            Console.SetCursorPosition(leftOffSet, topOffSet + 2);
            Console.WriteLine("Y or N");
        }

        public static void DisplayMagentaVictoryMessage(Figures[,]Formation,int Magenta_Score)
        {
            int NumberOfFigures = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.MagentaPawn || Formation[i, j] == Figures.MagentaQueen)
                        NumberOfFigures++;
                    if (Formation[i, j] == Figures.MagentaQueen)
                        Magenta_Score *= 5;
                }
            }
            Magenta_Score *= NumberOfFigures;
            Console.Clear();
            int leftOffSet = (Console.WindowWidth / 2 - 12);
            int topOffSet = (Console.WindowHeight / 2);
            Console.SetCursorPosition(leftOffSet, topOffSet);
            Console.WriteLine("Magenta Victory!");
            Console.SetCursorPosition(leftOffSet, topOffSet+1);
            Console.WriteLine("your score: "+Magenta_Score);
            Console.SetCursorPosition(leftOffSet, topOffSet + 2);
            Console.WriteLine("play again?");
            Console.SetCursorPosition(leftOffSet, topOffSet + 3);
            Console.WriteLine("Y or N");
        }

        public static void DisplayRedVictoryMessage(Figures[,] Formation, int Red_Score)
        {
            int NumberOfFigures = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.RedPawn || Formation[i, j] == Figures.RedQueen)
                        NumberOfFigures++;
                    if (Formation[i, j] == Figures.RedQueen)
                        Red_Score *= 5;
                }
            }
            Red_Score *= NumberOfFigures;
            Console.Clear();
            int leftOffSet = (Console.WindowWidth / 2 - 12);
            int topOffSet = (Console.WindowHeight / 2);
            Console.SetCursorPosition(leftOffSet, topOffSet);
            Console.WriteLine("Red Victory!");
            Console.SetCursorPosition(leftOffSet, topOffSet+1);
            Console.WriteLine("your score: " + Red_Score);
            Console.SetCursorPosition(leftOffSet, topOffSet + 2);
            Console.WriteLine("play again?");
            Console.SetCursorPosition(leftOffSet, topOffSet + 3);
            Console.WriteLine("Y or N");
        }

        public static bool MagentaPawnDetector( int x, int y,Figures[,]Formation,ref int w,ref int z)
        {
            
            if (Formation[x, y] == Figures.MagentaPawn)
            {
                w = x;
                z = y;
                return true;
            }   
            else return false;

        }

        public static bool MagentaQueenDetector( int x, int y, Figures[,] Formation, ref int w, ref int z)
        {
            
            if (Formation[x, y] == Figures.MagentaQueen)
            {
                w = x;
                z = y;
                return true;
            }
            else return false;
        }

        public static bool RedPawnDetector( int x, int y, Figures[,] Formation, ref int w, ref int z)
        {
            
            if (Formation[x, y] == Figures.RedPawn)
            {
                w = x;
                z = y;
                return true;
            }
                
            else return false;
        }

        public static bool RedQueenDetector( int x, int y, Figures[,] Formation, ref int w, ref int z)
        {
            
            if (Formation[x, y] == Figures.RedQueen)
            {
                w = x;
                z = y;
                return true;
            }
                
            else return false;
        }

        static void DescidingNextRound(ref bool Desciding,ref bool NextRound)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKey Key = Console.ReadKey().Key;
            switch (Key)
            {
                case ConsoleKey.Y:
                    NextRound = true;
                    Desciding = false;
                    break;
                case ConsoleKey.N:
                    NextRound = false;
                    Desciding = false;
                    break;
                default:
                    Desciding = true;
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible=false;
            Font font = new Font("newFont",30.0f, FontStyle.Italic);
            Colors[,] Board =
             {
                 {Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White,Colors.Grey },
                 {Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White },
                 {Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White,Colors.Grey },
                 {Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White },
                 {Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White,Colors.Grey },
                 {Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White },
                 {Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White,Colors.Grey },
                 {Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey, Colors.White, Colors.Grey,Colors.White }
             };//The Board itself.
            int[] LeaderBoard = new int[10];
            string Winners_Name=null;
            bool Player1_Turn,Playing,NextRound=false,Desciding=true;
            int x = 0, y = 0, w = 0, z = 0;//Coordinates.
            Colors NewColor = Colors.Cyan;
            Colors OldColor = Colors.White;
            Board[0, 0] = NewColor;
            do
            {
                Player1_Turn = true;
                Desciding = true;
                int Red_Score = 0, Magenta_Score = 0;
                Figures[,] Formation =
         {
                 {Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn },
                 {Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField },
                 {Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn,Figures.EmptyField,Figures.RedPawn },
                 {Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField },
                 {Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField,Figures.EmptyField },
                 {Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField },
                 {Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn },
                 {Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField,Figures.MagentaPawn,Figures.EmptyField }
             };
                Playing = true;
                while (Playing)
                {
                    Console.Clear();
                    BoardAction.DrawBoard(Board, Formation);
                    if (Player1_Turn)
                        Movement.MagentaMove(ref x, ref y, ref w, ref z, Board, Formation, ref OldColor, ref NewColor, ref Player1_Turn, ref Playing, ref Winners_Name, ref Magenta_Score);
                    else
                        Movement.RedMove(ref x, ref y, ref w, ref z, Board, Formation, ref OldColor, ref NewColor, ref Player1_Turn, ref Playing, ref Winners_Name, ref Red_Score);
                }
                while(Desciding)
                {
                    DescidingNextRound(ref Desciding, ref NextRound);
                }
            } while (NextRound);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Tanks for playing!");
            Console.ReadKey();
        }
    }
}
