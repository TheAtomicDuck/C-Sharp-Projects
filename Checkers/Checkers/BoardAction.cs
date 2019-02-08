using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class BoardAction
    {
        public static void ResetBoardColor(Colors[,] Board)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == Colors.Red || Board[i, j] == Colors.Magenta)
                        Board[i, j] = Colors.Grey;
                }
            }
        }
        public static void DrawBoard(Colors[,] Board, Figures[,] Formation)//Draws the board in it's current status.
        {
            for (int i = 0; i < 8; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 8, i);
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == Colors.Grey)
                        Console.BackgroundColor = ConsoleColor.Gray;
                    else if (Board[i, j] == Colors.White)
                        Console.BackgroundColor = ConsoleColor.White;
                    else if (Board[i, j] == Colors.Cyan)
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    else if (Board[i, j] == Colors.Magenta)
                        Console.BackgroundColor = ConsoleColor.Magenta;
                    else if (Board[i, j] == Colors.Red)
                        Console.BackgroundColor = ConsoleColor.Red;
                    if (Formation[i, j] == Figures.EmptyField)
                        Console.Write("  ");
                    else if (Formation[i, j] == Figures.MagentaPawn)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" P");
                    }
                    else if (Formation[i, j] == Figures.RedPawn)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" P");
                    }
                    else if (Formation[i, j] == Figures.MagentaQueen)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(" Q");
                    }
                    else if (Formation[i, j] == Figures.RedQueen)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" Q");
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
                Console.SetCursorPosition(0, 0);
            }
        }
        public static void ScanForQueens(Figures[,] Formation)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Formation[0, i] == Figures.MagentaPawn)
                {
                    Formation[0, i] = Figures.MagentaQueen;
                }
                if (Formation[7, i] == Figures.RedPawn)
                {
                    Formation[7, i] = Figures.RedQueen;
                }
            }
        }
        public static void ScanRedFigures(Figures[,]Formation,ref int Player1_Score)
        {
            int NumberOfRedFigures = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.RedPawn || Formation[i, j] == Figures.RedQueen)
                        NumberOfRedFigures++;
                }
            }
        }
        public static void ScanMagentaFigures(Figures[,] Formation, ref int Player1_Score)
        {
            int NumberOfRedFigures = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.MagentaPawn || Formation[i, j] == Figures.MagentaQueen)
                        NumberOfRedFigures++;
                }
            }
        }
        public static void ScanStalemateRed(Figures[,]Formation,Colors[,]Board,ref bool Playing, ref int Red_Score)
        {
            bool Checking = true;
            int PossibleMoves = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(Formation[i,j]==Figures.RedPawn)
                    {
                        Movement.DisplayRedPawnMoves(Board, Formation, i, j, Checking);
                    }
                    else if(Formation[i,j]==Figures.RedQueen)
                    {
                        Movement.DisplayRedQueenMoves(Board, Formation, i, j, Checking);
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == Colors.Red)
                        PossibleMoves++;
                }
            }
            ResetBoardColor(Board);
            if (PossibleMoves == 0)
            {
                Playing = false;
                Console.Clear();
                Program.DisplayStalemateMessage();
            }
            else
                DrawBoard(Board, Formation);
        }
        public static void ScanStalemateMagenta(Figures[,]Formation,Colors[,]Board,ref bool Playing, ref int Magenta_Score)
        {
            bool Checking = true;
            int PossibleMoves = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.MagentaPawn)
                    {
                        Movement.DisplayMagentaPawnMoves(Board, Formation, i, j,Checking);
                    }
                    else if (Formation[i, j] == Figures.MagentaQueen)
                    {
                        Movement.DisplayMagentaQueenMoves(Board, Formation, i, j,Checking);
                    }
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] == Colors.Magenta)
                        PossibleMoves++;
                }
            }
            ResetBoardColor(Board);
            if (PossibleMoves == 0)
            {
                Playing = false;
                Console.Clear();
                Program.DisplayStalemateMessage();
            }
            else
                DrawBoard(Board, Formation);
            
            
        }
        public static void ScanMagentaVictory(Figures[,]Formation,ref bool Playing,ref int Magenta_Score)
        {
            int RedFigures = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.RedPawn || Formation[i, j] == Figures.RedQueen)
                        RedFigures++;
                }
            }
            if (RedFigures == 0)
            {
                Playing = false;
                Program.DisplayMagentaVictoryMessage(Formation, Magenta_Score);
            }
        }
        public static void ScanRedVictory(Figures[,] Formation, ref bool Playing, ref int Red_Score)
        {
            int MagentaFigures = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Formation[i, j] == Figures.MagentaPawn || Formation[i, j] == Figures.MagentaQueen)
                        MagentaFigures++;
                }
            }
            if (MagentaFigures == 0)
            {
                Playing = false;
                Program.DisplayRedVictoryMessage(Formation, Red_Score);
            }
                
        }
    }
}
