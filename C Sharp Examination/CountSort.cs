using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examination
{
    //Suppose you have an array of 1000 integers. The integers are in random order, but you know each of the integers is between 1 and 5000 (inclusive). 
    //In addition, each number appears only once in the array. Assume that you can access each element of the array only once. Describe an algorithm to sort it. 

    public class CountSort
    {
        public int[] SortArray(int[] aryInput)
        {
            int[] _intResultArray = new int[1000];
            bool[] _intBoolCheckArray = new bool[5000];

            foreach (int _intInput in aryInput)
            {
                _intBoolCheckArray[_intInput] = true;
            }

            int _intResultIndex = 0;
            for (int i = 0; i < 5000; i++)
            {
                if (_intBoolCheckArray[i] == true)
                {
                    _intResultArray[_intResultIndex] = i;
                    _intResultIndex++;
                }
            }

            return _intResultArray;
        }
    }
}