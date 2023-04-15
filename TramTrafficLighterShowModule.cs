using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Traffic_lighters
{
    internal class TramTrafficLighterEventArgs
    {
        internal bool RightLamp { get; set; }
        internal bool LeftLamp { get; set; }
        internal bool MiddleLamp { get; set; }
        internal bool BottomLamp { get; set; }
        internal TramTrafficLighterEventArgs(bool rightLamp, bool leftLamp, bool middleLamp, bool bottomLamp)
        {
            RightLamp = rightLamp;
            LeftLamp = leftLamp;
            MiddleLamp = middleLamp;
            BottomLamp = bottomLamp;
        }        
    }
}
