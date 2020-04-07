using DubuisGelin.Data;
using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Implementation
{
    public class LiaisonService : ILiaisonValueService
    {
        public LiaisonService(ApplicationDbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ApplicationDbContext Context { get; }

        public IEnumerable<LiaisonValueChamps> GetAllLiaison()
        {
            return Context.LiaisonValueChamps;
        }

        public LiaisonValueChamps GetLiaison(int id)
        {
            return Context.LiaisonValueChamps.FirstOrDefault(w => w.Id == id);
        }

        public int CreateLiaison(IEnumerable<Value> Values)
        {
            var liaison = new LiaisonValueChamps();
            if (Values == null)
            {

            }
            else
            {
                liaison.Values = Values.ToList();
            }
            Context.LiaisonValueChamps.Add(liaison);
            return liaison.Id;
        }

        public void UpdateLiaison(IEnumerable<Value> values, int idLiaison)
        {
            var liaison = GetLiaison(idLiaison);
            liaison.Values.AddRange(values);
            Context.LiaisonValueChamps.Update(liaison);
            Context.SaveChanges();
        }


    }
}
