using System;
using System.Text;
using System.Data;
namespace PGTA
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            mapToolStripMenuItem.Enabled = false;
        }

        DataDecoded[] all_data;
        Basic_functions bf = new Basic_functions();

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog archivo = new OpenFileDialog();
            //archivo.Filter = "Archivos asterix(*.asterix)|*.asterix" ;


            if (archivo.ShowDialog() == DialogResult.OK)
            {

                FileStream fichero = new FileStream(archivo.FileName, FileMode.Open, FileAccess.Read);
                Byte[] buffer = new byte[fichero.Length];
                fichero.Read(buffer, 0, buffer.Length);
                fichero.Close();

                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                

                DataTable dt = new DataTable();
                dt.Columns.Add("Cat");
                dt.Columns.Add("Sic");
                dt.Columns.Add("Sac");
                dt.Columns.Add("Service ID");
                dt.Columns.Add("Time Track Info");
                dt.Columns.Add("Latitude (WGS-84)");
                dt.Columns.Add("Longitude (WGS-84)");
                dt.Columns.Add("X (Cartesian)");
                dt.Columns.Add("Y (Cartesian)");
                dt.Columns.Add("Vx (Cartesian)");
                dt.Columns.Add("Vy (Cartesian)");
                dt.Columns.Add("ax (Cartesian)");
                dt.Columns.Add("ay (Cartesian)");
                dt.Columns.Add("Octal Mode 3A");
                dt.Columns.Add("Target Identification Status");
                dt.Columns.Add("Target ID");
                dt.Columns.Add("Aircraft delivered Data (Click row to expand)");
                dt.Columns.Add("Track number");
                dt.Columns.Add("Track status (Click row to expand)");
                dt.Columns.Add("System Track Update Ages (Click row to expand)");
                dt.Columns.Add("Mode of Movement (Click to expand)");
                dt.Columns.Add("Track Data Ages (Click to expand)");
                dt.Columns.Add("Measured Flight Level");
                dt.Columns.Add("Geometric Altitude (ft)");
                dt.Columns.Add("Barometric Altitude (Click to expand)");
                dt.Columns.Add("Rate of Climb/Descent (feet/minute)");
                dt.Columns.Add("Vehicle Fleet ID");
                dt.Columns.Add("Mode 5 Data reports & Extended Mode 1 Code (Click to expand)");
                dt.Columns.Add("Track Mode 2 Code");
                dt.Columns.Add("Measured Information (Click to expand)");

                this.all_data = new DataDecoded[1000000];

                int n = 0;//message counter
                int k = 0;
                while (n < buffer.Length)
                {
                    List<string> row = new List<string>();

                    DataDecoded data = new DataDecoded();
                    int len;
                    switch (((sbyte)buffer[n]))
                    {
                        case 62:
                            data.Categoria = "Cat 62";
                            row.Add(data.Categoria);
                            len = buffer[n + 1] + buffer[n + 2];
                            string frns = "";
                            bool last1 = true;
                            int p;//length frns counter
                            for (p = 0; last1; p++)
                            {
                                last1 = false;
                                string var = Convert.ToString(buffer[n + p + 3], 2);
                                if (Convert.ToString(var[var.Length - 1]).Equals("1"))
                                {
                                    last1 = true;
                                }
                                var = var.Remove(var.Length - 1);
                                while (var.Length < 7)
                                {
                                    var = "0" + var;//padding
                                }
                                frns = frns + var;
                            }
                            int position = n + p + 3; //posición en la que empiezan los datos
                            for (int q = 0; q < frns.Length; q++)
                            {
                                if (Convert.ToString(frns[q]).Equals("1"))
                                {
                                    switch (q + 1)
                                    {
                                        case 1://I062/010 Data Source Identifier 
                                            data.Sac = buffer[position];
                                            data.Sic = buffer[position + 1];
                                            position = position + 2;
                                            break;

                                        case 2://
                                               //Spare
                                            break;

                                        case 3://I062/015 Service Identification 
                                            data.Service_Id = buffer[position];
                                            position++;
                                            break;

                                        case 4://I062/070 Time Of Track Information (cambiarlo)
                                            I062_070 c4 = new I062_070(buffer[position], buffer[position + 1], buffer[position + 2]);
                                            data.Time_track_info = c4.getTimeTrackInfo();
                                            position = position + 3;
                                            break;

                                        case 5://I062/105 Calculated Track Position (WGS-84) 
                                            I062_105 c5 = new I062_105(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3], buffer[position + 4], buffer[position + 5], buffer[position + 6], buffer[position + 7]);
                                            data.Latitude = c5.getLat();
                                            data.Longitude = c5.getLong();
                                            position = position + 8;
                                            break;

                                        case 6://I062/100 Calculated Track Position (Cartesian) 
                                            I062_100 c6 = new I062_100(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3], buffer[position + 4], buffer[position + 5]);
                                            data.X = c6.getX();
                                            data.Y = c6.getY();
                                            position = position + 6;
                                            break;

                                        case 7://I062/185 Calculated Track Velocity (Cartesian) 
                                            I062_185 c7 = new I062_185(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3]);
                                            data.Vx = c7.getVx();
                                            data.Vy = c7.getVy();
                                            position = position + 4;
                                            break;

                                        case 8:// I062 / 210 Calculated Acceleration(Cartesian)
                                            I062_210 c8 = new I062_210(buffer[position], buffer[position + 1]);
                                            data.Ax = c8.getAx();
                                            data.Ay = c8.getAy();
                                            position = position + 2;
                                            break;

                                        case 9://I062/060 Track Mode 3/A Code
                                            I062_060 c9 = new I062_060(buffer[position], buffer[position + 1]);
                                            data.IsValidated = c9.isValidated();
                                            data.IsGarbled_code = c9.isGarbled();
                                            data.Is3aChanged = c9.isChange3A();
                                            data.Octal_mode3A = c9.getOctal3A();
                                            position = position + 2;
                                            break;

                                        case 10://I062/245 Target Identification
                                            I062_245 c10 = new I062_245(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3], buffer[position + 4], buffer[position + 5], buffer[position + 6]);
                                            data.Target_id_status = c10.getTargetIdStatus();
                                            data.Target_id_245 = c10.getTargetId();
                                            position = position + 7;
                                            break;

                                        case 11://I062/380 Aircraft Derived Data (1+)
                                            I062_380 c11 = new I062_380();
                                            string data_air_str = "";
                                            bool fx = true;
                                            int r;//length frns counter
                                            for (r = 0; fx; r++)
                                            {
                                                fx = false;
                                                string var1 = Convert.ToString(buffer[position + r], 2);
                                                if (Convert.ToString(var1[var1.Length - 1]).Equals("1"))
                                                {
                                                    fx = true;
                                                }
                                                var1 = var1.Remove(var1.Length - 1);
                                                while (var1.Length < 7)
                                                {
                                                    var1 = "0" + var1;//padding
                                                }
                                                data_air_str = data_air_str + var1;
                                            }

                                            position = position + r;

                                            for (int t = 0; t < data_air_str.Length; t++)
                                            {
                                                if (Convert.ToString(data_air_str[t]).Equals("1"))
                                                {
                                                    switch (t + 1)
                                                    {
                                                        //ocet 1
                                                        case 1://ADR
                                                            data.Target_addr = c11.getTargetAddress(buffer[position], buffer[position + 1], buffer[position + 2]);
                                                            position = position + 3;
                                                            break;

                                                        case 2://ID
                                                            data.Target_id_380 = c11.getTargetId(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3], buffer[position + 4], buffer[position + 5]);
                                                            position = position + 6;
                                                            break;

                                                        case 3://MHG
                                                            data.Mag_heading = c11.GetMag_heading(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 4://IAS/Mach
                                                            data.IsMach = c11.isMach(buffer[position]);
                                                            data.Ias_or_Mach = c11.getIas_or_mach(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 5://TAS
                                                            data.Tas = c11.getTas(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 6://SAL
                                                            data.IsSas = c11.IsSas(buffer[position]);
                                                            data.Source = c11.getSource(buffer[position]);
                                                            data.Fms_altitude = c11.getAltitude(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 7://FSS
                                                            data.IsManageVertical = c11.IsManageVertical(buffer[position]);
                                                            data.IsAltitudeHold = c11.IsAltHold(buffer[position]);
                                                            data.IsApproachMode = c11.IsApprMode(buffer[position]);
                                                            data.Fms_final_state_altitude = c11.getFinalStateAlt(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 8://TIS
                                                            data.isTrajIntentAviable = c11.isTrajIntentAviable(buffer[position]);
                                                            data.isTrajIntentValid = c11.isTrajIntentValid(buffer[position]);
                                                            while (c11.is8fx(buffer[position]))
                                                            {
                                                                position++;

                                                            }
                                                            position++;
                                                            break;
                                                        //////////////////////////////////////////////////////////////preguntar si el cas 9 es posa dins del 8
                                                        case 9:
                                                            data.Rep_traj_int_fact = c11.getTrajIntRepFactor(buffer[position]);
                                                            data.isTcp_available = c11.isTcpAviable(buffer[position + 1]);
                                                            data.isTcp_compilance = c11.isTcpCompliance(buffer[position + 1]);
                                                            data.Traj_chang_point = c11.getTraj_chang_point(buffer[position + 1]);
                                                            data.Alt_traj_itent = c11.getTrajIntAltitude(buffer[position + 2], buffer[position + 3]);
                                                            data.Lat_traj_int_wgs84 = c11.getLatWGS84(buffer[position + 4], buffer[position + 5], buffer[position + 6]);
                                                            data.Long_traj_int_wgs84 = c11.getLongWGS84(buffer[position + 7], buffer[position + 8], buffer[position + 9]);
                                                            data.Point_type = c11.getPointType(buffer[position + 10]);
                                                            data.Td = c11.getTd(buffer[position + 10]);
                                                            data.isTurn_radius_available = c11.isTurnRdiusAvailable(buffer[position + 10]);
                                                            data.isTov_available = c11.isTOVsAvailable(buffer[position + 10]);
                                                            data.Time_over_time = c11.getTimeOverPoint(buffer[position + 11], buffer[position + 12], buffer[position + 13]);
                                                            data.Tcp_trun_radius = c11.getTcpTurnRadius(buffer[position + 14], buffer[position + 15]);
                                                            position = position + 16;
                                                            break;

                                                        case 10://Communications/ACAS Capability and Flight Status reported by Mode-S 
                                                            data.Comm_capability_transpond = c11.getComm_capability_transponder(buffer[position]);
                                                            data.Flight_status = c11.getFlightStatus(buffer[position]);
                                                            data.isSpecific_capability = c11.isSpecificServiceCapability(buffer[position + 1]);
                                                            data.Alt_capability = c11.getAltitudeCapability(buffer[position + 1]);
                                                            data.isAircraft_id_capability = c11.isIdCapability(buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 11:
                                                            data.Acas_adsb = c11.getAcas_adsb(buffer[position]);
                                                            data.Mult_nav_aids_adsb = c11.getMultNav_adsb(buffer[position]);
                                                            data.Diff_correlation_adsb = c11.getDiffCorrection_adsb(buffer[position]);
                                                            data.isTranpond_ground_bit_set_adsb = c11.isTranspondGroundBitSet_adsb(buffer[position]);
                                                            data.Flight_stat_adsb = c11.getFlightStatus_adsb(buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 12:
                                                            position = position + 7;
                                                            break;

                                                        case 13:
                                                            data.Barom_vert_rate = c11.getBaromVertRate(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 14:
                                                            data.Geom_vert_rate = c11.getGeomVertRate(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 15:
                                                            data.Roll_angle = c11.getRollAnle(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 16:
                                                            data.Turn_indicator = c11.getTurnIndicator(buffer[position]);
                                                            data.Rate_of_turn = c11.getRateOfTurn(buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 17:
                                                            data.Track_angle = c11.getTrackAnle(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 18://GS
                                                            data.GS = c11.getGS(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 19:
                                                            data.Vel_uncert_cat = buffer[position];
                                                            position++;
                                                            break;

                                                        case 20:
                                                            if (c11.isWindSpeedValid(buffer[position]))
                                                            {
                                                                data.Wind_speed = c11.getWindSpeed(buffer[position + 1], buffer[position + 2]);
                                                            }
                                                            if (c11.isWindDirectionValid(buffer[position]))
                                                            {
                                                                data.Wind_direction = c11.getWindDir(buffer[position + 3], buffer[position + 4]);
                                                            }
                                                            if (c11.isTempValid(buffer[position]))
                                                            {
                                                                data.Temperature = c11.getTemp(buffer[position + 5], buffer[position + 6]);
                                                            }
                                                            if (c11.isTurbValid(buffer[position]))
                                                            {
                                                                data.Turbulence = c11.getTurbulence(buffer[position + 7]);
                                                            }
                                                            position = position + 8;
                                                            break;

                                                        case 21:
                                                            data.Emitter_cat = c11.getEcat(buffer[position]);
                                                            position++;
                                                            break;

                                                        case 22:
                                                            data.Aircraft_derived_latWGS84 = c11.getLatWGS84(buffer[position], buffer[position + 1], buffer[position + 2]);
                                                            data.Aircraft_derived_longWGS84 = c11.getLongWGS84(buffer[position + 3], buffer[position + 4], buffer[position + 5]);
                                                            position = position + 6;
                                                            break;

                                                        case 23:
                                                            data.Geom_alt = c11.getGeomAltitude(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 24:
                                                            data.Position_uncert = c11.getPosUncert(buffer[position]);
                                                            position++;
                                                            break;

                                                        case 25:
                                                            //NO
                                                            position = position + 9;
                                                            break;

                                                        case 26:
                                                            data.Ias = c11.getIas(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 27:
                                                            data.Mach = c11.getMach(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                        case 28:
                                                            data.Barom_press_sett = c11.getBaromPressSett(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;

                                                    }
                                                }
                                            }
                                            break;

                                        case 12://I062/040 Track Number
                                            I062_040 c12 = new I062_040(buffer[position], buffer[position + 1]);
                                            data.Track_num = c12.getTrackNum();
                                            position = position + 2;
                                            break;

                                        case 13://I062/080 Track Status (1+)
                                            I062_080 c13 = new I062_080();

                                            c13.structure(buffer[position]);
                                            data.IsMonosensor = c13.IsMonosource();
                                            data.IsSPI = c13.IsSPI();
                                            data.Most_reliable_height = c13.getMrh();
                                            data.Source_080 = c13.getSrc();
                                            data.IsTrackConfirmed = c13.IsCnf();

                                            position++;

                                            string var2 = Convert.ToString(buffer[position - 1], 2);
                                            if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                            {
                                                c13.ext1(buffer[position]);
                                                data.Type_of_track = c13.getTypeOfTrack(); ;
                                                data.IsLast_Msg = c13.isLastMsg();
                                                data.IsFirst_Msg = c13.isFirstMsg();
                                                data.IsFlight_plan_correlated = c13.isFlightPlanCorrelated();
                                                data.IsAdsb_inconsistent = c13.isAdsbInconsistent();
                                                data.IsSlave_track_promotion = c13.isSlaveTrackPromotion();
                                                data.Service_used = c13.getServiceUsed();

                                                position++;

                                                var2 = Convert.ToString(buffer[position - 1], 2);
                                                if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                                {
                                                    c13.ext2(buffer[position]);
                                                    data.IsAmalgamation = c13.isAmalgamation();
                                                    data.Type_of_target_int4 = c13.getTypeOfTargetInt4();
                                                    data.IsMilitary_emergency = c13.isMilitaryEmergency();
                                                    data.IsMilitary_id = c13.isMilitaryId();
                                                    data.Type_of_target_int5 = c13.getTypeOfTargetInt5();

                                                    position++;

                                                    var2 = Convert.ToString(buffer[position - 1], 2);
                                                    if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                                    {
                                                        c13.ext3(buffer[position]);
                                                        data.IsAge_of_trackUpdate_higher_than_thold = c13.Is_age_of_trackUpdate_higher_than_thold();
                                                        data.IsAge_of_PSR_higher_than_thold = c13.Is_age_of_PSR_higher_than_thold();
                                                        data.IsAge_of_SSR_higher_than_thold = c13.Is_age_of_SSR_higher_than_thold();
                                                        data.IsAge_of_ModeS_higher_than_thold = c13.Is_age_of_ModeS_higher_than_thold();
                                                        data.IsAge_of_ADSB_higher_than_thold = c13.Is_age_of_ADSB_higher_than_thold();
                                                        data.IsSpecial_used_code = c13.Is_special_used_code();
                                                        data.IsAssigned_modeA_code_conflict = c13.Is_assigned_modeA_code_conflict();

                                                        position++;

                                                        var2 = Convert.ToString(buffer[position - 1], 2);
                                                        if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                                        {
                                                            c13.ext4(buffer[position]);
                                                            data.Surveillance_data_status = c13.Surveillance_data_status();
                                                            data.Emergency_status_indication = c13.Emergency_status_indication();
                                                            data.IsPotential_false_track_indication = c13.IsPotential_false_track_indication();
                                                            data.IsTrack_created_FPLdata = c13.IsTrack_created_FPLdata();

                                                            position++;

                                                            var2 = Convert.ToString(buffer[position - 1], 2);
                                                            if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                                            {
                                                                c13.ext5(buffer[position]);
                                                                data.IsDuplicate_3Acode = c13.IsDuplicate3Acode();
                                                                data.IsDuplicate_flight_plan = c13.IsDuplicateFlightPlan();
                                                                data.IsDuplicate_fplan_for_manual_corr = c13.IsDuplicateFplanForManualCorr();
                                                                data.IsSurface_target = c13.IsSurfaceTarget();
                                                                data.IsDuplicate_flight_id = c13.IsDuplicateFlightId();
                                                                data.IsInconsistent_emerg_code = c13.IsInconsistentEmergCode();

                                                                position++;
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            break;

                                        case 14://I062/290 System Track Update Ages (1+)
                                            I062_290 c14 = new I062_290();
                                            string system_ages = "";
                                            bool fx_ages = true;
                                            int o;//length frns counter
                                            for (o = 0; fx_ages && o < 2; o++)
                                            {
                                                fx_ages = false;
                                                string var1 = Convert.ToString(buffer[position + o], 2);
                                                if (Convert.ToString(var1[var1.Length - 1]).Equals("1"))
                                                {
                                                    fx_ages = true;
                                                }
                                                var1 = var1.Remove(var1.Length - 1);
                                                while (var1.Length < 7)
                                                {
                                                    var1 = "0" + var1;//padding
                                                }
                                                system_ages = system_ages + var1;
                                            }

                                            position = position + o;

                                            for (int t = 0; t < system_ages.Length; t++)
                                            {
                                                if (Convert.ToString(system_ages[t]).Equals("1"))
                                                {
                                                    switch (t + 1)
                                                    {
                                                        case 1:
                                                            data.Track_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 2:
                                                            data.Psr_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 3:
                                                            data.Ssr_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 4:
                                                            data.Mode_s_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 5:
                                                            data.Adsc_age = c14.get2oct(buffer[position], buffer[position + 1]);
                                                            position = position + 2;
                                                            break;
                                                        case 6:
                                                            data.Adsb_ext_sq_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 7:
                                                            data.Adsb_vdl_mode4_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 8:
                                                            data.Adsb_uat_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 9:
                                                            data.Loop_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 10:
                                                            data.Multilater_age = c14.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                    }
                                                }
                                            }

                                            break;

                                        case 15://I062/200 Mode of Movement 
                                            I062_200 c15 = new I062_200(buffer[position]);
                                            string status_movement_trans = c15.getMovementTrans();
                                            string status_movement_long = c15.getMovementLong();
                                            string status_movement_vert = c15.getMovementVert();
                                            bool altitude_discrepacy = c15.isAltitudeDiscrep();
                                            data.Status_movement_trans = status_movement_trans;
                                            data.Status_movement_long = status_movement_long;
                                            data.Status_movement_vert = status_movement_vert;
                                            data.IsAltitudeDiscrepacy = altitude_discrepacy;
                                            position++;

                                            break;

                                        case 16://I062/295 Track Data Ages (1+)
                                            I062_295 c16 = new I062_295();

                                            string track_ages = "";
                                            bool fx_track_ages = true;
                                            int w;//length frns counter
                                            for (w = 0; fx_track_ages && w < 2; w++)
                                            {
                                                fx_track_ages = false;
                                                string var1 = Convert.ToString(buffer[position + w], 2);
                                                if (Convert.ToString(var1[var1.Length - 1]).Equals("1"))
                                                {
                                                    fx_track_ages = true;
                                                }
                                                var1 = var1.Remove(var1.Length - 1);
                                                while (var1.Length < 7)
                                                {
                                                    var1 = "0" + var1;//padding
                                                }
                                                track_ages = track_ages + var1;
                                            }

                                            position = position + w;

                                            for (int t = 0; t < track_ages.Length; t++)
                                            {
                                                if (Convert.ToString(track_ages[t]).Equals("1"))
                                                {
                                                    switch (t + 1)
                                                    {
                                                        case 1:
                                                            data.Meas_fl_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 2:
                                                            data.Mode1_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 3:
                                                            data.Mode2_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 4:
                                                            data.Mode3A_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 5:
                                                            data.Mode4_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 6:
                                                            data.Mode5A_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 7:
                                                            data.Mag_head_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 8:
                                                            data.Ias_mach_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 9:
                                                            data.Tas_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 10:
                                                            data.Select_alt_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 11:
                                                            data.Fin_select_alt_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 12:
                                                            data.Traj_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 13:
                                                            data.Comm_acas_flight_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 14:
                                                            data.Stat_by_adsb_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 15:
                                                            data.Acas_resol_advisory_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 16:
                                                            data.Baromet_vert_rate_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 17:
                                                            data.Geomet_vert_rate_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 18:
                                                            data.Roll_angle_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 19:
                                                            data.Track_angle_rate_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 20:
                                                            data.Track_angle_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 21:
                                                            data.Gs_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 22:
                                                            data.Vel_uncert_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 23:
                                                            data.Metd_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 24:
                                                            data.Emitt_cat_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 25:
                                                            data.Pos_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 26:
                                                            data.Geom_alt_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 27:
                                                            data.Pos_uncert_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 28:
                                                            data.ModeSMB_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 29:
                                                            data.Ias_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 30:
                                                            data.Mach_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;
                                                        case 31:
                                                            data.Barom_press_sett_age = c16.get1oct(buffer[position]);
                                                            position++;
                                                            break;

                                                    }
                                                }
                                            }
                                            break;

                                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                        case 17://I062/136 Measured Flight Level 
                                            I062_136 c17 = new I062_136(buffer[position], buffer[position + 1]);
                                            data.FL = c17.getFl();
                                            position = position + 2;
                                            break;

                                        case 18://I062/130 Calculated Track Geometric Altitude 
                                            I062_130 c18 = new I062_130(buffer[position], buffer[position + 1]);
                                            data.TGA = c18.getTga();
                                            position = position + 2;
                                            break;

                                        case 19://I062/135 Calculated Track Barometric Altitude 
                                            I062_135 c19 = new I062_135(buffer[position], buffer[position + 1]);
                                            data.TBA = c19.getTba();
                                            data.CorrectionQNH = c19.getCorrectQNH();
                                            position = position + 2;
                                            break;

                                        case 20://062/220 Calculated Rate Of Climb/Descent
                                            I062_220 c20 = new I062_220(buffer[position], buffer[position + 1]);
                                            data.Rate = c20.getRate();
                                            position = position + 2;
                                            break;

                                        case 21: //I062/390 Flight Plan Related Data (1+)
                                            string total_data = "";
                                            bool fx_data = true;
                                            Basic_functions bf = new Basic_functions();
                                            int l;//length frns counter
                                            for (l = 0; fx_data && l < 3; l++)
                                            {
                                                fx_data = false;
                                                string oct = Convert.ToString(buffer[position + l], 2);
                                                oct = bf.padding(oct);
                                                if (oct[7].Equals('1'))
                                                {
                                                    fx_data = true;
                                                }
                                            }
                                            position = position + l;
                                            for (int i = 0; i < total_data.Length; i++)
                                            {
                                                if (total_data[i].Equals('1'))
                                                {
                                                    switch (i)
                                                    {
                                                        case 0: //FPPS Identification Tag
                                                            data.TAG = "SI";
                                                            position = position + 2;
                                                            break;
                                                        case 1: //Callsign
                                                            data.CSN = "SI";
                                                            position = position + 7;
                                                            break;
                                                        case 2: //IFPS_FLIGHT_ID
                                                            data.IFI = "SI";
                                                            position = position + 4;
                                                            break;
                                                        case 3: //Flight Category 
                                                            data.FCT = "SI";
                                                            position = position + 1;
                                                            break;
                                                        case 4: //Type of Aircraft 
                                                            data.TAC = "SI";
                                                            position = position + 4;
                                                            break;
                                                        case 5: //Wake Turbulence Category 
                                                            data.WTC = "SI";
                                                            position = position + 1;
                                                            break;
                                                        case 6: //Departure Airport 
                                                            data.DEP = "SI";
                                                            position = position + 4;
                                                            break;
                                                        case 7: //FX
                                                            break;
                                                        case 8: //Destination Airport 
                                                            data.DST = "SI";
                                                            position = position + 4;
                                                            break;
                                                        case 9: //Runway Designation
                                                            data.RDS = "SI";
                                                            position = position + 3;
                                                            break;
                                                        case 10: //Current Cleared Flight Level 
                                                            data.CFL = "SI";
                                                            position = position + 2;
                                                            break;
                                                        case 11: //Current Control Position
                                                            data.CTL = "SI";
                                                            position = position + 2;
                                                            break;
                                                        case 12: //Time of Departure / Arrival 
                                                            data.TOD = "SI";
                                                            position = position + 5;
                                                            break;
                                                        case 13: //Aircraft Stand 
                                                            data.AST = "SI";
                                                            position = position + 6;
                                                            break;
                                                        case 14: //Stand Status
                                                            data.STS = "SI";
                                                            position = position + 1;
                                                            break;
                                                        case 15: //FX
                                                            break;
                                                        case 16: //Standard Instrument Departure
                                                            data.STD = "SI";
                                                            position = position + 7;
                                                            break;
                                                        case 17: //STandard Instrument ARrival
                                                            data.STA = "SI";
                                                            position = position + 7;
                                                            break;
                                                        case 18: //Pre-emergency Mode 3/A code 
                                                            data.PEM = "SI";
                                                            position = position + 2;
                                                            break;
                                                        case 19: // Pre-emergency Callsign 
                                                            data.PEC = "SI";
                                                            position = position + 7;
                                                            break;
                                                    }
                                                }
                                                else 
                                                {
                                                    switch (i)
                                                    {
                                                        case 0: //FPPS Identification Tag
                                                            data.TAG = "NO";
                                                            break;
                                                        case 1: //Callsign
                                                            data.CSN = "NO";
                                                            break;
                                                        case 2: //IFPS_FLIGHT_ID
                                                            data.IFI = "NO";
                                                            break;
                                                        case 3: //Flight Category 
                                                            data.FCT = "NO";
                                                            break;
                                                        case 4: //Type of Aircraft 
                                                            data.TAC = "NO";
                                                            break;
                                                        case 5: //Wake Turbulence Category 
                                                            data.WTC = "NO";
                                                            break;
                                                        case 6: //Departure Airport 
                                                            data.DEP = "NO";
                                                            break;
                                                        case 7: //FX
                                                            break;
                                                        case 8: //Destination Airport 
                                                            data.DST = "NO";
                                                            break;
                                                        case 9: //Runway Designation
                                                            data.RDS = "NO";
                                                            break;
                                                        case 10: //Current Cleared Flight Level 
                                                            data.CFL = "NO";
                                                            break;
                                                        case 11: //Current Control Position
                                                            data.CTL = "NO";
                                                            break;
                                                        case 12: //Time of Departure / Arrival 
                                                            data.TOD = "NO";
                                                            break;
                                                        case 13: //Aircraft Stand 
                                                            data.AST = "NO";
                                                            break;
                                                        case 14: //Stand Status
                                                            data.STS = "NO";
                                                            break;
                                                        case 15: //FX
                                                            break;
                                                        case 16: //Standard Instrument Departure
                                                            data.STD = "NO";
                                                            break;
                                                        case 17: //STandard Instrument ARrival
                                                            data.STA = "NO";
                                                            break;
                                                        case 18: //Pre-emergency Mode 3/A code 
                                                            data.PEM = "NO";
                                                            break;
                                                        case 19: // Pre-emergency Callsign 
                                                            data.PEC = "NO";
                                                            break;
                                                    }
                                                }
                                            }
                                            break;

                                        case 22: //I062/270 Target Size & Orientation 
                                                 ///////NOOO!!!!!!!!!!!!!!!!
                                            break;

                                        case 23: // I062/300 Vehicle Fleet Identification 
                                            I062_300 c23 = new I062_300(buffer[position]);
                                            data.Vehicle = c23.getVehicle();
                                            position = position + 1;
                                            break;

                                        case 24://I062/110 Mode 5 Data reports & Extended Mode 1 Code (1+) ???????????????????
                                            string octeto = Convert.ToString(buffer[position], 2);
                                            position = position + 1;
                                            data.TOS_VAL = 0;
                                            for (int i = 0; i < octeto.Length; i++)
                                            {
                                                if (octeto[i].Equals('1'))
                                                {
                                                    switch (i)
                                                    {
                                                        case 0: //Mode 5 Summary
                                                            data.SUM = true;
                                                            I062_110_SUM c24_0 = new I062_110_SUM(buffer[position]);
                                                            data.M5 = c24_0.getM5();
                                                            data.ID = c24_0.getID();
                                                            data.DA = c24_0.getDA();
                                                            data.M1 = c24_0.getM1();
                                                            data.M2 = c24_0.getM2();
                                                            data.M3 = c24_0.getM3();
                                                            data.MC = c24_0.getMC();
                                                            data.X_110 = c24_0.getX_110();
                                                            position = position + 1;
                                                            break;

                                                        case 1: //Mode 5 PIN/ National
                                                            data.PMN = true;
                                                            I062_110_PMN c24_1 = new I062_110_PMN(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3]);
                                                            data.PIN = c24_1.getPIN();
                                                            data.NAT = c24_1.getNAT();
                                                            data.MIS = c24_1.getMIS();
                                                            position = position + 4;
                                                            break;
                                                        case 2: //Mode 5 Reported Position
                                                            data.POS = true;
                                                            I062_110_POS c24_2 = new I062_110_POS(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3], buffer[position + 4], buffer[position + 5]);
                                                            data.LONG_M5 = c24_2.getLong();
                                                            data.LAT_M5 = c24_2.getLat();
                                                            position = position + 6;
                                                            break;
                                                        case 3: //Mode 5 GNSS-derived Altitude
                                                            data.GA = true;
                                                            I062_110_GA c24_3 = new I062_110_GA(buffer[position], buffer[position + 1]);
                                                            data.ALT_GNSS = c24_3.getAltitudeGNSS();
                                                            data.RES_GNSS = c24_3.getRES();
                                                            position = position + 2;
                                                            break;
                                                        case 4: //Extended Mode 1 Code in Octal
                                                            data.EM1 = true;
                                                            I062_110_EM1 c24_4 = new I062_110_EM1(buffer[position], buffer[position + 1]);
                                                            data.CODE_M1 = c24_4.getCodeM1();
                                                            position = position + 2;
                                                            break;
                                                        case 5: //Time Offset for POS and GA.
                                                            data.TOS = true;
                                                            I062_110_TOS c24_5 = new I062_110_TOS(buffer[position]);
                                                            data.TOS_VAL = c24_5.getTOS();
                                                            position = position + 1;
                                                            break;
                                                        case 6: //Pulse Presence
                                                            data.XP = true;
                                                            I062_110_XP c24_6 = new I062_110_XP(buffer[position]);
                                                            data.X5 = c24_6.getX5();
                                                            data.XC = c24_6.getXC();
                                                            data.X3 = c24_6.getX3();
                                                            data.X2 = c24_6.getX2();
                                                            data.X1 = c24_6.getX1();
                                                            position = position + 1;
                                                            break;
                                                        case 7: //FX
                                                            break;

                                                    }
                                                }
                                            }
                                            break;

                                        case 25: //I062/120 Track Mode 2 Code 
                                            I062_120 c25 = new I062_120(buffer[position], buffer[position + 1]);
                                            data.Octal_mode2A = c25.getOctal2A();
                                            position = position + 2;
                                            break;

                                        case 26: //I062/510 Composed Track Number (3+)
                                                 ////////////////NO
                                            break;

                                        case 27: //I062/500 Estimated Accuracies  
                                                 //NOOO!!!!!!!!!!!!!
                                            break;

                                        case 28: //I062/340 Measured Information (1+)
                                            string oct1 = Convert.ToString(buffer[position], 2);
                                            position = position + 1;
                                            for (int i = 0; i < oct1.Length; i++)
                                            {
                                                char c = oct1[i];
                                                if (c.Equals('1'))
                                                {
                                                    switch (i)
                                                    {
                                                        case 0: //Sensor Identification  ¿tengo que poner los datos en los que ya habia o nueva variable?
                                                            data.SID = true;
                                                            I062_340_SID c28_0 = new I062_340_SID(buffer[position], buffer[position + 1]);
                                                            data.SAC2 = c28_0.getSAC();
                                                            data.SIC2 = c28_0.getSIC();
                                                            position = position + 2;
                                                            break;

                                                        case 1: //Measured Position 
                                                            data.POS_340 = true;
                                                            I062_340_POS c28_1 = new I062_340_POS(buffer[position], buffer[position + 1], buffer[position + 2], buffer[position + 3]);
                                                            data.RHO = c28_1.getRHO();
                                                            data.THETA = c28_1.getTHETA();
                                                            position = position + 4;
                                                            break;

                                                        case 2: //Measured 3-D Height
                                                            data.HEI = true;
                                                            I062_340_HEI c28_2 = new I062_340_HEI(buffer[position], buffer[position + 1]);
                                                            data.HEIGHT = c28_2.getHeight();
                                                            position = position + 2;
                                                            break;

                                                        case 3: //Last Measured Mode C code
                                                            data.MDC = true;
                                                            I062_340_MDC c28_3 = new I062_340_MDC(buffer[position], buffer[position + 1]);
                                                            data.VC = c28_3.getV();
                                                            data.GC = c28_3.getG();
                                                            data.Code_Mc = c28_3.getCodeModeC();
                                                            position = position + 2;
                                                            break;

                                                        case 4: //Last Measured Mode 3/A code  ¿¿¿¿¿¿¿¿hace ref al de la cat 060????????????
                                                            data.MDA = true;
                                                            I062_340_MDA c28_4 = new I062_340_MDA(buffer[position], buffer[position + 1]);
                                                            data.V_mda = c28_4.getV();
                                                            data.G_mda = c28_4.getG();
                                                            data.L_mda = c28_4.getL();
                                                            data.CodeM3A = c28_4.getOctal3A();
                                                            position = position + 2;
                                                            break;

                                                        case 5: //Report Type
                                                            data.TYP = true;
                                                            I062_340_TYP c28_5 = new I062_340_TYP(buffer[position]);
                                                            data.TST = c28_5.getTST();
                                                            data.RAB = c28_5.getRAB();
                                                            data.SIM = c28_5.getSIM();
                                                            data.Typ_val = c28_5.getTYP();
                                                            position = position + 1;
                                                            break;

                                                        case 6: //0
                                                            break;

                                                        case 7: //FX

                                                            break;

                                                    }
                                                }
                                            }
                                            break;

                                        case 29:
                                            break;
                                        case 30:
                                            break;
                                        case 31:
                                            break;
                                        case 32:
                                            break;
                                        case 33:
                                            break;
                                        case 34:
                                            position = position + buffer[position];
                                            break;
                                        case 35:
                                            position = position + buffer[position];
                                            break;

                                    }
                                }
                            }

                            n = n + len;
                            break;

                        default:
                            data.Categoria = buffer[n].ToString();
                            row.Add(data.Categoria);
                            len = ((sbyte)buffer[n + 1]) + ((sbyte)buffer[n + 2]);
                            n = n + len;
                            break;
                    }
                    data.Expanded = false;
                    all_data[k] = data;
                    
                    k++;

                    row.Add(data.Sic.ToString());
                    row.Add(data.Sac.ToString());;
                    row.Add(data.Service_Id.ToString());
                    row.Add(data.Time_track_info.ToString());
                    row.Add(data.Latitude.ToString());
                    row.Add(data.Longitude.ToString());
                    row.Add(data.X.ToString());
                    row.Add(data.Y.ToString());
                    row.Add(data.Vx.ToString());
                    row.Add(data.Vy.ToString());
                    if (data.Ax != 0)
                    {
                        row.Add(data.Ax.ToString()); 
                    }
                    else
                    {
                        row.Add("-");
                    }
                    if (data.Ay != 0)
                    {
                        row.Add(data.Ay.ToString());
                    }
                    else
                    {
                        row.Add("-");
                    }
                    row.Add(data.Octal_mode3A.ToString());
                    if (data.Target_id_status!=null)
                    {
                        row.Add(data.Target_id_status.ToString());
                    }
                    else
                    {
                        row.Add("-");
                    }
                    if (data.Target_id_245 != null)
                    {
                        row.Add(data.Target_id_245.ToString());
                    }
                    else
                    {
                        row.Add("-");
                    }
                    string aircraft_data = "";
                    if (data.Target_addr!=0)
                    {
                        aircraft_data = "ADR = " + data.Target_addr.ToString() + "\n";
                    }
                    if(data.Target_id_380 != null)
                    {
                        aircraft_data = aircraft_data + "ID = " + data.Target_id_380 + "\n";
                    }
                    if (data.Mag_heading!=0)
                    {
                        aircraft_data = aircraft_data + "MHG = " + data.Mag_heading.ToString() + "\n";
                    }
                    if (data.IsMach && data.Ias_or_Mach!=0)
                    {
                        aircraft_data = aircraft_data + "MACH = " + data.Ias_or_Mach.ToString() + "\n";
                    }
                    else if(data.Ias_or_Mach != 0)
                    {
                        aircraft_data = aircraft_data + "IAS = " + data.Ias_or_Mach.ToString() + "\n";
                    }
                    if (data.Tas != 0)
                    {
                        aircraft_data = aircraft_data + "TAS = " + data.Tas.ToString() + "\n";
                    }
                    if(data.IsSas)
                    {
                        aircraft_data = aircraft_data + "Selected Altitude Source Info = "+ data.Source + "\n" +"Selected Altitude = "+ data.Fms_altitude.ToString()+"\n";
                    }
                    if(data.IsManageVertical)
                    {
                        aircraft_data = aircraft_data + "Final State Manage Vertical Mode \n";
                    }
                    if (data.IsAltitudeHold)
                    {
                        aircraft_data = aircraft_data + "Final State Altitude Hold \n";
                    }
                    if (data.IsApproachMode)
                    {
                        aircraft_data = aircraft_data + "Final State Approach Mode \n";
                    }
                    if (data.Fms_final_state_altitude!=0)
                    {
                        aircraft_data = aircraft_data + "Final State Selected Alt = " + data.Fms_final_state_altitude.ToString() + " \n";
                    }
                    if (data.isTrajIntentAviable)
                    {
                        aircraft_data = aircraft_data + "Trajectory Intent Data Available \n";
                    }
                    if (data.isTrajIntentValid)
                    {
                        aircraft_data = aircraft_data + "Trajectory Intent Data Valid \n";
                    }
                    if (data.Rep_traj_int_fact!=0)
                    {
                        aircraft_data = aircraft_data + "Repetition Factor Trajectory Intent Data = " + data.Rep_traj_int_fact.ToString() + " \n";
                    }
                    if (data.isTcp_available)
                    {
                        aircraft_data = aircraft_data + "TCP Available \n";
                    }
                    if (data.isTcp_compilance)
                    {
                        aircraft_data = aircraft_data + "TCP Compilance \n";
                    }
                    if (data.Traj_chang_point!=0)
                    {
                        aircraft_data = aircraft_data + "TCP Number"+ data.Traj_chang_point.ToString()+ "\n";
                    }
                    if (data.Alt_traj_itent != 0)
                    {
                        aircraft_data = aircraft_data + "Trajectory Intent Data Alt = "+data.Alt_traj_itent.ToString() + "\n";
                    }
                    if (data.Lat_traj_int_wgs84 != 0)
                    {
                        aircraft_data = aircraft_data + "Trajectory Intent Data Lat = " + data.Lat_traj_int_wgs84.ToString() + "\n";
                    }
                    if (data.Long_traj_int_wgs84 != 0)
                    {
                        aircraft_data = aircraft_data + "Trajectory Intent Data Long = " + data.Long_traj_int_wgs84.ToString() + "\n";
                    }
                    if (data.Point_type != null)
                    {
                        aircraft_data = aircraft_data + "Point Type  = " + data.Point_type + "\n";
                    }
                    if (data.Td != null)
                    {
                        aircraft_data = aircraft_data + "TD  = " + data.Td + "\n";
                    }
                    if (data.isTurn_radius_available)
                    {
                        aircraft_data = aircraft_data + "TTR aviable" + "\n";
                    }
                    if (data.isTov_available)
                    {
                        aircraft_data = aircraft_data + "TOV aviable" + "\n";
                    }
                    if (data.Time_over_time!=0)
                    {
                        aircraft_data = aircraft_data + "Time Over Time = " + data.Time_over_time.ToString() + "\n";
                    }
                    if (data.Tcp_trun_radius != 0)
                    {
                        aircraft_data = aircraft_data + "Tcp Trun Radius  = " + data.Tcp_trun_radius.ToString() + "\n";
                    }
                    if (data.Comm_capability_transpond!=null)
                    {
                        aircraft_data = aircraft_data + "Capability of the Transponder  = " + data.Comm_capability_transpond + "\n";
                    }
                    if (data.Flight_status != null)
                    {
                        aircraft_data = aircraft_data + "Flight Status  = " + data.Flight_status + "\n";
                    }
                    if (data.isSpecific_capability)
                    {
                        aircraft_data = aircraft_data + "Specific service capability" + "\n";
                    }  
                    if (data.Alt_capability != null)
                    {
                        aircraft_data = aircraft_data + "Alt Capability  = " + data.Alt_capability + "\n";
                    }
                    if (data.isAircraft_id_capability)
                    {
                        aircraft_data = aircraft_data + "Aircraft Identification Capability" + "\n";
                    }
                    if (data.Acas_adsb != null)
                    {
                        aircraft_data = aircraft_data + "ACAS ADS-B  = " + data.Acas_adsb + "\n";
                    }
                    if (data.Mult_nav_aids_adsb != null)
                    {
                        aircraft_data = aircraft_data + "MN  = " + data.Mult_nav_aids_adsb + "\n";
                    }
                    if (data.Diff_correlation_adsb != null)
                    {
                        aircraft_data = aircraft_data + "DC  = " + data.Diff_correlation_adsb + "\n";
                    }
                    if (data.isTranpond_ground_bit_set_adsb)
                    {
                        aircraft_data = aircraft_data + "Tranpond Ground Bit Set \n";
                    }
                    if (data.Flight_stat_adsb != null)
                    {
                        aircraft_data = aircraft_data + "STAT  = " + data.Flight_stat_adsb + "\n";
                    }
                    if (data.Barom_vert_rate != 0)
                    {
                        aircraft_data = aircraft_data + "Barom Vert Rate  = " + data.Barom_vert_rate.ToString() + "\n";
                    }
                    if (data.Geom_vert_rate != 0)
                    {
                        aircraft_data = aircraft_data + "Geom Vert Rate  = " + data.Geom_vert_rate.ToString() + "\n";
                    }
                    if (data.Roll_angle != 0)
                    {
                        aircraft_data = aircraft_data + "Roll Angle  = " + data.Roll_angle.ToString() + "\n";
                    }
                    if (data.Turn_indicator != null)
                    {
                        aircraft_data = aircraft_data + "Turn Indicator  = " + data.Turn_indicator + "\n";
                    }
                    if (data.Rate_of_turn != 0)
                    {
                        aircraft_data = aircraft_data + "Rate Of Turn  = " + data.Rate_of_turn.ToString() + "\n";
                    }
                    if (data.Track_angle != 0)
                    {
                        aircraft_data = aircraft_data + "Track Angle  = " + data.Track_angle.ToString() + "\n";
                    }
                    if (data.GS != 0)
                    {
                        aircraft_data = aircraft_data + "GS = " + data.GS.ToString() + "\n";
                    }
                    if (data.Vel_uncert_cat != 0)
                    {
                        aircraft_data = aircraft_data + "Vel Uncert Cat = " + data.Vel_uncert_cat.ToString() + "\n";
                    }
                    if (data.Wind_speed != 0)
                    {
                        aircraft_data = aircraft_data + "Wind Speed = " + data.Wind_speed.ToString() + "\n";
                    }
                    if (data.Wind_direction != 0)
                    {
                        aircraft_data = aircraft_data + "Wind Direction = " + data.Wind_direction.ToString() + "\n";
                    }
                    if (data.Temperature != 0)
                    {
                        aircraft_data = aircraft_data + "Temperature = " + data.Temperature.ToString() + "\n";
                    }
                    if (data.Turbulence != 0)
                    {
                        aircraft_data = aircraft_data + "Turbulence = " + data.Turbulence.ToString() + "\n";
                    }
                    if (data.Emitter_cat != null)
                    {
                        aircraft_data = aircraft_data + "ECAT = " + data.Emitter_cat + "\n";
                    }
                    if (data.Aircraft_derived_latWGS84 != 0)
                    {
                        aircraft_data = aircraft_data + "Lat WGS84 = " + data.Aircraft_derived_latWGS84.ToString() + "\n";
                    }
                    if (data.Aircraft_derived_longWGS84 != 0)
                    {
                        aircraft_data = aircraft_data + "Long WGS84 = " + data.Aircraft_derived_longWGS84.ToString() + "\n";
                    }
                    if (data.Geom_alt != 0)
                    {
                        aircraft_data = aircraft_data + "Geom Alt = " + data.Geom_alt.ToString() + "\n";
                    }
                    if (data.Position_uncert != 0)
                    {
                        aircraft_data = aircraft_data + "Position Uncert = " + data.Position_uncert.ToString() + "\n";
                    }
                    if (data.Ias != 0)
                    {
                        aircraft_data = aircraft_data + "IAS = " + data.Ias.ToString() + "\n";
                    }
                    if (data.Mach != 0)
                    {
                        aircraft_data = aircraft_data + "MACH = " + data.Mach.ToString() + "\n";
                    }
                    if (data.Barom_press_sett != 0)
                    {
                        aircraft_data = aircraft_data + "Barometric pression = " + data.Barom_press_sett.ToString() + "\n";
                    }
                    if (aircraft_data == "")
                    {
                        aircraft_data = "-";
                                                                                                                                                                                                                                                                                                                                           }
                    row.Add(aircraft_data);
                    row.Add(data.Track_num.ToString());
                    string track_status = "";
                    if (data.IsMonosensor)
                    {
                        track_status = "Monosensor track \n";
                    }
                    if (data.IsSPI)       
                    {                                                                                                                                                                                                                    track_status = track_status + "SPI present \n";
                    }
                    if (data.Most_reliable_height!=null)
                    {
                        track_status = track_status + "Most Reliable Heigh = "+ data.Most_reliable_height + "\n";
                    }
                    if (data.Source_080 != null)
                    {
                        track_status = track_status + "SRC = " + data.Source_080 + "\n";
                    }
                    if (data.IsTrackConfirmed)
                    {
                        track_status = track_status + "Confirmed track \n";
                    }
                    if (data.Type_of_track!=null)
                    {
                        track_status = track_status + "Type Of Track = " + data.Type_of_track + "\n";
                    }
                    if (data.IsLast_Msg)
                    {
                        track_status = track_status + "Last msg tx to user \n";
                    }
                    if (data.IsFlight_plan_correlated)
                    {
                        track_status = track_status + "Flight Plan Correlated \n";
                    }
                    if (data.IsAdsb_inconsistent)
                    {
                         track_status = track_status + "ADS-B inconsistent with other info\n";
                    }
                    if (data.IsSlave_track_promotion)
                    {
                        track_status = track_status + "Slave Track Promotion \n";
                    }
                    if (data.Service_used!=null)
                    {
                        track_status = track_status + "Service Used = " + data.Service_used + "\n";
                    }
                    if (data.IsAmalgamation)
                    {
                        track_status = track_status + "Amalgamation Process \n";
                    }
                    if (data.Type_of_target_int4!=null)
                    {
                        track_status = track_status + "Mode 4 interrogation = " + data.Type_of_target_int4 + "\n";
                    }
                    if (data.IsMilitary_emergency)
                    {
                        track_status = track_status + "Military Emergency \n";
                    }
                    if (data.IsMilitary_id)
                    {
                        track_status = track_status + "Military ID in last report \n";
                    }
                    if (data.Type_of_target_int5!=null)
                    {
                        track_status = track_status + "Mode 5 interrogation = " + data.Type_of_target_int5 + "\n";
                    }
                    if (data.IsAge_of_trackUpdate_higher_than_thold)
                    {
                        track_status = track_status + "Age Of Track Update Higher Than Threshold \n";
                    }
                    if (data.IsAge_of_PSR_higher_than_thold)
                    {
                        track_status = track_status + "Age Of PSR Higher Than Threshold \n";
                    }
                    if (data.IsAge_of_SSR_higher_than_thold)
                    {
                        track_status = track_status + "Age Of SSR Higher Than Threshold \n";
                    }
                    if (data.IsAge_of_ModeS_higher_than_thold)
                    {
                        track_status = track_status + "Age Of ModeS Higher Than Threshold \n";
                    }
                    if (data.IsAge_of_ADSB_higher_than_thold)
                    {
                        track_status = track_status + "Age Of ADSB Higher Than Threshold \n";
                    }
                    if (data.IsSpecial_used_code)
                    {
                        track_status = track_status + "Special Used Code \n";
                    }
                    if (data.IsAssigned_modeA_code_conflict)
                    {
                        track_status = track_status + "Assigned ModeA Code Conflict \n";
                    }
                    if (data.Surveillance_data_status!=null)
                    {
                        track_status = track_status + "Surveillance Data Status = " + data.Surveillance_data_status + "\n";
                    }
                    if (data.Emergency_status_indication!=null)
                    {
                        track_status = track_status + "Emergency Status Indication = " + data.Emergency_status_indication + "\n";
                    }
                    if (data.IsPotential_false_track_indication)
                    {
                        track_status = track_status + "Potential False Track Indication \n";
                    }
                    if (data.IsTrack_created_FPLdata)
                    {
                        track_status = track_status + "Track created/updated with FPL data \n";
                    }
                    if (data.IsDuplicate_3Acode)
                    {
                        track_status = track_status + "Duplicate Mode 3/A \n";
                    }
                    if (data.IsDuplicate_flight_plan)
                    {
                        track_status = track_status + "Duplicate Flight Plan \n";
                    }
                    if (data.IsDuplicate_fplan_for_manual_corr)
                    {
                        track_status = track_status + "Duplicate FPlan For Manual Corr. \n";
                    }
                    if (data.IsSurface_target)
                    {
                        track_status = track_status + "Surface Target \n";
                    }
                    if (data.IsDuplicate_flight_id)
                    {
                        track_status = track_status + "Duplicate Flight ID \n";
                    }
                    if (data.IsInconsistent_emerg_code)
                    {
                        track_status = track_status + "Inconsistent Emerg Code \n";
                    }
                    if (track_status == "")
                    {
                        track_status = "-";
                    }
                    row.Add(track_status);
                    string track_update_ages = "";
                    if (data.Track_age != 0)
                    {
                        track_update_ages = track_update_ages + "Track Age = " + data.Track_age.ToString() + "\n";
                    }
                    if (data.Psr_age != 0)
                    {
                        track_update_ages = track_update_ages + "PSR Age = " + data.Psr_age.ToString() + "\n";
                    }
                    if (data.Ssr_age != 0)
                    {
                        track_update_ages = track_update_ages + "SSR Age = " + data.Ssr_age.ToString() + "\n";
                    }
                    if (data.Mode_s_age != 0)
                    {
                        track_update_ages = track_update_ages + "Mode S Age = " + data.Mode_s_age.ToString() + "\n";
                    }
                    if (data.Adsc_age != 0)
                    {
                        track_update_ages = track_update_ages + "ADS-C Age = " + data.Adsc_age.ToString() + "\n";
                    }
                    if (data.Adsb_ext_sq_age != 0)
                    {
                        track_update_ages = track_update_ages + "ES Age = " + data.Adsb_ext_sq_age.ToString() + "\n";
                    }
                    if (data.Adsb_vdl_mode4_age != 0)
                    {
                        track_update_ages = track_update_ages + "VDL Age = " + data.Adsb_vdl_mode4_age.ToString() + "\n";
                    }
                    if (data.Adsb_uat_age != 0)
                    {
                        track_update_ages = track_update_ages + "UAT Age = " + data.Adsb_uat_age.ToString() + "\n";
                    }
                    if (data.Loop_age != 0)
                    {
                        track_update_ages = track_update_ages + "Loop Age = " + data.Loop_age.ToString() + "\n";
                    }
                    if (data.Multilater_age != 0)
                    {
                        track_update_ages = track_update_ages + "Multilateration Age = " + data.Multilater_age.ToString() + "\n";
                    }
                    if (track_update_ages == "")
                    {
                        track_update_ages = "-";
                    }
                    row.Add(track_update_ages);
                    string mode_mov = "";
                    if (data.Status_movement_trans!=null)
                    {
                        mode_mov = mode_mov + "Transversal Acceleration  = " + data.Status_movement_trans + "\n";
                    }
                    if (data.Status_movement_long!=null)
                    {
                        mode_mov = mode_mov + "Longitudinal Acceleration = " + data.Status_movement_long + "\n";
                    }
                    if (data.Status_movement_vert!=null)
                    {
                        mode_mov = mode_mov + "Vertical Rate = " + data.Status_movement_vert + "\n";
                    }
                    if (data.IsAltitudeDiscrepacy)
                    {
                        mode_mov = mode_mov + "Altitude Discrepacy \n";
                    }
                    if (mode_mov == "")
                    {
                        mode_mov = "-";
                    }
                    row.Add(mode_mov);
                    string track_data_age = "";
                    if (data.Meas_fl_age != 0)
                    {
                        track_data_age = track_data_age + "Measured Flight Level Age = " + data.Meas_fl_age.ToString() + "\n";
                    }
                    if (data.Mode1_age != 0)
                    {
                        track_data_age = track_data_age + "Mode 1 Age = " + data.Mode1_age.ToString() + "\n";
                    }
                    if (data.Mode2_age != 0)
                    {
                        track_data_age = track_data_age + "Mode 2 Age = " + data.Mode2_age.ToString() + "\n";
                    }
                    if (data.Mode3A_age != 0)
                    {
                        track_data_age = track_data_age + "Mode 3/A Age = " + data.Mode3A_age.ToString() + "\n";
                    }
                    if (data.Mode4_age != 0)
                    {
                        track_data_age = track_data_age + "Mode 4 Age = " + data.Mode4_age.ToString() + "\n";
                    }
                    if (data.Mode5A_age != 0)
                    {
                        track_data_age = track_data_age + "Mode 5 Age = " + data.Mode5A_age.ToString() + "\n";
                    }
                    if (data.Mag_head_age != 0)
                    {
                        track_data_age = track_data_age + "Magnetic Heading Age = " + data.Mag_head_age.ToString() + "\n";
                    }
                    if (data.Ias_mach_age != 0)
                    {
                        track_data_age = track_data_age + "IAS/MACH Age = " + data.Ias_mach_age.ToString() + "\n";
                    }
                    if (data.Tas_age != 0)
                    {
                        track_data_age = track_data_age + "TAS Age = " + data.Tas_age.ToString() + "\n";
                    }
                    if (data.Select_alt_age != 0)
                    {
                        track_data_age = track_data_age + "Selected Altitude Age = " + data.Select_alt_age.ToString() + "\n";
                    }
                    if (data.Fin_select_alt_age != 0)
                    {
                        track_data_age = track_data_age + "Final State Selected Altitude Age = " + data.Fin_select_alt_age.ToString() + "\n";
                    }
                    if (data.Traj_age != 0)
                    {
                        track_data_age = track_data_age + "Trajectory Intent Age = " + data.Traj_age.ToString() + "\n";
                    }
                    if (data.Comm_acas_flight_age != 0)
                    {
                        track_data_age = track_data_age + "Communication/ACAS Age = " + data.Comm_acas_flight_age.ToString() + "\n";
                    }
                    if (data.Stat_by_adsb_age != 0)
                    {
                        track_data_age = track_data_age + "Status Reported by ADS-B Age = " + data.Stat_by_adsb_age.ToString() + "\n";
                    }
                    if (data.Acas_resol_advisory_age != 0)
                    {
                        track_data_age = track_data_age + "ACAS Resolution Advisory Report Age = " + data.Acas_resol_advisory_age.ToString() + "\n";
                    }
                    if (data.Baromet_vert_rate_age != 0)
                    {
                        track_data_age = track_data_age + "Barometric Vertical Rate Age = " + data.Baromet_vert_rate_age.ToString() + "\n";
                    }
                    if (data.Geomet_vert_rate_age != 0)
                    {
                        track_data_age = track_data_age + "Geometrical Vertical Rate Age = " + data.Geomet_vert_rate_age.ToString() + "\n";
                    }
                    if (data.Roll_angle_age != 0)
                    {
                        track_data_age = track_data_age + "Roll Angle Age = " + data.Roll_angle_age.ToString() + "\n";
                    }
                    if (data.Track_angle_rate_age != 0)
                    {
                        track_data_age = track_data_age + "Track Angle Rate Age = " + data.Track_angle_rate_age.ToString() + "\n";
                    }
                    if (data.Track_angle_age != 0)
                    {
                        track_data_age = track_data_age + "Track Angle Age = " + data.Track_angle_age.ToString() + "\n";
                    }
                    if (data.Gs_age != 0)
                    {
                        track_data_age = track_data_age + "GS Age = " + data.Gs_age.ToString() + "\n";
                    }
                    if (data.Vel_uncert_age != 0)
                    {
                        track_data_age = track_data_age + "Velocity Uncertainty Age = " + data.Vel_uncert_age.ToString() + "\n";
                    }
                    if (data.Metd_age != 0)
                    {
                        track_data_age = track_data_age + "Meteorological Data Age = " + data.Metd_age.ToString() + "\n";
                    }
                    if (data.Emitt_cat_age != 0)
                    {
                        track_data_age = track_data_age + "Emitter Category Age = " + data.Emitt_cat_age.ToString() + "\n";
                    }
                    if (data.Pos_age != 0)
                    {
                        track_data_age = track_data_age + "Position Age = " + data.Pos_age.ToString() + "\n";
                    }
                    if (data.Geom_alt_age != 0)
                    {
                        track_data_age = track_data_age + "Geometric Altitude Age = " + data.Geom_alt_age.ToString() + "\n";
                    }
                    if (data.Pos_uncert_age != 0)
                    {
                        track_data_age = track_data_age + "Position Uncertainty Age = " + data.Pos_uncert_age.ToString() + "\n";
                    }
                    if (data.ModeSMB_age != 0)
                    {
                        track_data_age = track_data_age + "Mode S MB Data Age = " + data.ModeSMB_age.ToString() + "\n";
                    }
                    if (data.Ias_age != 0)
                    {
                        track_data_age = track_data_age + "IAS Data Age = " + data.Ias_age.ToString() + "\n";
                    }
                    if (data.Mach_age != 0)
                    {
                        track_data_age = track_data_age + "Mach Age = " + data.Mach_age.ToString() + "\n";
                    }
                    if (data.Barom_press_sett_age != 0)
                    {
                        track_data_age = track_data_age + "Barometric Pressure Setting Data Age = " + data.Barom_press_sett_age.ToString() + "\n";
                    }
                    if (track_data_age == "")
                    {
                        track_data_age = "-";
                    }
                    row.Add(track_data_age);
                    row.Add(data.FL.ToString());
                    row.Add(data.TGA.ToString());
                    string barometric_alt;
                    if (data.CorrectionQNH)
                    {
                        barometric_alt = "QNH correction" + "\n" + "BA = " + data.TBA.ToString() + " ft";
                    }
                    else
                    {
                        barometric_alt = "No QNH correction" + "\n" + "BA = " + data.TBA.ToString() + " ft";
                    }
                    row.Add(barometric_alt);
                    row.Add(data.Rate.ToString());
                    row.Add(data.Vehicle);

                    //Mode 5 Data reports & Extended Mode 1 Code (Click to expand)
                    string mode5 = " - ";
                    if (data.SUM)
                    {
                        mode5 = "M5 = " + data.M5 + "\n" + "ID = " + data.ID + "\n" + "DA = " + data.DA + "\n" + "M1 = " + data.M1 + "\n" + "M2 = " + data.M2 + "\n" + "M3 = " + data.M3 + "\n" + "MC = " + data.MC + "\n" + "X = " + data.X_110;
                    }
                    if (data.PMN)
                    {
                        mode5 = mode5 + "\n" + "PIN = " + data.PIN.ToString() + "\n" + "NAT = " + data.NAT.ToString() + "\n" + "MIS = " + data.MIS.ToString();
                    }
                    if (data.PMN)
                    {
                        mode5 = mode5 + "\n" + "PIN = " + data.PIN.ToString() + "\n" + "NAT = " + data.NAT.ToString() + "\n" + "MIS = " + data.MIS.ToString();
                    }
                    if (data.POS)
                    {
                        mode5 = mode5 + "\n" + "LAT = " + data.LONG_M5.ToString() + " deg"  + "\n" + "LONG = " + data.LAT_M5.ToString() + " deg" ;
                    }
                    if (data.GA)
                    {
                        mode5 = mode5 + "\n" + "GA reported in " + data.RES_GNSS + "\n" + "GA = " + data.ALT_GNSS.ToString() + " ft";
                    }
                    if (data.EM1)
                    {
                        mode5 = mode5 + "\n" + "EM1 = " + data.CODE_M1 ;
                    }
                    if (data.TOS)
                    {
                        mode5 = mode5 + "\n" + "TOS = " + data.TOS_VAL + " s";
                    }
                    if (data.TOS)
                    {
                        mode5 = mode5 + "\n" + "TOS = " + data.TOS_VAL + " s";
                    }
                    if (data.XP)
                    {
                        mode5 = mode5 + "\n" + "X5 = " + data.X5 + "\n" + "XC = " + data.XC + "\n" + "X3 = " + data.X3 + "\n" + "X2 = " + data.X2 + "\n" + "X1 = " + data.X1;
                    }
                    row.Add(mode5);

                    //Track Mode 2 Code
                    string Octal_mode2A = "";
                    if (data.Octal_mode2A == 0)
                    {
                        Octal_mode2A = "-";
                    }
                    else
                    {
                        Octal_mode2A = data.Octal_mode2A.ToString();
                    }
                    row.Add(Octal_mode2A);

                    //Measured Information (Click to expand)
                    string measured_info = " - ";
                    if (data.SID)
                    {
                        measured_info = "SAC = " + data.SAC2.ToString() + "\n" + "SIC = " + data.SIC2.ToString();
                    }
                    if (data.POS)
                    {
                        measured_info = measured_info + "\n" + "RHO = " + data.RHO.ToString() + " NM"+ "\n" + "THETA = " + data.THETA.ToString() + " deg";
                    }
                    if (data.HEI)
                    {
                        measured_info = measured_info + "\n" + "HEIGHT = " + data.HEIGHT.ToString() +  " ft";
                    }
                    if (data.MDC)
                    {
                        measured_info = measured_info + "\n" + "V = " + data.VC.ToString() + "\n" + "G = " + data.GC.ToString() + "\n" + "Mode C Code = " + data.Code_Mc;
                    }
                    if (data.MDA)
                    {
                        measured_info = measured_info + "\n"+  "V = " + data.V_mda.ToString() + "\n" + "G = " + data.G_mda.ToString() + "\n" + "L = " + data.L_mda.ToString() + "\n" + "Mode 3/A = " + data.CodeM3A.ToString();
                    }
                    if (data.TYP)
                    {
                        measured_info = measured_info + "\n" + "TYP = " + data.Typ_val + "\n" + "SIM = " + data.SIM.ToString() + "\n" + "RAB = " + data.RAB.ToString() + "\n" + "TST = " + data.TST.ToString();
                    }

                    row.Add(measured_info);

                    DataRow row2 = dt.NewRow();
                    row2.ItemArray = row.ToArray();
                    dt.Rows.Add(row2);
                }

                MessageBox.Show("finaaaal");

   

                dataGridView1.DataSource = dt;
                dataGridView1.Visible = true;
                mapToolStripMenuItem.Enabled = true;
            }
        }


        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Map map = new Map();
            map.setData(all_data);
            map.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                if (all_data[e.RowIndex].Expanded)
                {
                    dataGridView1.Rows[e.RowIndex].Height = 65;
                    all_data[e.RowIndex].Expanded = false;
                }
                else
                {
                    dataGridView1.AutoResizeRow(e.RowIndex, DataGridViewAutoSizeRowMode.AllCells);
                    all_data[e.RowIndex].Expanded = true;
                }
            }
        }

    }

}