using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_380
    {

        Basic_functions bf = new Basic_functions();

        int target_address;
        string target_id;
        double mag_heading;
        bool mach;
        double ias;
        double tas;
        bool sas;
        string source;
        double final_altitude;
        bool manage_vert;
        bool alt_hold;
        bool appr_mode;
        double gs;
        public I062_380()
        {

        }

        public int getTargetAddress(int b, int b1, int b2)
        {
            string addr1 = Convert.ToString(b, 2);
            string addr2 = Convert.ToString(b1, 2);
            string addr3 = Convert.ToString(b2, 2);

            addr1 = bf.padding(addr1);
            addr2 = bf.padding(addr2);
            addr3 = bf.padding(addr3);

            string addr = addr1 + addr2 + addr3;
            this.target_address = Convert.ToInt32(addr, 2);

            return this.target_address;
        }

        public string getTargetId(int b, int b1, int b2, int b3, int b4, int b5)
        {
            string target_id1 = Convert.ToString(b, 2);
            string target_id2 = Convert.ToString(b1, 2);
            string target_id3 = Convert.ToString(b2, 2);
            string target_id4 = Convert.ToString(b3, 2);
            string target_id5 = Convert.ToString(b4, 2);
            string target_id6 = Convert.ToString(b5, 2);

            target_id1 = bf.padding(target_id1);
            target_id2 = bf.padding(target_id2);
            target_id3 = bf.padding(target_id3);
            target_id4 = bf.padding(target_id4);
            target_id5 = bf.padding(target_id5);
            target_id6 = bf.padding(target_id6);

            string target_id_coded = target_id1 + target_id2 + target_id3 + target_id4 + target_id5 + target_id6;
            string target_id_str = "";
            for (int i = 0; i < target_id_coded.Length; i += 6)
            {
                string subtarget_coded = target_id_coded.Substring(i, 6);
                string subtarget = bf.hexadecimal(subtarget_coded);
                target_id_str = target_id_str + subtarget;
            }

            this.target_id = target_id_str;
            return target_id;

        }

        public double GetMag_heading(int b, int b1)
        {
            string head1 = Convert.ToString(b, 2);
            string head2 = Convert.ToString(b1, 2);

            head1 = bf.padding(head1);
            head2 = bf.padding(head2);

            string heading_str = head1 + head2;
            this.mag_heading = Convert.ToDouble(Convert.ToInt32(heading_str, 2)) * (360 / Math.Pow(2, 16));
            return this.mag_heading;
        }

        public double getIas(int b, int b1)
        {
            string ias1 = Convert.ToString(b, 2);
            string ias2 = Convert.ToString(b1, 2);

            ias1 = bf.padding(ias1);
            ias2 = bf.padding(ias2);

            string ias_str1 = ias1 + ias2;
            string ias_str = ias_str1.Substring(1, 15);
            if (ias_str[0].ToString().Equals("1"))
            {
                this.mach = true;
                this.ias = Convert.ToDouble(Convert.ToInt32(ias_str, 2)) * 0.001;
            }
            else
            {
                this.mach = false;
                this.ias = Convert.ToDouble(Convert.ToInt32(ias_str, 2)) * (1 / Math.Pow(2, 14));
            }
            return this.ias;

        }

        public bool isMach()
        {
            return this.mach;
        }

        public double getTas(int b, int b1)
        {
            string tas1 = Convert.ToString(b, 2);
            string tas2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            tas1 = bf.padding(tas1);
            tas2 = bf.padding(tas2);

            string tas_str = tas1 + tas2;
            this.tas = Convert.ToDouble(Convert.ToInt32(tas_str, 2));
            return this.tas;
        }

        public bool IsSas(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(0, 1);

            if (str.Equals("0"))
            {
                this.sas = false;
            }
            else
            {
                this.sas = true;
            }

            return this.sas;
        }

        public string getSource(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(1, 2);
            if (str.Equals("00"))
            {
                this.source = "Unknown";
            }
            else if (str.Equals("01"))
            {
                this.source = "Aircraft Altitude";
            }
            else if (str.Equals("10"))
            {
                this.source = "FCU/MCP Selected Altitude";
            }
            else if (str.Equals("11"))
            {
                this.source = "FMS Selected Altitude";
            }
            return this.source;
        }
        public double getAltitude(int b, int b1)
        {
            string alt1 = Convert.ToString(b, 2);
            alt1 = bf.padding(alt1);
            alt1 = alt1.Substring(3, 5);
            string alt2 = Convert.ToString(b1, 2);
            alt2 = bf.padding(alt2);

            string alt = alt1 + alt2;

            if (alt[0].ToString().Equals("1"))
            {
                alt = bf.complement2(alt);
                this.final_altitude = Convert.ToDouble(Convert.ToInt32(alt, 2)) * -25;
            }
            else
            {
                this.final_altitude = Convert.ToDouble(Convert.ToInt32(alt, 2)) * 25;
            }

            return this.final_altitude;
        }
        public bool IsManageVertical(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(0, 1);

            if (str.Equals("0"))
            {
                this.manage_vert = false;
            }
            else
            {
                this.manage_vert = true;
            }

            return this.manage_vert;

        }

        public bool IsAltHold(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(1, 1);

            if (str.Equals("0"))
            {
                this.alt_hold = false;
            }
            else
            {
                this.alt_hold = true;
            }

            return this.alt_hold;
        }

        public bool IsApprMode(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(2, 1);

            if (str.Equals("0"))
            {
                this.appr_mode = false;
            }
            else
            {
                this.appr_mode = true;
            }

            return this.appr_mode;
        }

        public double getGS(int b, int b1)
        {
            string gs1 = Convert.ToString(b, 2);
            string gs2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            gs1 = bf.padding(gs1);
            gs2 = bf.padding(gs2);

            string gs_str = gs1 + gs2;
            if (gs_str[0].ToString().Equals("1"))
            {
                gs_str = bf.complement2(gs_str);
                this.gs = Convert.ToDouble(Convert.ToInt32(gs_str, 2)) * -Math.Pow(2,-14);
            }
            else
            {
                this.gs = Convert.ToDouble(Convert.ToInt32(gs_str, 2)) * Math.Pow(2, -14);
            }
            return this.gs;
        }
    }
}
