using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_290
    {
        Basic_functions bf = new Basic_functions();
        public I062_290(int b, int b1)
        {
            string oct1 = Convert.ToString(b, 2);
            oct1 = bf.padding(oct1);
            string oct2 = Convert.ToString(b1, 2);
            oct2 = bf.padding(oct2);

            string oct = oct1 + oct2;


        }


    }
}
