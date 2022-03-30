using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGTA
{
    internal class I062_300
    {
        //Vehicle Fleet Identification
        string vehicle = "";

        public I062_300(int b)
        {
            switch (b)
            {
                case 0:
                    vehicle = "Unknown";
                    break;
                case 1:
                    vehicle = "ATC equipment maintenance";
                    break;
                case 2:
                    vehicle = "Airport maintenance";
                    break;
                case 3:
                    vehicle = "Fire";
                    break;
                case 4:
                    vehicle = "Bird scarer";
                    break;
                case 5:
                    vehicle = "Snow plough";
                    break;
                case 6:
                    vehicle = "Runway sweeper";
                    break;
                case 7:
                    vehicle = "Emergency";
                    break;
                case 8:
                    vehicle = "Police";
                    break;
                case 9:
                    vehicle = "Bus";
                    break;
                case 10:
                    vehicle = "Tug (push/tow)";
                    break;
                case 11:
                    vehicle = "Grass cutter";
                    break;
                case 12:
                    vehicle = "Fuel";
                    break;
                case 13:
                    vehicle = "Baggage";
                    break;
                case 14:
                    vehicle = "Catering";
                    break;
                case 15:
                    vehicle = "Aircraft maintenance";
                    break;
                case 16:
                    vehicle = "Flyco (follow me)";
                    break;
            }



        }

        public string getVehicle()
        {
            return this.vehicle;
        }
    }

}
