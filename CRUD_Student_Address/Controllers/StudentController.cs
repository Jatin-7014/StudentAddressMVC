using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_Student_Address.Models;

namespace CRUD_Student_Address.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        static List<Student> students = new List<Student>()
        {
            new Student() { Id = 1,
              Name="Allen",
              Age=42,
              Address=new Address(){
              Id=101,
              Country="India",
              State="Goa",
              City="Panjim"
              }
            },
            new Student() { Id = 2,
              Name="Marry",
              Age=34,
              Address=new Address(){
              Id=102,
              Country="India",
              State="Punjab",
              City="Mohali"
              }
            },
            new Student() { Id = 3,
              Name="Alex",
              Age=32,
              Address=new Address(){
              Id=103,
              Country="India",
              State="Gujrat",
              City="Ahmedabad"
              }
            },
            new Student() { Id = 4,
              Name="David",
              Age=37,
              Address=new Address(){
              Id=104,
              Country="India",
              State="Maharashtra",
              City="Andheri"
              }
            },
            new Student() { Id = 5,
              Name="Jatin",
              Age=22,
              Address=new Address(){
              Id=105,
              Country="India",
              State="J&K",
              City="Rspura"
              }
            }
        };
        public ActionResult Index()
        {
            var data = students;
            return View(data);
        }
        public ActionResult CreateNewStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewStudent(Student student)
        {
            students.Add(student);
            return RedirectToAction("Index");
        }

        public ActionResult StudentDetail(int id)
        {
            var student = students.FirstOrDefault(x=>x.Id==id);
            return View(student);
        }

        public ActionResult EditStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }
        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Age = student.Age;
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(Student studenN)
        {
            var student = students.FirstOrDefault(s => s.Id == studenN.Id);
            students.Remove(student);
            return RedirectToAction("Index");
        }

        public ActionResult GetStudentAddressById(int id)
        {
            var data = students.Where(st => st.Id == id).Select(st => st.Address).FirstOrDefault();
            return View(data);
        }
        public ActionResult EditAddress(int id)
        {
            var student = students.FirstOrDefault(s=>s.Id==id);
            var address=student.Address;
            return View(address);
        }
        [HttpPost]
        public ActionResult EditAddress(int id,Address newAddress)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            student.Address.City = newAddress.City;
            student.Address.Country = newAddress.Country;
            student.Address.State = newAddress.State;

            return RedirectToAction("GetStudentAddressById", new { id = student.Id });
            return View(newAddress);
        }
        public ActionResult DeleteAddress(int id)
        {
            var student = students.FirstOrDefault(st => st.Id == id);
            var address = student.Address;
            return View(address);
        }
        [HttpPost]
        public ActionResult DeleteAddress(int id,Address newAddress)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            student.Address.City =null;
            student.Address.Country =null;
            student.Address.State = null;

            return RedirectToAction("GetStudentAddressById", new { id = student.Id });
            return View(newAddress);
        }
    }
}