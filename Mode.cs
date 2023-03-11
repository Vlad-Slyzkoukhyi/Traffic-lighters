using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighter_0._0._2
{
    internal class Mode
    {
        internal MainRoad m1 = new("=1=");
        internal MainRoad m2 = new("=2=");
        internal SecondaryRoad s1 = new("=3=");
        internal SecondaryRoad s2 = new("=4=");
        internal Tram t1 = new("=5=");
        internal Tram t2 = new("=6=");
        internal Pedestrian p1 = new("=7=");
        internal Pedestrian p2 = new("=8=");

        internal const int mainTimer = 5000;
        internal const int blinkTimer = 500;
        internal const int numberOfChanges = 5;        
        internal const int yellowTimer = 2000;
                
        internal enum Modes
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Fifth =5,
            Sixth = 6,
            Seventh = 7
        }

        internal async Task Lighters_mode(Modes mode)
        {
            switch (mode)
            {
                case Modes.First:
                    m1.GreenOn();
                    m2.GreenOn();
                    s1.RedOn();
                    s2.RedOn();
                    t1.RedOn();
                    t2.RedOn();
                    p1.RedOn();
                    p2.RedOn();
                    await Task.Delay(mainTimer);
                    await m1.BlinkGreen();
                    await m2.BlinkGreen();
                    goto case Modes.Second;
                case Modes.Second:
                    m1.YellowOn();
                    m2.YellowOn();
                    s1.RedYellowOn();
                    s2.RedYellowOn();
                    t1.RedOn();
                    t2.RedOn();
                    p1.RedOn();
                    p2.RedOn();
                    await Task.Delay(yellowTimer);
                    goto case Modes.Third;
                case Modes.Third:
                    m1.RedOn();
                    m2.RedOn();
                    s1.GreenOn();
                    s2.GreenOn();
                    t1.RedOn();
                    t2.RedOn();
                    p1.RedOn();
                    p2.RedOn();
                    await Task.Delay(mainTimer);
                    await s1.BlinkGreen();
                    await s2.BlinkGreen();
                    goto case Modes.Fourth;
                case Modes.Fourth:
                    m1.RedOn();
                    m2.RedOn();
                    s1.YellowOn();
                    s2.YellowOn();
                    t1.RedOn();
                    t2.RedOn();
                    p1.RedOn();
                    p2.RedOn();
                    await Task.Delay(yellowTimer);
                    goto case Modes.Fifth;
                case Modes.Fifth:
                    m1.RedOn();
                    m2.RedOn();
                    s1.RedOn();
                    s2.RedOn();
                    t1.GreenOn();
                    t2.GreenOn();
                    p1.GreenOn();
                    p2.GreenOn();
                    await Task.Delay(mainTimer);
                    await t1.BlinkGreen();
                    await t2.BlinkGreen();
                    await p1.BlinkGreen();
                    await p2.BlinkGreen();
                    goto case Modes.Sixth;
                case Modes.Sixth:
                    m1.RedOn();
                    m2.RedOn();
                    s1.RedOn();
                    s2.RedOn();
                    t1.RedOn();
                    t2.RedOn();
                    p1.RedOn();
                    p2.RedOn();
                    goto case Modes.Seventh;
                case Modes.Seventh:
                    m1.RedYellowOn();
                    m2.RedYellowOn();
                    s1.RedOn();
                    s2.RedOn();
                    t1.RedOn();
                    t2.RedOn();
                    p1.RedOn();
                    p2.RedOn();
                    await Task.Delay(yellowTimer);
                    goto case Modes.First;
            }
        }
    }
}
