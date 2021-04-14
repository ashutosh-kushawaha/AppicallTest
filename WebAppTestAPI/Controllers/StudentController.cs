using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTestAPI.Model;

namespace WebAppTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public bool SaveStudent(Student stdObj)
        {
            if (stdObj.Name == "Ram")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet]
        public List<Student> GetAllStudent()
        {
            List<Student> stdList = new List<Student>();
            Student student1 = new Student()
            {
                Id = 1,
                Name = "Ram",
                Roll = 1,
                Email = "ram@gmail.com"
            };
            Student student2 = new Student()
            {
                Id = 2,
                Name = "Hari",
                Roll = 2,
                Email = "hari@gmail.com"
            };
            stdList.Add(student1);
            stdList.Add(student2);
            return stdList;
        }

        [HttpGet("studentById/{Id}")]
        public Student GetStudentDetails(int Id)
        {
            Student student2 = new Student()
            {
                Id = 2,
                Name = "Hari",
                Roll = 2,
                Email = "hari@gmail.com"
            };
            return student2;
        }

        [HttpGet("match/name/list/{name}")]
        public List<Student> GetMatchStudentNameList(string name)
        {
            var data = GetStudent();
            var res = data.Where(x => x.Name == name).OrderByDescending(x => x.Roll).ToList();
            return res;
        }

        private List<Student> GetStudent()
        {
            List<Student> stdList = new List<Student>();
            Student student1 = new Student()
            {
                Id = 1,
                Name = "Ram",
                Roll = 1,
                Email = "ram@gmail.com"
            };
            Student student3 = new Student()
            {
                Id = 3,
                Name = "Ram",
                Roll = 3,
                Email = "ram@gmail.com"
            };
            Student student4 = new Student()
            {
                Id = 4,
                Name = "Ram",
                Roll = 4,
                Email = "ram@gmail.com"
            };
            Student student2 = new Student()
            {
                Id = 2,
                Name = "Hari",
                Roll = 2,
                Email = "hari@gmail.com"
            };
            stdList.Add(student1);
            stdList.Add(student2);
            stdList.Add(student3);
            stdList.Add(student4);
            return stdList;
        }
    }
}