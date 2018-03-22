using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Linq;

namespace C_Sharp_Examination
{
    /// The DataObject class stored with a key
    public class DataObject
    {
        private string m_Key;
        private int m_Value;

        public DataObject(string strKey)
        {
            this.m_Key = strKey;
        }

        public string Key
        {
            get { return m_Key; }
            set { this.m_Key = value; }
        }

        public int Value
        {
            get { return m_Value; }
            set { this.m_Value = value; }
        }

        public int Decrease(int intValue)
        {
            this.m_Value -= intValue;
            return this.m_Value;
        }

        public int Increase(int intValue)
        {
            this.m_Value += intValue;
            return this.m_Value;
        }
    }

    class Program
    {
        static Hashtable Data = new Hashtable();
        static string[] StaticData = new string[] { "X-Ray","Echo","Alpha", "Yankee","Bravo", "Charlie",
            "Delta",    "Hotel", "India", "Juliet", "Foxtrot","Sierra",
            "Mike","Kilo", "Lima",  "November", "Oscar", "Papa", "Qubec",
            "Romeo",  "Tango","Golf", "Uniform", "Victor", "Whisky",
             "Zulu"};

        static void Main(string[] args)
        {
            for (int i = 0; i < StaticData.Length; i++)
                Data.Add(StaticData[i].ToLower(), new DataObject(StaticData[i]));
            while (true)
            {
                PrintSortedData();
                Console.WriteLine();
                Console.Write("> ");
                string str = Console.ReadLine();
                string[] strs = str.Split(' ');

                if (strs[0] == "q")
                    break;
                else if (strs[0] == "printv")
                    PrintSortedDataByValue();
                else if (strs[0] == "print")
                    PrintSortedData();
                else if (strs[0] == "inc")
                    Increase(strs[1]);
                else if (strs[0] == "dec")
                    Decrease(strs[1]);
                else if (strs[0] == "swap")
                    Swap(strs[1], strs[2]);
                else if (strs[0] == "ref")
                    Ref(strs[1], strs[2]);
                else if (strs[0] == "unref")
                    UnRef(strs[1]);
            }
        }

        /// <summary>
        /// Create a reference from one data object to another.
        /// </summary>
        /// <param name="key1">The object to create the reference on</param>
        /// <param name="key2">The reference object</param>
        static void Ref(string key1, string key2)
        {
            try
            {
                if (CheckKeyIsExist(key1) == false) { return; }
                if (CheckKeyIsExist(key2) == false) { return; }

                if (key1 == key2)
                {
                    Console.WriteLine("No Reference Becuase The Keys Are Same");
                    return;
                }

                Data[key1.ToLower()] = Data[key2.ToLower()];
                Console.WriteLine(key1.FormatOnlyFirstCharToUpper() + " Reference  <" + key2.FormatOnlyFirstCharToUpper() + ">");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Removes an object reference on the object specified.
        /// </summary>
        /// <param name="key">The object to remove the reference from</param>
        static void UnRef(string key)
        {
            try
            {
                if (CheckKeyIsExist(key) == false) { return; }

                string _strRefernceKey = ((DataObject)Data[key.ToLower()]).Key;

                if (_strRefernceKey != key.FormatOnlyFirstCharToUpper())
                {
                    Data[key.ToLower()] = new DataObject(key.FormatOnlyFirstCharToUpper());
                    Console.WriteLine(key.FormatOnlyFirstCharToUpper() + " Remove Reference  <" + _strRefernceKey + ">");
                }

                Console.WriteLine(key.FormatOnlyFirstCharToUpper() + " Reference Ifself");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        /// <summary>
        /// Swap the data objects stored in the keys specified
        /// </summary>
        static void Swap(string key1, string key2)
        {
            try
            {
                if (CheckKeyIsExist(key1) == false) { return; }
                if (CheckKeyIsExist(key2) == false) { return; }

                if (key1 == key2)
                {
                    Console.WriteLine("No Swap Becuase The Keys Are Same");
                    return;
                }

                DataObject _obj = (DataObject)Data[key1.ToLower()];
                Data[key1.ToLower()] = Data[key2.ToLower()];
                Data[key2.ToLower()] = _obj;

                Console.WriteLine(key1.FormatOnlyFirstCharToUpper() + " And " + key2.FormatOnlyFirstCharToUpper() + " Swap");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Decrease the Value field by 1 of the 
        /// data object stored with the key specified
        /// </summary>
        static void Decrease(string key)
        {
            try
            {
                if (CheckKeyIsExist(key) == false) { return; }

                Console.WriteLine(key.FormatOnlyFirstCharToUpper() + " Decrease 1 Into " + ((DataObject)Data[key.ToLower()]).Decrease(1));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Increase the Value field by 1 of the 
        /// data object stored with the key specified
        /// </summary>
        static void Increase(string key)
        {
            try
            {
                if (CheckKeyIsExist(key) == false) { return; }

                Console.WriteLine(key.FormatOnlyFirstCharToUpper() + " Increase 1 Into " + ((DataObject)Data[key.ToLower()]).Increase(1));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        /// <summary>
        /// Prints the information in the Data hashtable to the console.
        /// Output should be sorted by key 
        /// References should be printed between '<' and '>'
        /// The output should look like the following : 
        /// 
        /// 
        /// Alpha...... -3
        /// Bravo...... 2
        /// Charlie.... <Zulu>
        /// Delta...... 1
        /// Echo....... <Alpha>
        /// --etc---
        /// 
        /// </summary>
        static void PrintSortedData()
        {
            try
            {
                List<string> _strKeyList = new List<string>();
                foreach (var k in Data.Keys)
                {
                    _strKeyList.Add(k.ToString());
                }
                _strKeyList.Sort();

                foreach (string _strKey in _strKeyList)
                {
                    PrintDataValue(_strKey);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /// <summary>
        /// Prints the information in the Data hashtable to the console.
        /// Output should be sorted by stored value
        /// References should be printed between '<' and '>'
        /// Sorting order start from max to min, larger value takes priority.
        /// The output should look like the following : 
        /// 
        /// 
        /// Bravo...... 100
        /// Echo...... 99
        /// Zulu...... 98
        /// Charlie.... <Zulu>
        /// Delta...... 34
        /// Echo....... 33
        /// Alpha...... <Echo>
        /// --etc---
        /// 
        /// </summary>
        static void PrintSortedDataByValue()
        {
            try
            {
                ArrayList _aryKeyList = new ArrayList();
                _aryKeyList.AddRange(Data.Keys);

                for (int i = _aryKeyList.Count - 1; i > 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (((DataObject)Data[_aryKeyList[j + 1]]).Value > ((DataObject)Data[_aryKeyList[j]]).Value)
                        {
                            string _strSmallKey = _aryKeyList[j].ToString();
                            _aryKeyList[j] = _aryKeyList[j + 1];
                            _aryKeyList[j + 1] = _strSmallKey;
                        }
                    }

                }

                foreach (string _strKey in _aryKeyList)
                {
                    PrintDataValue(_strKey);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static bool CheckKeyIsExist(string key)
        {
            try
            {
                if (Data.ContainsKey(key.ToLower()) == false)
                {
                    Console.WriteLine("Key " + "'" + key + "' is Not Exist");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        static void PrintDataValue(string key)
        {
            try
            {
                if (CheckKeyIsExist(key) == false) { return; }

                DataObject _obj = (DataObject)Data[key];

                if (key.FormatOnlyFirstCharToUpper() == _obj.Key)
                {
                    Console.WriteLine(key.FormatOnlyFirstCharToUpper() + " " + _obj.Value);
                }
                else
                {
                    Console.WriteLine(key.FormatOnlyFirstCharToUpper() + " <" + _obj.Key + ">");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public static class StringExtension
    {
        public static string FormatOnlyFirstCharToUpper(this string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput))
            {
                return strInput;
            }

            if (strInput.Contains("-") == true)
            {
                string _strResult = string.Empty;

                bool _bolNextIsUpper = true;

                for (int i = 0; i < strInput.Length; i++)
                {
                    if (_bolNextIsUpper == true)
                    {
                        _strResult += strInput[i].ToString().ToUpper();
                        _bolNextIsUpper = false;
                    }
                    else
                    {
                        if (strInput[i].ToString() == "-")
                        {
                            _strResult += "-";
                            _bolNextIsUpper = true;
                        }
                        else
                        {
                            _strResult += strInput[i].ToString().ToLower();
                        }
                    }
                }
                return _strResult;
            }
            else
            {
                return strInput.Substring(0, 1).ToUpper() + (strInput.Length > 1 ? strInput.Substring(1).ToLower() : string.Empty);
            }

        }
    }
}