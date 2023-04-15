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
        internal delegate void RoadTrafficLighterHandler(TrafficLighter trafficLighter, RoadTrafficLighterEventArgs e);
        internal event RoadTrafficLighterHandler? RoadTrafficLighterEvent;        
        internal delegate void TramTrafficLighterHandler(TrafficLighter trafficLighter, TramTrafficLighterEventArgs e);
        internal event TramTrafficLighterHandler? TramTrafficLighterEvent;
        internal delegate void PedestrianTrafficLighterHandler(TrafficLighter trafficLighter, PedestrianTrafficLighterEventArgs e);
        internal event PedestrianTrafficLighterHandler? PedestrianTrafficLighterEvent;
        internal string Name { get; set; }
        internal bool RedLamp { get; set; }
        internal bool YellowLamp { get; set; }
        internal bool GreenLamp { get; set; }
        internal bool RightLamp { get; set; }
        internal bool LeftLamp { get; set; }
        internal bool MiddleLamp { get; set; }
        internal bool BottomLamp { get; set; }

        internal TrafficLighter(string name)
        {
            Name = name;
        }
        internal void RoadRedOn()
        {
            RedLamp = true;
            YellowLamp = false;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void RoadRedYellowOn()
        {
            RedLamp = true;
            YellowLamp = true;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void RoadGreenOn()
        {
            RedLamp = false;
            YellowLamp = false;
            GreenLamp = true;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void RoadYellowOn()
        {
            RedLamp = false;
            YellowLamp = true;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void RoadOffLight()
        {
            RedLamp = false;
            YellowLamp = false;
            GreenLamp = false;
            RoadTrafficLighterEvent?.Invoke(this, new RoadTrafficLighterEventArgs(RedLamp, YellowLamp, GreenLamp));
        }
        internal void TramRedOn()
        {
            RightLamp = true;
            LeftLamp = true;
            MiddleLamp = true;
            BottomLamp = false;
            TramTrafficLighterEvent?.Invoke(this, new TramTrafficLighterEventArgs(RightLamp, LeftLamp, MiddleLamp, BottomLamp));
        }
        internal void TramGreenOn()
        {
            RightLamp = true;
            LeftLamp = true;
            MiddleLamp = true;
            BottomLamp = true;
            TramTrafficLighterEvent?.Invoke(this, new TramTrafficLighterEventArgs(RightLamp, LeftLamp, MiddleLamp, BottomLamp));
        }
        internal void TramOffLight()
        {
            RightLamp = false;
            LeftLamp = false;
            MiddleLamp = false;
            BottomLamp = false;
            TramTrafficLighterEvent?.Invoke(this, new TramTrafficLighterEventArgs(RightLamp, LeftLamp, MiddleLamp, BottomLamp));
        }
        internal void PedestrianRedOn()
        {
            RedLamp = true;
            GreenLamp = false;
            PedestrianTrafficLighterEvent?.Invoke(this, new PedestrianTrafficLighterEventArgs(RedLamp, GreenLamp));
        }
        internal void PedestrianGreenOn()
        {
            RedLamp = false;
            GreenLamp = true;
            PedestrianTrafficLighterEvent?.Invoke(this, new PedestrianTrafficLighterEventArgs(RedLamp, GreenLamp));
        }
        internal void PedestrianOffLight()
        {
            RedLamp = false;
            GreenLamp = false;
            PedestrianTrafficLighterEvent?.Invoke(this, new PedestrianTrafficLighterEventArgs(RedLamp, GreenLamp)); 
        }
    }
}
