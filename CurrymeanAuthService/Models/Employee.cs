using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrymeanAuthService.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserMail { get; set; }
        public string Password { get; set; }
        public int Social { get; set; }
    }
 
}