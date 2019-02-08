using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Cursor
    {
        public static void MoveLeft(ref int x,ref int y, Colors[,] Board, Figures[,] Formation, ref Colors OldColor, ref Colors NewColor)
        {
            if (y == 0)
            {
                y = 8;
            }
            y--;
            if (y == 7)
            {
                Board[x, 0] = OldColor;
            }
            else
                 Board[x, y + 1] = OldColor;
            OldColor = Board[x, y];
            Board[x, y] = NewColor;
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void MoveRight(ref int x, ref int y, Colors[,] Board, Figures[,] Formation, ref Colors OldColor, ref Colors NewColor)
        {
            if (y == 7)
            {
                y = -1;
            }
            y++;
            if (y == 0)
            {
                Board[x, 7] = OldColor;
            }
            else
                Board[x, y - 1] = OldColor;
            OldColor = Board[x, y];
            Board[x, y] = NewColor;
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void MoveUp(ref int x, ref int y, Colors[,] Board, Figures[,] Formation, ref Colors OldColor, ref Colors NewColor)
        {
            if (x == 0)
            {
                x = 8;
            }
            x--;
            if (x == 7)
            {
                Board[0, y] = OldColor;
            }
            else
                Board[x + 1, y] = OldColor;
            OldColor = Board[x, y];
            Board[x, y] = NewColor;
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void MoveDown(ref int x, ref int y,Colors[,]Board,Figures[,]Formation, ref Colors OldColor, ref Colors NewColor)
        {
            if (x == 7)
            {
                x = -1;
            }
            x++;
            if (x == 0)
            {
                Board[7, y] = OldColor;
            }
            else
                Board[x - 1, y] = OldColor;
            OldColor = Board[x, y];
            Board[x, y] = NewColor;
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void MoveRedCursor(ref int x, ref int y, ref int w, ref int z, Colors[,] Board, Figures[,] Formation,ref  Colors OldColor,ref  Colors NewColor,ref bool Player1_Turn, ref int Red_Score)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            bool Checking = false;
            bool Moving = true;
            while (Moving)
            {
                ConsoleKey Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveLeft(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.Enter:
                        if (Program.RedPawnDetector(x, y, Formation, ref w, ref z))
                        {
                            Movement.DisplayRedPawnMoves(Board, Formation, x, y, Checking);
                        }
                        else if (Program.RedQueenDetector(x, y, Formation, ref w, ref z))
                        {
                            Movement.DisplayRedQueenMoves(Board, Formation, x, y, Checking);
                        }
                        else if (Board[x, y] == Colors.Cyan && OldColor == Colors.Red)
                        {
                            Movement.MoveRedFigure(Board, Formation, ref x, ref y, w, z, ref Red_Score);
                            OldColor = Colors.Grey;
                            BoardAction.ResetBoardColor(Board);
                            BoardAction.ScanForQueens(Formation);
                            Moving = !Moving;
                            BoardAction.DrawBoard(Board, Formation);
                            Player1_Turn = !Player1_Turn;

                        }
                        else
                        {
                            BoardAction.ResetBoardColor(Board);
                        }
                        break;
                    default:
                        
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }
            
        }
        public static void MoveMagentaCursor(ref int x, ref int y, ref int w, ref int z, Colors[,] Board, Figures[,] Formation,ref  Colors OldColor,ref  Colors NewColor,ref bool Player1_Turn, ref int Magenta_Score)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            bool Checking = false;
            bool Moving = true;
            while(Moving)
            {
                ConsoleKey Key = Console.ReadKey().Key;
                switch (Key)
                {
                    case ConsoleKey.LeftArrow:
                        MoveLeft(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.RightArrow:
                        MoveRight(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUp(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.DownArrow:
                        MoveDown(ref x, ref y, Board, Formation, ref OldColor, ref NewColor);
                        Console.Beep(400, 10);
                        break;
                    case ConsoleKey.Enter:
                        if (Program.MagentaPawnDetector(x, y, Formation, ref w, ref z))
                        {
                            Movement.DisplayMagentaPawnMoves(Board, Formation, x, y,Checking);
                        }
                        else if (Program.MagentaQueenDetector(x, y, Formation, ref w, ref z))
                        {
                            Movement.DisplayMagentaQueenMoves(Board, Formation, x, y, Checking);
                        }
                        else if (Board[x, y] == Colors.Cyan && OldColor == Colors.Magenta)
                        {
                            Movement.MoveMagentaFigure(Board, Formation, ref x, ref y, w, z, ref Magenta_Score);
                            OldColor = Colors.Grey;
                            BoardAction.ResetBoardColor(Board);
                            BoardAction.ScanForQueens(Formation);
                            Moving = !Moving;
                            BoardAction.DrawBoard(Board, Formation);
                            Player1_Turn = !Player1_Turn;
                        }
                        else
                        {
                            BoardAction.ResetBoardColor(Board);
                        }
                        break;
                    default:
                        
                        Console.SetCursorPosition(0, 0);
                        break;
                }
            }   
        }
    }
}
