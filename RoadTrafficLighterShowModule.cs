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

        internal static void ShowRoadTrafficLighter(Road_Traffic_Lighters roadLighter, RoadTrafficLighterEventArgs e)
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
    }
}