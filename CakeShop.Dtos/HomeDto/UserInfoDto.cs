using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Dtos.HomeDto
{
    public class UserInfoDto
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Dob { get; set; }
        public string Email {get;set;}
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
