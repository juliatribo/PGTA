using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_110_PMN
    {
        int pin;
        int nat;
        int mis;
        public I062_110_PMN(int b, int b1, int b2, int b3)
        {

            string code1 = Convert.ToString(b, 2);
            string code2 = Convert.ToString(b1, 2);
            string code3 = Convert.ToString(b2, 2);
            string code4 = Convert.ToString(b3, 2);

            Basic_functions bf = new Basic_functions();

            code1 = bf.padding(code1);
            code2 = bf.padding(code2);
            code3 = bf.padding(code3);
            code4 = bf.padding(code4);

            string pin = code1 + code2;

            string subpin = pin.Substring(2, 14);
            this.pin = Convert.ToInt32(subpin, 2);

            string subnat = code3.Substring(3, 5);
            this.nat = Convert.ToInt32(subnat, 2);

            string submis = code4.Substring(1, 6);
            this.mis = Convert.ToInt32(submis, 2);
        }

        public int getPIN()
        {
            return this.pin;
        }

        public int getNAT()
        {
            return this.nat;
        }

        public int getMIS()
        {
            return this.mis;
        }
    }
}
