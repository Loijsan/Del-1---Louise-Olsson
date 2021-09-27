using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Del_1___Louise_Olsson.Models
{
    public class AppUser : IdentityUser
    {
        public string NickName { get; set; }
    }
}
