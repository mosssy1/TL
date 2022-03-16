using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ht_university.Models;

namespace Ht_university.Repositories
{
    public interface IGroupsRepository
    {
        public void Add(Groups groups);
        List<Groups> GetAll();
        
    }
}
