using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lr_3_swqat_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol;
    //-----------------------------------------------------------------------------//
            while (true)
            {
                Console.Write("Perform calculation of S and R assessment? (y/n): ");
                symbol = Convert.ToChar(Console.Read());
                if (symbol.Equals('y') || symbol.Equals('n'))
                {
                    break;
                }
                Console.Clear();
                continue;
            }
    //-----------------------------------------------------------------------------//
            if (symbol.Equals('y'))
            {
                // Uses the second Core or Processor for the Test
                Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(2);
                // Prevents "Normal" processes from interrupting Threads
                Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
                // Prevents "Normal" Threads from interrupting this thread
                Thread.CurrentThread.Priority = ThreadPriority.Highest;

                int[] testQuantity = { 100, 1000, 10000, 100000 };

                for (int i = 0; i < testQuantity.Length; ++i)
                {
                    SnRAssessment assess = new SnRAssessment(testQuantity[i], 3, -30, 31);
                    assess.addOperation(testQuantity[i], -30, 31);
                    Console.WriteLine("\n-----------------\nAdd operation:");
                    Console.WriteLine(" - S assess: " + assess.sAssessmentCalculation(testQuantity[i], 0));
                    Console.WriteLine(" - R assess: " + assess.rAssessmentCalculation(testQuantity[i], 0));
                    assess.deleteOperation(testQuantity[i], -30, 31);
                    Console.WriteLine("Delete operation:");
                    Console.WriteLine(" - S assess: " + assess.sAssessmentCalculation(testQuantity[i], 1));
                    Console.WriteLine(" - R assess: " + assess.rAssessmentCalculation(testQuantity[i], 1));
                    assess.searchOperation(testQuantity[i], -30, 31);
                    Console.WriteLine("Search operation:");
                    Console.WriteLine(" - S assess: " + assess.sAssessmentCalculation(testQuantity[i], 2));
                    Console.WriteLine(" - R assess: " + assess.rAssessmentCalculation(testQuantity[i], 2));
                }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
            else if (symbol.Equals('n'))
            {
                int length = 10; 
                int[] Array = new int[0];
                List<int> list = new List<int>();
                Random rnd = new Random();

                for (int i = 0; i < length; i++)
                {
                    Array = Operations.addToArray(Array, rnd.Next(1, 10));
                    list.Insert(i, rnd.Next(1, 10));
                }

                Console.WriteLine("Array:\n" + Operations.searchInArray(Array, 7));
                Console.WriteLine();

                for (int i = 0; i < Array.Length; i++)
                {
                    Console.Write(Array[i]);
                }

                Console.WriteLine();
                

                for (int i = 0; i < Array.Length; i++)
                {
                    Console.Write(Array[i]);
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("List:\n" + Operations.searchInList(list, 7));
                Console.WriteLine();

                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i]);
                }

                Console.WriteLine();
                list = Operations.Remove(list, 7);

                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i]);
                }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}