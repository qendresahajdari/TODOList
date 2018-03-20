using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetAll();
        User GetByID(int Id);
        User GetByUserName(string username);
        void Create(User user);
        void Delete(int Id);
        void Update(User user);
    }
}
