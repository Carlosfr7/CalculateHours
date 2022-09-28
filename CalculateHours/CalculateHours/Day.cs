using System;
using System.Collections.Generic;
using System.Linq;
namespace CalculateHours
{
    internal class Day
    {
        private DateTime current;
        private int day;
        private Dictionary<int, List<DayIntervals>> daysTime = new Dictionary<int, List<DayIntervals>>() 
        {
            {
                0, new List<DayIntervals>()
                {
                }
            },
            {
                1, new List<DayIntervals>()
                {
                    new DayIntervals(09,12),
                    new DayIntervals(14,19),
                }
            },
            {
                2, new List<DayIntervals>()
                {
                    new DayIntervals(09,12),
                    new DayIntervals(14,19),
                }
            },
            {
                3, new List<DayIntervals>()
                {
                    new DayIntervals(09,12),
                    new DayIntervals(14,19),
                }
            },
            {
                4, new List<DayIntervals>()
                {
                    new DayIntervals(09,12),
                    new DayIntervals(14,19),
                }
            },
            {
                5, new List<DayIntervals>()
                {
                    new DayIntervals(09,12),
                    new DayIntervals(14,19),
                }
            },
            {
                6, new List<DayIntervals>()
                {
                }
            }
        };
        private List<DateTime> holidays = new List<DateTime>() { new DateTime(2022,09,29)};

        public Day(DateTime current)
        {
            this.current = current;
            this.day = (int)this.current.DayOfWeek;
        }

        internal DateTime ConsumeDay(ref TimeSpan remainingTime)
        {
            foreach (var dayInterval in this.daysTime[day])
            {
                if (remainingTime.Ticks <= 0) break;

                TimeSpan currentTime = new TimeSpan(current.Hour, current.Minute, current.Second);
                if (currentTime > dayInterval.TimeEnd) continue;
                if (currentTime < dayInterval.TimeStart) currentTime = dayInterval.TimeStart;

                TimeSpan timeUsed = remainingTime >= dayInterval.AvailableTime ? dayInterval.TimeEnd.Subtract(currentTime) : remainingTime;
                remainingTime = remainingTime.Subtract(timeUsed);

                currentTime = remainingTime.Ticks > 0 ? dayInterval.TimeEnd : dayInterval.TimeStart + timeUsed;

                current = new DateTime(current.Year, current.Month, current.Day, 0, 0, 0);
                current += currentTime;
            }

            return this.current;
        }

        internal bool isHoliday()
        {
            return holidays.Any(c => c == this.current);
        }

        internal Day GetNextDay()
        {
            current = current.AddDays(1);
            current = new DateTime(current.Year, current.Month, current.Day, 0, 0, 0);
            return new Day(current);
        }
    }
}