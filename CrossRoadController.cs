using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Traffic_lighters;
using static Traffic_lighters.CrossRoadController;

namespace Traffic_lighters
{
    internal class CrossRoadController
    {
        internal delegate void RoadTrafficLighterHandler(RoadTrafficLighterEventArgs e);
        internal event RoadTrafficLighterHandler? RoadTrafficLighterEvent;
        internal delegate void TramTrafficLighterHandler(TramTrafficLighterEventArgs e);
        internal event TramTrafficLighterHandler? TramTrafficLighterEvent;
        internal delegate void PedestrianTrafficLighterHandler(PedestrianTrafficLighterEventArgs e);
        internal event PedestrianTrafficLighterHandler? PedestrianTrafficLighterEvent;
        
        internal StatesCondition? MainTLState { get; set; }
        internal StatesCondition? SecondaryTLState { get; set; }
        internal StatesCondition? TramTLState { get; set; }
        internal StatesCondition? PedestrianTLState { get; set; }
        internal int Time { get; set; }

        internal enum TrafficLightsNames
        {
            MainTL = 0,
            SecondaryTL = 1,
            TramTL = 2,
            PedestrianTL = 3,
        }
        internal Dictionary<int, TrafficLightsNames> TrafficLightersNames = new()
        {
            {0, TrafficLightsNames.MainTL},
            {1, TrafficLightsNames.SecondaryTL},
            {2, TrafficLightsNames.TramTL},
            {3, TrafficLightsNames.PedestrianTL }
        };
        internal enum CrossRoadsStates
        {
            ALLRED = 0,
            MAINREDYELLOW = 1,
            MAINGREEN = 2,
            MAINBLINKGREEN = 3,
            MAINYELLOW = 4,
            SECONDARYGREEN = 5,
            SECONDARYBLINKGREEN = 6,
            SECONDARYYELLOW = 7,
            TRAMANDPEDESTRIANGREEN = 8,
            PEDESTRIANBLINKGREEN = 9,
            OFFLIGHT = 10,
            BLINKYELLOW =11
                            }
        internal enum StatesCondition
                            {
            RED = 0,
            REDYELLOW = 1,
            GREEN = 2,
            YELLOW = 3,
            BLINKGREEN = 4,
            BLINKYELLOW = 5,
            GO = 6,
            STOP = 7,
            OFFLIGHT = 8
                            }
        internal static Dictionary<CrossRoadsStates, CrossRoadController> BuildDayModeCollection()
                            {
            return new Dictionary<CrossRoadsStates, CrossRoadController>
                            {
            {CrossRoadsStates.ALLRED,             
                    new(){MainTLState = StatesCondition.RED,       SecondaryTLState = StatesCondition.RED,       TramTLState = StatesCondition.STOP,
                        PedestrianTLState = StatesCondition.RED,        Time = 0 } },
            {CrossRoadsStates.MAINREDYELLOW,      
                    new(){MainTLState = StatesCondition.REDYELLOW, SecondaryTLState = StatesCondition.RED,       TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=2000} },
            {CrossRoadsStates.MAINGREEN,          
                    new(){MainTLState = StatesCondition.GREEN,     SecondaryTLState = StatesCondition.RED,       TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=5000} },
            {CrossRoadsStates.MAINBLINKGREEN,     
                    new(){MainTLState = StatesCondition.BLINKGREEN,SecondaryTLState = StatesCondition.RED,       TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=3000} },
            {CrossRoadsStates.MAINYELLOW,         
                    new(){MainTLState = StatesCondition.YELLOW,    SecondaryTLState = StatesCondition.REDYELLOW, TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=2000} },
            {CrossRoadsStates.SECONDARYGREEN,     
                    new(){MainTLState = StatesCondition.RED,       SecondaryTLState = StatesCondition.GREEN,     TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=5000} },
            {CrossRoadsStates.SECONDARYBLINKGREEN,
                    new(){MainTLState = StatesCondition.RED,       SecondaryTLState = StatesCondition.BLINKGREEN,TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=3000} },
            {CrossRoadsStates.SECONDARYYELLOW,    
                    new(){MainTLState = StatesCondition.RED,       SecondaryTLState = StatesCondition.YELLOW,    TramTLState = StatesCondition.STOP, 
                        PedestrianTLState = StatesCondition.RED,        Time=2000} },
            {CrossRoadsStates.TRAMANDPEDESTRIANGREEN,
                    new(){MainTLState = StatesCondition.RED,       SecondaryTLState = StatesCondition.RED,       TramTLState = StatesCondition.GO,   
                        PedestrianTLState = StatesCondition.GREEN,      Time=5000} },
            {CrossRoadsStates.PEDESTRIANBLINKGREEN,
                    new(){MainTLState = StatesCondition.RED,       SecondaryTLState = StatesCondition.RED,       TramTLState = StatesCondition.GO,   
                        PedestrianTLState = StatesCondition.BLINKGREEN, Time=3000} }
            };
                            }
        internal static Dictionary<CrossRoadsStates, CrossRoadController> BuildNightModeCollection()
                {
            return new Dictionary<CrossRoadsStates, CrossRoadController>
                    {
            {CrossRoadsStates.OFFLIGHT,
                    new(){MainTLState = StatesCondition.OFFLIGHT,       SecondaryTLState = StatesCondition.OFFLIGHT,       TramTLState = StatesCondition.OFFLIGHT,
                        PedestrianTLState = StatesCondition.OFFLIGHT,        Time = 500 } },
            {CrossRoadsStates.BLINKYELLOW,
                    new(){MainTLState = StatesCondition.YELLOW, SecondaryTLState = StatesCondition.YELLOW,       TramTLState = StatesCondition.OFFLIGHT,
                        PedestrianTLState = StatesCondition.OFFLIGHT,        Time=500} },            
            };
                            }
        internal async Task DayMode()
                            {
            RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            TramTrafficLighterEvent += TramTrafficLighterEventArgs.ShowTramTrafficLighter;
            PedestrianTrafficLighterEvent += PedestrianTrafficLighterEventArgs.ShowPedestrianTrafficLight;
            
            Dictionary<CrossRoadsStates, CrossRoadController> DayModeStates = BuildDayModeCollection();
                    do
                    {
                foreach (KeyValuePair<CrossRoadsStates, CrossRoadController> stateName in DayModeStates)
                        {
                    var trafficLightState = stateName.Value;
                    var time = trafficLightState.Time;
                    foreach (var trafficLightName in TrafficLightersNames)
                            {
                        var trafficLighter = trafficLightName;
                        switch (trafficLightName.Value)
                            {
                            case TrafficLightsNames.MainTL:
                                RoadTrafficLighterEvent?.Invoke(new RoadTrafficLighterEventArgs(trafficLightState.MainTLState, trafficLighter.Value, time));
                                break;
                            case TrafficLightsNames.SecondaryTL:
                                RoadTrafficLighterEvent?.Invoke(new RoadTrafficLighterEventArgs(trafficLightState.SecondaryTLState, trafficLighter.Value, time));
                                break;
                            case TrafficLightsNames.TramTL:
                                TramTrafficLighterEvent?.Invoke(new TramTrafficLighterEventArgs(trafficLightState.TramTLState, trafficLighter.Value));
                                break;
                            case TrafficLightsNames.PedestrianTL:
                                PedestrianTrafficLighterEvent?.Invoke(new PedestrianTrafficLighterEventArgs(trafficLightState.PedestrianTLState, trafficLighter.Value, time));
                                break;
                        }
                    }
                    await Task.Delay(time);
                }
            }
            while (true);
            
        }
        internal async Task NightMode()
        {
            RoadTrafficLighterEvent += RoadTrafficLighterEventArgs.ShowRoadTrafficLighter;
            TramTrafficLighterEvent += TramTrafficLighterEventArgs.ShowTramTrafficLighter;
            PedestrianTrafficLighterEvent += PedestrianTrafficLighterEventArgs.ShowPedestrianTrafficLight;

            Dictionary<CrossRoadsStates, CrossRoadController> NightModeStates = BuildNightModeCollection();
            do
            {
                foreach (KeyValuePair<CrossRoadsStates, CrossRoadController> stateName in NightModeStates)
                {
                    var trafficLightState = stateName.Value;
                    var time = trafficLightState.Time;
                    foreach (var trafficLightName in TrafficLightersNames)
                    {
                        var trafficLighter = trafficLightName;
                        switch (trafficLightName.Value)
                        {
                            case TrafficLightsNames.MainTL:
                                RoadTrafficLighterEvent?.Invoke(new RoadTrafficLighterEventArgs(trafficLightState.MainTLState, trafficLighter.Value, time));
                                break;
                            case TrafficLightsNames.SecondaryTL:
                                RoadTrafficLighterEvent?.Invoke(new RoadTrafficLighterEventArgs(trafficLightState.SecondaryTLState, trafficLighter.Value, time));
                                break;
                            case TrafficLightsNames.TramTL:
                                TramTrafficLighterEvent?.Invoke(new TramTrafficLighterEventArgs(trafficLightState.TramTLState, trafficLighter.Value));
                                break;
                            case TrafficLightsNames.PedestrianTL:
                                PedestrianTrafficLighterEvent?.Invoke(new PedestrianTrafficLighterEventArgs(trafficLightState.PedestrianTLState, trafficLighter.Value, time));
                                break;
                        }
                    }
                    await Task.Delay(time);
                }               
            }
            while (true);
        }
    }
}

    