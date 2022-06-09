using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace WebApplication6.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int FromAge { get; set; }
        public int Duration { get; set; }
        public byte[] Poster { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<Screening> Screenings { get; set; }
    }
}