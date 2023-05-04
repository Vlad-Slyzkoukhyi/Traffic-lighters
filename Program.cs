using Traffic_lighters;


Console.WriteLine($"Application start {DateTime.Now}");

CrossRoadController crossRoadController = new();
await crossRoadController.DayMode();
//NightMode
//await crossRoadController.NightMode();




