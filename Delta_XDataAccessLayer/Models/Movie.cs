using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delta_XDataAccessLayer.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActor = new HashSet<MovieActor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string FkProducer { get; set; }
        public string Plot { get; set; }
        [JsonIgnore]
        public virtual Producer FkProducerNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}
