namespace KamikazeVTPRO.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using KamikazeVTPRO.Model.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<KamikazeVTPRO.Data.KamikazeVTPRODbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KamikazeVTPRO.Data.KamikazeVTPRODbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            CreateUser(context);
        }

        private void CreateUser(KamikazeVTPRODbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new KamikazeVTPRODbContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new KamikazeVTPRODbContext()));

            var user = new ApplicationUser()
            {
                UserName = "kamikazevtpro",
                Email = "vietnamthaotranvan@gmail.com",
                EmailConfirmed = true
            };
            if (manager.Users.Count(x => x.UserName == "KamikazeVTPRO") == 0)
            {
                manager.Create(user, "kamikazevtpro");

                if (!roleManager.Roles.Any())
                {
                    roleManager.Create(new IdentityRole { Name = "Admin" });
                    roleManager.Create(new IdentityRole { Name = "User" });
                }

                var adminUser = manager.FindByEmail("vietnamthaotranvan@gmail.com");

                manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
            }
        }
    }
}