using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 5, 2, 4, 6, 1, 3, 2, 6 };
            int p = 0;
            int r = A.Length - 1;

            MergeSort(A, p, r);
            Console.WriteLine("Массив после сортировки: ");
            foreach (var item in A)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }

        static void MergeSort(int[] arr, int begin, int end)
        {
            if (begin < end)
            {
                int half = (begin + end) / 2;
                MergeSort(arr, begin, half);
                MergeSort(arr, half + 1, end);
                Merge(arr, begin, half, end);
            }
        }

        static void Merge(int[] arr, int begin, int half, int end)
        {
            int[] leftArray = new int[half - begin + 1];
            int[] rightArray = new int[end - half];

            Array.Copy(arr, begin, leftArray, 0, half - begin + 1);
            Array.Copy(arr, half + 1, rightArray, 0, end - half);

            int i = 0;
            int j = 0;
            for (int k = begin; k < end + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}
