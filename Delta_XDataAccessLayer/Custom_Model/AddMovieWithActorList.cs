using System;
using System.Collections.Generic;
using System.Text;

namespace Delta_XDataAccessLayer.Models
{
   public class AddMovieWithActorList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public string FkProducer { get; set; }
        public string Plot { get; set; }
        //public List <Movie> Mov { get; set; }

        public List<string> Actors { get; set; }
    }
}
