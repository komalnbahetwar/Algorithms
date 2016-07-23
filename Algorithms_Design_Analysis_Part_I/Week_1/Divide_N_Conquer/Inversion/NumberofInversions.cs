using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversion
{
    class NumberofInversions
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            string[] lines = System.IO.File.ReadAllLines(@"E:\Komal Bahetwar\Training\Coursera\Algorithms_Design_Analysis_Part_I\Week_1\Divide_N_Conquer\Inputs\Input.txt");
            int length = lines.Length;
            int[] input = new int[length];

            for (int i = 0; i < length; i++)
            {
                input[i] = Convert.ToInt32(lines[i].Trim());
            }
            Console.WriteLine("Total number of inversions :" + InversionCount(input, length));

            Console.WriteLine("Total time taken : " + (DateTime.Now - startTime).TotalMilliseconds);
            Console.ReadKey();
        }

        public static long InversionCount(int[] input, int length)
        {
            long output = 0;
            output = InversionDivideNConquer(input, 0, length - 1, length);

            //output = InversionBruteForce(input, length);
            return output;
        }

        public static long InversionDivideNConquer(int[] input, int low, int high, int length)
        {
            if (high - low < 1)
            {
                return 0;
            }
            int mid = low + (high - low) / 2;
            long x = InversionDivideNConquer(input, low, mid, length);
            long y = InversionDivideNConquer(input, mid + 1, high, length);
            long z = CountSplitInversion(input, low, mid, high, length);
            return x + y + z;
        }

        public static long CountSplitInversion(int[] input, int low, int mid, int high, int length)
        {
            int i = 0, j = 0, k = low;
            long count = 0;
            int n1 = mid - low + 1, n2 = high - mid;
            int[] left = new int[n1];
            int[] right = new int[n2];
            for (int p = 0; p < n1; p++)
            {
                left[p] = input[p + low];
            }
            for (int q = 0; q < n2; q++)
            {
                right[q] = input[q + mid + 1];
            }
            while (i < n1 && j < n2)
            {
                if (left[i] > right[j])
                {
                    input[k] = right[j];
                    count += (n1 - 1) - (i - 1);
                    j++;
                }
                else
                {
                    input[k] = left[i];
                    i++;
                }
                k++;
            }
            while (i < n1)
            {
                input[k] = left[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                input[k] = right[j];
                j++;
                k++;
            }
            return count;
        }

        public static long InversionBruteForce(int[] input, int length)
        {
            long numOfInversion = 0;
            for (int j = 0; j < length; j++)
            {
                for (int k = j; k < length; k++)
                {
                    if (input[j] > input[k])
                    {
                        numOfInversion += 1;
                    }
                }
            }
            return numOfInversion;
        }
    }
}

//Output for given input : 2407905288