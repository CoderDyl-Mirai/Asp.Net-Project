using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName {  get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty ;
    }
}
