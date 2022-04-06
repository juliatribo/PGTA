using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_110_EM1
    {
        int code_mode1;
        public I062_110_EM1(int b, int b1)
        {

            string code1 = Convert.ToString(b, 2);
            string code2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            code1 = bf.padding(code1);
            code2 = bf.padding(code2);

            string codeM1 = code1 + code2;

            string subcode_A = codeM1.Substring(4, 3);
            int bin_subcode_A = Convert.ToInt32(subcode_A, 2);
            string octal_str_A = Convert.ToString(bin_subcode_A, 8);

            string subcode_B = codeM1.Substring(7, 3);
            int bin_subcode_B = Convert.ToInt32(subcode_B, 2);
            string octal_str_B = Convert.ToString(bin_subcode_B, 8);

            string subcode_C = codeM1.Substring(10, 3);
            int bin_subcode_C = Convert.ToInt32(subcode_C, 2);
            string octal_str_C = Convert.ToString(bin_subcode_C, 8);

            string subcode_D = codeM1.Substring(13, 3);
            int bin_subcode_D = Convert.ToInt32(subcode_D, 2);
            string octal_str_D = Convert.ToString(bin_subcode_D, 8);

            string octal_str = octal_str_A + octal_str_B + octal_str_C + octal_str_D;
            this.code_mode1 = Convert.ToInt32(octal_str);

        }
        public int getCodeM1()
        {
            return this.code_mode1;
        }
    }
}
