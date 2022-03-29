using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_040
    {
        int track_num;
        public I062_040(int b, int b1)
        {
            string track_num1 = Convert.ToString(b, 2);
            string track_num2 = Convert.ToString(b1, 2);

            Basic_functions bf = new Basic_functions();

            track_num1 = bf.padding(track_num1);
            track_num2 = bf.padding(track_num2);

            string track_num_str = track_num1 + track_num2;
            this.track_num = Convert.ToInt32(track_num_str, 2);
        }

        public int getTrackNum()
        {
            return this.track_num;
        }
    }
}
