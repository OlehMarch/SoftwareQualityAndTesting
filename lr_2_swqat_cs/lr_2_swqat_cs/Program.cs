using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr_2_swqat_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            int[] Array = { 2, 8, 3, 5, 1, 6, 0, 7, 9, 4 };

            UnitTest uTest = new UnitTest();
            uTest.testLog(Array);

            Console.Write("Array before sorting: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(Array[i]);
            }
            Console.WriteLine();

	        Console.Write("Insert 1 or 2: ");
	        choice = Console.Read() - 48;

	        if (choice == 1) {
                Array = selectionSort(Array);
	        }
	        else if (choice == 2) {
                Array = bubbleSort(Array);
	        }
	        else {
		        Console.WriteLine("Inserted value is not correct!\n");
		        Console.ReadKey();
		        return;
	        }
            Console.Write("Array after sorting:  ");
	        for (int i = 0; i < 10; i++) {
		        Console.Write(Array[i]);
	        }

            Console.WriteLine(uTest.TestStatus);            
            Console.ReadKey();
        }

        public static int[] addToArray(int[] Array, int value, bool first = false)
        {
            int length = Array.Length + 1;
            int[] ArrayPlusOneNod = new int[length];
            if (first == true)
            {
                ArrayPlusOneNod[0] = value;
                for (int i = 1; i < length; i++)
                {
                    ArrayPlusOneNod[i] = Array[i - 1];
                }
            }
            else
            {
                for (int i = 0; i < length - 1; i++)
                {
                    ArrayPlusOneNod[i] = Array[i];
                }
                ArrayPlusOneNod[length - 1] = value;
            }
            return ArrayPlusOneNod;
        }

        public static int[] deleteFromArray(int[] Array, int value)
        {
            int length = Array.Length;
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (Array[i] == value)
                {
                    ++counter;
                    int j = 0;
                    for (j = i; j + 1 < length; j++)
                    {
                        Array[j] = Array[j + 1];
                    }
                }
            }
            if (counter > 0)
            {
                int[] ArrayAfterDelete = new int[length - counter];
                for (int i = 0; i < length - counter; i++)
                {
                    ArrayAfterDelete[i] = Array[i];
                }
                return ArrayAfterDelete;
            }
            else
            {
                return Array;
            }
        }

        public static int[] bubbleSort(int[] Array)
        {
            //сортировка пузырьком
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = i + 1; j < Array.Length; j++)
                {
                    if (Array[j] < Array[i])
                    {
                        var temp = Array[i];
                        Array[i] = Array[j];
                        Array[j] = temp;
                    }
                }
            }
            return Array;
        }

        public static int[] selectionSort(int[] Array)
        {
            //сортировка методом выбора
            int min, temp;
            int length = Array.Length;
            for (int i = 0; i < length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (Array[j] < Array[min])
                    {
                        min = j;
                    }
                }
                if (min != i)
                {
                    temp = Array[i];
                    Array[i] = Array[min];
                    Array[min] = temp;
                }
            }
            return Array;
        }
    }
}
