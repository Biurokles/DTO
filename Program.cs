using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DTO.Interfaces;
using DTO.Models;
using DTO.Models.Entities;
using DTO.Services.Repositories;
using DTO.Services;

namespace DTO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddRazorPages();
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            builder.Services.AddDefaultIdentity<User>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IHistoryService, HistoryService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}