using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_110_XP
    {
        bool X5 = false;
        bool X1 = false;
        bool X2 = false;
        bool X3 = false;
        bool XC = false;

        public I062_110_XP(int b)
        {
            string oct = Convert.ToString(b, 2);

            Basic_functions bf = new Basic_functions();

            oct = bf.padding(oct);
            string suboct = oct.Substring(3, 5);

            for (int i = 0; i < suboct.Length; i++)
            {
                if (suboct[i].Equals("1"))
                {
                    switch (i)
                    {
                        case 0: //X5
                            X5 = true;
                            break;
                        case 1: //XC
                            XC = true;
                            break;
                        case 2: //X3
                            X3 = true;
                            break;
                        case 3: //X2
                            X2 = true;
                            break;
                        case 4: //X1
                            X1 = true;
                            break;
                        
                    }
                }
            }
        }
        public bool getX5()
        {
            return this.X5;
        }
        public bool getXC()
        {
            return this.XC;
        }
        public bool getX3()
        {
            return this.X3;
        }
        public bool getX2()
        {
            return this.X2;
        }
        public bool getX1()
        {
            return this.X1;
        }
        
    }
}

