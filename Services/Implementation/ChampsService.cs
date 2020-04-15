﻿using DubuisGelin.Data;
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


        /// <summary>
        /// Renvoie un champs en fonction de son id
        /// </summary>
        /// <param name="id">id du champs recherché</param>
        /// <returns></returns>
        public Champs GetChamps(int id)
        {
            return Context.Champs.FirstOrDefault(w => w.Id == id);
        }

        /// <summary>
        /// Renvoie tous les champs d'une table
        /// </summary>
        /// <param name="idTable">Id de la table</param>
        /// <returns></returns>
        public IEnumerable<Champs> GetChampsFromTable(int idTable)
        {
            return Context.Champs.Where(w => w.TableId == idTable);
        }

        /// <summary>
        /// Ajoute un champs à une table
        /// </summary>
        /// <param name="nom">Nom du champs</param>
        /// <param name="idTable">Id de la table parent</param>
        /// <param name="table">Table parent</param>
        /// <param name="type">type du champs</param>
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

        /// <summary>
        /// Créer des champs pour un nouvel utilisateur
        /// </summary>
        /// <param name="listeId"></param>
        public void CreateChampsForNewUser(List<int> listeId)
        {
            foreach (var id in listeId)
            {
                if (id == listeId.ElementAt(0))
                {
                    var newChamps = new Champs
                    {
                        Name = "Nom",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(newChamps);
                    Context.SaveChanges();

                    var mail = new Champs
                    {
                        Name = "Mail",
                        TableId = id,
                        TypeEnum = TypeEnum.String
                    };
                    Context.Champs.Add(mail);
                    Context.SaveChanges();

                    var date = new Champs
                    {
                        Name = "Date de création",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(date);
                    Context.SaveChanges();
                }
                if (id == listeId.ElementAt(1))
                {
                    var newChamps = new Champs
                    {
                        Name = "Référence client",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(newChamps);
                    Context.SaveChanges();

                    var dateenvoie = new Champs
                    {
                        Name = "Date d'émission",
                        TableId = id,
                        TypeEnum = TypeEnum.String
                    };
                    Context.Champs.Add(dateenvoie);
                    Context.SaveChanges();

                    var paie = new Champs
                    {
                        Name = "Payé ?",
                        TableId = id,
                        TypeEnum = TypeEnum.Boolean,
                    };
                    Context.Champs.Add(paie);
                    Context.SaveChanges();

                    var datepaiement = new Champs
                    {
                        Name = "Date de paiment",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(datepaiement);
                    Context.SaveChanges();

                    var prix = new Champs
                    {
                        Name = "Prix",
                        TableId = id,
                        TypeEnum = TypeEnum.String
                    };
                    Context.Champs.Add(prix);
                    Context.SaveChanges();

                    var refProduct = new Champs
                    {
                        Name = "Référence à un produit",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(refProduct);
                    Context.SaveChanges();
                }
                if (id == listeId.ElementAt(2))
                {
                    var nom = new Champs
                    {
                        Name = "Nom",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(nom);
                    Context.SaveChanges();

                    var stock = new Champs
                    {
                        Name = "Stock",
                        TableId = id,
                        TypeEnum = TypeEnum.Int,
                    };
                    Context.Champs.Add(stock);
                    Context.SaveChanges();

                    var prix = new Champs
                    {
                        Name = "Prix",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(prix);
                    Context.SaveChanges();

                    var refFacture = new Champs
                    {
                        Name = "Référence à une facture",
                        TableId = id,
                        TypeEnum = TypeEnum.String,
                    };
                    Context.Champs.Add(refFacture);
                    Context.SaveChanges();

                }
            }

        }

        /// <summary>
        /// Modifie un champs
        /// </summary>
        /// <param name="idChamps">Id du champs à modifier</param>
        /// <param name="newName">nouveau Nom du champs</param>
        public void UpdateChamps(int idChamps, string newName)
        {
            var champs = Context.Champs.FirstOrDefault(w => w.Id == idChamps);
            champs.Name = newName;
            Context.Champs.Update(champs);
            Context.SaveChanges();
        }

        /// <summary>
        /// Supprime un champs
        /// </summary>
        /// <param name="idChampsToDelete">Id du champs à supprimer</param>
        public void DeleteChamps(int idChampsToDelete)
        {
            var champsToDelete = Context.Champs.FirstOrDefault(w => w.Id == idChampsToDelete);
            Context.Champs.Remove(champsToDelete);
            Context.SaveChanges();
        }
    }
}
