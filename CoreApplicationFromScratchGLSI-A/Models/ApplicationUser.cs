using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApplicationFromScratchGLSI_A.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
