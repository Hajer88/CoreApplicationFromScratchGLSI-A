using CoreApplicationFromScratchGLSI_A.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApplicationFromScratchGLSI_A.Models;

namespace CoreApplicationFromScratchGLSI_A.Areas.Admin.Services
{
    public class UserService : IUserService
    { 
        private readonly ApplicationDbContext _db;
        public UserService(ApplicationDbContext _db)
        {
            this._db = _db;
        }
        public IEnumerable<ApplicationUser> getusers()
        {
            return _db.Users;
        }

    }
}
