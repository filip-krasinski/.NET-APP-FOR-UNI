using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Screening
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Movie Movie { get; set; }
        public DateTime ScreeningDate { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}