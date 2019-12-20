using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lr_3_swqat_cs
{
    class SnRAssessment
    {
        public SnRAssessment()
        {
            Array = new int[0];
            list = new List<int>();
            rnd = new Random();
            timer = new Stopwatch();
            timer.Reset();
            operationQuantity = 3;
            sAssessmentArray = new double[operationQuantity];
            rAssessmentArray = new double[operationQuantity];
        }

        public SnRAssessment(int length, int opQuantity = 3, int lowerInclusiveLimit = 1, int upperExclusiveLimit = 10)
        {
            Array = new int[length];
            list = new List<int>();
            rnd = new Random();

            for (int i = 0; i < length; ++i)
            {
                int value = rnd.Next(lowerInclusiveLimit, upperExclusiveLimit);
                Array[i] = value;
                list.Add(value);
            }

            timer = new Stopwatch();
            timer.Reset();
            operationQuantity = opQuantity;
            sAssessmentArray = new double[operationQuantity];
            rAssessmentArray = new double[operationQuantity];
        }

        int[] Array;
        List<int> list;
        Random rnd;
        Stopwatch timer;
        double[,] TimerArray;
        int operationQuantity;
        bool trigger = false;

        public double[] sAssessmentArray;
        public double[] rAssessmentArray;

    //---------------------------------------------------------------------------------------------------------------//
        public void addOperation(int testQuantity = 100, int lowerInclusiveLimit = 1, int upperExclusiveLimit = 10, int operationNumber = 0)
        {
            initArrayOfTimers(testQuantity);
            for (int i = 0 + (operationNumber * testQuantity); i < testQuantity + (operationNumber * testQuantity); ++i)
            {
                int value = rnd.Next(lowerInclusiveLimit, upperExclusiveLimit);

                timer.Reset();
                timer.Start();
                Array = Operations.addToArray(Array, value);
                timer.Stop();
                TimerArray[0, i] = Convert.ToDouble(timer.Elapsed.TotalMilliseconds);

                timer.Reset();
                timer.Start();
                list.Insert(i, value);
                timer.Stop();
                TimerArray[1, i] = Convert.ToDouble(timer.Elapsed.TotalMilliseconds);
            }
        }

        public void deleteOperation(int testQuantity = 100, int lowerInclusiveLimit = 1, int upperExclusiveLimit = 10, int operationNumber = 1)
        {
            initArrayOfTimers(testQuantity);
            for (int i = 0 + (operationNumber * testQuantity); i < testQuantity + (operationNumber * testQuantity); ++i)
            {
                int value = rnd.Next(lowerInclusiveLimit, upperExclusiveLimit);

                timer.Reset();
                timer.Start();
                Array = Operations.deleteFromArray(Array, value);
                timer.Stop();
                TimerArray[0, i] = Convert.ToDouble(timer.Elapsed.TotalMilliseconds);

                timer.Reset();
                timer.Start();
                list = Operations.Remove(list, value);
                timer.Stop();
                TimerArray[1, i] = Convert.ToDouble(timer.Elapsed.TotalMilliseconds);
            }
        }

        public void searchOperation(int testQuantity = 100, int lowerInclusiveLimit = 1, int upperExclusiveLimit = 10, int operationNumber = 2)
        {
            initArrayOfTimers(testQuantity);
            for (int i = 0 + (operationNumber * testQuantity); i < testQuantity + (operationNumber * testQuantity); ++i)
            {
                int value = rnd.Next(lowerInclusiveLimit, upperExclusiveLimit);

                timer.Reset();
                timer.Start();
                Operations.searchInArray(Array, value);
                timer.Stop();
                TimerArray[0, i] = Convert.ToDouble(timer.Elapsed.TotalMilliseconds);

                timer.Reset();
                timer.Start();
                Operations.searchInList(list, value);
                timer.Stop();
                TimerArray[1, i] = Convert.ToDouble(timer.Elapsed.TotalMilliseconds);
            }
        }
    //---------------------------------------------------------------------------------------------------------------//
        void initArrayOfTimers(int testQuantity)
        {
            if (trigger == false)
            {
                TimerArray = new double[2, testQuantity * operationQuantity];
                trigger = true;
            }
        }
    //---------------------------------------------------------------------------------------------------------------//
        public double sAssessmentCalculation(int testQuantity, int operationNumber = 0)
        {
            double sAssessment = 0;
            double sum = 0;
            for (int i = 0 + (operationNumber * testQuantity); i < testQuantity + (operationNumber * testQuantity); ++i)
            {
                if ((TimerArray[0, i] == 0.0) && ((TimerArray[1, i] == 0.0))) continue;
                sum += (TimerArray[0, i] - TimerArray[1, i]) / Math.Max(TimerArray[0, i], TimerArray[1, i]);
            }
            sAssessment = sum / testQuantity * 100;
            return sAssessment;
        }

        public double rAssessmentCalculation(int testQuantity, int operationNumber = 0)
        {
            double rAssessment = 0;
            double sum = 0;
            for (int i = 0 + (operationNumber * testQuantity); i < testQuantity + (operationNumber * testQuantity); ++i)
            {
                if (Math.Sign(TimerArray[0, i] - TimerArray[1, i]) == 1)
                {
                    sum += 1;
                }
                else
                {
                    sum += 0;
                }
            }
            rAssessment = sum / testQuantity * 100;
            return rAssessment;
        }
    //---------------------------------------------------------------------------------------------------------------//
    }
}
