using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizMachine.Models;

[assembly: HostingStartup(typeof(QuizMachine.Areas.Identity.IdentityHostingStartup))]
namespace QuizMachine.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<VeridocsStatesCapitalsContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("QuizMachineIdentityDbContextConnection")));

                // Removing this, as it causes conflicts with startup.
                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //    .AddEntityFrameworkStores<VeridocsStatesCapitalsContext>();
            });
        }
    }
}