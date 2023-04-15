using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighters
{
    internal class TrafficLighterShowModule
    {
        internal static void ShowRoadTrafficLighter(TrafficLighter roadLighter, RoadTrafficLighterEventArgs e)
        {
            Console.WriteLine($"{roadLighter.Name}");
            Console.ResetColor();
            Console.WriteLine("---");
            Console.Write("|");
            Console.ForegroundColor = e.RedLamp ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write("O");
            Console.ResetColor();
            Console.WriteLine("|");
            Console.Write("|");
            Console.ForegroundColor = e.YellowLamp ? ConsoleColor.Yellow : ConsoleColor.Gray;
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
        internal static void ShowPedestrianTrafficLight(TrafficLighter pedestrianTrafficLighter, PedestrianTrafficLighterEventArgs e)
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
        internal static void ShowTramTrafficLighter(TrafficLighter tramLighter, TramTrafficLighterEventArgs e)
        {
            Console.WriteLine($"{tramLighter.Name}");
            Console.ResetColor();
            Console.WriteLine("-------");
            Console.Write("|");
            Console.ForegroundColor = e.LeftLamp ? ConsoleColor.White : ConsoleColor.Black;
            Console.Write("O");
            Console.ResetColor();
            Console.Write("|");
            Console.ForegroundColor = e.MiddleLamp ? ConsoleColor.White : ConsoleColor.Black;
            Console.Write("O");
            Console.ResetColor();
            Console.Write("|");
            Console.ForegroundColor = e.RightLamp ? ConsoleColor.White : ConsoleColor.Black;
            Console.Write("O");
            Console.ResetColor();
            Console.WriteLine("|");
            Console.ResetColor();
            Console.WriteLine("-------");
            Console.Write("  |");
            Console.ForegroundColor = e.BottomLamp ? ConsoleColor.White : ConsoleColor.Black;
            Console.Write("O");
            Console.ResetColor();
            Console.WriteLine("|");
            Console.WriteLine("   -");
        }
    }
}
