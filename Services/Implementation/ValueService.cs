using DubuisGelin.Data;
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

        /// <summary>
        /// Renvoie une valeur en fonction du champs
        /// </summary>
        /// <param name="idChamps">id du champs</param>
        /// <returns></returns>
        public IEnumerable<Value> GetValue(int idChamps)
        {
            return Context.Values.Where(w => w.ChampsId == idChamps);

        }

        /// <summary>
        /// Renvoie des valeur en fonction de la liaison
        /// </summary>
        /// <param name="idLiaison">Id de la liaison</param>
        /// <returns></returns>
        public IEnumerable<Value> GetValueFromLiaison(int idLiaison)
        {
            return Context.Values.Where(w => w.IdLiaison == idLiaison);
        }

        /// <summary>
        /// Créer une valeur
        /// </summary>
        /// <param name="name">Nom de la valeur</param>
        /// <param name="idLiaison"> id de la liaison</param>
        /// <param name="idChamps">id du champs</param>
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

        /// <summary>
        /// Supprime un ensemble de valeurs
        /// </summary>
        /// <param name="idLiaison">Id de la liaison</param>
        public void DeleteValues(int idLiaison)
        {
            var valuesToDelete = GetValueFromLiaison(idLiaison);
            Context.Values.RemoveRange(valuesToDelete);
            Context.SaveChanges();
        }
    }
}
