using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delta_XDataAccessLayer.Models
{
    public partial class MovieActor
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string ActorName { get; set; }
        [JsonIgnore]
        public virtual Actor ActorNameNavigation { get; set; }
        [JsonIgnore]
        public virtual Movie MovieNameNavigation { get; set; }
    }
}
