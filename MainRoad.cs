using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traffic_lighter_0._0._2;

namespace Traffic_lighter_0._0._2
{
    internal class MainRoad
    {
        internal string Name { get; set; }
        internal bool RedLamp { get; set; }
        internal bool YellowLamp { get; set; }
        internal bool GreenLamp { get; set; }
        internal MainRoad(string name) 
        { 
            Name = name;
        }
        internal void RedOn()
        {
            RedLamp = true;
            YellowLamp = false;
            GreenLamp = false;
            Show();
        }
        internal void RedYellowOn()
        {
            RedLamp = true;
            YellowLamp = true;
            GreenLamp = false;
            Show();
        }
        internal void GreenOn()
        {
            RedLamp = false;
            YellowLamp = false;
            GreenLamp = true;
            Show();
        }
        internal async Task BlinkGreen()
        {
            for (int i = 0; i < Mode.numberOfChanges; i++)
            {
                if (GreenLamp == true)
                {
                    GreenLamp = false;
                    Show();
                    await Task.Delay(Mode.blinkTimer);
                }
                else if (GreenLamp == false)
                {
                    GreenLamp = true;
                    Show();
                    await Task.Delay(Mode.blinkTimer);
                }
            }
        }
        
        internal void YellowOn()
        {
            RedLamp = false;
            YellowLamp = true;
            GreenLamp = false;
            Show();
        }
        internal void OffLight()
        {
            RedLamp = false;
            YellowLamp = false;
            GreenLamp = false;
            Show();
        }
        internal void Show()
        {
            Console.WriteLine($"{Name}");
            Console.ResetColor();
            Console.WriteLine("===");
            Console.Write("|");
            Console.ForegroundColor = RedLamp ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.Write("O");
            Console.ResetColor(); 
            Console.WriteLine("|");
            Console.Write("|");
            Console.ForegroundColor = YellowLamp ? ConsoleColor.Yellow : ConsoleColor.Gray;
            Console.Write("O");
            Console.ResetColor(); 
            Console.WriteLine("|");
            Console.Write("|");
            Console.ForegroundColor = GreenLamp ? ConsoleColor.Green : ConsoleColor.Gray;
            Console.Write("O");
            Console.ResetColor(); 
            Console.WriteLine("|");
            Console.ResetColor();
            Console.WriteLine("===");
        }
    }
}
