using AgendaForro.Models;
using System.Collections.Generic;

namespace AgendaForro.Helpers.Interfaces
{
    public interface IGoogleSheetsService
    {
        IEnumerable<CalendarEvent> GetCalendarEvents();
    }
}
