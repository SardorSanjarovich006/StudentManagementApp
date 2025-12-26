using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp.Domain.Entities;
using StudentManagementApp.Domain.Interfaces;
using StudentManagementApp.Infrastucture.Data;

namespace StudentManagementApp.Infrastucture.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _db;

        public StudentRepository(AppDbContext db)
        {
            _db = db;
        }

        public void Add(Student st)
        {
            _db.Students.Add(st);
        }

        public Student GetById(int id)
        {
            return _db.Students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetByName(string name)
        {
            return _db.Students
                      .Where(s => s.FullName.ToLower().Contains(name.ToLower()))
                      .ToList();
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }

        public bool Delete(int id)
        {
            var st = GetById(id);
            if (st == null) return false;

            _db.Students.Remove(st);
            return true;
        }

        public bool Update(Student st)
        {
            var old = GetById(st.Id);
            if (old == null) return false;

            old.FullName = st.FullName;
            old.Age = st.Age;
            return true;
        }
    }

}
