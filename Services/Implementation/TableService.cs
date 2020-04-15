using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Implementation
{
    public class TableService : ITableService
    {
        private readonly Data.ApplicationDbContext _context;

        public IUserService UserService { get; }

        public TableService(Data.ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            UserService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        /// <summary>
        /// Créer une table
        /// </summary>
        /// <param name="nom">Nom de la table</param>
        /// <param name="idUser">Id de l'utilisateur</param>
        public void CreateTable(string nom, Guid idUser)
        {
            var newTable = new Table
            {
                Nom = nom,
                UserId = idUser,
                User = UserService.GetUserById(idUser)
            };
            _context.Tables.Add(newTable);
            _context.SaveChanges();
        }

        /// <summary>
        /// Renvoie une table en fonction de son id
        /// </summary>
        /// <param name="Id">Id de la table</param>
        /// <returns></returns>
        public Table GetTableById(int Id)
        {
            return _context.Tables.FirstOrDefault(m => m.Id == Id);
        }

        /// <summary>
        /// Renvoie les tables d'un utilisateur
        /// </summary>
        /// <param name="idUser">id de l'utilisateur</param>
        /// <returns></returns>
        public IEnumerable<Table> GetTablesFromUser(Guid idUser)
        {
            return _context.Tables.Where(w => w.UserId == idUser);
        }

        /// <summary>
        /// Créer une table pour un nouvel utilisateur
        /// </summary>
        /// <param name="idUser">Id de l'utilisateur</param>
        /// <returns></returns>
        public List<int> CreateTableForNewUser(Guid idUser)
        {
            var retour = new List<int>();
            var newTable = new Table
            {
                Nom = "Client",
                UserId = idUser,
                User = UserService.GetUserById(idUser),
            };
            _context.Tables.Add(newTable);
            _context.SaveChanges();
            retour.Add(newTable.Id);

            var newTable2 = new Table
            {
                Nom = "Factures",
                UserId = idUser,
                User = UserService.GetUserById(idUser),
            };
            _context.Tables.Add(newTable2);
            _context.SaveChanges();
            retour.Add(newTable2.Id);

            var newTable3 = new Table
            {
                Nom = "Produits",
                UserId = idUser,
                User = UserService.GetUserById(idUser),
            };
            _context.Tables.Add(newTable3);
            _context.SaveChanges();
            retour.Add(newTable3.Id);

            return retour;
        }

        /// <summary>
        /// Modifie une table
        /// </summary>
        /// <param name="idTable">Id de la table à modifier</param>
        /// <param name="newName">Nouveaux nom</param>
        public void UpdateTable(int idTable, string newName)
        {
            var tableToUpdate = GetTableById(idTable);
            tableToUpdate.Nom = newName;
            _context.Update(tableToUpdate);
            _context.SaveChanges();
        }

        /// <summary>
        /// Supprime une table
        /// </summary>
        /// <param name="idTable">id de la table à supprimer</param>
        public void DeleteTable(int idTable)
        {
            var tableToDelete = GetTableById(idTable);
            _context.Tables.Remove(tableToDelete);
            _context.SaveChanges();
        }
    }
}
