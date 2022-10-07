using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>() { 5, 13, 7, 3, 1, 42 };
            int searchItem = 42;
            int foundIndex = LinearSearch(nums, searchItem);
            if(foundIndex >= 0)
                Console.WriteLine($"Found {searchItem} at index {foundIndex}");
            else
                Console.WriteLine($"{searchItem} was not found.");
        }

        private static int LinearSearch(List<int> nums, int searchItem) //O(N) - linear
        {
            int index = -1;//means not-found
            for (int i = 0; i < nums.Count; i++)
            {
                if(searchItem == nums[i])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
