using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            

            string[] rows = { "0001010", "0100000", "0101001", "0011001", "1111110", "1001011", "0100101", "1101110", "1010101", "1110000" };
            char[,] matrix = new char[10,7];
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                {
                    matrix[i, j] = rows[i][j];
                }
            MaximalRectangle(matrix);
        }

        public static int MaximalRectangle(char[,] matrix)
        {
            int maxSize = 0;
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            int currentX = 0;
            int currentY = 0;
            int currentSize = 1;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (matrix[x, y] != '1')
                    {
                        currentX = 0;
                        continue;
                    }
                    while (x + currentX < width && matrix[x + currentX, y] == '1')
                    {
                        currentX++;
                        bool end = true;
                        while (end && currentY + y < height)
                        {
                            for (int xx = x; xx < x + currentX; xx++)
                            {
                                if (matrix[xx, y + currentY] != '1')
                                {
                                    end = false;
                                    currentY--;
                                    break;
                                }
                            }
                            currentY++;
                        }
                        currentSize = currentX * currentY;
                        currentY = 0;
                        if (currentSize > maxSize)
                            maxSize = currentSize;
                    }
                    currentX = 0;
                }
            }
            return maxSize;
        }
    }
}
