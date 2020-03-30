using DubuisGelin.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Interface
{
    public interface IChampsService
    {
        IEnumerable<Champs> GetChampsFromTable(int idTable);
    }
}
