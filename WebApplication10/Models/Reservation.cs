using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Models
{
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime ReservedAt { get; set; }
        public IdentityUser ReservedBy { get; set; }
        public List<Seat> Seats { get; set; }
        public Screening Screening { get; set; }
    }
}