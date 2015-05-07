using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            List<int> numbers = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!numbers.Contains(int.Parse(input[i])))
                {
                    numbers.Add(int.Parse(input[i]));
                }

            }

            int combCount = (int)Math.Pow(2, numbers.Count);
            byte[,] combinataions = new byte[combCount, numbers.Count];
            for (int i = 1; i < combinataions.GetLength(0); i++)
            {
                int currentCombo = i;
                for (int j = 0; j < numbers.Count; j++)
                {
                    combinataions[i, j] = (byte)(currentCombo >> j & 1);
                }
            }
            List<bool> matchedComb = new List<bool>(combCount);
            matchedComb.Add(false);
            for (int i = 1; i < combinataions.GetLength(0); i++)
            {
                int sum = 0;
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (combinataions[i, j] == 1)
                    {
                        sum += numbers[j];
                    }
                }
                if (sum == n)
                {
                    matchedComb.Add(true);
                }
                else
                {
                    matchedComb.Add(false);
                }
            }
            if (matchedComb.Contains(true))
            {
                for (int i = 0; i < combinataions.GetLength(0); i++)
                {
                    if (matchedComb[i] == true)
                    {
                        bool neeedsSign = false;
                        for (int j = 0; j < numbers.Count; j++)
                        {

                            if (combinataions[i, j] == 1)
                            {
                                if (neeedsSign == true)
                                {
                                    Console.Write(" + ");
                                }
                                Console.Write("{0}", numbers[j]);
                                neeedsSign = true;
                            }

                        }
                        Console.WriteLine("={0}", n);
                    }
                }

            }
          
            else
            {
                Console.WriteLine("No matching subsets.");
            }
        }
    }
}