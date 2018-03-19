using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface IRoleRepository : IDisposable
    {
        IEnumerable<Role> GetAll();
        Role GetByID(int Id);
        void Create(Role role);
        void Delete(int Id);
        void Update(Role role);
    }
}
