using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_120
    {
        int code_mode2A;
        public I062_120(int b, int b1)
        {

            string track1 = Convert.ToString(b, 2);
            string track2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            track1 = bf.padding(track1);
            track2 = bf.padding(track2);

            string track3A = track1 + track2;

            string subtrack_A = track3A.Substring(4, 3);
            int bin_subtrack_A = Convert.ToInt32(subtrack_A, 2);
            string octal_mode_str_A = Convert.ToString(bin_subtrack_A, 8);

            string subtrack_B = track3A.Substring(7, 3);
            int bin_subtrack_B = Convert.ToInt32(subtrack_B, 2);
            string octal_mode_str_B = Convert.ToString(bin_subtrack_B, 8);

            string subtrack3A_C = track3A.Substring(10, 3);
            int bin_subtrack_C = Convert.ToInt32(subtrack3A_C, 2);
            string octal_mode_str_C = Convert.ToString(bin_subtrack_C, 8);

            string subtrack_D = track3A.Substring(13, 3);
            int bin_subtrack_D = Convert.ToInt32(subtrack_D, 2);
            string octal_mode_str_D = Convert.ToString(bin_subtrack_D, 8);

            string octal_mode3A_str = octal_mode_str_A + octal_mode_str_B + octal_mode_str_C + octal_mode_str_D;
            this.code_mode2A = Convert.ToInt32(octal_mode3A_str);
        }

        public int getOctal2A()
        {
            return this.code_mode2A;
        }

    }
}
    
