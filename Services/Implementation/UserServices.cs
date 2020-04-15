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

        /// <summary>
        /// Créer un utilisateur
        /// </summary>
        /// <param name="mail">mail de l'utilisateur</param>
        /// <returns></returns>
        public async Task CreateUser(string mail)
        {
            var newUser = new User()
            {
                Mail = mail
            };
            await _context.Utilisateur.AddAsync(newUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Renvoie un utilisateur en fonction de son mail
        /// </summary>
        /// <param name="mail">Mail de l'utilisateur recherché</param>
        /// <returns></returns>
        public User GetUserByMail(string mail)
        {
            return _context.Utilisateur.FirstOrDefault(m => m.Mail == mail);
        }

        /// <summary>
        /// Renvoie un utilisateur en fonction de son Id
        /// </summary>
        /// <param name="Id">Id de l'utilisateur recherché</param>
        /// <returns></returns>
        public User GetUserById(Guid Id)
        {
            return _context.Utilisateur.FirstOrDefault(m => m.Id == Id);
        }

        /// <summary>
        /// Renvoie tous les utilisateurs
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetAllUser()
        {
            return _context.Utilisateur;
        }

        /// <summary>
        /// Supprime un utilisateur
        /// </summary>
        /// <param name="id">Id de l'utilisateur à supprimer</param>
        public void DeleteUser(Guid id)
        {
            var user = GetUserById(id);
            var identityUser = _context.Users.FirstOrDefault(w => w.Email == user.Mail);
            _context.Users.Remove(identityUser);
            _context.Utilisateur.Remove(user);
            _context.SaveChanges();
        }
    }
}
