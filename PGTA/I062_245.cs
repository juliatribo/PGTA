using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_245
    {
        string target_id_status = "";
        string target_id;

        public I062_245(int b, int b1, int b2, int b3, int b4, int b5, int b6)
        {
            string sti_ocet = Convert.ToString(b, 2);
            string target_id1 = Convert.ToString(b1, 2);
            string target_id2 = Convert.ToString(b2, 2);
            string target_id3 = Convert.ToString(b3, 2);
            string target_id4 = Convert.ToString(b4, 2);
            string target_id5 = Convert.ToString(b5, 2);
            string target_id6 = Convert.ToString(b6, 2);

            Basic_functions bf = new Basic_functions();

            sti_ocet = bf.padding(sti_ocet);
            target_id1 = bf.padding(target_id1);
            target_id2 = bf.padding(target_id2);
            target_id3 = bf.padding(target_id3);
            target_id4 = bf.padding(target_id4);
            target_id5 = bf.padding(target_id5);
            target_id6 = bf.padding(target_id6);

            string sti = sti_ocet.Substring(0, 2);
            if (sti.Equals("00"))
            {
                this.target_id_status = "Callsign or registrationdownlinked from target";
            }
            else if (sti.Equals("01"))
            {
                this.target_id_status = "Callsign not downlinked from target";
            }
            else if (sti.Equals("10"))
            {
                this.target_id_status = "Registration not downlinked from target";
            }
            else if (sti.Equals("11"))
            {
                this.target_id_status = "Invalid";
            }

            string target_id_coded = target_id1 + target_id2 + target_id3 + target_id4 + target_id5 + target_id6;
            string target_id_str = "";
            for (int i = 0; i < target_id_coded.Length; i += 6)
            {
                string subtarget_coded = target_id_coded.Substring(i, 6);
                string subtarget = bf.hexadecimal(subtarget_coded);
                target_id_str = target_id_str + subtarget;
            }

            this.target_id = target_id_str;
        }
        public string getTargetId()
        {
            return this.target_id;
        }
        public string getTargetIdStatus()
        {
            return this.target_id_status;
        }
    }
}
