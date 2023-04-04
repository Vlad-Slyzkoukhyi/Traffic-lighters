using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighters
{
    internal class CheckStatusShowModuleEventArgs
    {
        internal string Name { get; set;}
        internal CheckStatusShowModuleEventArgs(string name)
        {
            Name = name;
        }
        internal static void CheckTrafficLighterStatus(TrafficLighter trafficLighter, CheckStatusShowModuleEventArgs e)
        {
            if (trafficLighter != null)
            {
                Console.WriteLine($"{e.Name} {trafficLighter.GetType()} was created, and ready for work");
            }
            else
            {                
                Console.WriteLine("System was not working, check settings");
            }
        }
    }
}
