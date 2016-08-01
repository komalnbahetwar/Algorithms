using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSortNumofComparisions
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"E:\Komal Bahetwar\Training\Coursera\Algorithms_Design_Analysis_Part_I\Week_2\MasterMethod_N_QuickSort\Problem_1\Input.txt");
            int length = lines.Length;

            //Creating 3 different array with same values for 3 different problem
            int[] input1 = new int[length];
            int[] input2 = new int[length];
            int[] input3 = new int[length];

            for (int i = 0; i < length; i++)
            {
                input1[i] = Convert.ToInt32(lines[i].Trim());
                input2[i] = Convert.ToInt32(lines[i].Trim());
                input3[i] = Convert.ToInt32(lines[i].Trim());
            }
            Console.WriteLine("Total number of comparions when selected first element as Pivot : " + GetTotalComparisions1(input1, length));

            Console.WriteLine("Total number of comparions when selected last element as Pivot : " + GetTotalComparisions2(input2, length));

            Console.WriteLine("Total number of comparions when 'median-of-three' pivot rule applied : " + GetTotalComparisions3(input3, length));

            Console.ReadKey();
        }

        #region First element as Pivot
        public static long GetTotalComparisions1(int[] input, int length)
        {
            return QuickSort1(input, 0, length - 1);
        }

        public static long QuickSort1(int[] input, int left, int right)
        {
            if (right - left < 1)
            {
                return 0;
            }
            int pt = PartitionFirstElementAsPivot(input, left, right);

            long x = QuickSort1(input, left, pt - 1);
            long y = QuickSort1(input, pt + 1, right);
            long z = right - left;

            return x + y + z;
        }

        public static int PartitionFirstElementAsPivot(int[] input, int left, int right)
        {
            int pivot = input[left];
            int i = left + 1;
            for (int j = left + 1; j <= right; j++)
            {
                if (input[j] < pivot)
                {
                    Swap(input, i, j);
                    i++;
                }
            }
            Swap(input, left, i - 1);
            return (i - 1);
        }
        #endregion

        #region Last element as Pivot
        public static long GetTotalComparisions2(int[] input, int length)
        {
            return QuickSort2(input, 0, length - 1);
        }

        public static long QuickSort2(int[] input, int left, int right)
        {
            if (right - left < 1)
            {
                return 0;
            }
            int pt = PartitionLastElementAsPivot(input, left, right);

            long x = QuickSort2(input, left, pt - 1);
            long y = QuickSort2(input, pt + 1, right);
            long z = right - left;

            return x + y + z;
        }

        public static int PartitionLastElementAsPivot(int[] input, int left, int right)
        {
            int pivot = input[right];
            Swap(input, left, right);
            return PartitionFirstElementAsPivot(input, left, right);
        }
        #endregion

        #region "median-of-three" pivot rule
        public static long GetTotalComparisions3(int[] input, int length)
        {
            return QuickSort3(input, 0, length - 1);
        }

        public static long QuickSort3(int[] input, int left, int right)
        {
            if (right - left < 1)
            {
                return 0;
            }
            int pt = PartitionMedianofThreeAsPivot(input, left, right);

            long x = QuickSort3(input, left, pt - 1);
            long y = QuickSort3(input, pt + 1, right);
            long z = right - left;

            return x + y + z;
        }

        public static int PartitionMedianofThreeAsPivot(int[] input, int left, int right)
        {
            int mid = left + (right - left) / 2;
            int median = left;
            if (input[left] > input[mid])
            {
                if (input[mid] > input[right])
                {
                    median = mid;
                }
                else if (input[left] > input[right])
                {
                    median = right;
                }
                else
                {
                    median = left;
                }
            }
            else
            {
                if (input[left] > input[right])
                {
                    median = left;
                }
                else if (input[mid] > input[right])
                {
                    median = right;
                }
                else
                {
                    median = mid;
                }
            }
            Swap(input, left, median);
            return PartitionFirstElementAsPivot(input, left, right);
        }
        #endregion

        public static void Swap(int[] input, int i, int j)
        {
            int temp = input[j];
            input[j] = input[i];
            input[i] = temp;
        }
    }
}
