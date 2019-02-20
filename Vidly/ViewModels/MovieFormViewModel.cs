using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public List<MovieGenre> MovieGenres { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Movie Name")]
        public string Name { get; set; }

        [Required] [Display(Name = "Genre")] public byte? MovieGenreId { get; set; }

        [Display(Name = "Number in stock")]
        [Range(1, 40)]
        public byte? NumberInStock { get; set; }

        public byte? NumberAvailable { get; set; }

        [Display(Name = "Release Date")] public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date added")] public DateTime? DateAdded { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";


        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            DateAdded = movie.DateAdded;
            MovieGenreId = movie.MovieGenreId;
            NumberAvailable = movie.NumberAvailable;
            NumberInStock = movie.NumberInStock;
            ReleaseDate = movie.ReleaseDate;
        }
    }
}