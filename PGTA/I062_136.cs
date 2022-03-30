using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_136
    {
        //Measured Flight Level
        double fl;

        public I062_136(int b, int b1)
        {

            string fl1 = Convert.ToString(b, 2);
            string fl2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            fl1 = bf.padding(fl1);
            fl2 = bf.padding(fl2);

            string fl_str = fl1 + fl2;
            if (fl_str[0].ToString().Equals("1"))
            {
                fl_str = bf.complement2(fl_str);
                this.fl = Convert.ToDouble(Convert.ToInt32(fl_str, 2)) * -0.25;
            }
            else
            {
                this.fl = Convert.ToDouble(Convert.ToInt32(fl_str, 2)) * 0.25;
            }
            
        }

        public double getFl()
        {
            return this.fl;
        }

    }
}
