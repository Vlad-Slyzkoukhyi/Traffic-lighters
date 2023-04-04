using Traffic_lighters;
using static Traffic_lighters.TrafficLighterModes;

Console.WriteLine($"Application start {DateTime.Now}");

TrafficLighterModes mode = new ();

mode.CheckStatus();

await mode.Work_Mode(WorkMode.First);


