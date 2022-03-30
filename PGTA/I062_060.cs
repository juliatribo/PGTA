using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_060
    {
        bool prueba;
        bool validated;
        bool garbled_code;
        bool change_in_3A;
        int octal_mode3A;
        public I062_060(int b, int b1)
        {

            string track3A_1 = Convert.ToString(b, 2);
            string track3A_2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            track3A_1 = bf.padding(track3A_1);
            track3A_2 = bf.padding(track3A_2);

            string track3A = track3A_1 + track3A_2;
            if (track3A[0].ToString().Equals("0"))
            {
                this.validated = false;
            }
            else
            {
                this.validated = true;

            }
            if (track3A[1].ToString().Equals("0"))
            {
                this.garbled_code = false;
            }
            else
            {
                this.garbled_code = true;

            }
            if (track3A[2].ToString().Equals("0"))
            {
                this.change_in_3A = false;
            }
            else
            {
                this.change_in_3A = true;

            }
            string subtrack3A_A = track3A.Substring(4, 3);
            int bin_subtrack3A_A = Convert.ToInt32(subtrack3A_A, 2);
            string octal_mode3A_str_A = Convert.ToString(bin_subtrack3A_A, 8);

            string subtrack3A_B = track3A.Substring(7, 3);
            int bin_subtrack3A_B = Convert.ToInt32(subtrack3A_B, 2);
            string octal_mode3A_str_B = Convert.ToString(bin_subtrack3A_B, 8);

            string subtrack3A_C = track3A.Substring(10, 3);
            int bin_subtrack3A_C = Convert.ToInt32(subtrack3A_C, 2);
            string octal_mode3A_str_C = Convert.ToString(bin_subtrack3A_C, 8);

            string subtrack3A_D = track3A.Substring(13, 3);
            int bin_subtrack3A_D = Convert.ToInt32(subtrack3A_D, 2);
            string octal_mode3A_str_D = Convert.ToString(bin_subtrack3A_D, 8);

            string octal_mode3A_str = octal_mode3A_str_A + octal_mode3A_str_B + octal_mode3A_str_C + octal_mode3A_str_D;
            this.octal_mode3A = Convert.ToInt32(octal_mode3A_str);
        }

        public bool isValidated()
        {
            return this.validated;
        }
        public bool isGarbled()
        {
            return this.garbled_code;
        }
        public bool isChange3A()
        {
            return this.change_in_3A;
        }
        public int getOctal3A()
        {
            return this.octal_mode3A;
        }

    }
}
