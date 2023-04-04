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
        internal static void ShowPedestrianTrafficLight(Pedestrian_Traffic_Lighters pedestrianTrafficLighter, PedestrianTrafficLighterEventArgs e)
        {
            Console.WriteLine($"{pedestrianTrafficLighter.Name}");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.Write("|");
            Console.ForegroundColor = e.RedLamp ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write("O");
            Console.ResetColor();
            Console.WriteLine("|");
            Console.Write("|");
            Console.ForegroundColor = e.GreenLamp ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.Write("O");
            Console.ResetColor();
            Console.WriteLine("|");
            Console.ResetColor();
            Console.WriteLine("---");
        }
    }
}
