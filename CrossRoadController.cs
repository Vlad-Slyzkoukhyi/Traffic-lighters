using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Traffic_lighters;

namespace Traffic_lighters
{
    internal class CrossRoadController
    {
        internal delegate void CrossRoadControllerHandler(CrossRoadController controller, CrossRoadControllerEventArgs e);
        internal event CrossRoadControllerHandler? CrossRoadControllerEvent;
        
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

        internal const int mainTimer = 5000;
        internal const int blinkTimer = 500;
        internal const int numberOfChanges = 5;
        internal const int yellowTimer = 2000;
        int time = TimeOfDay.TimeNow();
        internal int cycleTime = 0;

        internal Dictionary<string, List<string>> DayModeStatesCollection = new()
        {
            {"States",    new(){"1","2","3","4","5", "6", "7", "8", "9", "10"} },
            {"Main",      new(){"RED","REDYELLOW","GREEN","BLINKGREEN","YELLOW",   "RED",  "RED",       "RED",   "RED","RED"}},
            {"Secondary", new(){"RED","RED",      "RED",  "RED",       "REDYELLOW","GREEN","BLINKGREEN","YELLOW","RED","RED"}},
            {"Tram",      new(){"STOP","STOP",    "STOP", "STOP",       "STOP",     "STOP","STOP",      "STOP",  "GO", "GO" }},
            {"Pedestrian",new(){"RED", "RED",      "RED", "RED",        "RED",      "RED", "RED",       "RED",  "GREEN","BLINKGREEN"}}
        };
        internal Dictionary<string, List<string>> NightModeStatesCollection = new()
        {
            {"States",    new(){"11","12" } },
            {"Main",      new(){"BLINKYELLOW","OFF"}},
            {"Secondary", new(){"BLINKYELLOW","OFF"}},
            {"Tram",      new(){ "OFF", "OFF" } },
            {"Pedestrian",new(){ "OFF", "OFF" }}
        };
        
        //First implementation
        internal async Task DayMode()
        {
            CrossRoadController crossRoadController = new();
            do
            {
                time = TimeOfDay.TimeNow();
                if (time >= TimeOfDay.DayModeStart() && time <= TimeOfDay.DayModeEnd())
                {
                    crossRoadController.CrossRoadControllerEvent += CrossRoadControllerEventArgs.ShowCrossRoadDayModeState;
                    do
                    {
                        for (int i = 0; i < DayModeStatesCollection["States"].Count; i++)
                        {
                            time += cycleTime;
                            cycleTime = 0;
                            State = DayModeStatesCollection["States"][i];
                            Main = DayModeStatesCollection["Main"][i];
                            Secondary = DayModeStatesCollection["Secondary"][i];
                            Tram = DayModeStatesCollection["Tram"][i];
                            Pedestrian = DayModeStatesCollection["Pedestrian"][i];
                            if (Main == "GREEN" || Secondary == "GREEN" || Pedestrian == "GREEN")
                            {
                                cycleTime += mainTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(mainTimer);
                            }
                            else if (Main == "REDYELLOW" || Secondary == "REDYELLOW" || Main == "YELLOW" || Secondary == "YELLOW")
                            {
                                cycleTime += yellowTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(yellowTimer);
                            }
                            else if (Main == "BLINKGREEN" || Secondary == "BLINKGREEN" || Pedestrian == "BLINKGREEN")
                            {
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                            }
                            else
                            {
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                            }
                        }
                    }
                    while (time >= TimeOfDay.DayModeStart() && time <= TimeOfDay.DayModeEnd());
                }
                else if (time > TimeOfDay.DayModeEnd() && time < TimeOfDay.DayEnd())
                {
                    crossRoadController.CrossRoadControllerEvent += CrossRoadControllerEventArgs.ShowCrossRoadNightModeState;
                    Pedestrian = NightModeStatesCollection["Pedestrian"][0];
                    Tram = NightModeStatesCollection["Tram"][0];
                    do
                    {
                        for (int i = 0; i < NightModeStatesCollection["States"].Count; i++)
                        {
                            time += cycleTime;
                            cycleTime = 0;
                            State = NightModeStatesCollection["States"][i];
                            Main = NightModeStatesCollection["Main"][i];
                            Secondary = NightModeStatesCollection["Secondary"][i];
                            if (Main == "BLINKYELLOW" && Secondary == "BLINKYELLOW")
                            {
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                            }
                            else
                            {
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                            }
                        }
                    }
                    while (time > TimeOfDay.DayModeEnd() && time < TimeOfDay.DayEnd());
                }
                else if (time > TimeOfDay.DayStart() && time < TimeOfDay.DayModeStart())
                {
                    crossRoadController.CrossRoadControllerEvent += CrossRoadControllerEventArgs.ShowCrossRoadNightModeState;
                    Pedestrian = NightModeStatesCollection["Pedestrian"][0];
                    Tram = NightModeStatesCollection["Tram"][0];
                    do
                    {
                        for (int i = 0; i < NightModeStatesCollection["States"].Count; i++)
                        {
                            time += cycleTime;
                            cycleTime = 0;
                            State = NightModeStatesCollection["States"][i];
                            Main = NightModeStatesCollection["Main"][i];
                            Secondary = NightModeStatesCollection["Secondary"][i];
                            if (Main == "BLINKYELLOW" && Secondary == "BLINKYELLOW")
                            {
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                            }
                            else
                            {
                                cycleTime += blinkTimer;
                                crossRoadController.CrossRoadControllerEvent?.Invoke(this, new CrossRoadControllerEventArgs(State, Main, Secondary, Tram, Pedestrian));
                                await Task.Delay(blinkTimer);
                            }
                        }
                    }
                    while (time > TimeOfDay.DayStart() && time < TimeOfDay.DayModeStart());
                }
            }
            while (true);
            
        }
        //Second implementation
        internal async Task DayMode2(TrafficLighter TRL)
        {
            TRL.RoadTrafficLighterEvent += TrafficLighterShowModule.ShowRoadTrafficLighter;
            TRL.TramTrafficLighterEvent += TrafficLighterShowModule.ShowTramTrafficLighter;
            TRL.PedestrianTrafficLighterEvent += TrafficLighterShowModule.ShowPedestrianTrafficLight;

            if (time > TimeOfDay.DayModeStart() && time <= TimeOfDay.DayModeEnd())
            {
                do
                {
                    for (int i = 0; i < DayModeStatesCollection["States"].Count; i++)
                    {
                        time += cycleTime;
                        cycleTime = 0;
                        State = DayModeStatesCollection["States"][i];
                        switch (State)
                        {
                            case "1":
                                TRL.RoadRedOn();
                                TRL.RoadRedOn();
                                TRL.TramRedOn();
                                TRL.PedestrianRedOn();
                                break;
                            case "2":
                                TRL.RoadRedYellowOn();
                                TRL.RoadRedOn();
                                TRL.TramRedOn();
                                TRL.PedestrianRedOn();
                                await Task.Delay(yellowTimer);
                                cycleTime += yellowTimer;
                                break;
                            case "3":
                                TRL.RoadGreenOn();
                                TRL.RoadRedOn();
                                TRL.TramRedOn();
                                TRL.PedestrianRedOn();
                                await Task.Delay(mainTimer);
                                cycleTime += mainTimer;
                                break;
                            case "4":
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadOffLight();
                                break;
                            case "5":
                                TRL.RoadYellowOn();
                                TRL.RoadRedYellowOn();
                                TRL.TramRedOn();
                                TRL.PedestrianRedOn();
                                await Task.Delay(yellowTimer);
                                cycleTime += yellowTimer;
                                break;
                            case "6":
                                TRL.RoadRedOn();
                                TRL.RoadGreenOn();
                                TRL.TramRedOn();
                                TRL.PedestrianRedOn();
                                await Task.Delay(mainTimer);
                                cycleTime += mainTimer;
                                break;
                            case "7":
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.RoadOffLight();
                                break;
                            case "8":
                                TRL.RoadRedOn();
                                TRL.RoadYellowOn();
                                TRL.TramRedOn();
                                TRL.PedestrianRedOn();
                                await Task.Delay(yellowTimer);
                                cycleTime += yellowTimer;
                                break;
                            case "9":
                                TRL.RoadRedOn();
                                TRL.RoadRedOn();
                                TRL.TramGreenOn();
                                TRL.PedestrianGreenOn();
                                await Task.Delay(mainTimer);
                                cycleTime += mainTimer;
                                break;
                            case "10":
                                TRL.PedestrianOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.PedestrianGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.PedestrianOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.PedestrianGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.PedestrianOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.PedestrianGreenOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                TRL.PedestrianOffLight();
                                break;
                        }
                    }
                }
                while (time >= TimeOfDay.DayModeStart() && time <= TimeOfDay.DayModeEnd());
            }
            else if (time > TimeOfDay.DayModeEnd() && time < TimeOfDay.DayEnd())
            {
                TRL.PedestrianOffLight();
                TRL.TramOffLight();
                do
                {
                    for (int i = 0; i < NightModeStatesCollection["States"].Count; i++)
                    {
                        time += cycleTime;
                        cycleTime = 0;
                        State = NightModeStatesCollection["States"][i];
                        switch (State)
                        {
                            case "1":
                                TRL.RoadYellowOn();
                                TRL.RoadYellowOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                break;
                            case "2":
                                TRL.RoadOffLight();
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                break;
                        }
                    }
                }
                while (time > TimeOfDay.DayModeEnd() && time < TimeOfDay.DayEnd());
            }
            else if (time > TimeOfDay.DayStart() && time < TimeOfDay.DayModeStart())
            {
                TRL.PedestrianOffLight();
                TRL.TramOffLight();
                do
                {
                    for (int i = 0; i < NightModeStatesCollection["States"].Count; i++)
                    {
                        time += cycleTime;
                        cycleTime = 0;
                        State = NightModeStatesCollection["States"][i];
                        switch (State)
                        {
                            case "1":
                                TRL.RoadYellowOn();
                                TRL.RoadYellowOn();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                break;
                            case "2":
                                TRL.RoadOffLight();
                                TRL.RoadOffLight();
                                await Task.Delay(blinkTimer);
                                cycleTime += blinkTimer;
                                break;
                        }
                    }
                }
                while (time > TimeOfDay.DayStart() && time < TimeOfDay.DayModeStart());
            }
        }
    }
}
