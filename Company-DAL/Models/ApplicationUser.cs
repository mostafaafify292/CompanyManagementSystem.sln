using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Company_DAL.Models
{
    public class ApplicationUser :IdentityUser
    {
        public bool IsAgree { get; set; }
        public string FullName { get; set; }
        
    }
}
