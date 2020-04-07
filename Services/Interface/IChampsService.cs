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
        IEnumerable<Champs> GetChampsFromTable(int idTable);
        void AddChampsToTable(string nom, int idTable, Table table, TypeEnum type);
    }
}
