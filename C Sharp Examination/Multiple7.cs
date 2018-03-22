using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Examination
{
    public class Multiple7
    {
        public int Multiply(int intMultiplicand)
        {
            if (intMultiplicand == 0) { return 0; }

            string strAbsMultiplicand = Convert.ToString(Math.Abs(intMultiplicand), 2);

            // (X << 3) - X
            string _strAbsResult = this.Minus(Convert.ToString(Math.Abs(intMultiplicand << 3), 2) , strAbsMultiplicand);

            if (intMultiplicand >= 0)
            {
                return Convert.ToInt32(_strAbsResult, 2);
            }
            else
            {
                return 0 - Convert.ToInt32(_strAbsResult, 2);
            }
        }

        //二進位相減
        public string Minus(string strBinary, string strMultiplicand)
        {
            string _strResult = string.Empty;

            List<char> _charBinaryList = strBinary.ToList();
            List<char> _charMultiplicandList = strMultiplicand.ToList();

            for (int i = 0; i <= _charMultiplicandList.Count() - 1; i++)
            {
                if (strMultiplicand[_charMultiplicandList.Count() - 1 - i] == '1')
                {
                    if (_charBinaryList[_charBinaryList.Count() - 1 - i] == '1')
                    {
                        _charBinaryList[_charBinaryList.Count() - 1 - i] = '0';
                    }
                    else
                    {
                        _charBinaryList[_charBinaryList.Count() - 1 - i] = '1';

                        for (int k = i + 1; k < _charBinaryList.Count(); k++)
                        {
                            if (_charBinaryList[_charBinaryList.Count() - 1 - k] == '1')
                            {
                                _charBinaryList[_charBinaryList.Count() - 1 - k] = '0';
                                break;
                            }
                            else
                            {
                                _charBinaryList[_charBinaryList.Count() - 1 - k] = '1';
                            }
                        }
                    }
                }
            }

            foreach (char _char in _charBinaryList)
            {
                _strResult += _char == '1' ? "1" : "0";
            }

            return _strResult;
        }

        //負值轉補數
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
