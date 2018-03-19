using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface IProjectRepository : IDisposable
    {        
        IEnumerable<Project> GetAll();
        Project GetByID(int Id);
        void Create(Project project);
        void Delete(int Id);
        void Update(Project project);
    }
}
