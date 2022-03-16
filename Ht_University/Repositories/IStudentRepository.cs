using Ht_university.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ht_university.Repositories
{
    public interface IStudentRepository
    {
        public void Add(Student student);
        List<Student> GetAll();
        Student GetStudent(int id);

    }
}
