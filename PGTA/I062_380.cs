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

        bool mach;
        bool fx8;

        public I062_380()
        {

        }

        public string getTargetAddress(int b, int b1, int b2)
        {
            string addr1 = Convert.ToString(b, 2);
            string addr2 = Convert.ToString(b1, 2);
            string addr3 = Convert.ToString(b2, 2);

            addr1 = bf.padding(addr1);
            addr2 = bf.padding(addr2);
            addr3 = bf.padding(addr3);

            string addr = addr1 + addr2 + addr3;
            int target_address1 = Convert.ToInt32(addr, 2);
            string target_address = target_address1.ToString("X");

            return target_address;
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

            string target_id = target_id_str;
            return target_id;

        }

        public double GetMag_heading(int b, int b1)
        {
            string head1 = Convert.ToString(b, 2);
            string head2 = Convert.ToString(b1, 2);

            head1 = bf.padding(head1);
            head2 = bf.padding(head2);

            string heading_str = head1 + head2;
            double mag_heading = Convert.ToDouble(Convert.ToInt32(heading_str, 2)) * (360 / Math.Pow(2, 16));
            return mag_heading;
        }
        public bool isMach(int b)
        {
            string ias_mach = Convert.ToString(b, 2);
            ias_mach = bf.padding(ias_mach);
            if (ias_mach[0].ToString().Equals("1"))
            {
                this.mach = true;
            }
            else
            {
                this.mach = false;
            }
            return this.mach;
        }
        public double getIas_or_mach(int b, int b1)
        {
            string ias1 = Convert.ToString(b, 2);
            string ias2 = Convert.ToString(b1, 2);

            ias1 = bf.padding(ias1);
            ias2 = bf.padding(ias2);

            string ias_str1 = ias1 + ias2;
            string ias_str = ias_str1.Substring(1, 15);

            if (this.mach)
            {
                double ias = Convert.ToDouble(Convert.ToInt32(ias_str, 2)) * 0.001;
                return ias;
            }
            else
            {
                double mach = Convert.ToDouble(Convert.ToInt32(ias_str, 2)) * (1 / Math.Pow(2, 14));
                return mach;
            }
        }

        public double getTas(int b, int b1)
        {
            string tas1 = Convert.ToString(b, 2);
            string tas2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            tas1 = bf.padding(tas1);
            tas2 = bf.padding(tas2);

            string tas_str = tas1 + tas2;
            double tas = Convert.ToDouble(Convert.ToInt32(tas_str, 2));
            return tas;
        }

        public bool IsSas(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            bool sas;
            if (str[0].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string getSource(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(1, 2);
            string source = "";
            if (str.Equals("00"))
            {
                source = "Unknown";
            }
            else if (str.Equals("01"))
            {
                source = "Aircraft Altitude";
            }
            else if (str.Equals("10"))
            {
                source = "FCU/MCP Selected Altitude";
            }
            else if (str.Equals("11"))
            {
                source = "FMS Selected Altitude";
            }
            return source;
        }
        public double getAltitude(int b, int b1)
        {
            string alt1 = Convert.ToString(b, 2);
            alt1 = bf.padding(alt1);
            alt1 = alt1.Substring(3, 5);
            string alt2 = Convert.ToString(b1, 2);
            alt2 = bf.padding(alt2);

            string alt = alt1 + alt2;
            double final_altitude;
            if (alt[0].ToString().Equals("1"))
            {
                alt = bf.complement2(alt);
                final_altitude = Convert.ToDouble(Convert.ToInt32(alt, 2)) * -25;
            }
            else
            {
                final_altitude = Convert.ToDouble(Convert.ToInt32(alt, 2)) * 25;
            }

            return final_altitude;
        }
        public bool IsManageVertical(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(0, 1);
            bool manage_vert;
            if (str[0].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsAltHold(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            bool alt_hold;
            if (str[1].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool IsApprMode(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            bool appr_mode;
            if (str[2].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public double getFinalStateAlt(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            str1 = str1.Substring(3, 5);

            string str = str1 + str2;
            double altitude;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                altitude = Convert.ToDouble(Convert.ToInt32(str, 2)) * -25;
            }
            else
            {
                altitude = Convert.ToDouble(Convert.ToInt32(str, 2)) * 25;
            }
            return altitude;
        }

        public bool isTrajIntentAviable(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[0].ToString().Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isTrajIntentValid(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[1].ToString().Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool is8fx(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[0].ToString().Equals("0"))
            {
                this.fx8 = false;
            }
            else
            {
                this.fx8 = true;
            }
            return this.fx8;
        }
        public int getTrajIntRepFactor(int b)
        {
            string str = Convert.ToString(b, 2);
            return Convert.ToInt32(str, 2);
        }
        public bool isTcpAviable(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[0].ToString().Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool isTcpCompliance(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[0].ToString().Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int getTraj_chang_point(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(2, 6);
            return Convert.ToInt32(str, 2);
        }
        public double getTrajIntAltitude(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double altitude;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                altitude = Convert.ToDouble(Convert.ToInt32(str, 2)) * -10;
            }
            else
            {
                altitude = Convert.ToDouble(Convert.ToInt32(str, 2)) * 10;
            }
            return altitude;
        }
        public double getLatWGS84(int b, int b1, int b2)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            string str3 = Convert.ToString(b2, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);
            str3 = bf.padding(str3);

            string str = str1 + str2 + str3;

            double lat;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                lat = Convert.ToDouble(Convert.ToInt32(str, 2)) * -(180 / Math.Pow(2, 23));
            }
            else
            {
                lat = Convert.ToDouble(Convert.ToInt32(str, 2)) * (180 / Math.Pow(2, 23));
            }
            return lat;
        }
        public double getLongWGS84(int b, int b1, int b2)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            string str3 = Convert.ToString(b2, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);
            str3 = bf.padding(str3);

            string str = str1 + str2 + str3;

            double longitude;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                longitude = Convert.ToDouble(Convert.ToInt32(str, 2)) * -(180 / Math.Pow(2, 23));
            }
            else
            {
                longitude = Convert.ToDouble(Convert.ToInt32(str, 2)) * (180 / Math.Pow(2, 23));
            }
            return longitude;
        }
        public string getPointType(int b)
        {
            string str = Convert.ToString(b, 2);
            str = str.Substring(0, 4);
            int num = Convert.ToInt32(str, 2);
            string pt = "";
            if (num == 0)
            {
                pt = "Unknown";
            }
            else if (num == 1)
            {
                pt = "Fly by waypoint (LT)";
            }
            else if (num == 2)
            {
                pt = "Fly over waypoint (LT)";
            }
            else if (num == 3)
            {
                pt = "Hold pattern (LT)";
            }
            else if (num == 4)
            {
                pt = "Procedure hold (LT)";
            }
            else if (num == 5)
            {
                pt = "Procedure turn (LT)";
            }
            else if (num == 6)
            {
                pt = "RF leg (LT)";
            }
            else if (num == 7)
            {
                pt = "Top of climb (VT)";
            }
            else if (num == 8)
            {
                pt = "Top of descent (VT)";
            }
            else if (num == 9)
            {
                pt = "Start of level (VT)";
            }
            else if (num == 10)
            {
                pt = "Cross-over altitude (VT)";
            }
            else if (num == 11)
            {
                pt = "Transition altitude (VT)";
            }
            return pt;
        }
        public string getTd(int b)
        {
            string str = Convert.ToString(b, 2);
            str = str.Substring(4, 2);
            string td = "";
            if (str == "00")
            {
                td = "N/A";
            }
            else if (str == "01")
            {
                td = "Turn right";
            }
            else if (str == "10")
            {
                td = "Turn left";
            }
            else if (str == "11")
            {
                td = "No turn";
            }
            return td;
        }
        public bool isTurnRdiusAvailable(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[6].ToString().Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isTOVsAvailable(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[7].ToString().Equals("0"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double getTimeOverPoint(int b, int b1, int b2)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            string str3 = Convert.ToString(b2, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);
            str3 = bf.padding(str3);

            string str = str1 + str2 + str3;

            double tov = Convert.ToDouble(Convert.ToInt32(str, 2));
            return tov;
        }
        public double getTcpTurnRadius(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double ttr = Convert.ToDouble(Convert.ToInt32(str, 2)) * 0.01;
            return ttr;
        }
        public string getComm_capability_transponder(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(0, 3);
            int num = Convert.ToInt32(str, 2);
            string comm = "";
            if (num == 0)
            {
                comm = "No communications capability (surveillance only)";
            }
            else if (num == 1)
            {
                comm = "Comm. A and Comm. B capability";
            }
            else if (num == 2)
            {
                comm = "Comm. A, Comm. B and Uplink ELM";
            }
            else if (num == 3)
            {
                comm = "Comm. A, Comm. B, Uplink ELM and Downlink ELM";
            }
            else if (num == 4)
            {
                comm = "Level 5 Transponder capability";
            }
            else if (num == 5 || num == 6 || num == 7)
            {
                comm = "Not assigned";
            }
            return comm;
        }
        public string getFlightStatus(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(3, 3);
            int num = Convert.ToInt32(str, 2);
            string stat = "";
            if (num == 0)
            {
                stat = "No alert, no SPI, aircraft airborne";
            }
            else if (num == 1)
            {
                stat = "No alert, no SPI, aircraft on ground";
            }
            else if (num == 2)
            {
                stat = "Alert, no SPI, aircraft airborne";
            }
            else if (num == 3)
            {
                stat = "Alert, no SPI, aircraft on ground";
            }
            else if (num == 4)
            {
                stat = "Alert, SPI, aircraft airborne or on ground";
            }
            else if (num == 5)
            {
                stat = "No alert, SPI, aircraft airborne or on ground";
            }
            else if (num == 6)
            {
                stat = "Not defined";
            }
            else if (num == 7)
            {
                stat = "Unknown or not yet extracted";
            }
            return stat;
        }

        public bool isSpecificServiceCapability(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[0].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string getAltitudeCapability(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string alt = "";
            if (str[1].ToString().Equals("0"))
            {
                alt = "100 ft resolution";
            }
            else
            {
                alt = "25 ft resolution";
            }
            return alt;
        }
        public bool isIdCapability(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[2].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string getAcas_adsb(int b)
        {
            string str = Convert.ToString(b, 2);
            str = str.Substring(0, 2);
            string ac = "";
            if (str == "00")
            {
                ac = "unknown";
            }
            else if (str == "01")
            {
                ac = "ACAS not operational";
            }
            else if (str == "10")
            {
                ac = "ACAS operational";
            }
            else if (str == "11")
            {
                ac = "invalid";
            }
            return ac;
        }
        public string getMultNav_adsb(int b)
        {
            string str = Convert.ToString(b, 2);
            str = str.Substring(2, 2);
            string mnav = "";
            if (str == "00")
            {
                mnav = "unknown";
            }
            else if (str == "01")
            {
                mnav = "Multiple navigational aids not operating";
            }
            else if (str == "10")
            {
                mnav = "Multiple navigational aids operating";
            }
            else if (str == "11")
            {
                mnav = "invalid";
            }
            return mnav;
        }
        public string getDiffCorrection_adsb(int b)
        {
            string str = Convert.ToString(b, 2);
            str = str.Substring(2, 2);
            string dif_corr = "";
            if (str == "00")
            {
                dif_corr = "unknown";
            }
            else if (str == "01")
            {
                dif_corr = "Differential correction";
            }
            else if (str == "10")
            {
                dif_corr = "Differential correction";
            }
            else if (str == "11")
            {
                dif_corr = "invalid";
            }
            return dif_corr;
        }
        public bool isTranspondGroundBitSet_adsb(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[6].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string getFlightStatus_adsb(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            str = str.Substring(5, 3);
            int num = Convert.ToInt32(str, 2);
            string stat = "";
            if (num == 0)
            {
                stat = "No emergency";
            }
            else if (num == 1)
            {
                stat = "General emergency";
            }
            else if (num == 2)
            {
                stat = "Lifeguard / medical";
            }
            else if (num == 3)
            {
                stat = "Minimum fuel";
            }
            else if (num == 4)
            {
                stat = "No communications";
            }
            else if (num == 5)
            {
                stat = "Unlawful interference";
            }
            else if (num == 6)
            {
                stat = "“Downed” Aircraft ";
            }
            else if (num == 7)
            {
                stat = "Unknown";
            }
            return stat;
        }
        public double getBaromVertRate(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double rate;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                rate = Convert.ToDouble(Convert.ToInt32(str, 2)) * -6.25;
            }
            else
            {
                rate = Convert.ToDouble(Convert.ToInt32(str, 2)) * 6.25;
            }
            return rate;
        }
        public double getGeomVertRate(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double rate;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                rate = Convert.ToDouble(Convert.ToInt32(str, 2)) * -6.25;
            }
            else
            {
                rate = Convert.ToDouble(Convert.ToInt32(str, 2)) * 6.25;
            }
            return rate;
        }
        public double getRollAnle(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double roll;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                roll = Convert.ToDouble(Convert.ToInt32(str, 2)) * -0.01;
            }
            else
            {
                roll = Convert.ToDouble(Convert.ToInt32(str, 2)) * 0.01;
            }
            return roll;
        }
        public string getTurnIndicator(int b)
        {
            string str = Convert.ToString(b, 2);
            str = str.Substring(0, 2);
            string ti = "";
            if (str == "00")
            {
                ti = "Not available";
            }
            else if (str == "01")
            {
                ti = "Left";
            }
            else if (str == "10")
            {
                ti = "Right";
            }
            else if (str == "11")
            {
                ti = "Straight";
            }
            return ti;
        }
        public double getRateOfTurn(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);

            str = str.Substring(0, 7);

            double turn_rate;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                turn_rate = Convert.ToDouble(Convert.ToInt32(str, 2)) * -(1 / 4);
            }
            else
            {
                turn_rate = Convert.ToDouble(Convert.ToInt32(str, 2)) * (1 / 4);
            }
            return turn_rate;
        }
        public double getTrackAnle(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double roll;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                roll = Convert.ToDouble(Convert.ToInt32(str, 2)) * -0.0055;
            }
            else
            {
                roll = Convert.ToDouble(Convert.ToInt32(str, 2)) * 0.0055;
            }
            return roll;
        }
        public double getGS(int b, int b1)
        {
            string gs1 = Convert.ToString(b, 2);
            string gs2 = Convert.ToString(b1, 2);

            gs1 = bf.padding(gs1);
            gs2 = bf.padding(gs2);

            string gs_str = gs1 + gs2;
            double gs;
            if (gs_str[0].ToString().Equals("1"))
            {
                gs_str = bf.complement2(gs_str);
                gs = Convert.ToDouble(Convert.ToInt32(gs_str, 2)) * -Math.Pow(2, -14);
            }
            else
            {
                gs = Convert.ToDouble(Convert.ToInt32(gs_str, 2)) * Math.Pow(2, -14);
            }
            return gs;
        }
        public bool isWindSpeedValid(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[0].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool isWindDirectionValid(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[1].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool isTempValid(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[2].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool isTurbValid(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            if (str[3].ToString().Equals("0"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public double getWindSpeed(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double ws = Convert.ToDouble(Convert.ToInt32(str, 2));
            return ws;
        }
        public double getWindDir(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;

            double dir = Convert.ToDouble(Convert.ToInt32(str, 2));
            return dir;
        }
        public double getTemp(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;
            /////////////////////////////////////??
            double temp;
            if (str[0].ToString().Equals("1"))
            {
                str = bf.complement2(str);
                temp = Convert.ToDouble(Convert.ToInt32(str, 2)) * -0.25;
            }
            else
            {
                temp = Convert.ToDouble(Convert.ToInt32(str, 2)) * 0.25;
            }
            return temp;
        }
        public double getTurbulence(int b)
        {
            string str = Convert.ToString(b, 2);

            /////////////////////////////////////??
            double turb = Convert.ToDouble(Convert.ToInt32(str, 2));
            return turb;
        }
        public string getEcat(int b)
        {
            string str = Convert.ToString(b, 2);
            double num = Convert.ToInt32(str, 2);
            string cat = "";
            if (num == 1)
            {
                cat = "light aircraft ≤ 7000 kg";
            }
            else if (num == 2)
            {
                cat = "reserved";
            }
            else if (num == 3)
            {
                cat = "7000 kg < medium aircraft < 136000 kg";
            }
            else if (num == 4 || num == 7 || num == 8 || num == 9 || num == 17 || num == 18 || num == 19 || num == 23 || num == 24)
            {
                cat = "reserved";
            }
            else if (num == 5)
            {
                cat = "136000 kg ≤ heavy aircraft";
            }
            else if (num == 6)
            {
                cat = "highly manoeuvrable (5g acceleration capability) and high speed(> 400 knots cruise)";
            }
            else if (num == 10)
            {
                cat = "rotocraft";
            }
            else if (num == 11)
            {
                cat = "glider / sailplane";
            }
            else if (num == 12)
            {
                cat = "lighter-than-air";
            }
            else if (num == 13)
            {
                cat = "unmanned aerial vehicle";
            }
            else if (num == 14)
            {
                cat = "space / transatmospheric vehicle";
            }
            else if (num == 15)
            {
                cat = "ultralight / handglider / paraglider";
            }
            else if (num == 16)
            {
                cat = "parachutist / skydiver";
            }
            else if (num == 20)
            {
                cat = "surface emergency vehicle";
            }
            else if (num == 21)
            {
                cat = "surface service vehicle";
            }
            else if (num == 22)
            {
                cat = "fixed ground or tethered obstruction";
            }
            return cat;
        }
        public double getGeomAltitude(int b, int b1)
        {
            string alt1 = Convert.ToString(b, 2);
            string alt2 = Convert.ToString(b1, 2);
            alt1 = bf.padding(alt1);
            alt2 = bf.padding(alt2);

            string alt = alt1 + alt2;
            double geo_alt;
            if (alt[0].ToString().Equals("1"))
            {
                alt = bf.complement2(alt);
                geo_alt = Convert.ToDouble(Convert.ToInt32(alt, 2)) * -6.25;
            }
            else
            {
                geo_alt = Convert.ToDouble(Convert.ToInt32(alt, 2)) * 6.25;
            }

            return geo_alt;
        }
        public int getPosUncert(int b)
        {
            string pos = Convert.ToString(b, 2);
            pos = bf.padding(pos);
            pos = pos.Substring(4, 4);
            int pos_un = Convert.ToInt32(pos, 2);
            return pos_un;
        }
        public double getIas(int b, int b1)
        {
            string str1 = Convert.ToString(b, 2);
            string str2 = Convert.ToString(b1, 2);
            str1 = bf.padding(str1);
            str2 = bf.padding(str2);

            string str = str1 + str2;
            double ias = Convert.ToDouble(Convert.ToInt32(str, 2));
            return ias;

        }
        public double getMach(int b, int b1)
        {
            string mach1 = Convert.ToString(b, 2);
            string mach2 = Convert.ToString(b1, 2);
            mach1 = bf.padding(mach1);
            mach2 = bf.padding(mach2);

            string mach = mach1 + mach2;
            double mach_numb=Convert.ToDouble(Convert.ToInt32(mach, 2))*0.008;
            return mach_numb;
        }
        public double getBaromPressSett(int b, int b1)
        {
            string press1 = Convert.ToString(b, 2);
            string press2 = Convert.ToString(b1, 2);
            press1 = bf.padding(press1);
            press1 = press1.Substring(4, 4);
            press2 = bf.padding(press2);

            string press = press1 + press2;

            double bar_press = Convert.ToDouble(Convert.ToInt32(press, 2)) * 0.1;
            return bar_press;
        }

    }
}
