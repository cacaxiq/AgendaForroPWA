using AgendaForro.Helpers;
using AgendaForro.Helpers.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AgendaForro.Pages
{
    public class IndexModel : PageModel
    {
        private IHostingEnvironment _env;
        private IGoogleSheetsService _sheets;

        public IndexModel(IHostingEnvironment env, IGoogleSheetsService sheets)
        {
            _env = env;
            _sheets = sheets;
        }

        public void OnGet()
        {
            if (ConnectivityService.IsConnected())
            {
                var calendarEvents = _sheets.GetCalendarEvents();

                var webRoot = _env.WebRootPath;
                var file = System.IO.Path.Combine(webRoot, "data.json");

                string jsonData = JsonConvert.SerializeObject(calendarEvents, Formatting.None);
                System.IO.File.WriteAllText(file, jsonData);
            }
        }
    }
}
