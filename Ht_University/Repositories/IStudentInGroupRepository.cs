using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ht_university.Models;

namespace Ht_university.Repositories
{
    public interface IStudentInGroupRepository
    {
        public void Add(StudentInGroup studentGroup);

    
        List<StudentInGroup> Get(int id);
    }
}
