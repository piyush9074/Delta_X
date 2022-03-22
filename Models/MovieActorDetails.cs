using System;
using System.Collections.Generic;

namespace Delta_XServices.Models
{
    public partial class MovieActorDetails
    {
        public int Id { get; set; }
        public int FkMovieId { get; set; }
        public int FkActorId { get; set; }

        public virtual Actor FkActor { get; set; }
        public virtual Movie FkMovie { get; set; }
    }
}
