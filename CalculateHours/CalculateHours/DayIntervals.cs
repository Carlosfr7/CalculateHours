using System;

namespace CalculateHours
{
    internal class DayIntervals
    {
        public DayIntervals(int timeStart, int timeEnd)
        {
            if (timeStart > timeEnd) throw new Exception("Start time should be major than End time");

            this.TimeStart = new TimeSpan(timeStart,0,0);
            this.TimeEnd = new TimeSpan(timeEnd,0,0);
            this.AvailableTime = TimeEnd.Subtract(TimeStart);
        }

        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public TimeSpan AvailableTime { get; set; }
    }
}