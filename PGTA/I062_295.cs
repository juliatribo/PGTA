using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_295
    {
        Basic_functions bf = new Basic_functions();
        public I062_295()
        {

        }

        public double get1oct(int b)
        {
            string oct = Convert.ToString(b, 2);
            oct = bf.padding(oct);
            double oct1_field = Convert.ToDouble(Convert.ToInt32(oct, 2)) * 0.25;
            return oct1_field;
        }

    }
}
