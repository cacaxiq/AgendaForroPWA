using AgendaForro.Models;
using System;
using System.Collections.Generic;

namespace AgendaForro.Helpers
{
    public static class CalendarService
    {
        public static IEnumerable<CalendarEvent> GenerateCalendarEvent(int amount)
        {
            var calendarEvents = new List<CalendarEvent>();

            var random = new Random();

            for (int i = 1; i < amount; i++)
            {
                var calendarEvent = new CalendarEvent
                {
                    Id = i,
                    Title = $"Evento {random.Next(1, 100)}",
                    Start = new DateTime(2018, random.Next(1, 12), random.Next(1, 28), random.Next(0, 23), random.Next(1, 59), random.Next(1, 59))
                };

                calendarEvent.End = calendarEvent.Start.AddMinutes(random.Next(1, 5000));

                calendarEvents.Add(calendarEvent);
            }

            return calendarEvents;
        }
    }
}
