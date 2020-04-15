using DubuisGelin.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DubuisGelin.Services.Interface
{
    public interface IUserService
    {
        Task CreateUser(string mail);

        User GetUserByMail(string mail);

        User GetUserById(Guid Id);

        IEnumerable<User> GetAllUser();

        void DeleteUser(Guid id);

    }
}
