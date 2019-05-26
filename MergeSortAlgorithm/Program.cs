using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] unsortedNumbers = new int[10] { 20, 34, 11, 7, 59, 28, 10, 30, 15, 5 };
            List<int> unsortedList = new List<int>();
            List<int> sortedList;

            Console.WriteLine("INPUT: The unsorted numbers are given as below:");
            Console.WriteLine("===============================================");
           
            for (int i = 0; i < unsortedNumbers.Length; i++)
            {
                unsortedList.Add(unsortedNumbers[i]);
                Console.Write(unsortedNumbers[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            sortedList = DivideTheUnsortedList(unsortedList);           

            Console.WriteLine("OUTPUT: The unsorted numbers are sorted as below:");
            Console.WriteLine("=================================================");

            foreach (int item in sortedList)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }

        public static List<int> DivideTheUnsortedList(List<int> unsortedList)
        {
            if(unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            int middle = unsortedList.Count / 2;

            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            
            for (int i = 0; i < middle; i++)
            {
                leftList.Add(unsortedList[i]);
            }

            for (int i = middle; i < unsortedList.Count; i++)
            {
                rightList.Add(unsortedList[i]);
            }

            leftList = DivideTheUnsortedList(leftList);
            rightList = DivideTheUnsortedList(rightList);

            return MergeTheSortedList(leftList, rightList);
        }

        public static List<int> MergeTheSortedList(List<int> leftList, List<int> rightList)
        {
            List<int> sortedList = new List<int>();
            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList.First() <= rightList.First())
                    {
                        sortedList.Add(leftList.First());
                        leftList.Remove(leftList.First());
                    }
                    else
                    {
                        sortedList.Add(rightList.First());
                        rightList.Remove(rightList.First());
                    }
                }
                else if (leftList.Count > 0)
                {
                    sortedList.Add(leftList.First());
                    leftList.Remove(leftList.First());
                }
                else if (rightList.Count > 0)
                {
                    sortedList.Add(rightList.First());
                    rightList.Remove(rightList.First());
                }
            }

            return sortedList;
        }
    }
}
