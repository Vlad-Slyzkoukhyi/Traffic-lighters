using Traffic_lighters;


Console.WriteLine($"Application start {DateTime.Now}");

CrossRoadController crossRoadController = new();
await crossRoadController.DayMode();
/*Second Implementation
TrafficLighter TRL = new("TRL");
await crossRoadController.DayMode2(TRL);*/



