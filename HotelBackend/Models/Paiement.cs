using System.ComponentModel.DataAnnotations;

namespace HotelBackend.Models
{
    public class Paiement
    {
        [Key]
        public int IdPaiement { get; set; }

        public int? IdReservation { get; set; }

        public decimal? Montant { get; set; }

        public DateTime? DatePaiement { get; set; }

        [StringLength(100)]
        public string? MethodePaiement { get; set; }

        // Relation avec Reservation
        public Reservation? Reservation { get; set; }
    }
}
