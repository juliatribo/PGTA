using System;
using System.Text;
namespace PGTA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        Basic_functions bf = new Basic_functions();

        private void btn1_Click(object sender, EventArgs e)
        {

            OpenFileDialog archivo = new OpenFileDialog();
            //archivo.Filter = "Archivos asterix(*.asterix)|*.asterix" ;


            if (archivo.ShowDialog() == DialogResult.OK)
            {
                this.textFile.Text = archivo.FileName;

            }

            FileStream fichero = new FileStream(this.textFile.Text,FileMode.Open,FileAccess.Read);
            Byte[] buffer = new byte[fichero.Length];
            fichero.Read(buffer, 0, buffer.Length);
            fichero.Close();

            DataDecoded[] all_data = new DataDecoded[10000000];

            int n = 0;//message counter
            int k = 0;
            while (n < buffer.Length)
            {
                DataDecoded data = new DataDecoded();
                int len;
                switch (((sbyte)buffer[n]))
                {
                    case 62:
                        data.Categoria = "Cat 62";
                        len = buffer[n + 1] + buffer[n + 2];

                        string frns = "";
                        bool last1 = true;
                        int p;//length frns counter
                        for (p = 0; last1 ; p++)
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
                                        I062_070 c4 = new I062_070(buffer[position], buffer[position + 1], buffer[position +2]);
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
                                                switch (t+1)
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

                                                    case 4://IAS
                                                        data.Ias = c11.getIas(buffer[position], buffer[position + 1]);
                                                        data.IsMach = c11.isMach();
                                                        position = position + 2;
                                                        break;

                                                    case 5://TAS
                                                        data.Tas = c11.getTas(buffer[position], buffer[position + 1]);
                                                        position = position + 2;
                                                        break;

                                                    case 6://SAL
                                                        data.IsSas = c11.IsSas(buffer[position]);
                                                        data.Source = c11.getSource(buffer[position]);
                                                        data.Fms_altitude_selected = c11.getAltitude(buffer[position], buffer[position + 1]);
                                                        position = position + 2;
                                                        break;

                                                    case 7://FSS
                                                       // bool
                                                        data.Fms_altitude_selected = c11.getAltitude(buffer[position], buffer[position + 1]);
                                                        position = position + 2;
                                                        break;

                                                    case 8://TIS

                                                        break;

                                                    case 9:

                                                        break;

                                                    case 10:

                                                        break;

                                                    case 11:

                                                        break;

                                                    case 12:

                                                        break;

                                                    case 13:

                                                        break;

                                                    case 14:

                                                        break;

                                                    case 15:

                                                        break;

                                                    case 16:
                                                        break;
                                                    case 17:
                                                        break;

                                                    case 18://GS
                                                        data.GS = c11.getGS(buffer[position], buffer[position + 1]);
                                                        position = position + 2;
                                                        break;

                                                    case 19:
                                                        break;
                                                    case 20:
                                                        break;
                                                    case 21:
                                                        break;
                                                    case 22:
                                                        break;
                                                    case 23:
                                                        break;
                                                    case 24:
                                                        break;
                                                    case 25:
                                                        break;
                                                    case 26:
                                                        break;
                                                    case 27:
                                                        break;
                                                    case 28:
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

                                        string var2 = Convert.ToString(buffer[position-1], 2);
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

                                            var2 = Convert.ToString(buffer[position-1], 2);
                                            if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                            {
                                                c13.ext2(buffer[position]);
                                                data.IsAmalgamation = c13.isAmalgamation();
                                                data.Type_of_target_int4 = c13.getTypeOfTargetInt4();
                                                data.IsMilitary_emergency = c13.isMilitaryEmergency();
                                                data.IsMilitary_id = c13.isMilitaryId();
                                                data.Type_of_target_int5 = c13.getTypeOfTargetInt5();

                                                position++;

                                                var2 = Convert.ToString(buffer[position-1], 2);
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

                                                    var2 = Convert.ToString(buffer[position-1], 2);
                                                    if (Convert.ToString(var2[var2.Length - 1]).Equals("1"))
                                                    {
                                                        c13.ext4(buffer[position]);
                                                        data.Surveillance_data_status = c13.Surveillance_data_status();
                                                        data.Emergency_status_indication = c13.Emergency_status_indication();
                                                        data.IsPotential_false_track_indication = c13.IsPotential_false_track_indication();
                                                        data.IsTrack_created_FPLdata = c13.IsTrack_created_FPLdata();

                                                        position++;

                                                        var2 = Convert.ToString(buffer[position-1], 2);
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
                                        position ++;

                                        break;

                                    case 16://I062/295 Track Data Ages (1+)
                                        break;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////
                                    case 17://I062/136 Measured Flight Level 
                                        break;
                                    case 18://I062/130 Calculated Track Geometric Altitude 
                                        break;
                                    case 19://I062/135 Calculated Track Barometric Altitude 
                                        break;
                                    case 20:
                                        break;
                                    case 21:
                                        break;
                                    case 22:
                                        break;
                                    case 23:
                                        break;
                                    case 24:
                                        break;
                                    case 25:
                                        break;
                                    case 26:
                                        break;
                                    case 27:
                                        break;
                                    case 28:
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
                                        break;
                                    case 35:
                                        break;

                                }
                            }
                        }

                        n = n + len;
                        break;

                    default:
                        data.Categoria = buffer[n].ToString();
                        len = ((sbyte)buffer[n + 1]) + ((sbyte)buffer[n + 2]);
                        n = n + len;
                        break;
                }
                all_data[k] = data;
                k++;

            }



        }
    }

}