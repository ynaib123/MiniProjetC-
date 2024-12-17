using System.ComponentModel.DataAnnotations;

namespace HotelBackend.Models
{
    public class Admin
    {
        [Key]
        public int IdAdmin { get; set; }

        [StringLength(100)]
        public string? Nom { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }
    }
}
