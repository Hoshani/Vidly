using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Genre")]
        public byte MovieGenreId { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1,40)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }
    }
}