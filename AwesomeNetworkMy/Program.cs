using AwesomeNetworkMy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace AwesomeNetworkMy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //ад
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");


            var mapperConfig = new MapperConfiguration((v) =>
            {
                v.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            builder.Services.AddSingleton(mapper);



            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection))
                   .AddIdentity<User, IdentityRole>(opts =>
                   {
                       opts.Password.RequiredLength = 5;
                       opts.Password.RequireNonAlphanumeric = false;
                       opts.Password.RequireLowercase = false;
                       opts.Password.RequireUppercase = false;
                       opts.Password.RequireDigit = false;
                   })
                       .AddEntityFrameworkStores<ApplicationDbContext>();



            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}