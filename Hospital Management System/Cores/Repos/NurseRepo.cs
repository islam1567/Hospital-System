using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Hospital_Management_System.Cores.Entities;
using System.Numerics;

namespace Hospital_Management_System.Cores.Repos
{
    public class NurseRepo : IRepository<NursesDto>
    {
        private readonly AppDbContext context;

        public NurseRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<NursesDto> GetAll()
        {
            var result = context.Nurses.
                Select(e => new NursesDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                }).ToList();
            return result;
        }

        public NursesDto GetById(string id)
        {
            var result = context.Nurses.
                Select(e => new NursesDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(NursesDto entity)
        {
            var nurse = new Nurses
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Phone = entity.Phone,
            };
            context.Nurses.Add(nurse);
            context.SaveChanges();
        }

        public void Update(string id, NursesDto entity)
        {
            var nurse = context.Nurses.FirstOrDefault(x => x.Id == id);
            nurse.Id = entity.Id;
            nurse.FirstName = entity.FirstName;
            nurse.LastName = entity.LastName;
            nurse.Phone = entity.Phone;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var nurse = context.Nurses.FirstOrDefault(x => x.Id == id);
            context.Remove(nurse);
            context.SaveChanges();
        }
        
    }
}
