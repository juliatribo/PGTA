using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_135
    {
        //Calculated Track Barometric Altitude
        int tba;
        bool correctionQNH;

        public I062_135(int b, int b1)
        {

            string tba1 = Convert.ToString(b, 2);
            string tba2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            tba1 = bf.padding(tba1);
            tba2 = bf.padding(tba2);

            string tba_str = tba1 + tba2;
            if (tba_str[0].Equals("0"))
            {
                correctionQNH = false;
            }
            else
            {
                correctionQNH = true;
            }
            tba_str = tba_str.Remove(tba_str[0]);
            if (tba_str[0].ToString().Equals("1"))
            {
                tba_str = bf.complement2(tba_str);
                this.tba = Convert.ToInt32(tba_str, 2) * -25;
            }
            else
            {
                this.tba = Convert.ToInt32(tba_str, 2) * 25;
            }

        }

        public int getTba()
        {
            return this.tba;
        }

        public bool getCorrectQNH()
        {
            return this.correctionQNH;
        }

    }
}
