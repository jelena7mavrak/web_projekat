﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
   public interface IPersonRepository : IRepository<ApplicationUser, int>
    {
        bool Login(string username, string password);
        bool Register(ApplicationUser user);
    }
}
