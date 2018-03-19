using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface ISoftwareTaskRepository : IDisposable
    {
        IEnumerable<SoftwareTask> GetAll();
        SoftwareTask GetByID(int Id);
        void Create(SoftwareTask softwareTask);
        void Delete(int Id);
        void Update(SoftwareTask softwareTask);
    }
}
