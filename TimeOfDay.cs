using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_lighters
{
    internal class TimeOfDay
    {
        internal static int TimeNow()
        {
            TimeSpan timeNow = DateTime.Now.TimeOfDay;
            int hour = timeNow.Hours;
            int minute = timeNow.Minutes;
            int second = timeNow.Seconds;
            int milisecond = timeNow.Milliseconds;
            int milisecondsNow = hour * 60 * 60 * 1000 + minute * 60 * 1000 + second * 1000 + milisecond;
            return milisecondsNow;
        }
        internal static int DayModeEnd()
        {
            TimeSpan endOfWork = new(23, 00, 00);
            int hour = endOfWork.Hours;
            int minute = endOfWork.Minutes;
            int second = endOfWork.Seconds;
            int milisecond = endOfWork.Milliseconds;
            int endDayAtMilisecond = hour * 60 * 60 * 1000 + minute * 60 * 1000 + second * 1000 + milisecond;
            return endDayAtMilisecond;
        }
        internal static int DayModeStart()
        {
            TimeSpan startOfWork = new(06, 00, 00);
            int hour = startOfWork.Hours;
            int minute = startOfWork.Minutes;
            int second = startOfWork.Seconds;
            int milisecond = startOfWork.Milliseconds;
            int startDayAtSeconds = hour * 60 * 60 * 1000 + minute * 60 * 1000 + second * 1000 + milisecond;
            return startDayAtSeconds;
        }        
        internal static int DayEnd()
        {
            TimeSpan endOfEra = new(23, 59, 59);
            int hour = endOfEra.Hours;
            int minute = endOfEra.Minutes;
            int second = endOfEra.Seconds;
            int milisecond = endOfEra.Milliseconds;
            int endEra = hour * 60 * 60 * 1000 + minute * 60 * 1000 + second * 1000 + milisecond;
            return endEra;
        }
        internal static int DayStart()
        {
            TimeSpan startOfEra = new(00, 00, 00);
            int hour = startOfEra.Hours;
            int minute = startOfEra.Minutes;
            int second = startOfEra.Seconds;
            int milisecond = startOfEra.Milliseconds;
            int startEra = hour * 60 * 60 * 1000 + minute * 60 * 1000 + second * 1000 + milisecond;
            return startEra;
        }
    }
}
