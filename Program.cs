using Traffic_lighter_0._0._2;

Console.WriteLine($"Application start {DateTime.Now}");

Mode mode = new ();

await mode.Lighters_mode(Mode.Modes.First);