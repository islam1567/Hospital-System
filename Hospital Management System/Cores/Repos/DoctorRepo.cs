using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;
using System.Net;
using System.Numerics;

namespace Hospital_Management_System.Cores.Repos
{
    public class DoctorRepo : IRepository<DoctorDto>
    {
        private readonly AppDbContext context;

        public DoctorRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<DoctorDto> GetAll()
        {
            var result = context.Doctors.
                Select(e => new DoctorDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName, 
                    LastName = e.LastName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Specialist = e.Specialist,
                }).ToList();
            return result;
        }

        public DoctorDto GetById(string id)
        {
            var result = context.Doctors.
                Select(e => new DoctorDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Address = e.Address,
                    Phone = e.Phone,
                    Specialist = e.Specialist,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(DoctorDto entity)
        {
            var doctor = new Doctors
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Address = entity.Address,
                Phone = entity.Phone,
                Specialist = entity.Specialist,
            };
            context.Doctors.Add(doctor);
            context.SaveChanges();
        }   

        public void Update(string id ,DoctorDto entity)
        {
            var doctor = context.Doctors.FirstOrDefault(e => e.Id == id);
            doctor.Id = entity.Id;
            doctor.FirstName = entity.FirstName;
            doctor.LastName = entity.LastName;
            doctor.Address = entity.Address;
            doctor.Phone = entity.Phone;
            doctor.Specialist = entity.Specialist;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var doctor = context.Doctors.FirstOrDefault(e => e.Id == id);
            context.Remove(doctor);
            context.SaveChanges();
        }
    }
}
