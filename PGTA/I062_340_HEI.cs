using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_340_HEI
    {
        int height;
        public I062_340_HEI(int b, int b1)
        {

            string oct1 = Convert.ToString(b, 2);
            string oct2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);
            oct2 = bf.padding(oct2);

            string oct_str = oct1 + oct2;
            this.height = Convert.ToInt32(oct_str, 2) * (25); //ft

        }
        public int getHeight()
        {
            return this.height;
        }

    }
}
