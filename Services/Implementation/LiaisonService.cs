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

        public void CreateLiaison()
        {

        }
    }
}
