using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_lighters;

namespace Traffic_lighters
{
    internal class CrossRoadControllerEventArgs
    {
        internal string? State { get; set; }
        internal string? Main { get; set; }
        internal string? Secondary { get; set; }
        internal string? Tram { get; set; }
        internal string? Pedestrian { get; set; }
        internal bool RedLamp { get; set; }
        internal bool YellowLamp { get; set; }
        internal bool GreenLamp { get; set; }
        internal bool RightLamp { get; set; }
        internal bool LeftLamp { get; set; }
        internal bool MiddleLamp { get; set; }
        internal bool BottomLamp { get; set; }
        internal CrossRoadControllerEventArgs(string state, string main, string secondary, string tram, string pedestrian) 
        {
            State = state;
            Main = main;
            Secondary = secondary;
            Tram = tram;
            Pedestrian = pedestrian;
        }
        internal static void ShowCrossRoadNightModeState(CrossRoadController controller, CrossRoadControllerEventArgs e)
        {
            PedestrianOffLight();
            ShowPedestrianTrafficLight();
            TramOffLight();
            ShowTramTrafficLighter();
            switch (controller.State)
            {
                case "11":
                    Console.WriteLine($"{controller.State}");
                    RoadYellowOn();
                    ShowRoadTrafficLighter();
                    RoadYellowOn();
                    ShowRoadTrafficLighter();
                    break;
                case "12":
                    Console.WriteLine($"{controller.State}");
                    RoadOffLight();
                    ShowRoadTrafficLighter();
                    RoadOffLight();
                    ShowRoadTrafficLighter();                    
                    break;
            }
            void RoadYellowOn()
            {
                e.RedLamp = false;
                e.YellowLamp = true;
                e.GreenLamp = false;
            }
            void RoadOffLight()
            {
                e.RedLamp = false;
                e.YellowLamp = false;
                e.GreenLamp = false;
            }
            void TramOffLight()
            {
                e.RightLamp = false;
                e.LeftLamp = false;
                e.MiddleLamp = false;
                e.BottomLamp = false;
            }
            void PedestrianOffLight()
            {
                e.RedLamp = false;
                e.GreenLamp = false;
            }
            void ShowRoadTrafficLighter()
            {
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
            void ShowPedestrianTrafficLight()
            {
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
            void ShowTramTrafficLighter()
            {
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
        internal static void ShowCrossRoadDayModeState(CrossRoadController controller, CrossRoadControllerEventArgs e)
        {
            switch (controller.State)
            {
                case "1":
                    Console.WriteLine($"{controller.State}");
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    ShowRoadTrafficLighter();
                    PedestrianRedOn();
                    ShowPedestrianTrafficLight();                    
                    TramRedOn();
                    ShowTramTrafficLighter();
                    break;
                case "2":
                    Console.WriteLine($"{controller.State}");
                    RoadRedYellowOn();
                    ShowRoadTrafficLighter();
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    PedestrianRedOn();
                    ShowPedestrianTrafficLight();
                    TramRedOn();
                    ShowTramTrafficLighter();
                    break;
                case "3":
                    Console.WriteLine($"{controller.State}");
                    RoadGreenOn();
                    ShowRoadTrafficLighter();
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    TramRedOn();
                    ShowTramTrafficLighter();
                    PedestrianRedOn();
                    ShowPedestrianTrafficLight();
                    break;
                case "4":
                    Console.WriteLine($"{controller.State}");
                    RoadGreenOn();
                    ShowRoadTrafficLighter();
                    RoadOffLight();
                    ShowRoadTrafficLighter();                        
                    break;
                case "5":
                    Console.WriteLine($"{controller.State}");
                    RoadYellowOn();
                    ShowRoadTrafficLighter();
                    RoadRedYellowOn();
                    ShowRoadTrafficLighter();
                    TramRedOn();
                    ShowTramTrafficLighter();
                    PedestrianRedOn();       
                    ShowPedestrianTrafficLight();
                    break;
                case "6":
                    Console.WriteLine($"{controller.State}");
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    RoadGreenOn();
                    ShowRoadTrafficLighter();
                    TramRedOn();
                    ShowTramTrafficLighter();
                    PedestrianRedOn();
                    ShowPedestrianTrafficLight();
                    break;
                case "7":
                    Console.WriteLine($"{controller.State}");
                    RoadGreenOn();
                    ShowRoadTrafficLighter();
                    RoadOffLight();
                    ShowRoadTrafficLighter();
                    break;
                case "8":
                    Console.WriteLine($"{controller.State}");
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    RoadYellowOn();
                    ShowRoadTrafficLighter();
                    TramRedOn();
                    ShowTramTrafficLighter();
                    PedestrianRedOn();
                    ShowPedestrianTrafficLight();
                    break;
                case "9":
                    Console.WriteLine($"{controller.State}");
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    RoadRedOn();
                    ShowRoadTrafficLighter();
                    TramGreenOn();
                    ShowTramTrafficLighter();
                    PedestrianGreenOn();
                    ShowPedestrianTrafficLight();
                    break;
                case "10":
                    Console.WriteLine($"{controller.State}");
                    PedestrianGreenOn();
                    ShowPedestrianTrafficLight();
                    PedestrianOffLight();
                    ShowPedestrianTrafficLight();
                    break;
            }
            void RoadRedOn()
            {
                e.RedLamp = true;
                e.YellowLamp = false;
                e.GreenLamp = false;
            }
            void RoadRedYellowOn()
            {
                e.RedLamp = true;
                e.YellowLamp = true;
                e.GreenLamp = false;
            }
            void RoadGreenOn()
            {
                e.RedLamp = false;
                e.YellowLamp = false;
                e.GreenLamp = true;
            }
            void RoadYellowOn()
            {
                e.RedLamp = false;
                e.YellowLamp = true;
                e.GreenLamp = false;
            }
            void RoadOffLight()
            {
                e.RedLamp = false;
                e.YellowLamp = false;
                e.GreenLamp = false;
            }
            void TramRedOn()
            {
            e.RightLamp = true;
            e.LeftLamp = true;
            e.MiddleLamp = true;
            e.BottomLamp = false;
            }
            void TramGreenOn()
            {
            e.RightLamp = true;
            e.LeftLamp = true;
            e.MiddleLamp = true;
            e.BottomLamp = true;
            }            
            void PedestrianRedOn()
            {
            e.RedLamp = true;
            e.GreenLamp = false;
            }
            void PedestrianGreenOn()
            {
            e.RedLamp = false;
            e.GreenLamp = true;
            }
            void PedestrianOffLight()
            {
            e.RedLamp = false;
            e.GreenLamp = false;
            }
            void ShowRoadTrafficLighter()
            {
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
            void ShowPedestrianTrafficLight()
            {
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
            void ShowTramTrafficLighter()
            {
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
}
