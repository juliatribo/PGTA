using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class Basic_functions
    {
        public Basic_functions()
        {

        }

        public string padding(string str)
        {
            while (str.Length < 8)
            {
                str = "0" + str; //padding
            }
            return str;
        }
        public string complement2(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString().Equals("0"))
                {
                    StringBuilder sb = new StringBuilder(str);
                    sb[i] = '1';
                    str = sb.ToString();
                }
                else
                {
                    StringBuilder sb = new StringBuilder(str);
                    sb[i] = '0';
                    str = sb.ToString();

                }
            }
            bool end = false;
            for (int i = str.Length - 1; i >= 0 && !end; i--)
            {
                if (str[i].ToString().Equals("1"))
                {
                    StringBuilder sb = new StringBuilder(str);
                    sb[i] = '0';
                    str = sb.ToString();
                }
                else
                {
                    StringBuilder sb = new StringBuilder(str);
                    sb[i] = '1';
                    str = sb.ToString();
                    end = true;
                }
            }
            return str;
        }

        public string hexadecimal(string str)
        {
            string val = "";

            if (str.Equals("010000"))
            {
                val = "P";
            }
            else if (str.Equals("110000"))
            {
                val = "0";
            }
            else if (str.Equals("000001"))
            {
                val = "A";
            }
            else if (str.Equals("010001"))
            {
                val = "Q";
            }
            else if (str.Equals("110001"))
            {
                val = "1";
            }
            else if (str.Equals("000010"))
            {
                val = "B";
            }
            else if (str.Equals("010010"))
            {
                val = "R";
            }
            else if (str.Equals("110010"))
            {
                val = "2";
            }
            else if (str.Equals("000011"))
            {
                val = "C";
            }
            else if (str.Equals("010011"))
            {
                val = "S";
            }
            else if (str.Equals("110011"))
            {
                val = "3";
            }
            else if (str.Equals("000100"))
            {
                val = "D";
            }
            else if (str.Equals("010100"))
            {
                val = "T";
            }
            else if (str.Equals("110100"))
            {
                val = "4";
            }
            else if (str.Equals("000101"))
            {
                val = "E";
            }
            else if (str.Equals("010101"))
            {
                val = "U";
            }
            else if (str.Equals("110101"))
            {
                val = "5";
            }
            else if (str.Equals("000110"))
            {
                val = "F";
            }
            else if (str.Equals("010110"))
            {
                val = "V";
            }
            else if (str.Equals("110110"))
            {
                val = "6";
            }
            else if (str.Equals("000111"))
            {
                val = "G";
            }
            else if (str.Equals("010111"))
            {
                val = "W";
            }
            else if (str.Equals("110111"))
            {
                val = "7";
            }
            else if (str.Equals("001000"))
            {
                val = "H";
            }
            else if (str.Equals("011000"))
            {
                val = "X";
            }
            else if (str.Equals("111000"))
            {
                val = "8";
            }
            else if (str.Equals("001001"))
            {
                val = "I";
            }
            else if (str.Equals("011001"))
            {
                val = "Y";
            }
            else if (str.Equals("111001"))
            {
                val = "9";
            }
            else if (str.Equals("001010"))
            {
                val = "J";
            }
            else if (str.Equals("011010"))
            {
                val = "Z";
            }
            else if (str.Equals("001011"))
            {
                val = "K";
            }
            else if (str.Equals("001100"))
            {
                val = "L";
            }
            else if (str.Equals("001101"))
            {
                val = "M";
            }
            else if (str.Equals("001110"))
            {
                val = "N";
            }
            else if (str.Equals("001111"))
            {
                val = "O";
            }
            return val;
        }
    }
}
