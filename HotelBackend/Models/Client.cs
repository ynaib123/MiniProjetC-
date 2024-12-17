using System.ComponentModel.DataAnnotations;

namespace HotelBackend.Models
{
    public class Client
    {
        [Key]
        public int IdClient { get; set; }

        [StringLength(100)]
        public string? Nom { get; set; }

        [StringLength(100)]
        public string? Prenom { get; set; }

        [EmailAddress]
        [StringLength(200)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? Password { get; set; }

        // Relation avec Reservation
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
