using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    public class DataDecoded
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
        bool is_mach;
        double ias_or_Mach;
        double tas;
        bool sas;
        string source;
        double fms_altitude;
        bool manage_vertical;
        bool altitude_hold;
        bool approach_mode;
        double fms_final_state_altitude;
        bool trajIntentAviable;
        bool trajIntentValid;
        int rep_traj_int_fact;
        bool tcp_available;
        bool tcp_compilance;
        int traj_chang_point;
        double alt_traj_itent;
        double lat_traj_int_wgs84;
        double long_traj_int_wgs84;
        string point_type;
        string td;
        bool turn_radius_availab;
        bool tov_availab;
        double time_over_time;
        double tcp_trun_radius;
        string comm_capability_transpond;
        string flight_status;
        bool specific_capability;
        string alt_capability;
        bool aircraft_id_capability;
        string acas_adsb;
        string mult_nav_aids_adsb;
        string diff_correlation_adsb;
        bool tranpond_ground_bit_set_adsb;
        string flight_stat_adsb;
        double barom_vert_rate;
        double geom_vert_rate;
        double roll_angle;
        string turn_indicator;
        double rate_of_turn;
        double track_angle;
        double gs;
        int vel_uncert_cat;
        double wind_speed;
        double wind_direction;
        double temperature;
        double turbulence;
        string emitter_cat;
        double aircraft_derived_latWGS84;
        double aircraft_derived_longWGS84;
        double geom_alt;
        int position_uncert;
        double ias;
        double mach;
        double barom_press_sett;
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
        bool duplicate_3Acode;
        bool duplicate_flight_plan;
        bool duplicate_fplan_for_manual_corr;
        bool surface_target;
        bool duplicate_flight_id;
        bool inconsistent_emerg_code;
        double track_age;
        double psr_age;
        double ssr_age;
        double mode_s_age;
        double adsc_age;
        double adsb_ext_sq_age;
        double adsb_vdl_mode4_age;
        double adsb_uat_age;
        double loop_age;
        double multilater_age;
        string status_movement_trans;
        string status_movement_long;
        string status_movement_vert;
        bool altitude_discrepacy;
        double meas_fl_age;
        double mode1_age;
        double mode2_age;
        double mode3A_age;
        double mode4_age;
        double mode5A_age;
        double mag_head_age;
        double ias_mach_age;
        double tas_age;
        double select_alt_age;
        double fin_select_alt_age;
        double traj_age;
        double comm_acas_flight_age;
        double stat_by_adsb_age;
        double acas_resol_advisory_age;
        double baromet_vert_rate_age;
        double geomet_vert_rate_age;
        double roll_angle_age;
        double track_angle_rate_age;
        double track_angle_age;
        double gs_age;
        double vel_uncert_age;
        double metd_age;
        double emitt_cat_age;
        double pos_age;
        double geom_alt_age;
        double pos_uncert_age;
        double modeSMB_age;
        double ias_age;
        double mach_age;
        double barom_press_sett_age;





        double flight_level;
        double track_geometric_altitude;
        int track_barometric_altitude;
        bool correctionQNH;
        double rate_climb_descent;
        string vehicle;
        int octal_mode2A;
        string tag = "-";
        string csn = "-";
        string ifi = "-";
        string fct = "-";
        string tac = "-";
        string wtc = "-";
        string dep = "-";
        string dst = "-";
        string rds = "-";
        string cfl = "-";
        string ctl = "-";
        string tod = "-";
        string ast = "-";
        string sts = "-";
        string std = "-";
        string sta = "-";
        string pem = "-";
        string pec = "-";

        bool sum;
        bool pmn;
        bool pos;
        bool ga;
        bool em1;
        bool tos;
        bool xp;

        bool m5;
        bool id;
        bool da;
        bool m1;
        bool m2;
        bool m3;
        bool mc;
        bool x_100;

        int pin;
        int nat;
        int mis;

        double lat_M5;
        double lon_M5;

        string res_AltitudeGNSS;
        int altitudeGNSS;

        int code_M1;
        double tos_value;
        bool x5;
        bool xc;
        bool x3;
        bool x2;
        bool x1;

        bool sid;
        bool pos_340;
        bool hei;
        bool mdc;
        bool mda;
        bool typ;

        double rho;
        double theta;

        int height;
        bool validated_code_340;
        bool garbled_code_340;
        double last_mesured_modeC_code;

        bool v_mda;
        bool g_mda;
        bool l_mda;
        int codeM3A;

        string typ_val;
        bool sim;
        bool rab;
        bool tst;
        int sic2;
        int sac2;

        bool expanded;


        public DataDecoded()
        {

        }

        public string Categoria { get { return categoria; } set { categoria = value; } }
        public int Sic { get { return sic; } set { sic = value; } }
        public int Sac { get { return sac; } set { sac = value; } }
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
        public bool IsMach { get { return is_mach; } set { is_mach = value; } }
        public double Ias_or_Mach { get { return ias_or_Mach; } set { ias_or_Mach = value; } }
        public double Tas { get { return tas; } set { tas = value; } }
        public bool IsSas { get { return sas; } set { sas = value; } }
        public string Source { get { return source; } set { source = value; } }
        public double Fms_altitude { get { return fms_altitude; } set { fms_altitude = value; } }
        public bool IsManageVertical { get { return manage_vertical; } set { manage_vertical = value; } }
        public bool IsAltitudeHold { get { return altitude_hold; } set { altitude_hold = value; } }
        public bool IsApproachMode { get { return approach_mode; } set { approach_mode = value; } }
        public double Fms_final_state_altitude { get { return fms_final_state_altitude; } set { fms_final_state_altitude = value; } }
        public bool isTrajIntentAviable { get { return trajIntentAviable; } set { trajIntentAviable = value; } }
        public bool isTrajIntentValid { get { return trajIntentValid; } set { trajIntentValid = value; } }
        public int Rep_traj_int_fact { get { return rep_traj_int_fact; } set { rep_traj_int_fact = value; } }
        public bool isTcp_available { get { return tcp_available; } set { tcp_available = value; } }
        public bool isTcp_compilance { get { return tcp_compilance; } set { tcp_compilance = value; } }
        public int Traj_chang_point { get { return traj_chang_point; } set { traj_chang_point = value; } }
        public double Alt_traj_itent { get { return alt_traj_itent; } set { alt_traj_itent = value; } }
        public double Lat_traj_int_wgs84 { get { return lat_traj_int_wgs84; } set { lat_traj_int_wgs84 = value; } }
        public double Long_traj_int_wgs84 { get { return long_traj_int_wgs84; } set { long_traj_int_wgs84 = value; } }
        public string Point_type { get { return point_type; } set { point_type = value; } }
        public string Td { get { return td; } set { td = value; } }
        public bool isTurn_radius_available { get { return turn_radius_availab; } set { turn_radius_availab = value; } }
        public bool isTov_available { get { return tov_availab; } set { tov_availab = value; } }
        public double Time_over_time { get { return time_over_time; } set { time_over_time = value; } }
        public double Tcp_trun_radius { get { return tcp_trun_radius; } set { tcp_trun_radius = value; } }
        public string Comm_capability_transpond { get { return comm_capability_transpond; } set { comm_capability_transpond = value; } }
        public string Flight_status { get { return flight_status; } set { flight_status = value; } }
        public bool isSpecific_capability { get { return specific_capability; } set { specific_capability = value; } }
        public string Alt_capability { get { return alt_capability; } set { alt_capability = value; } }
        public bool isAircraft_id_capability { get { return aircraft_id_capability; } set { aircraft_id_capability = value; } }
        public string Acas_adsb { get { return acas_adsb; } set { acas_adsb = value; } }
        public string Mult_nav_aids_adsb { get { return mult_nav_aids_adsb; } set { mult_nav_aids_adsb = value; } }
        public string Diff_correlation_adsb { get { return diff_correlation_adsb; } set { diff_correlation_adsb = value; } }
        public bool isTranpond_ground_bit_set_adsb { get { return tranpond_ground_bit_set_adsb; } set { tranpond_ground_bit_set_adsb = value; } }
        public string Flight_stat_adsb { get { return flight_stat_adsb; } set { flight_stat_adsb = value; } }
        public double Barom_vert_rate { get { return barom_vert_rate; } set { barom_vert_rate = value; } }
        public double Geom_vert_rate { get { return geom_vert_rate; } set { geom_vert_rate = value; } }
        public double Roll_angle { get { return roll_angle; } set { roll_angle = value; } }
        public string Turn_indicator { get { return turn_indicator; } set { turn_indicator = value; } }
        public double Rate_of_turn { get { return rate_of_turn; } set { rate_of_turn = value; } }
        public double Track_angle { get { return track_angle; } set { track_angle = value; } }
        public double GS { get { return gs; } set { gs = value; } }
        public int Vel_uncert_cat { get { return vel_uncert_cat; } set { vel_uncert_cat = value; } }
        public double Wind_speed { get { return wind_speed; } set { wind_speed = value; } }
        public double Wind_direction { get { return wind_direction; } set { wind_direction = value; } }
        public double Temperature { get { return temperature; } set { temperature = value; } }
        public double Turbulence { get { return turbulence; } set { turbulence = value; } }
        public string Emitter_cat { get { return emitter_cat; } set { emitter_cat = value; } }
        public double Aircraft_derived_latWGS84 { get { return aircraft_derived_latWGS84; } set { aircraft_derived_latWGS84 = value; } }
        public double Aircraft_derived_longWGS84 { get { return aircraft_derived_longWGS84; } set { aircraft_derived_longWGS84 = value; } }
        public double Geom_alt { get { return geom_alt; } set { geom_alt = value; } }
        public int Position_uncert { get { return position_uncert; } set { position_uncert = value; } }
        public double Ias { get { return ias; } set { ias = value; } }
        public double Mach { get { return mach; } set { mach = value; } }
        public double Barom_press_sett { get { return barom_press_sett; } set { barom_press_sett = value; } }
        public int Track_num { get { return track_num; } set { track_num = value; } }
        public bool IsMonosensor { get { return monosensor; } set { monosensor = value; } }
        public bool IsSPI { get { return spi; } set { spi = value; } }
        public string Most_reliable_height { get { return most_reliable_height; } set { most_reliable_height = value; } }
        public string Source_080 { get { return source_080; } set { source_080 = value; } }
        public bool IsTrackConfirmed { get { return confirmed_track; } set { confirmed_track = value; } }
        public string Type_of_track { get { return type_of_track; } set { type_of_track = value; } }
        public bool IsLast_Msg { get { return last_msg; } set { last_msg = value; } }
        public bool IsFirst_Msg { get { return first_msg; } set { first_msg = value; } }
        public bool IsFlight_plan_correlated { get { return flight_plan_correlated; } set { flight_plan_correlated = value; } }
        public bool IsAdsb_inconsistent { get { return adsb_inconsistent; } set { adsb_inconsistent = value; } }
        public bool IsSlave_track_promotion { get { return slave_track_promotion; } set { slave_track_promotion = value; } }
        public string Service_used { get { return service_used; } set { service_used = value; } }
        public bool IsAmalgamation { get { return amalgamation; } set { amalgamation = value; } }
        public string Type_of_target_int4 { get { return type_of_target_int4; } set { type_of_target_int4 = value; } }
        public bool IsMilitary_emergency { get { return military_emergency; } set { military_emergency = value; } }
        public bool IsMilitary_id { get { return military_id; } set { military_id = value; } }
        public string Type_of_target_int5 { get { return type_of_target_int5; } set { type_of_target_int5 = value; } }
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
        public bool IsDuplicate_3Acode { get { return duplicate_3Acode; } set { duplicate_3Acode = value; } }
        public bool IsDuplicate_flight_plan { get { return duplicate_flight_plan; } set { duplicate_flight_plan = value; } }
        public bool IsDuplicate_fplan_for_manual_corr { get { return duplicate_fplan_for_manual_corr; } set { duplicate_fplan_for_manual_corr = value; } }
        public bool IsSurface_target { get { return surface_target; } set { surface_target = value; } }
        public bool IsDuplicate_flight_id { get { return duplicate_flight_id; } set { duplicate_flight_id = value; } }
        public bool IsInconsistent_emerg_code { get { return inconsistent_emerg_code; } set { inconsistent_emerg_code = value; } }
        public double Track_age { get { return track_age; } set { track_age = value; } }
        public double Psr_age { get { return psr_age; } set { psr_age = value; } }
        public double Ssr_age { get { return ssr_age; } set { ssr_age = value; } }
        public double Mode_s_age { get { return mode_s_age; } set { mode_s_age = value; } }
        public double Adsc_age { get { return adsc_age; } set { adsc_age = value; } }
        public double Adsb_ext_sq_age { get { return adsb_ext_sq_age; } set { adsb_ext_sq_age = value; } }
        public double Adsb_vdl_mode4_age { get { return adsb_vdl_mode4_age; } set { adsb_vdl_mode4_age = value; } }
        public double Adsb_uat_age { get { return adsb_uat_age; } set { adsb_uat_age = value; } }
        public double Loop_age { get { return loop_age; } set { loop_age = value; } }
        public double Multilater_age { get { return multilater_age; } set { multilater_age = value; } }
        public string Status_movement_trans { get { return status_movement_trans; } set { status_movement_trans = value; } }
        public string Status_movement_long { get { return status_movement_long; } set { status_movement_long = value; } }
        public string Status_movement_vert { get { return status_movement_vert; } set { status_movement_vert = value; } }
        public bool IsAltitudeDiscrepacy { get { return altitude_discrepacy; } set { altitude_discrepacy = value; } }
        public double Meas_fl_age { get { return meas_fl_age; } set { meas_fl_age = value; } }
        public double Mode1_age { get { return mode1_age; } set { mode1_age = value; } }
        public double Mode2_age { get { return mode2_age; } set { mode2_age = value; } }
        public double Mode3A_age { get { return mode3A_age; } set { mode3A_age = value; } }
        public double Mode4_age { get { return mode4_age; } set { mode4_age = value; } }
        public double Mode5A_age { get { return mode5A_age; } set { mode5A_age = value; } }
        public double Mag_head_age { get { return mag_head_age; } set { mag_head_age = value; } }
        public double Ias_mach_age { get { return ias_mach_age; } set { ias_mach_age = value; } }
        public double Tas_age { get { return tas_age; } set { tas_age = value; } }
        public double Select_alt_age { get { return select_alt_age; } set { select_alt_age = value; } }
        public double Fin_select_alt_age { get { return fin_select_alt_age; } set { fin_select_alt_age = value; } }
        public double Traj_age { get { return traj_age; } set { traj_age = value; } }
        public double Comm_acas_flight_age { get { return comm_acas_flight_age; } set { comm_acas_flight_age = value; } }
        public double Stat_by_adsb_age { get { return stat_by_adsb_age; } set { stat_by_adsb_age = value; } }
        public double Acas_resol_advisory_age { get { return acas_resol_advisory_age; } set { acas_resol_advisory_age = value; } }
        public double Baromet_vert_rate_age { get { return baromet_vert_rate_age; } set { baromet_vert_rate_age = value; } }
        public double Geomet_vert_rate_age { get { return geomet_vert_rate_age; } set { geomet_vert_rate_age = value; } }
        public double Roll_angle_age { get { return roll_angle_age; } set { roll_angle_age = value; } }
        public double Track_angle_rate_age { get { return track_angle_rate_age; } set { track_angle_rate_age = value; } }
        public double Track_angle_age { get { return track_angle_age; } set { track_angle_age = value; } }
        public double Gs_age { get { return gs_age; } set { gs_age = value; } }
        public double Vel_uncert_age { get { return vel_uncert_age; } set { vel_uncert_age = value; } }
        public double Metd_age { get { return metd_age; } set { metd_age = value; } }
        public double Emitt_cat_age { get { return emitt_cat_age; } set { emitt_cat_age = value; } }
        public double Pos_age { get { return pos_age; } set { pos_age = value; } }
        public double Geom_alt_age { get { return geom_alt_age; } set { geom_alt_age = value; } }
        public double Pos_uncert_age { get { return pos_uncert_age; } set { pos_uncert_age = value; } }
        public double ModeSMB_age { get { return modeSMB_age; } set { modeSMB_age = value; } }
        public double Ias_age { get { return ias_age; } set { ias_age = value; } }
        public double Mach_age { get { return mach_age; } set { mach_age = value; } }
        public double Barom_press_sett_age { get { return barom_press_sett_age; } set { barom_press_sett_age = value; } }






   
        public double FL { get { return flight_level; } set { flight_level = value; } }
        public double TGA { get { return track_geometric_altitude; } set { track_geometric_altitude = value; } }
        public int TBA { get { return track_barometric_altitude; } set { track_barometric_altitude = value; } }
        public bool CorrectionQNH { get { return correctionQNH; } set { correctionQNH = value; } }
        public double Rate { get { return rate_climb_descent; } set { rate_climb_descent = value; } }
        public string Vehicle { get { return vehicle; } set { vehicle = value; } }
        public int Octal_mode2A { get { return octal_mode2A; } set { octal_mode2A = value; } }
        
        public string TAG { get { return tag; } set { tag = value; } }
        public string CSN { get { return csn; } set { csn = value; } }

        public string IFI { get { return ifi; } set { ifi = value; } }
        public string FCT { get { return fct; } set { fct = value; } }
        public string TAC { get { return tac; } set { tac = value; } }
        public string WTC { get { return wtc; } set { wtc = value; } }

        public string DEP { get { return dep; } set { dep = value; } }
        public string DST { get { return dst; } set { dst = value; } }
        public string RDS { get { return rds; } set { rds = value; } }
        public string CFL { get { return cfl; } set { cfl = value; } }

        public string CTL { get { return ctl; } set { ctl = value; } }
        public string TOD { get { return tod; } set { tod = value; } }
        public string AST { get { return ast; } set { ast = value; } }
        public string STS { get { return sts; } set { sts = value; } }

        public string STD { get { return std; } set { std = value; } }
        public string STA { get { return sta; } set { sta = value; } }
        public string PEM { get { return pem; } set { pem = value; } }
        public string PEC { get { return pec; } set { pec = value; } }

        public bool SUM { get { return sum; } set { sum = value; } }
        public bool PMN { get { return pmn; } set { pmn = value; } }
        public bool POS { get { return pos; } set { pos = value; } }

        public bool GA { get { return ga; } set { ga = value; } }
        public bool EM1 { get { return em1; } set { em1 = value; } }
        public bool TOS { get { return tos; } set { tos = value; } }
        public bool XP { get { return xp; } set { xp = value; } }

        public bool M5 { get { return m5; } set { m5 = value; } }
        public bool ID { get { return id; } set { id = value; } }
        public bool DA { get { return da; } set { da = value; } }
        public bool M1 { get { return m1; } set { m1 = value; } }
        public bool M2 { get { return m2; } set { m2 = value; } }
        public bool M3 { get { return m3; } set { m3 = value; } }
        public bool MC { get { return mc; } set { mc = value; } }
        public bool X_110 { get { return x_100; } set { x_100 = value; } }

        public int PIN { get { return pin; } set { pin = value; } }
        public int NAT { get { return nat; } set { nat = value; } }
        public int MIS { get { return mis; } set { mis = value; } }

        public double LONG_M5 { get { return lat_M5; } set { lat_M5 = value; } }
        public double LAT_M5 { get { return lon_M5; } set { lon_M5 = value; } }

        public string RES_GNSS { get { return res_AltitudeGNSS; } set { res_AltitudeGNSS = value; } }
        public int ALT_GNSS { get { return altitudeGNSS; } set { altitudeGNSS = value; } }

        public int CODE_M1 { get { return code_M1; } set { code_M1 = value; } }

        public double TOS_VAL { get { return tos_value; } set { tos_value = value; } }
        public bool X5 { get { return x5; } set { x5 = value; } }
        public bool XC { get { return xc; } set { xc = value; } }
        public bool X3 { get { return x3; } set { x3 = value; } }
        public bool X2 { get { return x2; } set { x2 = value; } }
        public bool X1 { get { return x1; } set { x1 = value; } }

        public bool SID { get { return sid; } set { sid = value; } }
        public bool POS_340 { get { return pos_340; } set { pos_340 = value; } }
        public bool HEI { get { return hei; } set { hei = value; } }
        public bool MDC { get { return mdc; } set { mdc = value; } }
        public bool MDA { get { return mda; } set { mda = value; } }
        public bool TYP { get { return typ; } set { typ = value; } }

        public double RHO { get { return rho; } set { rho = value; } }
        public double THETA { get { return theta; } set { theta = value; } }
        public int HEIGHT { get { return height; } set { height = value; } }

        public bool VC { get { return validated_code_340; } set { validated_code_340 = value; } }
        public bool GC { get { return garbled_code_340; } set { garbled_code_340 = value; } }
        public double Code_Mc { get { return last_mesured_modeC_code; } set { last_mesured_modeC_code = value; } }

       
        public bool V_mda { get { return v_mda; } set { v_mda = value; } }
        public bool G_mda { get { return g_mda; } set { g_mda = value; } }
        public bool L_mda { get { return l_mda; } set { l_mda = value; } }
        public int CodeM3A { get { return codeM3A; } set { codeM3A = value; } }
 
        public bool TST { get { return tst; } set { tst = value; } }
        public bool RAB { get { return rab; } set { rab = value; } }
        public bool SIM { get { return sim; } set { sim = value; } }
        public string Typ_val { get { return typ_val; } set { typ_val = value; } }
        public int SIC2 { get { return sic2; } set { sic2 = value; } }
        public int SAC2 { get { return sac2; } set { sac2 = value; } }

        public bool Expanded { get { return expanded; } set { expanded = value; } }
    }
}
