using DubuisGelin.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Interface
{
    public interface ILiaisonValueService
    {
        IEnumerable<LiaisonValueChamps> GetAllLiaison();

        int CreateLiaison(IEnumerable<Value> Values, int idTable);

        void UpdateLiaison(IEnumerable<Value> values, int idLiaison);

        void DeleteLiaison(int idLiaison);
    }
}
