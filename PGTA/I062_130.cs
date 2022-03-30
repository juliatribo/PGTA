using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_130
    {
        //Calculated Track Geometric Altitude
        double tga;

        public I062_130(int b, int b1)
        {

            string tga1 = Convert.ToString(b, 2);
            string tga2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            tga1 = bf.padding(tga1);
            tga2 = bf.padding(tga2);

            string tga_str = tga1 + tga2;
            if (tga_str[0].ToString().Equals("1"))
            {
                tga_str = bf.complement2(tga_str);
                this.tga = Convert.ToDouble(Convert.ToInt32(tga_str, 2)) * -6.25;
            }
            else
            {
                this.tga = Convert.ToDouble(Convert.ToInt32(tga_str, 2)) * 6.25;
            }

        }

        public double getTga()
        {
            return this.tga;
        }

    }

}
