using DubuisGelin.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Interface
{
    public interface ITableService
    {
        void CreateTable(string nom, Guid idUser);

        Table GetTableById(int Id);

        IEnumerable<Table> GetTablesFromUser(Guid idUser);

        List<int> CreateTableForNewUser(Guid idUser);
    }
}
