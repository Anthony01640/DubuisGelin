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

        /// <summary>
        /// Renvoie toute les liaisons
        /// </summary>
        /// <returns></returns>
        public IEnumerable<LiaisonValueChamps> GetAllLiaison()
        {
            return Context.LiaisonValueChamps;
        }

        /// <summary>
        /// Renvoie une liaison en fonction de son id
        /// </summary>
        /// <param name="id">id de la liaison</param>
        /// <returns></returns>
        public LiaisonValueChamps GetLiaison(int id)
        {
            return Context.LiaisonValueChamps.FirstOrDefault(w => w.Id == id);
        }

        /// <summary>
        /// Créer une liaison
        /// </summary>
        /// <param name="Values">Valeur ajoutés dans la liaison</param>
        /// <param name="idTable">id de la table liée à la liaison</param>
        /// <returns></returns>
        public int CreateLiaison(IEnumerable<Value> Values, int idTable)
        {
            var liaison = new LiaisonValueChamps();
            if (Values == null)
            {
                liaison.IdTable = idTable;
            }
            else
            {
                liaison.IdTable = idTable;
                liaison.Values = Values.ToList();
            }
            Context.LiaisonValueChamps.Add(liaison);
            Context.SaveChanges();
            return liaison.Id;
        }

        /// <summary>
        /// Met à jours une liaison en fonction de son id
        /// </summary>
        /// <param name="values">value à ajouter</param>
        /// <param name="idLiaison">Id de la liaison à mettre à jour</param>
        public void UpdateLiaison(IEnumerable<Value> values, int idLiaison)
        {
            var liaison = GetLiaison(idLiaison);
            liaison.Values.AddRange(values);
            Context.LiaisonValueChamps.Update(liaison);
            Context.SaveChanges();
        }

        /// <summary>
        /// Supprime une liaison
        /// </summary>
        /// <param name="idLiaison">Id de la liaison à supprimer</param>
        public void DeleteLiaison(int idLiaison)
        {
            var liaison = GetLiaison(idLiaison);
            Context.LiaisonValueChamps.Remove(liaison);
            Context.SaveChanges();
        }

    }
}
