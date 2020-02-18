using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[] { 2, 5, 9, 6, 1, 3 };
            int[] arr2 = new int[] { 2, 3, 7 };

            int[] result = FindSubArray(arr, arr2);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != 0)
                    Console.WriteLine(result[i]);
            }

            Console.ReadKey();

        }

        public static bool BinarySearch(int[] arr, int value)
        {
            int mid = arr.Length / 2;
            if (arr[mid] == value)
                return true;
            else if (arr.Length == 1)
                return false;
            if (value < arr[mid])
                return BinarySearch(SliceArray(arr, 0, mid - 1), value);
            else
                return BinarySearch(SliceArray(arr, mid + 1, arr.Length - 1), value);
        }
        public static int[] FindSubArray(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr2.Length];
            arr1 = sort(arr1);

            for (int i = 0; i < arr2.Length; i++)
            {
                if (BinarySearch(arr1, arr2[i]))
                    result[i] = arr2[i];
            }
            return result;
        }
        public static int[] sort(int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)

                // traverse i+1 to array length 
                for (int j = i + 1; j < arr.Length; j++)

                    // compare array element with  
                    // all next element 
                    if (arr[i] > arr[j])
                    {

                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
            return arr;
        }

        public static int[] SliceArray(int[] arr, int startingpoint, int endingpoint)
        {

            int[] result = new int[endingpoint - startingpoint + 1];
            int index = 0;
            for (int i = startingpoint; i <= endingpoint; i++)
            {
                result[index] = arr[i];
                index++;
            }
            return result;

        }
    }
}
