using DubuisGelin.Data;
using DubuisGelin.Data.Entity;
using DubuisGelin.Services.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public RoleManager<IdentityRole> RoleManager { get; }

        public UserService(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            RoleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task CreateUser(string mail)
        {
            var newUser = new User()
            {
                Mail = mail
            };
            await _context.Utilisateur.AddAsync(newUser);
            await _context.SaveChangesAsync();
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
