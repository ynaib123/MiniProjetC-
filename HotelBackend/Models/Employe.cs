using System.ComponentModel.DataAnnotations;

namespace HotelBackend.Models
{
    public class Employe
    {
        [Key]
        public int IdEmploye { get; set; }

        [StringLength(100)]
        public string? Nom { get; set; }

        [StringLength(100)]
        public string? Prenom { get; set; }

        [StringLength(100)]
        public string? Role { get; set; }
    }
}
