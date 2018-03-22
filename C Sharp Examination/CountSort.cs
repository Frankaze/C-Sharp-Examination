using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examination
{
    public class CountSort
    {
        public int[] SortArray(int[] aryInput)
        {
            int[] _intResultArray = new int[5];
            bool[] _intBoolCheckArray = new bool[100];

            foreach (int _intInput in aryInput)
            {
                _intBoolCheckArray[_intInput] = true;
            }

            int _intResultIndex = 0;
            for (int i = 0; i < 100; i++)
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