using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_lighters;

/*
namespace Traffic_lighters
{
    internal class Road_Traffic_Lighters : TrafficLighter
    {
        internal delegate void RoadTrafficLighterHandler(Road_Traffic_Lighters lighter, RoadTrafficLighterEventArgs e);
        internal event RoadTrafficLighterHandler? RoadTrafficLighterEvent;
        internal bool RedLamp { get; set; }
        internal bool YellowLamp { get; set; }
        internal bool GreenLamp { get; set; }
        
        internal Road_Traffic_Lighters(string name) : base (name)
        {             
        }
        
        internal void RedOn()
        {
            RedLamp = true;
            YellowLamp = false;
            GreenLamp = false;                       
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs (RedLamp,YellowLamp,GreenLamp));            
        }
        internal void RedYellowOn()
        {
            RedLamp = true;
            YellowLamp = true;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void GreenOn()
        {
            RedLamp = false;
            YellowLamp = false;
            GreenLamp = true;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }        
        internal void YellowOn()
        {
            RedLamp = false;
            YellowLamp = true;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void OffLight()
        {
            RedLamp = false;
            YellowLamp = false;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }        
    }
}
*/