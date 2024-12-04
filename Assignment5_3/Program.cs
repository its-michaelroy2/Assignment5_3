using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;

namespace Assignment5_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment5.3.1 (LEETCODE #605)");
            Console.WriteLine("===============\n");


            Console.WriteLine("Input: int[] flowerbed = { 1, 0, 0, 0, 1 }, n = 1");
            int[] flowerbed = { 1, 0, 0, 0, 1 };
            Console.WriteLine($"Output: {PlantFlowers(flowerbed, 1)}\n");

            Console.WriteLine("Input: int[] flowerbed = { 1, 0, 0, 0, 1 }, n = 2");
            flowerbed = new int[] { 1, 0, 0, 0, 1 };
            Console.WriteLine($"Output: {PlantFlowers(flowerbed, 2)}");
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Assignment5.3.2");
            Console.WriteLine("===============\n");

            Console.WriteLine("How many steps to reach the top?");
            string input = Console.ReadLine();
            int.TryParse(input, out int n);
            Console.WriteLine($"\nOutput: {ClimbStaircase(n)}");
            Console.WriteLine("\nThere are " + ClimbStaircase(n) + " ways to reach the top.");
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();

        }

        static bool PlantFlowers(int[] flowerbed, int n)
        {
            //1. You have a long flowerbed in which some of the plots are planted, and some are not. However, flowers cannot be planted in adjacent plots.\r\n\r\nGiven an integer array flowerbed containing 0's and 1's, where 0 means empty and 1 means not empty, and an integer n, return true if n new flowers can be planted in the flowerbed without violating the no-adjacent-flowers rule and false otherwise.;

            //What is the initial condition?
            //ANSWER: 1s and 0s
            //I'm done when I can no longer add 1s and 0s to flowerbed that abide by the rules

            //for loop through array 'flowerbed'
            //if flowerbed[i] == 0 && flowerbed[i--] !=1 && flowerbed[i++] !=1 
            //Then we flowerbed[i] = 1 & we add 1 to count
            //At end check if count == n & if so its true else false
            int count = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0 && (i == 0 || flowerbed[i - 1] == 0) && (i == flowerbed.Length - 1 || flowerbed[i + 1] == 0))
                {
                    flowerbed[i] = 1;
                    count++;
                }
            }
            if (count == n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static int ClimbStaircase(int n)
        {
            //2.You are climbing a staircase. It takes n steps to reach the top.

            //Each time you can either climb 1 or 2 steps.In how many distinct ways can you climb to the top?

            //Example 1:
            //Input: n = 2
            //Output: 2

            //Explanation: There are two ways to climb to the top.
            //1. 1 step + 1 step
            //2. 2 steps

            //Example 2:
            //Input: n = 3
            //Output: 3

            //Explanation: There are three ways to climb to the top.
            //1. 1 step + 1 step + 1 step
            //2. 1 step + 2 steps
            //3. 2 steps + 1 step

            //Best way w/ expression below?
            if (n == 0 || n == 1)
            {
                return 1;
            }

            int[] steps = new int[n + 1];
            steps[0] = 1;
            steps[1] = 1;

            for (int i = 2; i < steps.Length; i++)
            {
                steps[i] = steps[i - 1] + steps[i - 2];
            }
            return steps[n];
        }
    }
}
