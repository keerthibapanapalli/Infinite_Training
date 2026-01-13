using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Movies.Models
{


    public class Movie
    {
        [Key]
        public int Mid { get; set; }

        [Required, StringLength(200)]
        public string Moviename { get; set; }

        [Required, StringLength(200)]
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateofRelease { get; set; }
    }

}