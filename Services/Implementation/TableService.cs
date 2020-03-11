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
        private readonly UserService userService;

        public TableService(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateTable(string nom, Guid idUser)
        {
            var newTable = new Table
            {
                Nom = nom,
                UserId = idUser,
                User = userService.GetUserById(idUser)
            };
        }

        public Table GetTableById(int Id)
        {
            return _context.Tables.FirstOrDefault(m => m.Id == Id);
        }

        public IEnumerable<Table> GetTablesFromUser(Guid idUser)
        {
            return _context.Tables.Where(w => w.UserId == idUser);
        }

        public void CreateTableForNewUser(Guid idUser)
        {
            var newTable = new Table
            {
                Nom = "test",
                UserId = idUser,
                User = userService.GetUserById(idUser),
            };
            _context.Tables.Add(newTable);
            _context.SaveChanges();
        }
    }
}
