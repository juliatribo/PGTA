using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_210
    {
        double ax;
        double ay;
        public I062_210(int b, int b1)
        {
            string ax_str = Convert.ToString(b, 2);
            string ay_str = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            if (ax_str[0].ToString().Equals("1"))
            {
                ax_str = bf.complement2(ax_str);
                this.ax = Convert.ToDouble(Convert.ToInt32(ax_str, 2)) * -0.25;
            }
            else
            {
                this.ax = Convert.ToDouble(Convert.ToInt32(ax_str, 2)) * 0.25;
            }
            if (ay_str[0].ToString().Equals("1"))
            {
                ay_str = bf.complement2(ay_str);
                this.ay = Convert.ToDouble(Convert.ToInt32(ay_str, 2)) * -0.25;
            }
            else
            {
                this.ay = Convert.ToDouble(Convert.ToInt32(ay_str, 2)) * 0.25;
            }
        }
        public double getAx()
        {
            return this.ax;
        }
        public double getAy()
        {
            return this.ay;
        }
    }
}
