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
    }
}