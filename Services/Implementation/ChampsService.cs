using DubuisGelin.Data;
using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DubuisGelin.Services;
using DubuisGelin.Services.Enums;

namespace DubuisGelin.Services.Implementation
{
    public class ChampsService : IChampsService
    {
        
        public ChampsService(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ApplicationDbContext Context { get; }

        public IEnumerable<Champs> GetChampsFromTable(int idTable)
        {
            return Context.Champs.Where(w => w.TableId == idTable);
        }

        public void AddChampsToTable(string nom, int idTable, Table table, TypeEnum type)
        {
            var newChamps = new Champs
            {
                Name = nom,
                TableId = idTable,
                Table = table,
                TypeEnum = type,
                
            };
            Context.Champs.Add(newChamps);
            Context.SaveChanges();
        }
    }
}
