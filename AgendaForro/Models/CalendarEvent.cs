using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaForro.Models
{
    public class CalendarEvent
    {

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }
        //public bool AllDay { get; set; }
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Start { get; set; }
        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime End { get; set; }
        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }
        //public string ClassName { get; set; }
        //public bool Editable { get; set; }
        //public bool StartEditable { get; set; }
        //public bool DurationEditable { get; set; }
        //public bool ResourceEditable { get; set; }
        //public string Rendering { get; set; }
        //public bool Overlap { get; set; }
        //public string Constraint { get; set; }
        //public string Source { get; set; }
        //public string Color { get; set; }
        //public string BackgroundColor { get; set; }
        //public string BorderColor { get; set; }
        //public string TextColor { get; set; }
    }
}
