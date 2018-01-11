using AgendaForro.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AgendaForro.Pages
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment _env;

        public IndexModel(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnGet()
        {
            IPNetwork net = new IPNetwork();
            var calendarEvents = CalendarService.GenerateCalendarEvent(50);

            var webRoot = _env.WebRootPath;
            var file = System.IO.Path.Combine(webRoot, "data.json");

            string jsonData = JsonConvert.SerializeObject(calendarEvents, Formatting.None);
            System.IO.File.WriteAllText(file, jsonData);
        }
    }
}
