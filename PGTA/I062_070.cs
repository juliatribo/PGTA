using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_070
    {

        double time_track_info;
        public I062_070(int b1, int b2, int b3)
        {
            string track1 = Convert.ToString(b1, 2);
            string track2 = Convert.ToString(b2, 2);
            string track3 = Convert.ToString(b3, 2);

            Basic_functions bf = new Basic_functions();

            track1 = bf.padding(track1);
            track2 = bf.padding(track2);
            track3 = bf.padding(track3);

            string track_str = track1 + track2 + track3;
            this.time_track_info = Convert.ToDouble(Convert.ToInt32(track_str, 2)) / 128;
        }


        public double getTimeTrackInfo()
        {
            return this.time_track_info;
        }

    }
}
