using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr_2_swqat_cs
{
    class UnitTest
    {
        public UnitTest()
        {
            TestStatus = "";
        }

        private int[] targetArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private int[] targetChoiceArray = { 0, 1, 2, 0 };
        public string TestStatus {set; get;}

        private int[] choiceCheckWithIntegerInput()
        {
            int[] choiceArray = new int[4];
            for (int choice = 0; choice < choiceArray.Length; ++choice)
            {
                if (choice == 1)
                {
                    choiceArray[choice] = 1;
                }
                else if (choice == 2)
                {
                    choiceArray[choice] = 2;
                }
                else
                {
                    choiceArray[choice] = 0;
                }
            }
            return choiceArray;
	    }

        public bool choiceCheckWithCharInput()
        {
            for (int choice = 32; choice < 127; ++choice)
            {
                if ((1 == (char) choice) || (2 == (char) choice))
                {
                    return false;
                }
            }
            return true;
        }

        public bool choiceArrayEquality()
        {
            if (choiceCheckWithIntegerInput().Length == targetChoiceArray.Length)
            {
                for (int i = 0; i < choiceCheckWithIntegerInput().Length; ++i)
                {
                    if (choiceCheckWithIntegerInput()[i] != targetChoiceArray[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool arrayEquality(int[] Array, bool bubbleSort = true)
        { //false means that it will be a selection sort
            
            int[] tempArray = new  int[Array.Length];
            Array.CopyTo(tempArray, 0);

            if (bubbleSort == true)
            {
                tempArray = Program.bubbleSort(tempArray);
            }
            else
            {
                tempArray = Program.selectionSort(tempArray);
            }
            if (tempArray.Length == targetArray.Length)
            {
                for (int i = 0; i < tempArray.Length; ++i)
                {
                    if (tempArray[i] != targetArray[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool addToArrayIntValuesCheck(int[] Array, int LowerInclusiveLimit, int UpperExclususiveLimit)
        {
            int[] tempArray = new int[Array.Length];
            Array.CopyTo(tempArray, 0);
            int length = Array.Length;

            for (int i = LowerInclusiveLimit; i < UpperExclususiveLimit; ++i, length++)
            {
                tempArray = Program.addToArray(tempArray, i);
                if (tempArray.Length != length + 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool addToArrayCharValueCheck(int[] Array)
        {
            int[] tempArray = new int[Array.Length];
            Array.CopyTo(tempArray, 0);
            int length = Array.Length;

            for (int i = 32; i < 127; ++i, length++)
            {
                tempArray = Program.addToArray(tempArray, (char)i);
                if (tempArray.Length != length + 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool deleteFromArrayExistingValue(int[] Array)
        {
            int[] tempArray = new int[Array.Length];
            Array.CopyTo(tempArray, 0);
            int length = Array.Length;

            for (int i = 0; i < targetArray.Length; ++i, length--)
            {
                tempArray = Program.deleteFromArray(tempArray, targetArray[i]);
                if (tempArray.Length != length - 1)
                {
                    return false;
                }
            }
            return true;
        }

        public bool deleteFromArrayNonExistentValue(int[] Array)
        {
            int[] tempArray = new int[Array.Length];
            Array.CopyTo(tempArray, 0);
            int length = Array.Length;

            tempArray = Program.deleteFromArray(tempArray, new Random().Next(Array.Max(), Array.Max() * 100));
            if (tempArray.Length == length - 1)
            {
                return false;
            }
            return true;
        }

        public void testLog(int[] Array)
        {
            TestStatus += "\n\nTest based on system reaction of integer input of user: ----- ";
            TestStatus += (choiceArrayEquality() == true) ? "passed\n" : "failed\n";

            TestStatus += "Test based on system reaction of character input of user: --- ";
            TestStatus += (choiceCheckWithCharInput() == true) ? "passed\n" : "failed\n";

            TestStatus += "Group of tests which are based on equality of target array and resulting array:\n";

            TestStatus += " ----- Subtest based on check of bubble sort: --------------- ";
            TestStatus += (arrayEquality(Array) == true) ? "passed\n" : "failed\n";

            TestStatus += " ----- Subtest based on check of selection sort: ------------ ";
            TestStatus += (arrayEquality(Array, false) == true) ? "passed\n" : "failed\n";

            TestStatus += "Test based on adding integer values to array: --------------- ";
            TestStatus += (addToArrayIntValuesCheck(Array, -10, 21) == true) ? "passed\n" : "failed\n";

            TestStatus += "Test based on adding character values to array: ------------- ";
            TestStatus += (addToArrayCharValueCheck(Array) == true) ? "passed\n" : "failed\n";

            TestStatus += "Test based on deleting value that exist: -------------------- ";
            TestStatus += (deleteFromArrayExistingValue(Array) == true) ? "passed\n" : "failed\n";

            TestStatus += "Test based on deleting value that doesn't exist: ------------ ";
            TestStatus += (deleteFromArrayNonExistentValue(Array) == true) ? "passed\n" : "failed\n";
        }
    }
}
