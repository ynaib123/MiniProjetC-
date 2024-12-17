using Microsoft.EntityFrameworkCore;
using HotelBackend.Models;

namespace HotelBackend.Data
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext(DbContextOptions<HotelDBContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<Chambre> Chambres { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Paiement> Paiements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurations des relations et des clés primaires
        modelBuilder.Entity<Admin>()
            .HasKey(a => a.IdAdmin);

        modelBuilder.Entity<Client>()
            .HasKey(c => c.IdClient);
        
        modelBuilder.Entity<Employe>()
            .HasKey(e => e.IdEmploye);

        modelBuilder.Entity<Chambre>()
            .HasKey(c => c.NumChambre);
            
        modelBuilder.Entity<Chambre>()
            .Property(c => c.Prix)
            .HasColumnType("decimal(18,2)"); // Définir le type de la colonne Prix

        modelBuilder.Entity<Reservation>()
            .HasKey(r => r.IdReservation);
                    
        modelBuilder.Entity<Paiement>()
            .HasKey(p => p.IdPaiement);

        modelBuilder.Entity<Paiement>()
            .Property(p => p.Montant)
            .HasColumnType("decimal(18,2)"); // Définir le type de la colonne Montant

        // Définir les relations entre les entités
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Client)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.IdClient);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Chambre)
            .WithMany()
            .HasForeignKey(r => r.NumChambre);

        modelBuilder.Entity<Paiement>()
            .HasOne(p => p.Reservation)
            .WithMany()
            .HasForeignKey(p => p.IdReservation);
    }

    }
}
