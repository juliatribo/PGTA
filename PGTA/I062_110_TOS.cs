using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_110_TOS
    {
        double TOS;
        public I062_110_TOS(int b)
        {

            string oct1 = Convert.ToString(b, 2);


            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);

            if (oct1[0].ToString().Equals('1'))
            {
                oct1 = bf.complement2(oct1);
                this.TOS = Convert.ToDouble(Convert.ToInt32(oct1, 2)) * (1 / 128);
            }
            else
            {
                this.TOS = Convert.ToDouble(Convert.ToInt32(oct1, 2)) * (1 / 128);
            }

        }
        public double getTOS()
        {
            return this.TOS;
        }
    }
}