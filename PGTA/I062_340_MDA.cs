using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_340_MDA
    {
        int code_mode3A;
        string v_mda;
        string g_mda;
        string l_mda;
        public I062_340_MDA(int b, int b1)
        {

            string oct1 = Convert.ToString(b, 2);
            string oct2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);
            oct2 = bf.padding(oct2);

            string oct_str = oct1 + oct2;

            char v = oct_str[0];
            if (v.Equals('0'))
            {
                this.v_mda = "Code validated"; //Code validated
            }
            else
            {
                this.v_mda = "Code no validated"; //Code no validated
            }
            char g = oct_str[1];
            if (g.Equals('0'))
            {
                this.g_mda = "Default"; //Default
            }
            else
            {
                this.g_mda = "Garbled code"; //Garbled code
            }
            char l = oct_str[2];
            if (l.Equals('0'))
            {
                this.l_mda = "Mode 3A code as derived from the reply of the transponder"; 
            }
            else
            {
                this.l_mda = "Smoothed Mode 3/A code as provided by a sensor local tracker"; 
            }

            string sub_A = oct_str.Substring(4, 3);
            int bin_sub_A = Convert.ToInt32(sub_A, 2);
            string octal_mode_str_A = Convert.ToString(bin_sub_A, 8);

            string sub_B = oct_str.Substring(7, 3);
            int bin_sub_B = Convert.ToInt32(sub_B, 2);
            string octal_mode_str_B = Convert.ToString(bin_sub_B, 8);

            string sub_C = oct_str.Substring(10, 3);
            int bin_sub_C = Convert.ToInt32(sub_C, 2);
            string octal_mode_str_C = Convert.ToString(bin_sub_C, 8);

            string sub_D = oct_str.Substring(13, 3);
            int bin_sub_D = Convert.ToInt32(sub_D, 2);
            string octal_mode_str_D = Convert.ToString(bin_sub_D, 8);

            string octal_mode3A_str = octal_mode_str_A + octal_mode_str_B + octal_mode_str_C + octal_mode_str_D;
            this.code_mode3A = Convert.ToInt32(octal_mode3A_str);
        }

        public int getOctal3A()
        {
            return this.code_mode3A;
        }
        public string getV()
        {
            return this.v_mda;
        }
        public string getG()
        {
            return this.g_mda;
        }
        public string getL()
        {
            return this.l_mda;
        }
    }
}
