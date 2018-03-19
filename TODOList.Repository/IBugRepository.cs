using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOList.Domain;

namespace TODOList.Repository
{
    interface IBugRepository : IDisposable
    {
        IEnumerable<Bug> GetAll();
        Bug GetByID(int Id);
        void Create(Bug bug);
        void Delete(int Id);
        void Update(Bug bug);
    }
}
