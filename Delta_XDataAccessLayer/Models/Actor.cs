using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delta_XDataAccessLayer.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActor = new HashSet<MovieActor>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Bio { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}
