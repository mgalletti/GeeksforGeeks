using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace type_array_maximum_element
{
    class Program
    {
        // http://www.geeksforgeeks.org/type-array-maximum-element/
        static void Main(string[] args)
        {
            int[] n = { 2, 1, 5, 4, 3 };
            int max;
            ArrayType t = CheckArrayType(n, out max);
            Console.WriteLine("numbers: " + string.Join(" ", n));
            Console.WriteLine("array is: " + t.ToString());
            Console.WriteLine("max is: " + max.ToString());

            Console.Read();
        }

        public enum ArrayType { tyAscending, tyDescending, tyAscendingRotated, tyDescendingRotated, tyNone };

        static ArrayType CheckArrayType(int[] a, out int max)
        {
            for (int i = 0; i < a.Length - 2; i++)
            {
                if (a[i] < a[i + 1] && a[i + 1] < a[i + 2])
                {
                    if (i == 0)
                    {
                        max = a[a.Length - 1];
                        return ArrayType.tyAscending;
                    }
                    else
                    {
                        max = a[i - 1];
                        return ArrayType.tyAscendingRotated;
                    }
                }
            }

            for (int i = 0; i < a.Length - 2; i++)
            {
                if (a[i] > a[i + 1] && a[i + 1] > a[i + 2])
                {
                    if (i == 0)
                    {
                        max = a[0];
                        return ArrayType.tyDescending;
                    }
                    else
                    {
                        max = a[i];
                        return ArrayType.tyDescendingRotated;
                    }
                }
            }
            max = -1;
            return ArrayType.tyNone;
        }
    }
}
