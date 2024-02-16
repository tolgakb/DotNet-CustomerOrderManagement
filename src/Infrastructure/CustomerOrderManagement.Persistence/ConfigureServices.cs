using Ardalis.GuardClauses;
using CustomerOrderManagement.Application.Common.Interfaces;
using CustomerOrderManagement.Domain.Entities;
using CustomerOrderManagement.Persistence.DbContexts;
using CustomerOrderManagement.Persistence.Identity;
using CustomerOrderManagement.Persistence.UserProfiles;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderManagement.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("local");

            Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            // Add MSSQL DB Context
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false; // For special character
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                // Default SignIn settings.
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.User.RequireUniqueEmail = true;
            });

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddScoped<ICurrentHttpRequest, CurrentHttpRequest>();

            return services;

        }
    }
}
