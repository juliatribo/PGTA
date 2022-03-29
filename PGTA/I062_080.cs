using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_080
    {
        bool monosensor;
        bool spi;
        string most_reliable_height;
        string source;
        bool confirmed_track;
        string type_of_track;
        bool last_msg;
        bool first_msg;
        bool flight_plan_correlated;
        bool adsb_inconsistent;
        bool slave_track_promotion;
        string service_used;
        bool amalgamation;
        string type_of_target_int4;
        bool military_emergency;
        bool military_id;
        string type_of_target_int5;
        bool duplicate_3Acode;
        bool duplicate_flight_plan;
        bool duplicate_fplan_for_manual_corr;
        bool surface_target;
        bool duplicate_flight_id;
        bool inconsistent_emerg_code;
        bool age_of_trackUpdate_higher_than_thold;
        bool age_of_PSR_higher_than_thold;
        bool age_of_SSR_higher_than_thold;
        bool age_of_ModeS_higher_than_thold;
        bool age_of_ADSB_higher_than_thold;
        bool special_used_code;
        bool assigned_modeA_code_conflict;
        string surveillance_data_status;
        string emergency_status_indication;
        bool potential_false_track_indication;
        bool track_created_FPLdata;


        Basic_functions bf = new Basic_functions();
        public I062_080()
        {

        }
        public void structure(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string str3 = str.Substring(2, 1);
            string str4 = str.Substring(3, 3);
            string str5 = str.Substring(6, 1);

            if (str1.Equals("0"))
            {
                this.monosensor = false;
            }
            else
            {
                this.monosensor = true;
            }

            if (str2.Equals("0"))
            {
                this.spi = false;
            }
            else
            {
                this.spi = true;
            }

            if (str3.Equals("0"))
            {
                this.most_reliable_height = "Barometric";
            }
            else
            {
                this.most_reliable_height = "Geometric";
            }


            if (str4.Equals("000"))
            {
                this.source = "No source";
            }
            else if (str4.Equals("001"))
            {
                this.source = "GNSS";
            }
            else if (str4.Equals("010"))
            {
                this.source = "3D radar";
            }
            else if (str4.Equals("011"))
            {
                this.source = "Triangulation";
            }
            else if (str4.Equals("100"))
            {
                this.source = "Height from coverage";
            }
            else if (str4.Equals("101"))
            {
                this.source = "Speed look-up table";
            }
            else if (str4.Equals("110"))
            {
                this.source = "Default height";
            }
            else if (str4.Equals("111"))
            {
                this.source = "Multilateration";
            }

            if (str5.Equals("0"))
            {
                this.confirmed_track = true;
            }
            else
            {
                this.confirmed_track = false;
            }
        }
        public bool IsMonosource()
        {
            return this.monosensor;
        }
        public bool IsSPI()
        {
            return this.spi;
        }
        public string getMrh()
        {
            return this.most_reliable_height;
        }
        public string getSrc()
        {
            return this.source;
        }
        public bool IsCnf()
        {
            return this.confirmed_track;
        }


        public void ext1(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string str3 = str.Substring(2, 1);
            string str4 = str.Substring(3, 1);
            string str5 = str.Substring(4, 1);
            string str6 = str.Substring(5, 1);
            string str7 = str.Substring(6, 1);

            if (str1.Equals("0"))
            {
                this.type_of_track = "Actual track";
            }
            else
            {
                this.type_of_track = "Simulated track";
            }

            if (str2.Equals("0"))
            {
                this.last_msg = false;
            }
            else
            {
                this.last_msg = true;
            }

            if (str3.Equals("0"))
            {
                this.first_msg = false;
            }
            else
            {
                this.first_msg = true;
            }

            if (str4.Equals("0"))
            {
                this.flight_plan_correlated = false;
            }
            else
            {
                this.flight_plan_correlated = true;
            }

            if (str5.Equals("0"))
            {
                this.adsb_inconsistent = false;
            }
            else
            {
                this.adsb_inconsistent = true;
            }

            if (str6.Equals("0"))
            {
                this.slave_track_promotion = false;
            }
            else
            {
                this.slave_track_promotion = true;
            }

            if (str7.Equals("0"))
            {
                this.service_used = "Complementary";
            }
            else
            {
                this.service_used = "Background";
            }


        }

        public string getTypeOfTrack()
        {
            return this.type_of_track;
        }
        public bool isLastMsg()
        {
            return this.last_msg;
        }
        public bool isFirstMsg()
        {
            return this.first_msg;
        }
        public bool isFlightPlanCorrelated()
        {
            return this.flight_plan_correlated;
        }
        public bool isAdsbInconsistent()
        {
            return this.adsb_inconsistent;
        }
        public bool isSlaveTrackPromotion()
        {
            return this.slave_track_promotion;
        }
        public string getServiceUsed()
        {
            return this.service_used;
        }

        public void ext2(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 2);
            string str3 = str.Substring(3, 1);
            string str4 = str.Substring(4, 1);
            string str5 = str.Substring(5, 2);

            if (str1.Equals("0"))
            {
                this.amalgamation = false;
            }
            else
            {
                this.amalgamation = true;
            }


            if (str2.Equals("00"))
            {
                this.type_of_target_int4 = "No Mode 4 interrogation";
            }
            else if (str2.Equals("01"))
            {
                this.type_of_target_int4 = "Friendly target ";
            }
            else if (str2.Equals("10"))
            {
                this.type_of_target_int4 = "Unknown target";
            }
            else if (str2.Equals("11"))
            {
                this.type_of_target_int4 = "No reply";
            }


            if (str3.Equals("0"))
            {
                this.military_emergency = false;
            }
            else
            {
                this.military_emergency = true;
            }

            if (str4.Equals("0"))
            {
                this.military_id = false;
            }
            else
            {
                this.military_id = true;
            }


            if (str5.Equals("00"))
            {
                this.type_of_target_int5 = "No Mode 5 interrogation";
            }
            else if (str5.Equals("01"))
            {
                this.type_of_target_int5 = "Friendly target ";
            }
            else if (str5.Equals("10"))
            {
                this.type_of_target_int5 = "Unknown target";
            }
            else if (str5.Equals("11"))
            {
                this.type_of_target_int5 = "No reply";
            }

        }


        public bool isAmalgamation()
        {
            return this.amalgamation;
        }
        public string getTypeOfTargetInt4()
        {
            return this.type_of_target_int4;
        }
        public bool isMilitaryEmergency()
        {
            return this.military_emergency;
        }
        public bool isMilitaryId()
        {
            return this.military_id;
        }
        public string getTypeOfTargetInt5()
        {
            return this.type_of_target_int5;
        }


        public void ext3(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string str3 = str.Substring(2, 1);
            string str4 = str.Substring(3, 1);
            string str5 = str.Substring(4, 1);
            string str6 = str.Substring(5, 1);
            string str7 = str.Substring(6, 1);


            if (str1.Equals("0"))
            {
                this.age_of_trackUpdate_higher_than_thold = false;
            }
            else
            {
                this.age_of_trackUpdate_higher_than_thold = true;
            }

            if (str2.Equals("0"))
            {
                this.age_of_PSR_higher_than_thold = false;
            }
            else
            {
                this.age_of_PSR_higher_than_thold = true;
            }

            if (str3.Equals("0"))
            {
                this.age_of_SSR_higher_than_thold = false;
            }
            else
            {
                this.age_of_SSR_higher_than_thold = true;
            }

            if (str4.Equals("0"))
            {
                this.age_of_ModeS_higher_than_thold = false;
            }
            else
            {
                this.age_of_ModeS_higher_than_thold = true;
            }

            if (str5.Equals("0"))
            {
                this.age_of_ADSB_higher_than_thold = false;
            }
            else
            {
                this.age_of_ADSB_higher_than_thold = true;
            }

            if (str6.Equals("0"))
            {
                this.special_used_code = false;
            }
            else
            {
                this.special_used_code = true;
            }


            if (str7.Equals("0"))
            {
                this.assigned_modeA_code_conflict = false;
            }
            else
            {
                this.assigned_modeA_code_conflict = true;
            }

        }


        public bool Is_age_of_trackUpdate_higher_than_thold()
        {
            return this.age_of_trackUpdate_higher_than_thold;
        }
        public bool Is_age_of_PSR_higher_than_thold()
        {
            return this.age_of_PSR_higher_than_thold;
        }
        public bool Is_age_of_SSR_higher_than_thold()
        {
            return this.age_of_SSR_higher_than_thold;
        }
        public bool Is_age_of_ModeS_higher_than_thold()
        {
            return this.age_of_ModeS_higher_than_thold;
        }
        public bool Is_age_of_ADSB_higher_than_thold()
        {
            return this.age_of_ADSB_higher_than_thold;
        }
        public bool Is_special_used_code()
        {
            return this.special_used_code;
        }
        public bool Is_assigned_modeA_code_conflict()
        {
            return this.assigned_modeA_code_conflict;
        }

        public void ext4(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string str1 = str.Substring(0, 2);
            string str2 = str.Substring(2, 3);
            string str3 = str.Substring(5, 1);
            string str4 = str.Substring(6, 2);

            string emergency_status_indication;


            if (str1.Equals("00"))
            {
                this.surveillance_data_status = "Combined";
            }
            else if (str1.Equals("01"))
            {
                this.surveillance_data_status = "Co-operative only";
            }
            else if (str1.Equals("10"))
            {
                this.surveillance_data_status = "Non-Cooperative only";
            }
            else if (str1.Equals("11"))
            {
                this.surveillance_data_status = "Not defined";
            }


            if (Convert.ToInt32(str2, 2) == 0)
            {
                this.emergency_status_indication = "No emergency";
            }
            else if(Convert.ToInt32(str2, 2) == 1)
            {
                this.emergency_status_indication = "General emergency";
            }
            else if (Convert.ToInt32(str2, 2) == 2)
            {
                this.emergency_status_indication = "Lifeguard / medical";
            }
            else if (Convert.ToInt32(str2, 2) == 3)
            {
                this.emergency_status_indication = "Minimum fuel";
            }
            else if (Convert.ToInt32(str2, 2) == 4)
            {
                this.emergency_status_indication = "No communications";
            }
            else if (Convert.ToInt32(str2, 2) == 5)
            {
                this.emergency_status_indication = "Unlawful interference";
            }
            else if (Convert.ToInt32(str2, 2) == 6)
            {
                this.emergency_status_indication = "“Downed” Aircraft";
            }
            else if (Convert.ToInt32(str2, 2) == 7)
            {
                this.emergency_status_indication = "Undefined";
            }


            if (str3.Equals("0"))
            {
                this.potential_false_track_indication = false;
            }
            else
            {
                this.potential_false_track_indication = true;
            }


            if (str4.Equals("0"))
            {
                this.track_created_FPLdata = false;
            }
            else
            {
                this.track_created_FPLdata = true;
            }

        }

        public string Surveillance_data_status()
        {
            return this.surveillance_data_status;
        }
        public string Emergency_status_indication()
        {
            return this.emergency_status_indication;
        }
        public bool IsPotential_false_track_indication()
        {
            return this.potential_false_track_indication;
        }
        public bool IsTrack_created_FPLdata()
        {
            return this.track_created_FPLdata;
        }



        public void ext5(int b)
        {
            string str = Convert.ToString(b, 2);
            str = bf.padding(str);
            string str1 = str.Substring(0, 1);
            string str2 = str.Substring(1, 1);
            string str3 = str.Substring(2, 1);
            string str4 = str.Substring(3, 1);
            string str5 = str.Substring(4, 1);
            string str6 = str.Substring(5, 1);


            if (str1.Equals("0"))
            {
                this.duplicate_3Acode = false;
            }
            else
            {
                this.duplicate_3Acode = true;
            }


            if (str2.Equals("0"))
            {
                this.duplicate_flight_plan = false;
            }
            else
            {
                this.duplicate_flight_plan = true;
            }


            if (str3.Equals("0"))
            {
                this.duplicate_fplan_for_manual_corr = false;
            }
            else
            {
                this.duplicate_fplan_for_manual_corr = true;
            }


            if (str4.Equals("0"))
            {
                this.surface_target = false;
            }
            else
            {
                this.surface_target = true;
            }


            if (str5.Equals("0"))
            {
                this.duplicate_flight_id = false;
            }
            else
            {
                this.duplicate_flight_id = true;
            }


            if (str6.Equals("0"))
            {
                this.inconsistent_emerg_code = false;
            }
            else
            {
                this.inconsistent_emerg_code = true;
            }
        }


        public bool IsDuplicate3Acode()
        {
            return this.duplicate_3Acode;
        }
        public bool IsDuplicateFlightPlan()
        {
            return this.duplicate_flight_plan;
        }
        public bool IsDuplicateFplanForManualCorr()
        {
            return this.duplicate_fplan_for_manual_corr;
        }
        public bool IsSurfaceTarget()
        {
            return this.surface_target;
        }
        public bool IsDuplicateFlightId()
        {
            return this.duplicate_flight_id;
        }
        public bool IsInconsistentEmergCode()
        {
            return this.inconsistent_emerg_code;
        }


        
    }
}
