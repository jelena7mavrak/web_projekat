using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class PersonRepository : Repository<Person, int>, IPersonRepository
    {
        protected ApplicationDbContext AppDbContext
        {
            get { return context as ApplicationDbContext; }
        }

        public PersonRepository(DbContext context) : base(context)
        {
        }

        public bool Login(string username, string password)
        {
            foreach(var person in AppDbContext.Persons)
            {
                if ((person.Name == username || person.Email == username) &&
                    ApplicationUser.VerifyHashedPassword(person.Password, password))
                    return true;
            }
            return false;
        }

        public bool Register(Person user)
        {
            var userStore = new UserStore<Person>(context);
            var userManager = new UserManager<Person>(userStore);

            if (!AppDbContext.Users.Any(u => u.Email == user.Email || u.UserName == user.UserName))
            {
                userManager.Create(user);

                context.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}