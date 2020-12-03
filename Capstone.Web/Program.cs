using System;
using System.Collections.Generic;
using System.Linq;
using Capstone.Core.Models;
using Capstone.Infrastructure.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Capstone.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            IServiceProvider sp = host.Services.CreateScope().ServiceProvider;
            using (CapstoneDBContext Context = sp.GetServices<CapstoneDBContext>().First())
            {
                Context.Database.Migrate();
                UserManager<CapstoneUser> userManager =
                    sp.GetService(typeof(UserManager<CapstoneUser>)) as UserManager<CapstoneUser>;
                RoleManager<CapstoneRole> roleManager =
                    sp.GetService(typeof(RoleManager<CapstoneRole>)) as RoleManager<CapstoneRole>;

                IConfiguration configuration = ((IConfiguration) sp.GetService(typeof(IConfiguration)));
                string s = configuration.GetSection("Roles").Value;
                List<string> emailsList = new List<string>();
                for (int i = 0; configuration.GetSection($"Email{i}").Value != null; i++)
                    emailsList.Add(configuration.GetSection($"Email{i}").Value);
                List<string> rolesList = new List<string>();
                for (int i = 0; configuration.GetSection($"Roles{i}").Value != null; i++)
                    rolesList.Add(configuration.GetSection($"Roles{i}").Value);

                if (roleManager.Roles.Count() == 0)
                {
                    for (int i = 0; configuration.GetSection($"Roles{i}").Value != null; i++)
                    {
                        CapstoneRole role = new CapstoneRole { Name = configuration.GetSection($"Roles{i}").Value };
                        roleManager.CreateAsync(role);
                    }
                }

                if (userManager.Users.Count() == 0)
                {
                    for (int i = 0; configuration.GetSection($"Email{i}").Value != null; i++)
                    {
                        string email = configuration.GetSection($"Email{i}").Value;
                        CapstoneUser user = new CapstoneUser { Email = email, UserName = email };
                        Author author = new Author { Id = user.Id, Name = email };
                        user.AuthoredItems = author;
                        userManager.CreateAsync(user, configuration.GetSection("DefaultPass").Value);
                        userManager.AddToRoleAsync(user, roleManager.Roles.ToList()[i % roleManager.Roles.Count()].Name);
                    }
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}