using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;

namespace Hospital_Management_System.Cores.Repos
{
    public class PatientRepo : IRepository<PatientsDto>
    {
        private readonly AppDbContext context;

        public PatientRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<PatientsDto> GetAll()
        {
            var result = context.Patients.
                Select(e => new PatientsDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                    Address = e.Address,
                }).ToList();
            return result;
        }

        public PatientsDto GetById(string id)
        {
            var result = context.Patients.
                Select(e => new PatientsDto
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Phone = e.Phone,
                    Address = e.Address,
                }).FirstOrDefault(e => e.Id == id);
            return result;
        }

        public void Add(PatientsDto entity)
        {
            var patient = new Patients
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Phone = entity.Phone,
                Address = entity.Address,
            };
            context.Patients.Add(patient);
            context.SaveChanges();
        }

        public void Update(string id, PatientsDto entity)
        {
            var patient = context.Patients.FirstOrDefault(x => x.Id == id);
            patient.Id = entity.Id;
            patient.FirstName = entity.FirstName;
            patient.LastName = entity.LastName;
            patient.Phone = entity.Phone;
            patient.Address = entity.Address;
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var patient = context.Nurses.FirstOrDefault(x => x.Id == id);
            context.Remove(patient);
            context.SaveChanges();
        }

    }
}
