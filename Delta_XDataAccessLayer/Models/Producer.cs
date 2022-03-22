using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Delta_XDataAccessLayer.Models
{
    public partial class Producer
    {
        public Producer()
        {
            Movie = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Company { get; set; }
        public string Bio { get; set; }
        [JsonIgnore]
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
