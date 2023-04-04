using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighters
{
    internal class TrafficLighter
    {
        internal delegate void TrafficLighterHandler(TrafficLighter trafficLighter, CheckStatusShowModuleEventArgs e);
        internal event TrafficLighterHandler? TrafficLighterEvent;
        internal string Name { get; set; }
        internal TrafficLighter(string name)
        {
            Name = name;
        }
        internal void CheckTrafficLighterStatus()
        {
            TrafficLighterEvent?.Invoke(this, new CheckStatusShowModuleEventArgs(Name));
        }        
    }
}
