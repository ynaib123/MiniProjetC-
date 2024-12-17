using System.ComponentModel.DataAnnotations;

namespace HotelBackend.Models
{
    public class Reservation
    {
        [Key]
        public int IdReservation { get; set; }

        public int? IdClient { get; set; }

        public int? NumChambre { get; set; }

        public DateTime? DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

        // Relation avec Client et Chambre
        public Client? Client { get; set; }
        public Chambre? Chambre { get; set; }
    }
}
