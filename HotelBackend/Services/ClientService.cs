using HotelBackend.Data;
using HotelBackend.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using System;

namespace HotelBackend.Services
{
    public interface IClientService
    {
        Task RegisterClientAsync(Client client);
        Task<Client?> AuthenticateClientAsync(string email, string password); // Changer ici
    }

    public class ClientService : IClientService
    {
        private readonly HotelDBContext _context;

        public ClientService(HotelDBContext context)
        {
            _context = context;
        }

        // Enregistrer un client dans la base de données avec un mot de passe sécurisé
        public async Task RegisterClientAsync(Client client)
        {
            try
            {
                // Hashage du mot de passe avant de l'enregistrer
                client.Password = BCrypt.Net.BCrypt.HashPassword(client.Password);

                // Ajouter le client à la base de données
                await _context.Clients.AddAsync(client);
                Console.WriteLine($"Ajout du client : {client.Nom} {client.Prenom}");

                // Sauvegarder les modifications dans la base de données
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'enregistrement : {ex.Message}");
                throw;
            }
        }

        // Authentifier un client avec email et mot de passe
       public async Task<Client?> AuthenticateClientAsync(string email, string password)
{
    try
    {
        var client = await _context.Clients
            .FirstOrDefaultAsync(c => c.Email == email);

        if (client == null)
        {
            return null;  // Client non trouvé
        }

        // Vérifier le mot de passe avec la méthode Verify de BCrypt
        if (BCrypt.Net.BCrypt.Verify(password, client.Password, false, HashType.SHA384))  // Utilise SHA384 comme exemple
        {
            return client;  // Mot de passe valide, retourner le client
        }

        return null;  // Mot de passe incorrect
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors de l'authentification : {ex.Message}");
        throw;
    }
}

    }
}
