using DubuisGelin.Data;
using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly TableService _tableServices;
        private readonly UserService _userService;

        public UserService(ApplicationDbContext context, TableService tableService, UserService userService)
        {
            _userService = userService;
            _tableServices = tableService;
            _context = context;
        }

        public async Task CreateUser(string mail)
        {
            var newUser = new User()
            {
                Mail = mail
            };
            await _context.Utilisateur.AddAsync(newUser);
            await _context.SaveChangesAsync();
            var idUser = _userService.GetUserByMail(mail).Id;
            _tableServices.CreateTableForNewUser(idUser);
        }

        public User GetUserByMail(string mail)
        {
            return _context.Utilisateur.FirstOrDefault(m => m.Mail == mail);
        }
        public User GetUserById(Guid Id)
        {
            return _context.Utilisateur.FirstOrDefault(m => m.Id == Id);
        }
    }
}
