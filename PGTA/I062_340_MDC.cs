using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_340_MDC
    {
        string v;
        string g;
        double code_modeC;
        public I062_340_MDC(int b, int b1)
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
                this.v = "Code Validated"; //Code validated
            }
            else
            {
                this.v = "Code no validated"; //Code no validated
            }
            char g = oct_str[1];
            if (g.Equals('0'))
            {
                this.g = "Default"; //Default
            }
            else
            {
                this.g = "Garbled code"; //Garbled code
            }

            string code = oct_str.Substring(2, 14);
            this.code_modeC = Convert.ToDouble(Convert.ToInt32(code, 2)) * (0.25);

        }
        public double getCodeModeC()
        {
            return this.code_modeC;
        }
        public string getV()
        {
            return this.v;
        }
        public string getG()
        {
            return this.g;
        }

    }
}
