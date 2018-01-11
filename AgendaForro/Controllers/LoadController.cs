using AgendaForro.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AgendaForro.Controllers
{
    [Produces("application/json")]
    [Route("api/Load")]
    public class LoadController : Controller
    {
        private IHostingEnvironment _env;

        public LoadController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Route("api/Load/GetCalendarEvent")]
        public JsonResult GetCalendarEvent()
        {
            List<CalendarEvent> calendarEvent = new List<CalendarEvent>();
            var webRoot = _env.WebRootPath;
            var file = System.IO.Path.Combine(webRoot, "data.json");
            using (StreamReader sr = new StreamReader(file))
            {
                calendarEvent = JsonConvert.DeserializeObject<List<CalendarEvent>>(sr.ReadToEnd());
            }
            return Json(calendarEvent);
        }

    }
}