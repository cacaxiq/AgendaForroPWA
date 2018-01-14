using AgendaForro.Helpers.Interfaces;
using AgendaForro.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AgendaForro.Helpers
{
    public class GoogleSheetsService : IGoogleSheetsService
    {
        string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        string ApplicationName = "AgendadoForro";

        private IHostingEnvironment _env;

        public GoogleSheetsService(IHostingEnvironment env)
        {
            _env = env;
        }

        public IEnumerable<CalendarEvent> GetCalendarEvents()
        {
            UserCredential credential;
            List<CalendarEvent> calendarEvents = new List<CalendarEvent>();

            var webRoot = _env.WebRootPath;
            var file = Path.Combine(webRoot, "client_secret.json");

            using (var stream =
                new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None).Result;
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            String spreadsheetId = "1tCTUj_b8dXG2_HjTQ48Cn8PO9IHEYG08BGqrEPF3u-Y";
            String range = "A2:T";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values;

            Debug.Write($"Teste:{values}");

            if (values != null && values.Count > 0)
            {
                foreach (var row in values)
                {
                    CalendarEvent calendarEvent = new CalendarEvent();

                    int id = int.MinValue;
                    calendarEvent.Id = int.TryParse((string)row[0], out id) ? id : id;
                    calendarEvent.Title = (string)row[1];

                    bool allday = false;
                    calendarEvent.AllDay = bool.TryParse((string)row[2], out allday) ? allday : allday;

                    DateTime start = DateTime.MinValue;
                    calendarEvent.Start = DateTime.TryParse((string)row[3], out start) ? start : start;

                    DateTime end = DateTime.MinValue;
                    calendarEvent.End = DateTime.TryParse((string)row[4], out end) ? end : end;

                    calendarEvent.Url = Convert.ToString(row[5]);
                    calendarEvent.ClassName = (string)row[6];

                    bool editable = false;
                    calendarEvent.Editable = bool.TryParse((string)row[7], out editable) ? editable : editable;

                    bool starteditable = false;
                    calendarEvent.StartEditable = bool.TryParse((string)row[8], out starteditable) ? starteditable : starteditable;

                    bool durationeditable = false;
                    calendarEvent.DurationEditable = bool.TryParse((string)row[9], out durationeditable) ? durationeditable : durationeditable;

                    bool resourceeditable = false;
                    calendarEvent.ResourceEditable = bool.TryParse((string)row[10], out resourceeditable) ? resourceeditable : resourceeditable;

                    calendarEvent.Rendering = (string)row[11];

                    bool overlap = false;
                    calendarEvent.Overlap = bool.TryParse((string)row[12], out overlap) ? overlap : overlap;

                    calendarEvent.Constraint = (string)row[13];
                    calendarEvent.Source = (string)row[14];
                    calendarEvent.Color = (string)row[15];
                    calendarEvent.BackgroundColor = (string)row[16];
                    calendarEvent.BorderColor = (string)row[17];
                    calendarEvent.TextColor = (string)row[18];

                    calendarEvents.Add(calendarEvent);
                }
            }

            return calendarEvents;
        }
    }
}
