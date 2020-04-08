﻿using System;
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

        [HttpGet("/create")]
        public IActionResult CreateTable()
        {
            var createTableVM = new CreateTableViewModel
            {
                IdUser = UserService.GetUserByMail(User.Identity.Name).Id,
            };
            return View(createTableVM);
        }

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

        [HttpGet("/indexChamps/{id}")]
        public IActionResult IndexTable(int id)
        {
            var indexTable = new IndexTableViewModel()
            {
                NameTable = TableService.GetTableById(id).Nom,
                ListeChamps = ChampsService.GetChampsFromTable(id).Select(p => new ChampViewModel {
                    Nom = p.Name,
                }).ToList(),
                ListeLiaison = LiaisonValueService.GetAllLiaison().Select(w => new LiaisonTableIndexViewModel {
                    Id = w.Id,
                    ListeValue = ValueService.GetValueFromLiaison(w.Id).Select(a => new ValuesViewModel {
                        Nom = a.Name,
                        IdChamps = a.ChampsId
                    }).ToList(),
                }).ToList(),
            };
            return View(indexTable);
        }

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


        [HttpGet("/addvalue/{id}")]
        public IActionResult AddValues(int id)
        {
            var newCreateValueVM = new CreateValueViewModel()
            {
                ListeChamps = ChampsService.GetChampsFromTable(id).Select(w => new ChampsCreateValueViewModel()
                {
                    Id = w.Id,
                    Nom = w.Name,
                }).ToList(),

            };
            return View(newCreateValueVM);
        }
        

        public IActionResult PostAddValues(CreateValueViewModel newCreateValueVM)
        {
            var monDico = new Dictionary<int, string>();
            newCreateValueVM.IdLiaison = LiaisonValueService.CreateLiaison(null);

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
            return Ok();
        }

    }
}
