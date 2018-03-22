using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examination
{
    public class Multiple8
    {
        public int Multiply(int intMultiplicand)
        {
            string _strAbsResult = Convert.ToString(Math.Abs(intMultiplicand << 3), 2);

            if (intMultiplicand >= 0)
            {
                return Convert.ToInt32(_strAbsResult, 2);
            }
            else
            {
                return Convert.ToInt32(this.ReverseBinaryForNegative(_strAbsResult), 2);
            }
        }

        //轉補數
        public string ReverseBinaryForNegative(string strBinary)
        {
            List<char> _charBinaryList = strBinary.ToList();
            string _strReverse = string.Empty;

            foreach (char _char in _charBinaryList)
            {
                _strReverse += _char == '1' ? "0" : "1";
            }
            _strReverse = _strReverse.PadLeft(31, '1');

            string _strResult = "";
            bool _bolModity = false;

            for (int i = _strReverse.Length - 1; i >= 0; i--)
            {
                if (_bolModity == true)
                {
                    _strResult = _strReverse.Substring(i, 1) + _strResult;
                }
                else
                {
                    if (_strReverse.Substring(i, 1) == "0")
                    {
                        _strResult = "1" + _strResult;
                        _bolModity = true;
                    }
                    else
                    {
                        _strResult = "0" + _strResult;
                    }
                }
            }
            return "1" + _strResult;
        }
    }
}