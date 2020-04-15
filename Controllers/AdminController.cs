using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DubuisGelin.Models.ChampsViewModel;
using DubuisGelin.Models.HomeController;
using DubuisGelin.Models.LiaisonViewModel;
using DubuisGelin.Models.TableViewModel;
using DubuisGelin.Models.UserViewModel;
using DubuisGelin.Models.ValueViewModel;
using DubuisGelin.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DubuisGelin.Controllers
{
    public class AdminController : Controller
    {
        public AdminController(IUserService userService, ITableService tableService, IChampsService champsService, ILiaisonValueService liaisonValueService, IValueService valueService)
        {
            UserService = userService ?? throw new ArgumentNullException(nameof(userService));
            TableService = tableService ?? throw new ArgumentNullException(nameof(tableService));
            ChampsService = champsService ?? throw new ArgumentNullException(nameof(champsService));
            LiaisonValueService = liaisonValueService ?? throw new ArgumentNullException(nameof(liaisonValueService));
            ValueService = valueService ?? throw new ArgumentNullException(nameof(valueService));
        }
        public ITableService TableService { get; }
        public IChampsService ChampsService { get; }
        public ILiaisonValueService LiaisonValueService { get; }
        public IValueService ValueService { get; }
        public IUserService UserService { get; }

        /// <summary>
        /// Index de l'administration
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var all = new AllUser
            {
                ListeAllUser = UserService.GetAllUser().Select(w => new GetUserViewModel {
                    Id =w.Id,
                    Nom = w.Mail,
                }).ToList(),
            };
            return View(all);
        }

        /// <summary>
        /// Index des tables pour un utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult IndexTableForUser(Guid id)
        {
            var indexViewModel = new IndexViewModel();
            var user = UserService.GetUserById(id);
            indexViewModel.IdUser = user.Id;
            indexViewModel.TableUtilisateur = TableService.GetTablesFromUser(user.Id).Select(p => new TableUserViewModel
            {
                Name = p.Nom,
                Id = p.Id,
            });
            return View(indexViewModel);
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DeleteUser(Guid id)
        {
            UserService.DeleteUser(id);
            return RedirectToAction(nameof(AdminController.Index));
        }

        /// <summary>
        /// Montre les champs et les valeurs d'une table pour un utilisateur séléctionné
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult TableIndex(int id)
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
    }
}