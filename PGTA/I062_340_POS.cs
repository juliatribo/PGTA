using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_340_POS
    {
        double rho;
        double theta;

        public I062_340_POS(int b, int b1, int b2, int b3)
        {

            string oct1 = Convert.ToString(b, 2);
            string oct2 = Convert.ToString(b1, 2);
            string oct3 = Convert.ToString(b2, 2);
            string oct4 = Convert.ToString(b3, 2);


            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);
            oct2 = bf.padding(oct2);
            oct3 = bf.padding(oct3);
            oct4 = bf.padding(oct4);

            string rho_str = oct1 + oct2;
            string theta_str = oct3 + oct4;

            this.rho = Convert.ToDouble(Convert.ToInt32(rho_str, 2)) * (1 / 256);
            this.theta = Convert.ToDouble(Convert.ToInt32(theta_str, 2)) * (1 / 256);

        }
        public double getRHO()
        {
            return this.rho;
        }

        public double getTHETA()
        {
            return this.theta;
        }
    }
}
