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
        internal static void ShowTramTrafficLighter(Tram_Traffic_Lighters tramLighter, TramTrafficLighterEventArgs e)
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
