using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class DataDecoded
    {
        string categoria;
        int sic;
        int sac;
        int serviceId;
        double time_track_info;
        double latitude;
        double longitude;
        double x;
        double y;
        double vx;
        double vy;
        double ax;
        double ay;
        bool validated;
        bool garbled_code;
        bool change_in_3A;
        int octal_mode3A;
        string target_id_status;
        string target_id_245;
        int target_addr;
        string target_id_380;
        double mag_heading;
        bool mach;
        double ias;
        double tas;
        bool sas;
        string source;
        double fms_altitude_selected;
        bool manage_vertical;
        bool altitude_hold;
        bool approach_mode;
        double final_altitude;

        double gs;

        int track_num;
        bool monosensor;
        bool spi;
        string most_reliable_height;
        string source_080;
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


        string status_movement_trans;
        string status_movement_long;
        string status_movement_vert;
        bool altitude_discrepacy;

        public DataDecoded()
        {

        }

        public string Categoria { get { return categoria; } set { categoria = value; }}
        public int Sic { get { return sic; } set { sic = value; }}
        public int Sac { get { return sac; } set { sac = value; }}
        public int Service_Id { get { return serviceId; } set { serviceId = value; } }
        public double Time_track_info { get { return time_track_info; } set { time_track_info = value; } }
        public double Latitude { get { return latitude; } set { latitude = value; } }
        public double Longitude { get { return longitude; } set { longitude = value; } }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return y; } set { y = value; } }
        public double Vx { get { return vx; } set { vx = value; } }
        public double Vy { get { return vy; } set { vy = value; } }
        public double Ax { get { return ax; } set { ax = value; } }
        public double Ay { get { return ay; } set { ay = value; } }
        public bool IsValidated { get { return validated; } set { validated = value; } }
        public bool IsGarbled_code { get { return garbled_code; } set { garbled_code = value; } }
        public bool Is3aChanged { get { return change_in_3A; } set { change_in_3A = value; } }
        public int Octal_mode3A { get { return octal_mode3A; } set { octal_mode3A = value; } }
        public string Target_id_status { get { return target_id_status; } set { target_id_status = value; } }
        public string Target_id_245 { get { return target_id_245; } set { target_id_245 = value; } }
        public int Target_addr { get { return target_addr; } set { target_addr = value; } }
        public string Target_id_380 { get { return target_id_380; } set { target_id_380 = value; } }
        public double Mag_heading { get { return mag_heading; } set { mag_heading = value; } }
        public bool IsMach{ get { return mach; } set { mach = value; } }
        public double Ias { get { return ias; } set { ias = value; } }
        public double Tas { get { return tas; } set { tas = value; } }
        public bool IsSas { get { return sas; } set { sas = value; } }
        public string Source { get { return source; } set { source = value; } }
        public double Fms_altitude_selected { get { return fms_altitude_selected; } set { fms_altitude_selected = value; } }
        public bool IsManageVertical { get { return manage_vertical; } set { manage_vertical = value; } }
        public bool IsAltitudeHold { get { return altitude_hold; } set { altitude_hold = value; } }
        public bool IsApproachMode { get { return approach_mode; } set { approach_mode = value; } }
        public double IsFinalAltitude { get { return final_altitude; } set { final_altitude = value; } }


        public double GS { get { return gs; } set { gs = value; } }



        public int Track_num { get { return track_num; } set { track_num = value; } }
        public bool IsMonosensor { get { return monosensor; } set { monosensor = value; } }
        public bool IsSPI{ get { return spi; } set { spi = value; } }
        public string Most_reliable_height { get { return most_reliable_height; } set { most_reliable_height = value; } }
        public string Source_080 { get { return source_080; } set { source_080 = value; } }
        public bool IsTrackConfirmed { get { return confirmed_track; } set { confirmed_track = value; } }
        public string Type_of_track { get { return type_of_track; } set { type_of_track = value; } }
        public bool IsLast_Msg { get { return last_msg; } set { last_msg = value; } }
        public bool IsFirst_Msg { get { return first_msg; } set { first_msg = value; } }
        public bool IsFlight_plan_correlated { get { return flight_plan_correlated; } set { flight_plan_correlated = value; } }
        public bool IsAdsb_inconsistent{ get { return adsb_inconsistent; } set { adsb_inconsistent = value; } }
        public bool IsSlave_track_promotion { get { return slave_track_promotion; } set { slave_track_promotion = value; } }
        public string Service_used { get { return service_used; } set { service_used = value; } }
        public bool IsAmalgamation { get { return amalgamation; } set { amalgamation = value; } }
        public string Type_of_target_int4 { get { return type_of_target_int4; } set { type_of_target_int4 = value; } }
        public bool IsMilitary_emergency { get { return military_emergency; } set { military_emergency = value; } }
        public bool IsMilitary_id { get { return military_id; } set { military_id = value; } }
        public string Type_of_target_int5 { get { return type_of_target_int5; } set { type_of_target_int5 = value; } }
        public bool IsDuplicate_3Acode { get { return duplicate_3Acode; } set { duplicate_3Acode = value; } }
        public bool IsDuplicate_flight_plan { get { return duplicate_flight_plan; } set { duplicate_flight_plan = value; } }
        public bool IsDuplicate_fplan_for_manual_corr { get { return duplicate_fplan_for_manual_corr; } set { duplicate_fplan_for_manual_corr = value; } }
        public bool IsSurface_target { get { return surface_target; } set { surface_target = value; } }
        public bool IsDuplicate_flight_id { get { return duplicate_flight_id; } set { duplicate_flight_id = value; } }
        public bool IsInconsistent_emerg_code { get { return inconsistent_emerg_code; } set { inconsistent_emerg_code = value; } }



        public bool IsAge_of_trackUpdate_higher_than_thold { get { return age_of_trackUpdate_higher_than_thold; } set { age_of_trackUpdate_higher_than_thold = value; } }
        public bool IsAge_of_PSR_higher_than_thold { get { return age_of_PSR_higher_than_thold; } set { age_of_PSR_higher_than_thold = value; } }
        public bool IsAge_of_SSR_higher_than_thold { get { return age_of_SSR_higher_than_thold; } set { age_of_SSR_higher_than_thold = value; } }
        public bool IsAge_of_ModeS_higher_than_thold { get { return age_of_ModeS_higher_than_thold; } set { age_of_ModeS_higher_than_thold = value; } }
        public bool IsAge_of_ADSB_higher_than_thold { get { return age_of_ADSB_higher_than_thold; } set { age_of_ADSB_higher_than_thold = value; } }
        public bool IsSpecial_used_code { get { return special_used_code; } set { special_used_code = value; } }
        public bool IsAssigned_modeA_code_conflict { get { return assigned_modeA_code_conflict; } set { assigned_modeA_code_conflict = value; } }
        public string Surveillance_data_status { get { return surveillance_data_status; } set { surveillance_data_status = value; } }
        public string Emergency_status_indication { get { return emergency_status_indication; } set { emergency_status_indication = value; } }
        public bool IsPotential_false_track_indication { get { return potential_false_track_indication; } set { potential_false_track_indication = value; } }
        public bool IsTrack_created_FPLdata { get { return track_created_FPLdata; } set { track_created_FPLdata = value; } }





        public string Status_movement_trans { get { return status_movement_trans; } set { status_movement_trans = value; } }
        public string Status_movement_long { get { return status_movement_long; } set { status_movement_long = value; } }
        public string Status_movement_vert { get { return status_movement_vert; } set { status_movement_vert = value; } }
        public bool IsAltitudeDiscrepacy { get { return altitude_discrepacy; } set { altitude_discrepacy = value; } }


    }
}
