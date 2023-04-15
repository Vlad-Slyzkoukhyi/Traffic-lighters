using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Traffic_lighters
{
    internal class Pedestrian_Traffic_Lighters : TrafficLighter
    {
        internal delegate void PedestrianTrafficLighterHandler(Pedestrian_Traffic_Lighters lighter, PedestrianTrafficLighterEventArgs e);
        internal event PedestrianTrafficLighterHandler? PedestrianTrafficLighterEvent;
        internal bool RedLamp { get; set; }
        internal bool GreenLamp { get; set; }
        public Pedestrian_Traffic_Lighters(string name) : base(name)
        { }
       
        internal virtual void RedOn()
        {
            RedLamp = true;
            GreenLamp = false;
            PedestrianTrafficLighterEvent?.Invoke(this, new PedestrianTrafficLighterEventArgs(RedLamp,GreenLamp));
        }
        internal virtual void GreenOn()
        {
            RedLamp = false;
            GreenLamp = true;
            PedestrianTrafficLighterEvent?.Invoke(this, new PedestrianTrafficLighterEventArgs(RedLamp, GreenLamp));
        }        
        internal virtual void OffLight()
        {
            RedLamp = false;
            GreenLamp = false;
            PedestrianTrafficLighterEvent?.Invoke(this, new PedestrianTrafficLighterEventArgs(RedLamp, GreenLamp));
        }       
    }
}
*/