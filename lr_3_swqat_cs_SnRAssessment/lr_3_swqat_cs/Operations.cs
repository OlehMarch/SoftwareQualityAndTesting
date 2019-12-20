using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr_3_swqat_cs
{
    static class Operations
    {
        public static int searchInList(List<int> list, int value)
        {
            int capacity = list.Count;
            int counter = 0;
            for (int i = 0; i < capacity; i++)
            {
                if (list[i] == value)
                {
                    ++counter;
                }
            }
            return counter;
        }
        //--------------------------------------------------------------------------------------//
        public static List<int> Remove(List<int> list, int item)
        {
            while (true)
            {
                int index = list.IndexOf(item);
                if (index >= 0)
                {
                    list.RemoveAt(index);
                }
                else
                {
                    break;
                }
            }

            return list;
        }
        //--------------------------------------------------------------------------------------//
        public static int[] addToArray(int[] Array, int value, bool first = true)
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
        //--------------------------------------------------------------------------------------//
        public static int searchInArray(int[] Array, int value)
        {
            int length = Array.Length;
            int counter = 0;
            for (int i = 0; i < length; i++)
            {
                if (Array[i] == value)
                {
                    ++counter;
                }
            }
            return counter;
        }
        //--------------------------------------------------------------------------------------//
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
    }
}

/*
        public void Insert(int index, T item) {
            // Note that insertions at the end are legal.
            if ((uint) index > (uint)_size) {
                ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_ListInsert);
            }
            Contract.EndContractBlock();
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size) {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;            
            _version++;
        }

        public void RemoveAt(int index) {
            if ((uint)index >= (uint)_size) {
                ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            Contract.EndContractBlock();
            _size--;
            if (index < _size) {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T);
            _version++;
        }
*/
