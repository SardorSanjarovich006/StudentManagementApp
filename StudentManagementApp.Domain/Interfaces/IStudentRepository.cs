using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp.Domain.Entities;

namespace StudentManagementApp.Domain.Interfaces
{
    public interface IStudentRepository
    {
        void Add(Student st);
        Student GetById(int id);
        IEnumerable<Student> GetByName(string name);
        IEnumerable<Student> GetAll();
        bool Delete(int id);
        bool Update(Student st);
    }
}

