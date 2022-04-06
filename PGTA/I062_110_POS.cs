using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_110_POS
    {
        double lat;
        double lon; 
        public I062_110_POS(int b, int b1, int b2, int b3, int b4, int b5)
        {

            string oct1 = Convert.ToString(b, 2);
            string oct2 = Convert.ToString(b1, 2);
            string oct3 = Convert.ToString(b2, 2);
            string oct4 = Convert.ToString(b3, 2);
            string oct5 = Convert.ToString(b4, 2);
            string oct6 = Convert.ToString(b5, 2);

            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);
            oct2 = bf.padding(oct2);
            oct3 = bf.padding(oct3);
            oct4 = bf.padding(oct4);
            oct5 = bf.padding(oct5);
            oct6 = bf.padding(oct6);

            string lat_str = oct1 + oct2 + oct3;
            if (lat_str[0].ToString().Equals("1"))
            {
                lat_str = bf.complement2(lat_str);
                this.lat = Convert.ToDouble(Convert.ToInt32(lat_str, 2)) * (180/Math.Pow(2,23));
            }
            else
            {
                this.lat = Convert.ToDouble(Convert.ToInt32(lat_str, 2)) * (180 / Math.Pow(2, 23));
            }

            string long_str = oct4 + oct5 + oct6;
            if (long_str[0].ToString().Equals("1"))
            {
                long_str = bf.complement2(long_str);
                this.lon = Convert.ToDouble(Convert.ToInt32(long_str, 2)) * (180 / Math.Pow(2, 23));
            }
            else
            {
                this.lon = Convert.ToDouble(Convert.ToInt32(lat_str, 2)) * (180 / Math.Pow(2, 23));
            }

        }
        public double getLong()
        {
            return this.lon;
        }

        public double getLat()
        {
            return this.lat;
        }
    }
}
