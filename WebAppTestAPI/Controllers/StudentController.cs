using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppTestAPI.DataConnection;
using WebAppTestAPI.Model;

namespace WebAppTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public bool SaveStudent(Student stdObj)
        {
            try
            {
                _context.Students.Add(stdObj);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete("{Id}")]
        public bool DeleteStudent(int Id)
        {
            try
            {
                var data = _context.Students.Where(x => x.Roll == Id).FirstOrDefault();
                if (data != null)
                {
                    _context.Students.Remove(data);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public List<Student> GetAllStudent()
        {
            //List<Student> stdList = new List<Student>();
            //Student student1 = new Student()
            //{
            //    Id = 1,
            //    Name = "Ram",
            //    Roll = 1,
            //    Email = "ram@gmail.com"
            //};
            //Student student2 = new Student()
            //{
            //    Id = 2,
            //    Name = "Hari",
            //    Roll = 2,
            //    Email = "hari@gmail.com"
            //};
            //stdList.Add(student1);
            //stdList.Add(student2);
            var data = _context.Students.ToList();
            return data;
        }

        [HttpGet("studentById/{Id}")]
        public Student GetStudentDetails(int Id)
        {
            //Student student2 = new Student()
            //{
            //    Id = 2,
            //    Name = "Hari",
            //    Roll = 2,
            //    Email = "hari@gmail.com"
            //};
            var data = _context.Students.Where(x => x.Roll == Id).FirstOrDefault();
            return data;
        }

        [HttpGet("match/name/list/{name}")]
        public List<Student> GetMatchStudentNameList(string name)
        {
            var res = _context.Students.Where(x => x.Name == name).OrderByDescending(x => x.Roll).ToList();
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

        [HttpPut]
        public bool UpdateStudent(Student student)
        {
            var data = _context.Students.Where(x => x.Roll == student.Roll).FirstOrDefault();
            if (data != null)
            {
                data.Email = student.Email;
                data.Name = student.Name;
                _context.Students.Update(data);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}