using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace Traffic_lighters
{
    internal class Tram_Traffic_Lighters : TrafficLighter
    {
        internal delegate void TramTrafficLighterHandler(Tram_Traffic_Lighters lighter, TramTrafficLighterEventArgs e);
        internal event TramTrafficLighterHandler? TramTrafficLighterEvent;
        internal bool RightLamp { get; set; }
        internal bool LeftLamp { get; set; }
        internal bool MiddleLamp { get; set; }
        internal bool BottomLamp { get; set; }
        public Tram_Traffic_Lighters(string name) : base (name)
        {            
        }
        internal virtual void RedOn()
        {
            RightLamp = true;
            LeftLamp = true;
            MiddleLamp = true;
            BottomLamp = false;
            TramTrafficLighterEvent?.Invoke(this, new TramTrafficLighterEventArgs(RightLamp, LeftLamp, MiddleLamp, BottomLamp));
        }
        internal virtual void GreenOn()
        {
            RightLamp = true;
            LeftLamp = true;
            MiddleLamp = true;
            BottomLamp = true;
            TramTrafficLighterEvent?.Invoke(this, new TramTrafficLighterEventArgs(RightLamp, LeftLamp, MiddleLamp, BottomLamp));
        }        
        internal virtual void OffLight()
        {
            RightLamp = false;
            LeftLamp = false;
            MiddleLamp = false;
            BottomLamp = false;
            TramTrafficLighterEvent?.Invoke(this, new TramTrafficLighterEventArgs(RightLamp, LeftLamp, MiddleLamp, BottomLamp));
        }       
    }

}
*/