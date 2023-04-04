using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighters
{
    internal class TrafficLighterModes
    {
        internal Road_Traffic_Lighters mainRoadTrafficLighter_1 = new("=1=");
        internal Road_Traffic_Lighters mainRoadTrafficLighter_2 = new("=2=");
        internal Road_Traffic_Lighters secondaryRoadTrafficLighter_1 = new("=3=");
        internal Road_Traffic_Lighters secondaryRoadTrafficLighter_2 = new("=4=");
        internal Tram_Traffic_Lighters tramTrafficLighter_1 = new("=5=");
        internal Tram_Traffic_Lighters tramTrafficLighter_2 = new("=6=");
        internal Pedestrian_Traffic_Lighters pedestrianTrafficLighter_1 = new("=7=");
        internal Pedestrian_Traffic_Lighters pedestrianTrafficLighter_2 = new("=8=");

        internal const int mainTimer = 5000;
        internal const int blinkTimer = 500;
        internal const int numberOfChanges = 5;
        internal const int yellowTimer = 2000;
        internal int cycleTime = 0;

        internal enum DayTimeModes
        {
            First = 1,
            Second = 2,
            Third = 3,
            Fourth = 4,
            Fifth = 5,
            Sixth = 6,
            Seventh = 7
        }
        internal enum NightTimeModes
        {
            First = 1,
            Second = 2
        }
        internal enum WorkMode
        {
            First = 1,
            Second = 2,
            Third = 3
        }
        internal void CheckStatus()
        {
            mainRoadTrafficLighter_1.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            mainRoadTrafficLighter_2.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            secondaryRoadTrafficLighter_1.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            secondaryRoadTrafficLighter_2.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            tramTrafficLighter_1.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            tramTrafficLighter_2.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            pedestrianTrafficLighter_1.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            pedestrianTrafficLighter_2.TrafficLighterEvent += CheckStatusShowModuleEventArgs.CheckTrafficLighterStatus;
            mainRoadTrafficLighter_1.CheckTrafficLighterStatus();
            mainRoadTrafficLighter_2.CheckTrafficLighterStatus();
            secondaryRoadTrafficLighter_1.CheckTrafficLighterStatus();
            secondaryRoadTrafficLighter_2.CheckTrafficLighterStatus();
            tramTrafficLighter_1.CheckTrafficLighterStatus();
            tramTrafficLighter_2.CheckTrafficLighterStatus();
            pedestrianTrafficLighter_1.CheckTrafficLighterStatus();
            pedestrianTrafficLighter_2.CheckTrafficLighterStatus();
        }
        internal async Task Work_Mode(WorkMode mode)
        {
            mainRoadTrafficLighter_1.RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            mainRoadTrafficLighter_2.RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            secondaryRoadTrafficLighter_1.RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            secondaryRoadTrafficLighter_2.RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            tramTrafficLighter_1.TramTrafficLighterEvent += TramTrafficLighterEventArgs.ShowTramTrafficLighter;
            tramTrafficLighter_2.TramTrafficLighterEvent += TramTrafficLighterEventArgs.ShowTramTrafficLighter;
            pedestrianTrafficLighter_1.PedestrianTrafficLighterEvent += PedestrianTrafficLighterEventArgs.ShowPedestrianTrafficLight;
            pedestrianTrafficLighter_2.PedestrianTrafficLighterEvent += PedestrianTrafficLighterEventArgs.ShowPedestrianTrafficLight;
            switch (mode)
            {
                case WorkMode.First:
                    for (int i = TimeOfDay.TimeNow(); i >= TimeOfDay.DayModeStart() 
                        && i <= TimeOfDay.DayModeEnd(); i += cycleTime)
                    {
                        cycleTime = 0;
                        await DayTime_mode(DayTimeModes.First);
                    }
                    goto case WorkMode.Second;
                case WorkMode.Second:
                    OffTramAndPedestrian();
                    for (int i = TimeOfDay.TimeNow(); i > TimeOfDay.DayModeEnd() && i < TimeOfDay.DayEnd(); i+=cycleTime)                    
                    {
                        cycleTime = 0;                        
                        await NightTime_mode(NightTimeModes.First);
                    }
                    goto case WorkMode.Third;
                case WorkMode.Third:
                    OffTramAndPedestrian();
                    for( int i = TimeOfDay.TimeNow(); i > TimeOfDay.DayStart() && i < TimeOfDay.DayModeStart(); i+=cycleTime)
                    {
                        cycleTime = 0;
                        await NightTime_mode(NightTimeModes.First);
                    }
                    goto case WorkMode.First;                    
            }            
        }              

        internal async Task DayTime_mode(DayTimeModes mode)
        {
            switch (mode)
            {
                case DayTimeModes.First:
                    mainRoadTrafficLighter_1.RedOn();
                    mainRoadTrafficLighter_2.RedOn();
                    secondaryRoadTrafficLighter_1.RedOn();
                    secondaryRoadTrafficLighter_2.RedOn();
                    tramTrafficLighter_1.RedOn();
                    tramTrafficLighter_2.RedOn();
                    pedestrianTrafficLighter_1.RedOn();
                    pedestrianTrafficLighter_2.RedOn();
                    goto case DayTimeModes.Second;
                case DayTimeModes.Second:
                    mainRoadTrafficLighter_1.RedYellowOn();
                    mainRoadTrafficLighter_2.RedYellowOn();
                    secondaryRoadTrafficLighter_1.RedOn();
                    secondaryRoadTrafficLighter_2.RedOn();
                    tramTrafficLighter_1.RedOn();
                    tramTrafficLighter_2.RedOn();
                    pedestrianTrafficLighter_1.RedOn();
                    pedestrianTrafficLighter_2.RedOn();
                    await Task.Delay(yellowTimer);
                    cycleTime += yellowTimer;
                    goto case DayTimeModes.Third;
                case DayTimeModes.Third:
                    mainRoadTrafficLighter_1.GreenOn();
                    mainRoadTrafficLighter_2.GreenOn();
                    secondaryRoadTrafficLighter_1.RedOn();
                    secondaryRoadTrafficLighter_2.RedOn();
                    tramTrafficLighter_1.RedOn();
                    tramTrafficLighter_2.RedOn();
                    pedestrianTrafficLighter_1.RedOn();
                    pedestrianTrafficLighter_2.RedOn();
                    await Task.Delay(mainTimer);
                    cycleTime += mainTimer;
                    mainRoadTrafficLighter_1.OffLight();
                    mainRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    mainRoadTrafficLighter_1.GreenOn();
                    mainRoadTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    mainRoadTrafficLighter_1.OffLight();
                    mainRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    mainRoadTrafficLighter_1.GreenOn();
                    mainRoadTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    mainRoadTrafficLighter_1.OffLight();
                    mainRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    mainRoadTrafficLighter_1.GreenOn();
                    mainRoadTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    mainRoadTrafficLighter_1.OffLight();
                    mainRoadTrafficLighter_2.OffLight();                    
                    goto case DayTimeModes.Fourth;
                case DayTimeModes.Fourth:
                    mainRoadTrafficLighter_1.YellowOn();
                    mainRoadTrafficLighter_2.YellowOn();
                    secondaryRoadTrafficLighter_1.RedYellowOn();
                    secondaryRoadTrafficLighter_2.RedYellowOn();
                    tramTrafficLighter_1.RedOn();
                    tramTrafficLighter_2.RedOn();
                    pedestrianTrafficLighter_1.RedOn();
                    pedestrianTrafficLighter_2.RedOn();
                    await Task.Delay(yellowTimer);
                    cycleTime += yellowTimer;
                    goto case DayTimeModes.Fifth;
                case DayTimeModes.Fifth:
                    mainRoadTrafficLighter_1.RedOn();
                    mainRoadTrafficLighter_2.RedOn();
                    secondaryRoadTrafficLighter_1.GreenOn();
                    secondaryRoadTrafficLighter_2.GreenOn();
                    tramTrafficLighter_1.RedOn();
                    tramTrafficLighter_2.RedOn();
                    pedestrianTrafficLighter_1.RedOn();
                    pedestrianTrafficLighter_2.RedOn();
                    await Task.Delay(mainTimer);
                    cycleTime += mainTimer;
                    secondaryRoadTrafficLighter_1.OffLight();
                    secondaryRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    secondaryRoadTrafficLighter_1.GreenOn();
                    secondaryRoadTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    secondaryRoadTrafficLighter_1.OffLight();
                    secondaryRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    secondaryRoadTrafficLighter_1.GreenOn();
                    secondaryRoadTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    secondaryRoadTrafficLighter_1.OffLight();
                    secondaryRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    secondaryRoadTrafficLighter_1.GreenOn();
                    secondaryRoadTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    secondaryRoadTrafficLighter_1.OffLight();
                    secondaryRoadTrafficLighter_2.OffLight();
                    goto case DayTimeModes.Sixth;
                case DayTimeModes.Sixth:
                    mainRoadTrafficLighter_1.RedOn();
                    mainRoadTrafficLighter_2.RedOn();
                    secondaryRoadTrafficLighter_1.YellowOn();
                    secondaryRoadTrafficLighter_2.YellowOn();
                    tramTrafficLighter_1.RedOn();
                    tramTrafficLighter_2.RedOn();
                    pedestrianTrafficLighter_1.RedOn();
                    pedestrianTrafficLighter_2.RedOn();
                    await Task.Delay(yellowTimer);
                    cycleTime += yellowTimer;
                    goto case DayTimeModes.Seventh;
                case DayTimeModes.Seventh:
                    mainRoadTrafficLighter_1.RedOn();
                    mainRoadTrafficLighter_2.RedOn();
                    secondaryRoadTrafficLighter_1.RedOn();
                    secondaryRoadTrafficLighter_2.RedOn();
                    tramTrafficLighter_1.GreenOn();
                    tramTrafficLighter_2.GreenOn();
                    pedestrianTrafficLighter_1.GreenOn();
                    pedestrianTrafficLighter_2.GreenOn();
                    await Task.Delay(mainTimer);
                    cycleTime += mainTimer;
                    pedestrianTrafficLighter_1.OffLight();
                    pedestrianTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    pedestrianTrafficLighter_1.GreenOn();
                    pedestrianTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    pedestrianTrafficLighter_1.OffLight();
                    pedestrianTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    pedestrianTrafficLighter_1.GreenOn();
                    pedestrianTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    pedestrianTrafficLighter_1.OffLight();
                    pedestrianTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    pedestrianTrafficLighter_1.GreenOn();
                    pedestrianTrafficLighter_2.GreenOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    pedestrianTrafficLighter_1.OffLight();
                    pedestrianTrafficLighter_2.OffLight();
                    break;
            }            
        }
        internal async Task NightTime_mode(NightTimeModes mode)
        {            
            switch (mode)
            {
                case NightTimeModes.First:
                    mainRoadTrafficLighter_1.OffLight();
                    mainRoadTrafficLighter_2.OffLight();
                    secondaryRoadTrafficLighter_1.OffLight();
                    secondaryRoadTrafficLighter_2.OffLight();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    goto case NightTimeModes.Second;
                case NightTimeModes.Second:
                    mainRoadTrafficLighter_1.YellowOn();
                    mainRoadTrafficLighter_2.YellowOn();
                    secondaryRoadTrafficLighter_1.YellowOn();
                    secondaryRoadTrafficLighter_2.YellowOn();
                    await Task.Delay(blinkTimer);
                    cycleTime += blinkTimer;
                    break;
            }
        }
        internal void OffTramAndPedestrian()
        {
            tramTrafficLighter_1.OffLight();
            tramTrafficLighter_2.OffLight();
            pedestrianTrafficLighter_1.OffLight();
            pedestrianTrafficLighter_2.OffLight();
        }
    }
}
