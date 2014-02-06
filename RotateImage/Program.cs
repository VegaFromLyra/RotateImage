using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given a N x N image matrix, rotate the image  by 90 degrees
// Follow up: Do it in place

namespace RotateImage
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] input = new int [4, 4] {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};

            RotateImageOptimal(input, 4);

            // int[,] input = new int[2, 2] { {1, 2}, {3, 4}};
            // RotateImageOptimal(input, 2);

            for (int i = 0; i < input.GetLength(0); i++)
            {
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    Console.Write(input[i, j] + " ");
                }

                Console.WriteLine("");
            }
        }

        public static void RotateImage(int[,] matrix, int N)
        {
            int start = 0;
            int end = N - 1;

            while (start < end)
            {
                int[] top = GetTopEdge(matrix, start, end);
                int[] right = GetRightEdge(matrix, start, end);
                int[] bottom = GetBottomEdge(matrix, start, end);
                int[] left = GetLeftEdge(matrix, start, end);

                CopyLeftToTop(matrix, start, end, left);
                CopyBottomToLeft(matrix, start, end, bottom);
                CopyRightToBottom(matrix, start, end, right);
                CopyTopToRight(matrix, start, end, top);

                start++;
                end--;
            }
        }

        public static void RotateImageOptimal(int[,] matrix, int N)
        {
            int start = 0;
            int end = N - 1;
            int offset = 0;

            while (start < end)
            {
                for (int i = start; i < end; i++)
                {
                    offset = i - start;
                    // Save top
                    int top = matrix[start,i];
                    // top = left
                    matrix[start, i] = matrix[end - offset, start];
                    // left = bottom
                    matrix[end - offset, start] = matrix[end, end - offset];
                    // bottom = right
                    matrix[end, end - offset] = matrix[i, end];
                    // right = top
                    matrix[i, end] = top;
                }

                start++;
                end--;
            }
        }

        private static void CopyBottomToLeft(int[,] matrix, int start, int end, int[] bottomEdge)
        {
            for (int i = end, bottomCounter = 0; i >= start; i--, bottomCounter++)
            {
                matrix[i, start] = bottomEdge[bottomCounter];
            }
        }

        private static void CopyLeftToTop(int[,] matrix, int start, int end, int[] leftEdge)
        {
            for (int i = start, leftCounter = 0; i <= end; i++, leftCounter++)
            {
                matrix[start, i] = leftEdge[leftCounter];
            }
        }

        private static void CopyRightToBottom(int[,] matrix, int start, int end, int[] rightEdge)
        {
            for (int i = end, rightCounter = 0; i >= start; i--, rightCounter++)
            {
                matrix[end, i] = rightEdge[rightCounter];
            }
        }

        private static void CopyTopToRight(int[,] matrix, int start, int end, int[] topEdge)
        {
            for (int i = start, topCounter = 0; i <= end; i++, topCounter++)
            {
                matrix[i, end] = topEdge[topCounter];
            }
        }

        private static int[] GetTopEdge(int[,] matrix, int start, int end)
        {
            int[] topEdge = new int[end - start + 1];

            // Copy top edge from left to right
            for (int i = start, topCounter = 0; i <= end; i++, topCounter++)
            {
                topEdge[topCounter] = matrix[start, i];
            }

            return topEdge;
        }

        private static int[] GetRightEdge(int[,] matrix, int start, int end)
        {
            int[] rightEdge = new int[end - start + 1];

            // Copy right edge from top to bottom

            for (int i = start, rightCounter = 0; i <= end; i++, rightCounter++)
            {
                rightEdge[rightCounter] = matrix[i, end];
            }

            return rightEdge;
        }

        private static int[] GetBottomEdge(int[,] matrix, int start, int end)
        {
            int[] bottomEdge = new int[end - start + 1];

            // Copy bottom edge from right to left

            for (int i = end, bottomCounter = 0; i >= start; i--, bottomCounter++)
            {
                bottomEdge[bottomCounter] = matrix[end, i];
            }

            return bottomEdge;
        }

        private static int[] GetLeftEdge(int[,] matrix, int start, int end)
        {
            int[] leftEdge = new int[end - start + 1];

            // Copy left from bottom to top

            for (int i = end, leftCounter = 0; i >= start; i--, leftCounter++)
            {
                leftEdge[leftCounter] = matrix[i, start];
            }

            return leftEdge;
        }
    }
}
