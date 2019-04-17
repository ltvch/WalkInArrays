using System;

namespace TwoDimensionalArray
{
    internal class Program
    {
        const int HEIGTH = 5;
        const int WIDTH = 5;

        private static int[,] BuildArray(int height, int width)
        {

            var arr = new int[height, width];
            Random rnd = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    arr[i, j] = rnd.Next();
                }
            }

            return arr;
        }


        public static int[,] Helix(int height, int width)
        {
            int[,] matrix = new int[height,width];

            int row = 0;
            int column = 0;
            int dx = 1;
            int dy = 0;
            int dirChanges = 0;
            int visits = width;

            for (int i = 0; i < height * width; i++)
            {
                matrix[row,column] = i + 1;
                if (--visits == 0)
                {
                    visits = width * (dirChanges % 2) +
                        height * ((dirChanges + 1) % 2) -
                        (dirChanges / 2 - 1) - 2;
                    int temp = dx;
                    dx = -dy;
                    dy = temp;
                    dirChanges++;
                }
                column += dx;
                row += dy;
            }

            return matrix;
        }

        private static int[,] HelixEasy(int height, int width)
        {
            int[,] matrix = new int[height, width];

            int row = 0;
            int col = 0;
            string direction = "right";
            int maxRotations = height * width;

            for (int i = 1; i <= maxRotations; i++)
            {
                if (direction == "right" && (col > width - 1 || matrix[row, col] != 0))
                {
                    direction = "down";
                    col--;
                    row++;
                }
                if (direction == "down" && (row > height - 1 || matrix[row, col] != 0))
                {
                    direction = "left";
                    row--;
                    col--;
                }
                if (direction == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    direction = "up";
                    col++;
                    row--;
                }

                if (direction == "up" && row < 0 || matrix[row, col] != 0)
                {
                    direction = "right";
                    row++;
                    col++;
                }

                matrix[row, col] = i;

                if (direction == "right")
                {
                    col++;
                }
                if (direction == "down")
                {
                    row++;
                }
                if (direction == "left")
                {
                    col--;
                }
                if (direction == "up")
                {
                    row--;
                }
            }
            return matrix;
        }

        public static int[,] ZigZag(int height, int width)
        {
            int[,] matrix = new int[height, width];
            int i = 0,
                j = 0,
                d = -1; // -1 for top-right move, +1 for bottom-left move
            int start = 0, 
                end = height * width - 1;
            do
            {
                matrix[i, j] = start++;
                matrix[height - i - 1, width - j - 1] = end--;

                i += d; j -= d;
                if (i < 0)
                {
                    i++; d = -d; // top reached, reverse
                }
                else if (j < 0)
                {
                    j++; d = -d; // left reached, reverse
                }
            } while (start < end);
            if (start == end)
                matrix[i, j] = start;
            return matrix;
        }

        private static int[,] Snake(int rows, int cols)
        {
            /*
             * var A:array[1..100,1..100] of integer;
                     n,m,i,j: integer;
                     c: integer;
            begin
                     readln(n,m);
               c:=1;
               for j:=1 to m do
               begin
                     for i:=1 to n do
                      begin
                         A[i,j]:=c;
                         if (j mod 2 = 0) and (i<>n) then
                                  dec(c)
                         else
                                  inc(c);
                      end;
                  c:=c+n-1;
               end;
               for i:=1 to n do
               begin
                     for j:=1 to m do
                           write(A[i,j]:5);
                  writeln;
               end;
               readln;
             *
             **/

            int[,] matrix = new int[rows, cols];
            /*
            int c = 1;
            for(int j = 1; j < width; j++)
            {
                for(int i = 1; i < height; i++)
                {
                    matrix[i, j] = c;
                    if (j % 2 == 0 && i != width) c--;
                    else c++;
                }
                c += width - 1;
            }
            */
            /*
            for i:= 1 to n do
            begin
               for j:= 1 to m do
               begin
                if i mod 2 = 1 then
                    A[i, j] = (i - 1) * m + j;
                else
                    A[i, j] = i * m - j + 1;
                write(A[i, j]:3);
                end;
               writeln;
            end;
            */
            /* */
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (i % 2 == 1) 
                        matrix[i, j] = (i - 1) * cols + j;
                    else
                        matrix[i, j] = i * cols - j - 1;
                }
            }
           
            /* true and work 
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = i * cols + (i % 2 == 0 ? j : cols - j - 1);
            */
            return matrix;
        }

        private static void Main(string[] args)
        {

            //ShowMatrix(Helix(HEIGTH, WIDTH));                    
            // ShowMatrix(HelixEasy(HEIGTH, WIDTH));
            //ShowMatrix(ZigZag(HEIGTH, WIDTH));

            ShowMatrix(Snake(HEIGTH, WIDTH));
            Console.WriteLine("\nPress any key to continue..");
            Console.ReadKey();
        }

        private static void ShowMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write("{0,4}", matrix[i, j]);
                Console.WriteLine();
            }
        }
    }
}
