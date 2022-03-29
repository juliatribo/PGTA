using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PGTA
{
    internal class I062_185
    {
        double vx;
        double vy;

        public I062_185(int b, int b1, int b2, int b3)
        {

            string vx1 = Convert.ToString(b, 2);
            string vx2 = Convert.ToString(b1, 2);
            string vy1 = Convert.ToString(b2, 2);
            string vy2 = Convert.ToString(b3, 2);

            Basic_functions bf =new Basic_functions();

            vx1 = bf.padding(vx1);
            vx2 = bf.padding(vx2);
            vy1 = bf.padding(vy1);
            vy2 = bf.padding(vy2);

            string vx_str = vx1 + vx2;
            if (vx_str[0].ToString().Equals("1"))
            {
                vx_str = bf.complement2(vx_str);
                this.vx = Convert.ToDouble(Convert.ToInt32(vx_str, 2)) * -0.25;
            }
            else
            {
                this.vx = Convert.ToDouble(Convert.ToInt32(vx_str, 2)) * 0.25;
            }
            string vy_str = vy1 + vy2;
            if (vy_str[0].ToString().Equals("1"))
            {
                vy_str = bf.complement2(vy_str);
                this.vy = Convert.ToDouble(Convert.ToInt32(vy_str, 2)) * -0.25;
            }
            else
            {
                this.vy = Convert.ToDouble(Convert.ToInt32(vy_str, 2)) * 0.25;
            }
        }

        public double getVx()
        {
            return this.vx;
        }

        public double getVy()
        {
            return this.vy;
        }


    }
}
