using System;
using System.Collections.Generic;

namespace Delta_XServices.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieActorDetails = new HashSet<MovieActorDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public int FkProducer { get; set; }

        public virtual Producer FkProducerNavigation { get; set; }
        public virtual ICollection<MovieActorDetails> MovieActorDetails { get; set; }
    }
}
