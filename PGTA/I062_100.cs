using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_100
    {
        double x;
        double y;

        public I062_100(int b, int b1, int b2, int b3, int b4, int b5)
        {
            string x1 = Convert.ToString(b, 2);
            string x2 = Convert.ToString(b1, 2);
            string x3 = Convert.ToString(b2, 2);

            string y1 = Convert.ToString(b3, 2);
            string y2 = Convert.ToString(b4, 2);
            string y3 = Convert.ToString(b5, 2);

            Basic_functions bf = new Basic_functions();

            x1 = bf.padding(x1);
            x2 = bf.padding(x2);
            x3 = bf.padding(x3);
            
            y1 = bf.padding(y1);
            y2 = bf.padding(y2);
            y3 = bf.padding(y3);

            string x_str = x1 + x2 + x3;
            if (x_str[0].ToString().Equals("1"))
            {
                x_str = bf.complement2(x_str);
                this.x = Convert.ToDouble(Convert.ToInt32(x_str, 2)) * -0.5;

            }
            else
            {
                this.x = Convert.ToDouble(Convert.ToInt32(x_str, 2)) * 0.5;
            }

            string y_str = y1 + y2 + y3;
            if (y_str[0].ToString().Equals("1"))
            {
                y_str = bf.complement2(y_str);
                this.y = Convert.ToDouble(Convert.ToInt32(y_str, 2)) * -0.5;

            }
            else
            {
                this.y = Convert.ToDouble(Convert.ToInt32(y_str, 2)) * 0.5;
            }
        }


        public double getX()
        {
            return this.x;
        }

        public double getY()
        {
            return this.y;
        }
    }
}
