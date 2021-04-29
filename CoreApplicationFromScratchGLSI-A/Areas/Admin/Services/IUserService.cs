using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApplicationFromScratchGLSI_A.Models;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public interface IUserService
    {
        public IEnumerable<ApplicationUser> getusers();
    }
}
