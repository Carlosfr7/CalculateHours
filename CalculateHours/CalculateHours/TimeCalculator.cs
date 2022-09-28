using System;
using System.Collections.Generic;

namespace CalculateHours
{
    internal class TimeCalculator
    {
        DateTime estimatedFinal = new DateTime();

        public TimeCalculator()
        {
        }

        internal DateTime GetDate(TimeSpan remainingTime)
        {
            DateTime current = DateTime.Now;
            Day day = new Day(current);

            while (remainingTime.Ticks > 0)
            {
                if (day.isHoliday()) 
                { 
                    day = day.GetNextDay(); 
                    continue; 
                }

                estimatedFinal = day.ConsumeDay(ref remainingTime);
                day = day.GetNextDay();
            }

            return estimatedFinal;
        }
    }
}