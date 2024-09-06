using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Student_Address.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State {  get; set; }
        public string City { get; set; }

    }
}