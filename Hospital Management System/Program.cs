
using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(e =>
            e.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HospitalDB;Integrated Security=True")
            );

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>().
                AddDefaultTokenProviders();


            builder.Services.AddScoped<IRepository<DoctorDto>, DoctorRepo>();
            builder.Services.AddScoped<IRepository<PatientsDto>, PatientRepo>();
            builder.Services.AddScoped<IRepository<RoomsDto>, RoomRepo>();
            builder.Services.AddScoped<IRepository<PaymentDto>, PaymentRepo>();
            builder.Services.AddScoped<IRepository<NursesDto>, NurseRepo>();
            builder.Services.AddScoped<IAuthService, AuthService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
