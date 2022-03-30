using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_220
    {
        //Calculated Rate Of Climb/Descent
        double rate;

        public I062_220(int b, int b1)
        {

            string rate1= Convert.ToString(b, 2);
            string rate2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            rate1 = bf.padding(rate1);
            rate2 = bf.padding(rate2);

            string rate_str = rate1 + rate2;
            if (rate_str[0].ToString().Equals("1"))
            {
                rate_str = bf.complement2(rate_str);
                this.rate = Convert.ToDouble(Convert.ToInt32(rate_str, 2)) * -6.25;
            }
            else
            {
                this.rate = Convert.ToDouble(Convert.ToInt32(rate_str, 2)) * 6.25;
            }

        }

        public double getRate()
        {
            return this.rate;
        }
    }
}
