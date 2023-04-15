using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Traffic_lighters;
using static Traffic_lighters.CrossRoadController;

namespace Traffic_lighters
{
    internal class TramTrafficLighterEventArgs
    {
        internal CrossRoadController.StatesCondition? State { get; set; }
        internal CrossRoadController.TrafficLightsNames Name { get; set; }
        internal TramTrafficLighterEventArgs(CrossRoadController.StatesCondition? state, CrossRoadController.TrafficLightsNames name)
        {
            State = state;
            Name = name;
        }
        internal bool RightLamp { get; set; }
        internal bool LeftLamp { get; set; }
        internal bool MiddleLamp { get; set; }
        internal bool BottomLamp { get; set; }
       
        internal static void ShowTramTrafficLighter(TramTrafficLighterEventArgs e)
        {
            switch (e.State)
            {
                case StatesCondition.STOP:
                    e.LeftLamp = true;
                    e.MiddleLamp = true;
                    e.RightLamp = true;
                    e.BottomLamp = false;
                    break;                
                case StatesCondition.GO:
                    e.LeftLamp = true;
                    e.MiddleLamp = true;
                    e.RightLamp = true;
                    e.BottomLamp = true;
                    break;                
                case StatesCondition.OFFLIGHT:
                    e.LeftLamp = false;
                    e.MiddleLamp = false;
                    e.RightLamp = false;
                    e.BottomLamp = false;
                    break;
            }
            Console.WriteLine($"{e.Name}");
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
