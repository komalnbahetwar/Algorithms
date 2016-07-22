using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversion
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;
            string[] lines = System.IO.File.ReadAllLines(@"E:\Komal Bahetwar\Training\Coursera\Algorithm Design Analysis I\Week 1\Input.txt");
            int length = lines.Length;
            int[] input = new int[length];

            for (int i = 0; i < length; i++)
            {
                input[i] = Convert.ToInt32(lines[i].Trim());
            }

            //Console.WriteLine("Divide n Conquer :" + InversionDivideNConquer(input, length));
            Console.WriteLine("Bruteforce :" + InversionBruteForce(input, length));

            Console.WriteLine("Total time taken : " + (DateTime.Now - startTime).TotalMilliseconds);
            Console.ReadKey();
        }

        public static long InversionDivideNConquer(int[] input, int length)
        {

            return 0;
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
