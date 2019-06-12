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

            var i1 = new Item { Id = 1, Type = Enums.TicketType.Hourly };
            var i2 = new Item { Id = 2, Type = Enums.TicketType.Daily };
            var i3 = new Item { Id = 3, Type = Enums.TicketType.Monthly };
            var i4 = new Item { Id = 4, Type = Enums.TicketType.Annual };

            context.Items.AddOrUpdate(a => a.Id, i1);
            context.Items.AddOrUpdate(a => a.Id, i2);
            context.Items.AddOrUpdate(a => a.Id, i3);
            context.Items.AddOrUpdate(a => a.Id, i4);

            context.SaveChanges();

            

            var s1 = new Station { StatioId = 1, Name = "Grbavica", Address = "Puskinova", LineId=1 };
            var s2 = new Station { StatioId = 2, Name = "Liman", Address = "Narodnog fronta", LineId = 3 };
            var s3 = new Station { StatioId = 3, Name = "Klisa", Address = "Tolstojeva", LineId = 2 };
            var s4 = new Station { StatioId = 4, Name = "Podbara", Address = "Kosovska", LineId = 5 };
            var s5 = new Station { StatioId = 5, Name = "Liman", Address = "Vojvodjanskih brigada", LineId = 4 };

            context.Stations.AddOrUpdate(s => s.StatioId, s1);
            context.Stations.AddOrUpdate(s => s.StatioId, s2);
            context.Stations.AddOrUpdate(s => s.StatioId, s3);
            context.Stations.AddOrUpdate(s => s.StatioId, s4);
            context.Stations.AddOrUpdate(s => s.StatioId, s5);

             context.SaveChanges();

            var r1 = new Line { Id = 1, RouteNumber = 4, RouteType = Enums.RouteType.Town, StationId = 1, Stations={s1, s2, s3, s4, s5} };
            var r2 = new Line { Id = 2, RouteNumber = 56, RouteType = Enums.RouteType.Suburban, StationId = 2, Stations = { s4, s2, s1 } };
            var r3 = new Line { Id = 3, RouteNumber = 7, RouteType = Enums.RouteType.Town, StationId = 3, Stations = { s1, s2, s3, s4 } };
            var r4 = new Line { Id = 4, RouteNumber = 54, RouteType = Enums.RouteType.Suburban, StationId = 4, Stations = { s1, s2, s3, s4, s5 } };
            var r5 = new Line { Id = 5, RouteNumber = 11, RouteType = Enums.RouteType.Town, StationId = 5, Stations = { s3, s4, s5 } };

            context.Routes.AddOrUpdate(r => r.Id, r1);
            context.Routes.AddOrUpdate(r => r.Id, r2);
            context.Routes.AddOrUpdate(r => r.Id, r3);
            context.Routes.AddOrUpdate(r => r.Id, r4);
            context.Routes.AddOrUpdate(r => r.Id, r5);
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
                var user = new ApplicationUser() { Id = "admin", UserName = "admin@yahoo.com", Email = "admin@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Admin123!"), BirthdayDate=new DateTime(1999, 2, 2) };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "appu@yahoo.com"))
            { 
                var user = new ApplicationUser() { Id = "appu", UserName = "appu@yahoo.com", Email = "appu@yahoo.com", PasswordHash = ApplicationUser.HashPassword("Appu123!"), BirthdayDate = new DateTime(2000, 2, 2) };
                userManager.Create(user);
                userManager.AddToRole(user.Id, "AppUser");
            }
        }
    }
}
