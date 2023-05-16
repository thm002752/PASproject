using System;
using System.Linq;


namespace ConsoleApp2
{
        class Program
        {
            static void Main(string[] args)
            {
              
                Console.Write("Enter the number of items: ");
                int n = int.Parse(Console.ReadLine());
                int[] arr = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Enter value {i + 1}: ");
                    arr[i] = int.Parse(Console.ReadLine());
                }

                Array.Sort(arr);
                double median = n % 2 == 0 ? (arr[n / 2 - 1] + arr[n / 2]) / 2.0 : arr[n / 2];
                int mode = arr.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
                int range = arr[n - 1] - arr[0];
                double q1 = n % 4 == 0 ? (arr[n / 4 - 1] + arr[n / 4]) / 2.0 : arr[n / 4];
                double q3 = n % 4 == 0 ? (arr[n / 4 * 3 - 1] + arr[n / 4 * 3]) / 2.0 : arr[n / 4 * 3];
                double p90 = arr[(int)(n * 0.9) - 1];
                double iqr = q3 - q1;
                double lowerBound = q1 - 1.5 * iqr;
                double upperBound = q3 + 1.5 * iqr;

         
                Console.WriteLine($"Median: {median}");
                Console.WriteLine($"Mode: {mode}");
                Console.WriteLine($"Range: {range}");
                Console.WriteLine($"First Quartile: {q1}");
                Console.WriteLine($"Third Quartile: {q3}");
                Console.WriteLine($"P90: {p90}");
                Console.WriteLine($"Interquartile Range: {iqr}");
                Console.WriteLine($"Outlier Boundaries: {lowerBound} to {upperBound}");
                Console.Write("Enter a value to check if it's an outlier: ");
                int val = int.Parse(Console.ReadLine());
                bool isOutlier = val < lowerBound || val > upperBound;
                Console.WriteLine($"{val} is {(isOutlier ? "" : "not ")}an outlier.");
            }
        }
    }
