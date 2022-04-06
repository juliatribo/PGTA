﻿using System;
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


        string status_movement_trans;
        string status_movement_long;
        string status_movement_vert;
        bool altitude_discrepacy;

        double flight_level;
        double track_geometric_altitude;
        int track_barometric_altitude;
        bool correctionQNH;
        double rate_climb_descent;
        string vehicle;
        int octal_mode2A;
        bool tag;
        bool csn;
        bool ifi;
        bool fct;
        bool tac;
        bool wtc;
        bool dep;
        bool dst;
        bool rds;
        bool cfl;
        bool ctl;
        bool tod;
        bool ast;
        bool sts;
        bool std;
        bool sta;
        bool pem;
        bool pec;

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
        public bool IsMach { get { return mach; } set { mach = value; } }
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


   
        public double FL { get { return flight_level; } set { flight_level = value; } }
        public double TGA { get { return track_geometric_altitude; } set { track_geometric_altitude = value; } }
        public int TBA { get { return track_barometric_altitude; } set { track_barometric_altitude = value; } }
        public bool CorrectionQNH { get { return correctionQNH; } set { correctionQNH = value; } }
        public double Rate { get { return rate_climb_descent; } set { rate_climb_descent = value; } }
        public string Vehicle { get { return vehicle; } set { vehicle = value; } }
        public int Octal_mode2A { get { return octal_mode2A; } set { octal_mode2A = value; } }
        
        public bool TAG { get { return tag; } set { tag = value; } }
        public bool CSN { get { return csn; } set { csn = value; } }

        public bool IFI { get { return ifi; } set { ifi = value; } }
        public bool FCT { get { return fct; } set { fct = value; } }
        public bool TAC { get { return tac; } set { tac = value; } }
        public bool WTC { get { return wtc; } set { wtc = value; } }

        public bool DEP { get { return dep; } set { dep = value; } }
        public bool DST { get { return dst; } set { dst = value; } }
        public bool RDS { get { return rds; } set { rds = value; } }
        public bool CFL { get { return cfl; } set { cfl = value; } }

        public bool CTL { get { return ctl; } set { ctl = value; } }
        public bool TOD { get { return tod; } set { tod = value; } }
        public bool AST { get { return ast; } set { ast = value; } }
        public bool STS { get { return sts; } set { sts = value; } }

        public bool STD { get { return std; } set { std = value; } }
        public bool STA { get { return sta; } set { sta = value; } }
        public bool PEM { get { return pem; } set { pem = value; } }
        public bool PEC { get { return pec; } set { pec = value; } }

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
    }
}