using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_340_TYP
    {
        string typ;
        bool sim;
        bool rab;
        bool tst;
        public I062_340_TYP(int b)
        {

            string oct1 = Convert.ToString(b, 2);

            Basic_functions bf = new Basic_functions();

            oct1 = bf.padding(oct1);

            string typ_val = oct1.Substring(0, 3);
            if (typ_val.Equals("000"))
            {
                this.typ = "No detection";
            }
            else if(typ_val.Equals("001")){
                this.typ = "Single PSR detection";
            }
            else if(typ_val.Equals("010")){
                this.typ = "Single SSR detection";
            }
            else if (typ_val.Equals("011"))
            {
                this.typ = "SSR + PSR detection";
            }
            else if (typ_val.Equals("100"))
            {
                this.typ = "Single ModeS All-Call ";
            }
            else if (typ_val.Equals("101"))
            {
                this.typ = "Single ModeS Roll-Call";
            }
            else if (typ_val.Equals("110"))
            {
                this.typ = "ModeS All-Call + PSR ";
            }
            else if (typ_val.Equals("111"))
            {
                this.typ = "ModeS Roll-Call +PSR";
            }

            char sim = oct1[3];
            if (sim.Equals("0"))
            {
                this.sim = false; //Actual target report
            }
            else
            {
                this.sim = true; //Simulated target report
            }
            char rab = oct1[4];
            if (rab.Equals("0"))
            {
                this.rab = false; //Report from target transponder
            }
            else
            {
                this.rab = true; //Report from field monitor
            }
            char tst = oct1[5];
            if (tst.Equals("0"))
            {
                this.tst = false; //Real target report
            }
            else
            {
                this.tst = true; //Test target report
            }

        }
        public bool getTST()
        {
            return this.tst;
        }
        public bool getRAB()
        {
            return this.rab;
        }
        public bool getSIM()
        {
            return this.sim;
        }
        public string getTYP()
        {
            return this.typ;
        }
    }
}
