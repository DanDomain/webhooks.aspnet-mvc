using System.Collections.Generic;

namespace Webhooks.Models
{
    public class Event
    {
        public List<string> PropertiesChanged { get; set; }
        public Dictionary<string, object> OldValues { get; set; }
        public Dictionary<string, object> NewValues { get; set; }
        public string ObjectType { get; set; }
    }
}