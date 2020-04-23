using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    interface IStorage
    {
        void Sort(int[] array);
        void Print();
    }

    class InsertionSort : IStorage
    {

        public int[] Array { get; set; }

        public void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    array[j] = key;
                    j--;

                }
            }

            Array = array;
        }

        public void Print()
        {
            Console.WriteLine("Сортировка вставками");

            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine();
        }
    }



    class MergeSort : IStorage
    {
        public int[] Array { get; set; }

        public void Sort(int[] array)
        {

            int mid = array.Length / 2;
            int[] leftArray = new int[mid];
            int[] rightArray = new int[array.Length - mid];

            for (int z = 0; z < mid; z++)
            {
                leftArray[z] = array[z];

            }
            for (int z = mid; z < array.Length; z++)
            {
                rightArray[z - mid] = array[z];
            }

            if (leftArray.Length > 1)
                Sort(leftArray);
            if (rightArray.Length > 1)
                Sort(rightArray);
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < leftArray.Length && j < rightArray.Length)
                if (leftArray[i] < rightArray[j])
                {
                    array[k] = leftArray[i];
                    k++;
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    k++;
                    j++;
                }
            while (i < leftArray.Length)
                array[k++] = leftArray[i++];
            while (j < rightArray.Length)
                array[k++] = rightArray[j++];

            Array = array;
        }

        public void Print()
        {
            Console.WriteLine("Сортировка слиянием");

            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write(Array[i] + " ");
            }
            Console.WriteLine();
        }
    }

    class Sorts
    {
        IStorage SortStrategy;

        public Sorts(IStorage SortStrategy)
        {
            this.SortStrategy = SortStrategy;
        }

        public void Sort(int[] array)
        {
            SortStrategy.Sort(array);
        }

        public void Print()
        {
            SortStrategy.Print();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[100];

            Random rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0, 99);
            }

            Sorts insert = new Sorts(new InsertionSort());
            Sorts merge = new Sorts(new MergeSort());

            insert.Sort(arr);
            insert.Print();

            merge.Sort(arr);
            merge.Print();

        }
    }
}

