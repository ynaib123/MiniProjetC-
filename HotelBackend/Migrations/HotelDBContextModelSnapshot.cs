﻿// <auto-generated />
using System;
using HotelBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelBackend.Migrations
{
    [DbContext(typeof(HotelDBContext))]
    partial class HotelDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelBackend.Models.Admin", b =>
                {
                    b.Property<int>("IdAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAdmin"));

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdAdmin");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("HotelBackend.Models.Chambre", b =>
                {
                    b.Property<int>("NumChambre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumChambre"));

                    b.Property<bool?>("EstDisponible")
                        .HasColumnType("bit");

                    b.Property<decimal?>("Prix")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("NumChambre");

                    b.ToTable("Chambres");
                });

            modelBuilder.Entity("HotelBackend.Models.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdClient"));

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("HotelBackend.Models.Employe", b =>
                {
                    b.Property<int>("IdEmploye")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEmploye"));

                    b.Property<string>("Nom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenom")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Role")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdEmploye");

                    b.ToTable("Employes");
                });

            modelBuilder.Entity("HotelBackend.Models.Paiement", b =>
                {
                    b.Property<int>("IdPaiement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaiement"));

                    b.Property<DateTime?>("DatePaiement")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdReservation")
                        .HasColumnType("int");

                    b.Property<string>("MethodePaiement")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdPaiement");

                    b.HasIndex("IdReservation");

                    b.ToTable("Paiements");
                });

            modelBuilder.Entity("HotelBackend.Models.Reservation", b =>
                {
                    b.Property<int>("IdReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReservation"));

                    b.Property<DateTime?>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdClient")
                        .HasColumnType("int");

                    b.Property<int?>("NumChambre")
                        .HasColumnType("int");

                    b.HasKey("IdReservation");

                    b.HasIndex("IdClient");

                    b.HasIndex("NumChambre");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("HotelBackend.Models.Paiement", b =>
                {
                    b.HasOne("HotelBackend.Models.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("IdReservation");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("HotelBackend.Models.Reservation", b =>
                {
                    b.HasOne("HotelBackend.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("IdClient");

                    b.HasOne("HotelBackend.Models.Chambre", "Chambre")
                        .WithMany()
                        .HasForeignKey("NumChambre");

                    b.Navigation("Chambre");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("HotelBackend.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
