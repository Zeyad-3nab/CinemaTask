﻿using CinemaTask.Models;

namespace CinemaTask.ViewModels
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }

    }
}
