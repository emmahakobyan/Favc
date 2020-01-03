using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Favc.Models;

namespace Favc.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
        public String Title {
            get
            {
              if(Movie == null || Movie.Id == 0)
                 return "New Movie";
              
               return "Edit Movie";
            }
        }
    }
}