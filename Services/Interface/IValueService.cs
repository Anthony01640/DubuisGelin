using DubuisGelin.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Interface
{
    public interface IValueService
    {
        IEnumerable<Value> GetValue(int idChamps);

        IEnumerable<Value> GetValueFromLiaison(int idLiaison);
    }
}
