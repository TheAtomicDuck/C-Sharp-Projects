using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    class Movement
    {
        public static void DisplayRedPawnMoves(Colors[,] Board, Figures[,] Formation, int x, int y,bool Checking)
        {
            if(!Checking)
            {
                BoardAction.ResetBoardColor(Board);
                BoardAction.DrawBoard(Board, Formation);
            }
                 
            try
            {
                if (Formation[x + 1, y + 1] == Figures.EmptyField)
                    Board[x + 1, y + 1] = Colors.Red;
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Formation[x + 1, y - 1] == Figures.EmptyField)
                    Board[x + 1, y - 1] = Colors.Red;
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if ((Formation[x + 1, y + 1] == Figures.MagentaPawn || (Formation[x + 1, y + 1] == Figures.MagentaQueen)) && Formation[x + 2, y + 2] == Figures.EmptyField)
                    Board[x + 2, y + 2] = Colors.Red;
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if ((Formation[x + 1, y - 1] == Figures.MagentaPawn || (Formation[x + 1, y - 1] == Figures.MagentaQueen)) && Formation[x + 2, y - 2] == Figures.EmptyField)
                    Board[x + 2, y - 2] = Colors.Red;
            }
            catch (IndexOutOfRangeException) { }
            if(!Checking)
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void DisplayMagentaPawnMoves(Colors[,] Board, Figures[,] Formation, int x, int y, bool Checking)
        {
            if (!Checking)
            {
                BoardAction.ResetBoardColor(Board);
                BoardAction.DrawBoard(Board, Formation);
            }
                
            try
            {
                if (Formation[x - 1, y + 1] == Figures.EmptyField)
                    Board[x - 1, y + 1] = Colors.Magenta;
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if (Formation[x - 1, y - 1] == Figures.EmptyField)
                    Board[x - 1, y - 1] = Colors.Magenta;
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if ((Formation[x - 1, y + 1] == Figures.RedPawn || (Formation[x - 1, y + 1] == Figures.RedQueen)) && Formation[x - 2, y + 2] == Figures.EmptyField)
                    Board[x - 2, y + 2] = Colors.Magenta;
            }
            catch (IndexOutOfRangeException) { }
            try
            {
                if ((Formation[x - 1, y - 1] == Figures.RedPawn || (Formation[x - 1, y - 1] == Figures.RedQueen)) && Formation[x - 2, y - 2] == Figures.EmptyField)
                    Board[x - 2, y - 2] = Colors.Magenta;
            }
            catch (IndexOutOfRangeException) { }
            if(!Checking)
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void DisplayMagentaQueenMoves(Colors[,] Board, Figures[,] Formation, int x, int y, bool Checking)
        {
            if (!Checking)
                BoardAction.ResetBoardColor(Board);
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x + i, y + i] == Figures.RedPawn || Formation[x + i, y + i] == Figures.RedQueen) && Formation[x + (i + 1), y + (i + 1)] == Figures.EmptyField)
                    {
                        Board[x + (i + 1), y + (i + 1)] = Colors.Magenta;
                        i = 8;
                    }

                    else if (Formation[x + i, y + i] == Figures.EmptyField)
                        Board[x + i, y + i] = Colors.Magenta;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x + i, y - i] == Figures.RedPawn || Formation[x + i, y - i] == Figures.RedQueen) && Formation[x + (i + 1), y - (i + 1)] == Figures.EmptyField)
                    {
                        Board[x + (i + 1), y - (i + 1)] = Colors.Magenta;
                        i = 8;
                    }

                    else if (Formation[x + i, y - i] == Figures.EmptyField)
                        Board[x + i, y - i] = Colors.Magenta;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x - i, y + i] == Figures.RedPawn || Formation[x - i, y + i] == Figures.RedQueen) && Formation[x - (i + 1), y + (i + 1)] == Figures.EmptyField)
                    {
                        Board[x - (i + 1), y + (i + 1)] = Colors.Magenta;
                        i = 8;
                    }

                    else if (Formation[x - i, y + i] == Figures.EmptyField)
                        Board[x - i, y + i] = Colors.Magenta;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x - i, y - i] == Figures.RedPawn || Formation[x - i, y - i] == Figures.RedQueen) && Formation[x - (i + 1), y - (i + 1)] == Figures.EmptyField)
                    {
                        Board[x - (i + 1), y - (i + 1)] = Colors.Magenta;
                        i = 8;
                    }

                    else if (Formation[x - i, y - i] == Figures.EmptyField)
                        Board[x - i, y - i] = Colors.Magenta;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            if(!Checking)
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void DisplayRedQueenMoves(Colors[,] Board, Figures[,] Formation, int x, int y, bool Checking)
        {
            if (!Checking)
                BoardAction.ResetBoardColor(Board);
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x + i, y + i] == Figures.MagentaPawn || Formation[x + i, y + i] == Figures.MagentaQueen) && Formation[x + (i + 1), y + (i + 1)] == Figures.EmptyField)
                    {
                        Board[x + (i + 1), y + (i + 1)] = Colors.Red;
                        i = 8;
                    }
                    else if (Formation[x + i, y + i] == Figures.EmptyField)
                        Board[x + i, y + i] = Colors.Red;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x + i, y - i] == Figures.MagentaPawn || Formation[x + i, y - i] == Figures.MagentaQueen) && Formation[x + (i + 1), y - (i + 1)] == Figures.EmptyField)
                    {
                        Board[x + (i + 1), y - (i + 1)] = Colors.Red;
                        i = 8;
                    }
                    else if (Formation[x + i, y - i] == Figures.EmptyField)
                        Board[x + i, y - i] = Colors.Red;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x - i, y + i] == Figures.MagentaPawn || Formation[x - i, y + i] == Figures.MagentaQueen) && Formation[x - (i + 1), y + (i + 1)] == Figures.EmptyField)
                    {
                        Board[x - (i + 1), y + (i + 1)] = Colors.Red;
                        i = 8;
                    }
                    else if (Formation[x - i, y + i] == Figures.EmptyField)
                        Board[x - i, y + i] = Colors.Red;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            for (int i = 1; i < 8; i++)
            {
                try
                {
                    if ((Formation[x - i, y - i] == Figures.MagentaPawn || Formation[x - i, y - i] == Figures.MagentaQueen) && Formation[x - (i + 1), y - (i + 1)] == Figures.EmptyField)
                    {
                        Board[x - (i + 1), y - (i + 1)] = Colors.Red;
                        i = 8;
                    }
                    else if (Formation[x - i, y - i] == Figures.EmptyField)
                        Board[x - i, y - i] = Colors.Red;
                    else i = 8;
                }
                catch (IndexOutOfRangeException) { i = 8; }
            }
            if(!Checking)
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void MoveMagentaFigure(Colors[,] Board, Figures[,] Formation, ref int x, ref int y, int w, int z, ref int Magenta_Score)
        {
            if (Formation[w, z] == Figures.MagentaPawn)
            {
                Formation[x, y] = Figures.MagentaPawn;
                Formation[w, z] = Figures.EmptyField;
                if (y > z)
                {
                    if (Formation[x + 1, y - 1]==Figures.RedPawn)
                        Magenta_Score++;
                    else if (Formation[x + 1, y - 1] == Figures.RedQueen)
                        Magenta_Score += 5;
                    Formation[x + 1, y - 1] = Figures.EmptyField;
                }
                else if (y < z)
                {
                    if (Formation[x + 1, y + 1] == Figures.RedPawn)
                        Magenta_Score++;
                    else if (Formation[x + 1, y + 1] == Figures.RedQueen)
                        Magenta_Score += 5;
                    Formation[x + 1, y + 1] = Figures.EmptyField;
                }
            }
            else if (Formation[w, z] == Figures.MagentaQueen)
            {
                Formation[x, y] = Figures.MagentaQueen;
                Formation[w, z] = Figures.EmptyField;
                if (x > w)
                {
                    if (y > z)
                    {
                        if (Formation[x - 1, y - 1] == Figures.RedPawn)
                            Magenta_Score++;
                        else if (Formation[x - 1, y - 1] == Figures.RedQueen)
                            Magenta_Score += 5;
                        Formation[x - 1, y - 1] = Figures.EmptyField;
                    }
                    else if (y < z)
                    {
                        if (Formation[x - 1, y + 1] == Figures.RedPawn)
                            Magenta_Score++;
                        else if (Formation[x - 1, y + 1] == Figures.RedQueen)
                            Magenta_Score += 5;
                        Formation[x - 1, y + 1] = Figures.EmptyField;
                    }
                }
                else if (x < w)
                {
                    if (y > z)
                    {
                        if (Formation[x + 1, y - 1] == Figures.RedPawn)
                            Magenta_Score++;
                        else if (Formation[x + 1, y - 1] == Figures.RedQueen)
                            Magenta_Score += 5;
                        Formation[x + 1, y - 1] = Figures.EmptyField;
                    }
                    else if (y < z)
                    {
                        if (Formation[x + 1, y + 1] == Figures.RedPawn)
                            Magenta_Score++;
                        else if (Formation[x + 1, y + 1] == Figures.RedQueen)
                            Magenta_Score += 5;
                        Formation[x + 1, y + 1] = Figures.EmptyField;
                    }
                }
            }
            Console.Beep(750, 10);
            BoardAction.ResetBoardColor(Board);
            BoardAction.DrawBoard(Board, Formation);
        }
        public static void MoveRedFigure(Colors[,] Board, Figures[,] Formation, ref int x, ref int y, int w, int z, ref int Red_Score)
        {
            if (Formation[w, z] == Figures.RedPawn)
            {
                Formation[x, y] = Figures.RedPawn;
                Formation[w, z] = Figures.EmptyField;
                if (y > z)
                {
                    if (Formation[x - 1, y - 1] == Figures.MagentaPawn)
                        Red_Score++;
                    else if (Formation[x - 1, y - 1] == Figures.MagentaQueen)
                        Red_Score += 5;
                        Formation[x - 1, y - 1] = Figures.EmptyField;
                    
                }
                else if (y < z)
                {
                    if (Formation[x - 1, y + 1] == Figures.MagentaPawn)
                        Red_Score++;
                    else if (Formation[x - 1, y + 1] == Figures.MagentaQueen)
                        Red_Score += 5;
                    Formation[x - 1, y + 1] = Figures.EmptyField;
                }
            }
            else if (Formation[w, z] == Figures.RedQueen)
            {
                Formation[x, y] = Figures.RedQueen;
                Formation[w, z] = Figures.EmptyField;
                if (x > w)
                {
                    if (y > z)
                    {
                        if (Formation[x - 1, y - 1]==Figures.MagentaPawn)
                            Red_Score++;
                        else if(Formation[x - 1, y - 1]==Figures.MagentaQueen)
                            Red_Score+=5;
                        Formation[x - 1, y - 1] = Figures.EmptyField;
                    }
                    else if (y < z)
                    {
                        if (Formation[x - 1, y + 1]== Figures.MagentaPawn)
                            Red_Score++;
                        else if (Formation[x - 1, y + 1]== Figures.MagentaQueen)
                            Red_Score += 5;
                        Formation[x - 1, y + 1] = Figures.EmptyField;
                    }
                }
                else if (x < w)
                {
                    if (y > z)
                    {
                        if (Formation[x + 1, y - 1]== Figures.MagentaPawn)
                            Red_Score++;
                        else if (Formation[x + 1, y - 1]== Figures.MagentaQueen)
                            Red_Score += 5;
                        Formation[x + 1, y - 1] = Figures.EmptyField;
                    }
                    else if (y < z)
                    {
                        if (Formation[x + 1, y + 1]== Figures.MagentaPawn)
                            Red_Score++;
                        else if (Formation[x + 1, y + 1]== Figures.MagentaQueen)
                            Red_Score += 5;
                        Formation[x + 1, y + 1] = Figures.EmptyField;
                    }
                }
            }
            BoardAction.ResetBoardColor(Board);
            BoardAction.DrawBoard(Board, Formation);
            Console.Beep(1500, 10);
        }
        public static void MagentaMove(ref int x, ref int y, ref int w, ref int z, Colors[,] Board, Figures[,] Formation,ref Colors OldColor,ref Colors NewColor, ref bool Player1_Turn,ref bool Playing, ref string Winners_Name, ref int Magenta_Score)
        {
            BoardAction.ScanRedVictory(Formation, ref Playing,ref Magenta_Score);
            BoardAction.ScanStalemateMagenta(Formation, Board, ref Playing, ref Magenta_Score);
            if (Playing)
            {
                Cursor.MoveMagentaCursor(ref x, ref y, ref w, ref z, Board, Formation, ref OldColor, ref NewColor, ref Player1_Turn,ref Magenta_Score);
            }
            BoardAction.ScanRedVictory(Formation, ref Playing, ref Magenta_Score);
        }
        public static void RedMove(ref int x, ref int y, ref int w, ref int z, Colors[,] Board, Figures[,] Formation,ref Colors OldColor,ref Colors NewColor, ref bool Player1_Turn, ref bool Playing, ref string Winners_Name, ref int Red_Score)
        {
            BoardAction.ScanMagentaVictory(Formation, ref Playing,ref Red_Score);
            BoardAction.ScanStalemateRed(Formation, Board, ref Playing, ref Red_Score);
            if (Playing)
            {
                Cursor.MoveRedCursor(ref x, ref y, ref w, ref z, Board, Formation, ref OldColor, ref NewColor, ref Player1_Turn, ref Red_Score);
            }
            BoardAction.ScanMagentaVictory(Formation, ref Playing, ref Red_Score);
        }
    }
}
