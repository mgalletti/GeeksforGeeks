using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimum_number_of_jumps_to_reach_end_of_a_given_array
{
    class Program
    {
        // http://www.geeksforgeeks.org/minimum-number-of-jumps-to-reach-end-of-a-given-array/
        static void Main(string[] args)
        {
            //int[] arr = { 1, 3, 5, 8, 9, 2, 6, 7, 6, 8, 9 };
            int[] arr = { 1, 3, 6, 3, 2, 3, 6, 8, 9, 5 };
            //int jumps = MinJump(arr, 0, arr.Length - 1);
            int jumps = MinJump(arr, arr.Length);
            Console.WriteLine(string.Join(" ", arr));
            Console.WriteLine("Minimum no. of jumps to reach the end: " + jumps.ToString());
            Console.Read();
        }

        static int MinJump(int[] arr, int low, int high)
        {
            if (low >= high)
                return 0;
            if (arr[low] == 0)
                return -1;
            int min = Int32.MaxValue;
            for (int i = low + 1; i <= high && i <= low + arr[low]; i++)
            {
                int jumps = MinJump(arr, i, high);
                if (jumps >= 0 && jumps + 1 < min)
                {
                    min = jumps + 1;
                }
            }
            return min;
        }

        static int MinJump(int[] arr, int n)
        {
            int[] jump = new int[n];
            if (n == 0 || arr[0] == 0)
                return -1;

            jump[0] = 0;
            for (int i = 1; i < n; i++)
            {
                jump[i] = Int32.MaxValue;
                for (int j = 0; j < i; j++)
                {
                    if (i <= j + arr[j] && jump[j] != Int32.MaxValue)
                    {
                        jump[i] = Math.Min(jump[i], jump[j] + 1);
                        break;
                    }
                }
            }
            return jump[n - 1];
        }
    }
}
