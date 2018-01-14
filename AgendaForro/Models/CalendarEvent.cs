using Newtonsoft.Json;
using System;

namespace AgendaForro.Models
{
    public class CalendarEvent
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("allday", NullValueHandling = NullValueHandling.Ignore)]
        public bool AllDay { get; set; }

        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime End { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty("classname", NullValueHandling = NullValueHandling.Ignore)]
        public string ClassName { get; set; }

        [JsonProperty("editable", NullValueHandling = NullValueHandling.Ignore)]
        public bool Editable { get; set; }

        [JsonProperty("starteditable", NullValueHandling = NullValueHandling.Ignore)]
        public bool StartEditable { get; set; }

        [JsonProperty("durationeditable", NullValueHandling = NullValueHandling.Ignore)]
        public bool DurationEditable { get; set; }

        [JsonProperty("resourceeditable", NullValueHandling = NullValueHandling.Ignore)]
        public bool ResourceEditable { get; set; }

        [JsonProperty("rendering", NullValueHandling = NullValueHandling.Ignore)]
        public string Rendering { get; set; }

        [JsonProperty("overlap", NullValueHandling = NullValueHandling.Ignore)]
        public bool Overlap { get; set; }

        [JsonProperty("constraint", NullValueHandling = NullValueHandling.Ignore)]
        public string Constraint { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }

        [JsonProperty("backgroundcolor", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundColor { get; set; }

        [JsonProperty("bordercolor", NullValueHandling = NullValueHandling.Ignore)]
        public string BorderColor { get; set; }

        [JsonProperty("textcolor", NullValueHandling = NullValueHandling.Ignore)]
        public string TextColor { get; set; }
    }
}
