using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementApp.Domain.Entities;

namespace StudentManagementApp.Infrastucture.Data
{
    public class AppDbContext
    {
       
            public List<Student> Students { get; set; } = new List<Student>();
        
    }
}
