using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{

    internal class I062_110_SUM
    {
        bool M5 = false;
        bool ID = false;
        bool DA = false;
        bool M1 = false;
        bool M2 = false;
        bool M3 = false;
        bool MC = false;
        bool X_110 = false;

        public I062_110_SUM(int b)
        {
            string oct = Convert.ToString(b, 2);

            Basic_functions bf = new Basic_functions();

            oct = bf.padding(oct);

            for (int i = 0; i < oct.Length; i++)
            {
                if (oct[i].Equals('1'))
                {
                    switch (i)
                    {
                        case 0: //M5
                            M5 = true;
                            break;
                        case 1: //ID
                            ID = true;
                            break;
                        case 2: //DA
                            DA = true;
                            break;
                        case 3: //M1
                            M1 = true;
                            break;
                        case 4: //M2
                            M2 = true;
                            break;
                        case 5: //M3
                            M3 = true;
                            break;
                        case 6: //MC
                            MC = true;
                            break;
                        case 7: //X
                            X_110 = true;
                            break;
                    }
                }
            }
        }
        public bool getM5()
        {
            return this.M5;
        }
        public bool getID()
        {
            return this.ID;
        }
        public bool getDA()
        {
            return this.DA;
        }
        public bool getM1()
        {
            return this.M1;
        }
        public bool getM2()
        {
            return this.M2;
        }
        public bool getM3()
        {
            return this.M3;
        }
        public bool getMC()
        {
            return this.MC;
        }
        public bool getX_110()
        {
            return this.X_110;
        }

    }
}
