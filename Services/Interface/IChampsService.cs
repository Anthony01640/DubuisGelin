using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Interface
{
    public interface IChampsService
    {
        Champs GetChamps(int id);

        IEnumerable<Champs> GetChampsFromTable(int idTable);
        void AddChampsToTable(string nom, int idTable, Table table, TypeEnum type);

        void CreateChampsForNewUser(List<int> listeId);

        void UpdateChamps(int idChamps, string newName);

        void DeleteChamps(int idChampsToDelete);
    }
}
