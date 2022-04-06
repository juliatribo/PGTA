using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_340_SID
    {
        int sac;
        int sic;
        public I062_340_SID(int b, int b1)
        {
            string oct1 = Convert.ToString(b, 2);
            string oct2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);
            oct2 = bf.padding(oct2);

            this.sac = Convert.ToInt32(oct1, 2);
            this.sic = Convert.ToInt32(oct2, 2);

        }
        public int getSAC()
        {
            return this.sac;
        }
        public int getSIC()
        {
            return this.sic;
        }
    }
}
