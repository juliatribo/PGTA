using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_105
    {

        double latitude;
        double longitude;

        public I062_105(int b,int b1, int b2, int b3, int b4, int b5, int b6, int b7)
        {
            string lat1 = Convert.ToString(b, 2);
            string lat2 = Convert.ToString(b1, 2);
            string lat3 = Convert.ToString(b2, 2);
            string lat4 = Convert.ToString(b3, 2);

            string long1 = Convert.ToString(b4, 2);
            string long2 = Convert.ToString(b5, 2);
            string long3 = Convert.ToString(b6, 2);
            string long4 = Convert.ToString(b7, 2);

            Basic_functions bf = new Basic_functions();

            lat1 = bf.padding(lat1);
            lat2 = bf.padding(lat2);
            lat3 = bf.padding(lat3);
            lat4 = bf.padding(lat4);

            string lat_str = lat1 + lat2 + lat3 + lat4;
            if (lat_str[0].ToString().Equals("1"))
            {
                lat_str = bf.complement2(lat_str);
                this.latitude = Convert.ToDouble(Convert.ToInt32(lat_str, 2)) * (-180 / Math.Pow(2, 25));

            }
            else
            {
                this.latitude = Convert.ToDouble(Convert.ToInt32(lat_str, 2)) * (180 / Math.Pow(2, 25));
            }

            long1 = bf.padding(long1);
            long2 = bf.padding(long2);
            long3 = bf.padding(long3);
            long4 = bf.padding(long4);

            string long_str = long1 + long2 + long3 + long4;
            if (long_str[0].ToString().Equals("1"))
            {
                long_str = bf.complement2(long_str);
                this.longitude = Convert.ToDouble(Convert.ToInt32(long_str, 2)) * (-180 / Math.Pow(2, 25));

            }
            else
            {
                this.longitude = Convert.ToDouble(Convert.ToInt32(long_str, 2)) * (180 / Math.Pow(2, 25));
            }

        }

        public double getLong()
        {
            return this.longitude;
        }
        public double getLat()
        {
            return this.latitude;
        }
    }
}
