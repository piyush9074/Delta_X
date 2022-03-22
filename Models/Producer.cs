using System;
using System.Collections.Generic;

namespace Delta_XServices.Models
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

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
