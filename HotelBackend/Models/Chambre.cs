using System.ComponentModel.DataAnnotations;

namespace HotelBackend.Models
{
    public class Chambre
    {
        [Key]
        public int NumChambre { get; set; }

        [StringLength(100)]
        public string? Type { get; set; }

        public decimal? Prix { get; set; }

        public bool? EstDisponible { get; set; }
    }
}
