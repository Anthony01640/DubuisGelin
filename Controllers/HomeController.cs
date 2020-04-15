using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DubuisGelin.Models;
using DubuisGelin.Services.Implementation;
using DubuisGelin.Models.ChampsViewModel;
using Microsoft.AspNetCore.Authorization;
using DubuisGelin.Models.HomeController;
using DubuisGelin.Models.TableViewModel;
using DubuisGelin.Services.Interface;
using DubuisGelin.Models.LiaisonViewModel;
using DubuisGelin.Models.ValueViewModel;
using DubuisGelin.Services.Enums;
using System.IO;
using Newtonsoft.Json;

namespace DubuisGelin.Controllers
{
    [Authorize(Roles = "Utilisateur")]
    public class HomeController : Controller
    {
        public IUserService UserService { get; }
        public ITableService TableService { get; }
        public IChampsService ChampsService { get; }
        public ILiaisonValueService LiaisonValueService { get; }
        public IValueService ValueService { get; }

        public HomeController(IUserService userService, ITableService tableService, IChampsService champsService, ILiaisonValueService liaisonValueService, IValueService valueService)
        {
            UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            TableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            ChampsService = champsService ?? throw new ArgumentNullException(nameof(champsService));
            LiaisonValueService = liaisonValueService ?? throw new ArgumentNullException(nameof(liaisonValueService));
            ValueService = valueService ?? throw new ArgumentNullException(nameof(valueService));
        }

        /// <summary>
        /// Renvoie l'index de chaque utilisateur connecté
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var indexViewModel = new IndexViewModel();
            var user = UserService.GetUserByMail(User.Identity.Name);
            indexViewModel.IdUser = user.Id;
            indexViewModel.TableUtilisateur = TableService.GetTablesFromUser(user.Id).Select(p => new TableUserViewModel
            {
                Name = p.Nom,
                Id = p.Id,
            });
            return View(indexViewModel);
        }

        /// <summary>
        /// Get pour créer un table qui sera lié à un utilisateur
        /// </summary>
        /// <returns></returns>
        [HttpGet("/create")]
        public IActionResult CreateTable()
        {
            var createTableVM = new CreateTableViewModel
            {
                IdUser = UserService.GetUserByMail(User.Identity.Name).Id,
            };
            return View(createTableVM);
        }
        /// <summary>
        /// Post créer une table qui sera lié à un utilisateur qui la crée
        /// </summary>
        /// <param name="createTableVM"></param>
        /// <returns></returns>
        [HttpPost("/create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateTable(CreateTableViewModel createTableVM)
        {
            if (ModelState.IsValid)
            {
                TableService.CreateTable(createTableVM.Nom, createTableVM.IdUser);
                return RedirectToAction(nameof(HomeController.Index));
            }
            return View();
        }

        /// <summary>
        /// Edit un table
        /// </summary>
        /// <param name="idTable">Id de la table à éditer</param>
        /// <returns></returns>
        [HttpGet("/edittable/{idTable}")]
        public IActionResult EditTable(int idTable)
        {
            var tableToEdit = new TableUserViewModel
            {
                Id = idTable,
                Name = TableService.GetTableById(idTable).Nom
            };
            return View(tableToEdit);
        }

        /// <summary>
        /// Post de la table édité
        /// </summary>
        /// <param name="tableEdit">Comporte toute les modifications de la table</param>
        /// <returns></returns>
        [HttpPost("/edittable/{idTable}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditTable(TableUserViewModel tableEdit)
        {
            TableService.UpdateTable(tableEdit.Id, tableEdit.Name);
            return RedirectToAction(nameof(HomeController.Index));
        }

        /// <summary>
        /// Supprime une table
        /// </summary>
        /// <param name="idTable">Id de la table à supprimer</param>
        /// <returns></returns>
        public IActionResult DeleteTable(int idTable)
        {
            var listIdLiaison = LiaisonValueService.GetAllLiaison().Where(m => m.IdTable == idTable);
            foreach (var item in listIdLiaison)
            {
                LiaisonValueService.DeleteLiaison(item.Id);
            }
            TableService.DeleteTable(idTable);
            return RedirectToAction(nameof(HomeController.Index));
        }

        /// <summary>
        /// Get des cmlposant d'une table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/indexChamps/{id}")]
        public IActionResult IndexTable(int id)
        {
            var indexTable = new IndexTableViewModel()
            {
                NameTable = TableService.GetTableById(id).Nom,
                ListeChamps = ChampsService.GetChampsFromTable(id).Select(p => new ChampViewModel
                {
                    Id = p.Id,
                    Nom = p.Name,
                }).ToList(),
                ListeLiaison = LiaisonValueService.GetAllLiaison().Where(p => p.IdTable == id).Select(w => new LiaisonTableIndexViewModel
                {
                    Id = w.Id,
                    ListeValue = ValueService.GetValueFromLiaison(w.Id).Select(a => new ValuesViewModel
                    {
                        Nom = a.Name,
                        IdChamps = a.ChampsId
                    }).ToList(),
                }).ToList(),
            };
            return View(indexTable);
        }

        /// <summary>
        /// Get pour ajouter un champs à une table
        /// </summary>
        /// <param name="id">id de la table</param>
        /// <returns></returns>
        [HttpGet("/addchamps/{id}")]
        public IActionResult AddChampsToTable(int id)
        {
            var addChampsToTableVM = new AddChampsToTableViewModel
            {
                IdTable = id,
                Table = TableService.GetTableById(id)
            };
            return View(addChampsToTableVM);
        }

        /// <summary>
        /// Post pour ajouter un champs à une table
        /// </summary>
        /// <param name="addChampsToTableVM"></param>
        /// <returns></returns>
        [HttpPost("/addchamps/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult AddChampsToTable(AddChampsToTableViewModel addChampsToTableVM)
        {
            if (ModelState.IsValid)
            {
                ChampsService.AddChampsToTable(addChampsToTableVM.Name, addChampsToTableVM.IdTable, addChampsToTableVM.Table, addChampsToTableVM.Type);
                return RedirectToAction(nameof(HomeController.Index));
            }
            return View();
        }

        /// <summary>
        /// Edit un champs
        /// </summary>
        /// <param name="id">Id du champs à édité</param>
        /// <returns></returns>
        [HttpGet("/editchampstotable/{id}")]
        public IActionResult EditChamps(int id)
        {
            var champstoEdit = new TableUserViewModel()
            {
                Name = ChampsService.GetChamps(id).Name,
                Id = id,
            };
            return View(champstoEdit);
        }

        /// <summary>
        /// Post pour editer un champs
        /// </summary>
        /// <param name="champsEdit">Modification du champs</param>
        /// <returns></returns>
        [HttpPost("/editchampstotable/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult EditChamps(TableUserViewModel champsEdit)
        {
            ChampsService.UpdateChamps(champsEdit.Id, champsEdit.Name);
            return RedirectToAction(nameof(HomeController.Index));
        }

        /// <summary>
        /// Get pour supprimer un champs d'une table
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/deletechampstotable/{id}")]
        public IActionResult DeleteChampsToTable(int id)
        {
            var champs = new TableForDeleteChampsViewModel
            {
                Id = id,
                ListeChamps = ChampsService.GetChampsFromTable(id).Select(w => new ChampViewModel
                {
                    Id = w.Id,
                    Nom = w.Name,
                }).ToList()
            };
            return View(champs);
        }

        /// <summary>
        /// Post pour supprimer un ou des champs
        /// </summary>
        /// <param name="champs"></param>
        /// <returns></returns>
        [HttpPost("/deletechampstotable/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteChampsToTable(TableForDeleteChampsViewModel champs)
        {
            foreach (var id in champs.ListeSelectId)
            {
                ChampsService.DeleteChamps(id);
            }
            return RedirectToAction(nameof(HomeController.Index));
        }

        /// <summary>
        /// Get ajouter des valeurs
        /// </summary>
        /// <param name="id">id de la table</param>
        /// <returns></returns>
        [HttpGet("/addvalue/{id}")]
        public IActionResult AddValues(int id)
        {
            var newCreateValueVM = new CreateValueViewModel()
            {
                IdTable = id,
                ListeChamps = ChampsService.GetChampsFromTable(id).Select(w => new ChampsCreateValueViewModel()
                {
                    Id = w.Id,
                    Nom = w.Name,
                }).ToList(),

            };
            return View(newCreateValueVM);
        }

        /// <summary>
        /// Post pour ajouter une valeur
        /// </summary>
        /// <param name="newCreateValueVM"></param>
        /// <returns></returns>
        [HttpPost("/addvalue/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult PostAddValues(CreateValueViewModel newCreateValueVM)
        {
            var monDico = new Dictionary<int, string>();
            newCreateValueVM.IdLiaison = LiaisonValueService.CreateLiaison(null, newCreateValueVM.IdTable);

            foreach (var id in newCreateValueVM.ListeIdChamps)
            {
                foreach (var name in newCreateValueVM.ListeNomValeurs)
                {
                    if (!monDico.TryGetValue(id, out string maRecherche))
                    {
                        monDico.Add(id, name);
                    }
                }
                newCreateValueVM.ListeNomValeurs.RemoveAt(0);
            }

            foreach (var item in monDico)
            {
                ValueService.CreateValue(item.Value, newCreateValueVM.IdLiaison, item.Key);
            }
            LiaisonValueService.UpdateLiaison(ValueService.GetValue(newCreateValueVM.IdLiaison).ToList(), newCreateValueVM.IdLiaison);

            return Ok();
        }

        /// <summary>
        /// Supprime un ensemble de valeur
        /// </summary>
        /// <param name="idLiaison"></param>
        /// <returns></returns>
        public IActionResult DeleteLiaison(int idLiaison)
        {
            ValueService.DeleteValues(idLiaison);
            LiaisonValueService.DeleteLiaison(idLiaison);
            return RedirectToAction(nameof(HomeController.Index));
        }

        /// <summary>
        /// Renvoie un json avec toutes les infos
        /// </summary>
        /// <returns></returns>
        [HttpGet("/mcd")]
        public JsonResult GetMcd()
        {
            var jsonfile = "mcd.json";
            var pathTojson = Path.GetFullPath(jsonfile);
            using (StreamReader r = new StreamReader(pathTojson))
            {
                string json = r.ReadToEnd();
                json = json.Replace("\n", "").Replace("\r", "").Replace("\"", "");


                return Json(json);
            }

        }
    }
}
