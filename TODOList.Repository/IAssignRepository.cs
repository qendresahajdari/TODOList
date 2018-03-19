using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface IAssignRepository : IDisposable
    {
        IEnumerable<Assign> GetAll();
        Assign GetByID(int Id);
        void Create(Assign assign);
        void Delete(int Id);
        void Update(Assign assign);
    }
}
