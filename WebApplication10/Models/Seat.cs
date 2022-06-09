using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int RowNumber { get; set; }
        public int ColNumber { get; set; }
        public CinemaHall CinemaHall { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}