using Traffic_lighters;
using static Traffic_lighters.CrossRoadController;

namespace Traffic_lighters
{
    internal class RoadTrafficLighterEventArgs
    {
        internal CrossRoadController.StatesCondition? State { get; set; }
        internal CrossRoadController.TrafficLightsNames Name { get; set; }
        internal int Time { get; set; }
        internal RoadTrafficLighterEventArgs(CrossRoadController.StatesCondition? state, CrossRoadController.TrafficLightsNames name, int time)
        {
            State = state;
            Name = name;
            Time = time;
        }
        internal bool RedLamp { get; set; }
        internal bool YellowLamp { get; set; }
        internal bool GreenLamp { get; set; }
        internal static int blinkDuratation = 500;
        internal static void ShowRoadTrafficLighter(RoadTrafficLighterEventArgs e)
        {
            async void BlinkGreen()
            {
                e.RedLamp = false;
                e.YellowLamp = false;
                for (int i = 0; i < e.Time; i += blinkDuratation)
                {
                    if (e.GreenLamp == false)
                    {
                        e.GreenLamp = true;
                        await Task.Delay(blinkDuratation);
                    }
                    else
                    {
                        e.GreenLamp = false;
                        await Task.Delay(blinkDuratation);
                    }
                }
            }
            switch (e.State)
            {
                case StatesCondition.RED:
                    e.RedLamp = true;
                    e.YellowLamp = false;
                    e.GreenLamp = false;
                    break;
                case StatesCondition.REDYELLOW:
                    e.RedLamp = true;
                    e.YellowLamp = true;
                    e.GreenLamp = false;
                    break;
                case StatesCondition.GREEN:
                    e.RedLamp = false;
                    e.YellowLamp = false;
                    e.GreenLamp = true;
                    break;
                case StatesCondition.BLINKGREEN:
                    BlinkGreen();
                    break;
                case StatesCondition.YELLOW:
                    e.RedLamp = false;
                    e.YellowLamp = true;
                    e.GreenLamp = false;
                    break;
                case StatesCondition.OFFLIGHT:
                    e.RedLamp = false;
                    e.YellowLamp = false;
                    e.GreenLamp = false;
                    break;
            }            
            Console.WriteLine($"{e.Name}");
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
    }
}