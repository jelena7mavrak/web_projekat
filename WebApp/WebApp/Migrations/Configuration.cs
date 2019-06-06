namespace WebApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApp.Persistence.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        //ubaci try-catch
        protected override void Seed(WebApp.Persistence.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var coef1 = new Coefficients { Id = 1, Coefficient = 0.5, Type=Enums.PassengerType.Pensioner };
            var coef2 = new Coefficients { Id = 2, Coefficient = 0.8, Type=Enums.PassengerType.Student };
            var coef3 = new Coefficients { Id = 3, Coefficient = 1, Type = Enums.PassengerType.Regular };

            context.Coefficients.AddOrUpdate(a => a.Id, coef1);
            context.Coefficients.AddOrUpdate(a => a.Id, coef2);
            context.Coefficients.AddOrUpdate(a => a.Id, coef3);

            context.SaveChanges();

            var i1 = new Item { Id = 1, Type = Enums.TicketType.Annual };
            var i2 = new Item { Id = 2, Type = Enums.TicketType.Daily };
            var i3 = new Item { Id = 3, Type = Enums.TicketType.Hourly };
            var i4 = new Item { Id = 4, Type = Enums.TicketType.Monthly };

            context.Items.AddOrUpdate(a => a.Id, i1);
            context.Items.AddOrUpdate(a => a.Id, i2);
            context.Items.AddOrUpdate(a => a.Id, i3);
            context.Items.AddOrUpdate(a => a.Id, i4);

            context.SaveChanges();
            

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Controller"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Controller" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "AppUser"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "AppUser" };

                manager.Create(role);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@yahoo.com"))
            {
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!") };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }
        }
    }
}
