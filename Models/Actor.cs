using System;
using System.Collections.Generic;

namespace Delta_XServices.Models
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActorDetails = new HashSet<MovieActorDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<MovieActorDetails> MovieActorDetails { get; set; }
    }
}
