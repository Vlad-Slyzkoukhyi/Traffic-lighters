using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Traffic_lighters
{
    internal class PedestrianTrafficLighterEventArgs
    {
        internal bool RedLamp { get; set; }
        internal bool GreenLamp { get; set; }
        internal PedestrianTrafficLighterEventArgs(bool redLamp, bool greenLamp)
        {
            RedLamp = redLamp;
            GreenLamp = greenLamp;
        }        
    }
}
