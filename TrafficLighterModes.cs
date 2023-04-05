using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighters
{
    internal class TrafficLighterModes
    {
        internal Dictionary<string, Road_Traffic_Lighters> roadTrafficlighters = new()
        {
            {"mainRoadTL_1", new Road_Traffic_Lighters ("=1=")},
            {"mainRoadTL_2", new Road_Traffic_Lighters ("=2=")},
            {"secondaryRoadTL_1", new Road_Traffic_Lighters("=3=")},
            {"secondaryRoadTL_2", new Road_Traffic_Lighters("=4=")}
        };
        internal Dictionary<string, Tram_Traffic_Lighters> tramTrafficlighters = new()
        {
            {"tramTL_1", new Tram_Traffic_Lighters("=5=")},
            {"tramTL_2", new Tram_Traffic_Lighters("=6=")}
        };
        internal Dictionary<string, Pedestrian_Traffic_Lighters> pedestrianTrafficlighters = new()
        {
            {"pedestrianTL_1", new Pedestrian_Traffic_Lighters("=7=")},
            {"pedestrianTL_2", new Pedestrian_Traffic_Lighters("=8=")}
        };

        internal Dictionary<string, Road_Traffic_Lighters> roadTrafficlightersStates = new()
        {
            {"RoadTL_Red", new Road_Traffic_Lighters ("RoadTL") {RedLamp = true, YellowLamp = false, GreenLamp = false}},
            {"RoadTL_RedYellow", new Road_Traffic_Lighters ("RoadTL") {RedLamp = true, YellowLamp = true, GreenLamp = false}},
            {"RoadTL_Yellow", new Road_Traffic_Lighters("RoadTL") {RedLamp = false, YellowLamp = true, GreenLamp = false}},
            {"RoadTL_Green", new Road_Traffic_Lighters("RoadTL") {RedLamp = false, YellowLamp = false, GreenLamp = true}},
            {"RoadTL_Off", new Road_Traffic_Lighters("RoadTL"){RedLamp = false, YellowLamp = false, GreenLamp = false} }
        };
        internal Dictionary<string, Tram_Traffic_Lighters> tramTrafficlightersStates = new()
        {
            {"TramTL_Red", new Tram_Traffic_Lighters("TramTL"){RightLamp = true, MiddleLamp = true, LeftLamp = true, BottomLamp = false}},
            {"TramTL_Green", new Tram_Traffic_Lighters("TramTL"){RightLamp = true, MiddleLamp = true, LeftLamp = true, BottomLamp = true}},
            {"TramTL_Off", new Tram_Traffic_Lighters("TramTL"){RightLamp = false, MiddleLamp = false, LeftLamp = false, BottomLamp = false}}
        };
        internal Dictionary<string, Pedestrian_Traffic_Lighters> pedestrianTrafficlightersStates = new()
        {
            {"pedestrianTL_Red", new Pedestrian_Traffic_Lighters("PedestrianTL"){RedLamp = true, GreenLamp = false } },
            {"pedestrianTL_Green", new Pedestrian_Traffic_Lighters("PedestrianTL"){RedLamp = false, GreenLamp = true }},
            {"pedestrianTL_Off", new Pedestrian_Traffic_Lighters("PedestrianTL"){RedLamp = false, GreenLamp = false }}
        };    
        

        internal const int mainTimer = 5000;
        internal const int blinkTimer = 500;
        internal const int numberOfChanges = 5;
        internal const int yellowTimer = 2000;
        internal int cycleTime = 0;

        internal enum WorkMode
        {
            DayTimeMode = 1,
            ModeUntilMidnight = 2,
            ModeAfterMidnight = 3
        }
        
        internal void CheckStatus()
        {
            roadTrafficlighters["mainRoadTL_1"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            roadTrafficlighters["mainRoadTL_2"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            roadTrafficlighters["secondaryRoadTL_1"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            roadTrafficlighters["secondaryRoadTL_2"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            tramTrafficlighters["tramTL_1"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            tramTrafficlighters["tramTL_2"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            pedestrianTrafficlighters["pedestrianTL_1"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            pedestrianTrafficlighters["pedestrianTL_2"].TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            roadTrafficlighters["mainRoadTL_1"].CheckTrafficLighterStatus();
            roadTrafficlighters["mainRoadTL_2"].CheckTrafficLighterStatus();
            roadTrafficlighters["secondaryRoadTL_1"].CheckTrafficLighterStatus();
            roadTrafficlighters["secondaryRoadTL_2"].CheckTrafficLighterStatus();
            tramTrafficlighters["tramTL_1"].CheckTrafficLighterStatus();
            tramTrafficlighters["tramTL_2"].CheckTrafficLighterStatus();
            pedestrianTrafficlighters["pedestrianTL_1"].CheckTrafficLighterStatus();
            pedestrianTrafficlighters["pedestrianTL_2"].CheckTrafficLighterStatus();
        }
        internal async Task Work_Mode(WorkMode mode)
        {
            roadTrafficlighters["mainRoadTL_1"].RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            roadTrafficlighters["mainRoadTL_2"].RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            roadTrafficlighters["secondaryRoadTL_1"].RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            roadTrafficlighters["secondaryRoadTL_2"].RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            tramTrafficlighters["tramTL_1"].TramTrafficLighterEvent += TramTrafficLighterEventArgs.ShowTramTrafficLighter;
            tramTrafficlighters["tramTL_2"].TramTrafficLighterEvent += TramTrafficLighterEventArgs.ShowTramTrafficLighter;
            pedestrianTrafficlighters["pedestrianTL_1"].PedestrianTrafficLighterEvent += PedestrianTrafficLighterEventArgs.ShowPedestrianTrafficLight;
            pedestrianTrafficlighters["pedestrianTL_2"].PedestrianTrafficLighterEvent += PedestrianTrafficLighterEventArgs.ShowPedestrianTrafficLight;
            switch (mode)
            {
                case WorkMode.DayTimeMode:
                    for (int i = TimeOfDay.TimeNow(); i >= TimeOfDay.DayModeStart() 
                        && i <= TimeOfDay.DayModeEnd(); i += cycleTime)
                    {
                        cycleTime = 0;
                        await DayTime_mode();
                    }
                    goto case WorkMode.ModeUntilMidnight;
                case WorkMode.ModeUntilMidnight:
                    OffTramAndPedestrian();
                    for (int i = TimeOfDay.TimeNow(); i > TimeOfDay.DayModeEnd() && i < TimeOfDay.DayEnd(); i+=cycleTime)                    
                    {
                        cycleTime = 0;                        
                        await NightTime_mode();
                    }
                    goto case WorkMode.ModeAfterMidnight;
                case WorkMode.ModeAfterMidnight:
                    OffTramAndPedestrian();
                    for( int i = TimeOfDay.TimeNow(); i > TimeOfDay.DayStart() && i < TimeOfDay.DayModeStart(); i+=cycleTime)
                    {
                        cycleTime = 0;
                        await NightTime_mode();
                    }
                    goto case WorkMode.DayTimeMode;                    
            }            
        }

        internal async Task DayTime_mode()
        {
            AllRed();
            await MainRoadRedYellow();
            await MainRoadGreen();
            await MainRoadBlinkGreen();
            await SecondaryRoadRedYellowMainYellow();
            await SecondaryRoadGreen();
            await SecondaryRoadBlinkGreen();
            await SecondaryRoadYellow();
            await TramPedestrianGreen();
            await PedestrianBlinkGreen();
        }
        internal void AllRed()
        {
            roadTrafficlighters["mainRoadTL_1"].RedOn();
            roadTrafficlighters["mainRoadTL_2"].RedOn();
            roadTrafficlighters["secondaryRoadTL_1"].RedOn();
            roadTrafficlighters["secondaryRoadTL_2"].RedOn();
            tramTrafficlighters["tramTL_1"].RedOn();
            tramTrafficlighters["tramTL_2"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_1"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_2"].RedOn();
        }
        async Task MainRoadRedYellow()
        {
            roadTrafficlighters["mainRoadTL_1"].RedYellowOn();
            roadTrafficlighters["mainRoadTL_2"].RedYellowOn();
            roadTrafficlighters["secondaryRoadTL_1"].RedOn();
            roadTrafficlighters["secondaryRoadTL_2"].RedOn();
            tramTrafficlighters["tramTL_1"].RedOn();
            tramTrafficlighters["tramTL_2"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_1"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_2"].RedOn();
            await Task.Delay(yellowTimer);
            cycleTime += yellowTimer;
        }
        async Task MainRoadGreen()
        {
            roadTrafficlighters["mainRoadTL_1"].GreenOn();
            roadTrafficlighters["mainRoadTL_2"].GreenOn();
            roadTrafficlighters["secondaryRoadTL_1"].RedOn();
            roadTrafficlighters["secondaryRoadTL_2"].RedOn();
            tramTrafficlighters["tramTL_1"].RedOn();
            tramTrafficlighters["tramTL_2"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_1"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_2"].RedOn();
            await Task.Delay(mainTimer);
            cycleTime += mainTimer;
        }
        async Task MainRoadBlinkGreen()
        {
            roadTrafficlighters["mainRoadTL_1"].OffLight();
            roadTrafficlighters["mainRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["mainRoadTL_1"].GreenOn();
            roadTrafficlighters["mainRoadTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["mainRoadTL_1"].OffLight();
            roadTrafficlighters["mainRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["mainRoadTL_1"].GreenOn();
            roadTrafficlighters["mainRoadTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["mainRoadTL_1"].OffLight();
            roadTrafficlighters["mainRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["mainRoadTL_1"].GreenOn();
            roadTrafficlighters["mainRoadTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["mainRoadTL_1"].OffLight();
            roadTrafficlighters["mainRoadTL_2"].OffLight();
        }
        async Task SecondaryRoadRedYellowMainYellow()
        {
            roadTrafficlighters["mainRoadTL_1"].YellowOn();
            roadTrafficlighters["mainRoadTL_2"].YellowOn();
            roadTrafficlighters["secondaryRoadTL_1"].RedYellowOn();
            roadTrafficlighters["secondaryRoadTL_2"].RedYellowOn();
            tramTrafficlighters["tramTL_1"].RedOn();
            tramTrafficlighters["tramTL_2"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_1"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_2"].RedOn();
            await Task.Delay(yellowTimer);
            cycleTime += yellowTimer;
        }
        async Task SecondaryRoadGreen()
        {
            roadTrafficlighters["mainRoadTL_1"].RedOn();
            roadTrafficlighters["mainRoadTL_2"].RedOn();
            roadTrafficlighters["secondaryRoadTL_1"].GreenOn();
            roadTrafficlighters["secondaryRoadTL_2"].GreenOn();
            tramTrafficlighters["tramTL_1"].RedOn();
            tramTrafficlighters["tramTL_2"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_1"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_2"].RedOn();
            await Task.Delay(mainTimer);
            cycleTime += mainTimer;
        }
        async Task SecondaryRoadBlinkGreen()
        {
            roadTrafficlighters["secondaryRoadTL_1"].OffLight();
            roadTrafficlighters["secondaryRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["secondaryRoadTL_1"].GreenOn();
            roadTrafficlighters["secondaryRoadTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["secondaryRoadTL_1"].OffLight();
            roadTrafficlighters["secondaryRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["secondaryRoadTL_1"].GreenOn();
            roadTrafficlighters["secondaryRoadTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["secondaryRoadTL_1"].OffLight();
            roadTrafficlighters["secondaryRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["secondaryRoadTL_1"].GreenOn();
            roadTrafficlighters["secondaryRoadTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            roadTrafficlighters["secondaryRoadTL_1"].OffLight();
            roadTrafficlighters["secondaryRoadTL_2"].OffLight();
        }
        async Task SecondaryRoadYellow()
        {
            roadTrafficlighters["mainRoadTL_1"].RedOn();
            roadTrafficlighters["mainRoadTL_2"].RedOn();
            roadTrafficlighters["secondaryRoadTL_1"].YellowOn();
            roadTrafficlighters["secondaryRoadTL_2"].YellowOn();
            tramTrafficlighters["tramTL_1"].RedOn();
            tramTrafficlighters["tramTL_2"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_1"].RedOn();
            pedestrianTrafficlighters["pedestrianTL_2"].RedOn();
            await Task.Delay(yellowTimer);
            cycleTime += yellowTimer;
        }
        async Task TramPedestrianGreen()
        {
            roadTrafficlighters["mainRoadTL_1"].RedOn();
            roadTrafficlighters["mainRoadTL_2"].RedOn();
            roadTrafficlighters["secondaryRoadTL_1"].RedOn();
            roadTrafficlighters["secondaryRoadTL_2"].RedOn();
            tramTrafficlighters["tramTL_1"].GreenOn();
            tramTrafficlighters["tramTL_2"].GreenOn();
            pedestrianTrafficlighters["pedestrianTL_1"].GreenOn();
            pedestrianTrafficlighters["pedestrianTL_2"].GreenOn();
            await Task.Delay(mainTimer);
            cycleTime += mainTimer;
        }
        async Task PedestrianBlinkGreen()
        {
            pedestrianTrafficlighters["pedestrianTL_1"].OffLight();
            pedestrianTrafficlighters["pedestrianTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            pedestrianTrafficlighters["pedestrianTL_1"].GreenOn();
            pedestrianTrafficlighters["pedestrianTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            pedestrianTrafficlighters["pedestrianTL_1"].OffLight();
            pedestrianTrafficlighters["pedestrianTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            pedestrianTrafficlighters["pedestrianTL_1"].GreenOn();
            pedestrianTrafficlighters["pedestrianTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            pedestrianTrafficlighters["pedestrianTL_1"].OffLight();
            pedestrianTrafficlighters["pedestrianTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            pedestrianTrafficlighters["pedestrianTL_1"].GreenOn();
            pedestrianTrafficlighters["pedestrianTL_2"].GreenOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
            pedestrianTrafficlighters["pedestrianTL_1"].OffLight();
            pedestrianTrafficlighters["pedestrianTL_2"].OffLight();
        }

        internal async Task NightTime_mode()
        {
            await OffLightMainSecondary();
            await MainSecondaryYellow();
        }
        async Task OffLightMainSecondary()
        {
            roadTrafficlighters["mainRoadTL_1"].OffLight();
            roadTrafficlighters["mainRoadTL_2"].OffLight();
            roadTrafficlighters["secondaryRoadTL_1"].OffLight();
            roadTrafficlighters["secondaryRoadTL_2"].OffLight();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
        }
        async Task MainSecondaryYellow()
        {
            roadTrafficlighters["mainRoadTL_1"].YellowOn();
            roadTrafficlighters["mainRoadTL_2"].YellowOn();
            roadTrafficlighters["secondaryRoadTL_1"].YellowOn();
            roadTrafficlighters["secondaryRoadTL_2"].YellowOn();
            await Task.Delay(blinkTimer);
            cycleTime += blinkTimer;
        }
        
        internal void OffTramAndPedestrian()
        {
            tramTrafficlighters["tramTL_1"].OffLight();
            tramTrafficlighters["tramTL_2"].OffLight();
            pedestrianTrafficlighters["pedestrianTL_1"].OffLight();
            pedestrianTrafficlighters["pedestrianTL_2"].OffLight();
        }
    }
}
