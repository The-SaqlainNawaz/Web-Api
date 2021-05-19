using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookCrud.Models
{
    public class Contact
    {
        public string name { get; set; }
        public DateTime dob { get; set; }
        public string contactNumber { get; set; }
        public string email { get; set; }
        public DateTime saveOn { get; set; }
    }
}