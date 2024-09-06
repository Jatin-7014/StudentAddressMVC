using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Student_Address.Models
{
    public class Student
    {
        public string Name {  get; set; }
        public int Id { get; set; }
        public int Age {  get; set; }
        public Address Address { get; set; }
    }
}