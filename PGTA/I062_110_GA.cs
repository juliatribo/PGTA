using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_110_GA
    {
        string RES; //Resolution with which the GNSS-derived Altitude(GA) is reported.
        int altitude_GNSS;
        public I062_110_GA(int b, int b1)
        {

            string oct1 = Convert.ToString(b, 2);
            string oct2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);
            oct2 = bf.padding(oct2);

            string oct_str = oct1 + oct2;

            char res = oct_str[1];
            if (res.Equals('0'))
            {
                this.RES = "resolution 100ft increments";
            }
            else
            {
                this.RES = "resolution 25 ft increments";
            }

            string altitude = oct_str.Substring(2, 14);
            this.altitude_GNSS = Convert.ToInt32(altitude, 2);

        }
        public int getAltitudeGNSS()
        {
            return this.altitude_GNSS;
        }

        public string getRES()
        {
            return this.RES;
        }
    }
}
