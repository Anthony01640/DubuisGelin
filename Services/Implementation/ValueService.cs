﻿using DubuisGelin.Data;
using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Implementation
{
    public class ValueService : IValueService
    {
        public ValueService(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ApplicationDbContext Context { get; }

        public IEnumerable<Value> GetValue(int idChamps)
        {
            return Context.Values.Where(w => w.ChampsId == idChamps);

        }

        public IEnumerable<Value> GetValueFromLiaison(int idLiaison)
        {
            return Context.Values.Where(w => w.IdLiaison == idLiaison);
        }

        public void CreateValue(string name, int idLiaison, int idChamps)
        {

            var val = new Value()
            {
                Name = name,
                IdLiaison = idLiaison,
                ChampsId = idChamps,
            };
            Context.Values.Add(val);
            Context.SaveChanges();
        }

        public void DeleteValues(int idLiaison)
        {
            var valuesToDelete = GetValueFromLiaison(idLiaison);
            Context.Values.RemoveRange(valuesToDelete);
            Context.SaveChanges();
        }
    }
}
