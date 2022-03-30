using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_390
    {
        string total_data_str; 
        Basic_functions bf = new Basic_functions();
        public I062_390(int b, int b1, int b2, int b3)
        {
            string data1 = Convert.ToString(b, 2);
            string data2 = Convert.ToString(b1, 2);
            string data3 = Convert.ToString(b2, 2);
            string data4 = Convert.ToString(b3, 2);

            data1 = bf.padding(data1);
            data2 = bf.padding(data2);
            data3 = bf.padding(data3);
            data4 = bf.padding(data4);

            string total_data_str = data1 + data2 + data3 + data4;

        }
        public string GetTotalData()
        {
            return this.total_data_str;
        }

    }

    
}
