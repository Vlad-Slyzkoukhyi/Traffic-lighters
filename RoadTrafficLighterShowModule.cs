namespace Traffic_lighters
{
    internal class RoadTrafficLighterEventArgs
    {
        internal bool RedLamp { get; set; }
        internal bool YellowLamp { get; set; }
        internal bool GreenLamp { get; set; }
        internal RoadTrafficLighterEventArgs(bool redLamp, bool yellowLamp, bool greenLamp)
        {
            RedLamp = redLamp;
            YellowLamp = yellowLamp;
            GreenLamp = greenLamp;
        }        
    }
}