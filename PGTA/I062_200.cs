using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_200
    {
        string status_movement_trans="";
        string status_movement_long="";
        string status_movement_vert="";
        bool altitude_discrepacy;

        public I062_200(int b)
        {
            string mode_movement = Convert.ToString(b, 2);

            Basic_functions bf = new Basic_functions();

            mode_movement = bf.padding(mode_movement);
            string mode_movement_trans = mode_movement.Substring(0, 2);
            string mode_movement_long = mode_movement.Substring(2, 2);
            string mode_movement_vert = mode_movement.Substring(4, 2);
            string mode_movement_adf = mode_movement.Substring(6, 1);

            if (mode_movement_trans.Equals("00"))
            {
                this.status_movement_trans = "Constant Course";
            }
            else if (mode_movement_trans.Equals("01"))
            {
                this.status_movement_trans = "Right Turn";
            }
            else if (mode_movement_trans.Equals("10"))
            {
                this.status_movement_trans = "Left Turn";
            }
            else if (mode_movement_trans.Equals("11"))
            {
                this.status_movement_trans = "Undetermined";
            }

            if (mode_movement_long.Equals("00"))
            {
                this.status_movement_long = "Constant Groundspeed";
            }
            else if (mode_movement_long.Equals("01"))
            {
                this.status_movement_long = "Increasing Groundspeed";
            }
            else if (mode_movement_long.Equals("10"))
            {
                this.status_movement_long = "Decreasing Groundspeed";
            }
            else if (mode_movement_long.Equals("11"))
            {
                this.status_movement_long = "Undetermined";
            }

            if (mode_movement_vert.Equals("00"))
            {
                this.status_movement_vert = "Level";
            }
            else if (mode_movement_vert.Equals("01"))
            {
                this.status_movement_vert = "Climb";
            }
            else if (mode_movement_vert.Equals("10"))
            {
                this.status_movement_vert = "Descent";
            }
            else if (mode_movement_vert.Equals("11"))
            {
                this.status_movement_vert = "Undetermined";
            }

            if (mode_movement_adf.Equals("0"))
            {
                this.altitude_discrepacy = false;
            }
            else
            {
                this.altitude_discrepacy = true;
            }
        }

        public string getMovementTrans()
        {
            return this.status_movement_trans;
        }
        public string getMovementLong()
        {
            return this.status_movement_long;
        }
        public string getMovementVert()
        {
            return this.status_movement_vert;
        }
        public bool isAltitudeDiscrep()
        {
            return this.altitude_discrepacy;
        }
    }
}
