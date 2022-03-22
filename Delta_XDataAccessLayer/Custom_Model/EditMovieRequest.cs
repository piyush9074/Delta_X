using System;
using System.Collections.Generic;
using System.Text;

namespace Delta_XDataAccessLayer.Custom_Model
{
    public class EditMovieRequest
    {
        int id; string name; string dor; string producer; string plot; string act;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Dor { get; set; }
        public string Producer { get; set; }
        public string Plot { get; set; }
        public string Act { get; set; }


    }
}
