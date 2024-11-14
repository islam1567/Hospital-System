using Hospital_Management_System.Cores.ApplicationDbContext;
using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Entities;
using Hospital_Management_System.Cores.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Cores.Repos
{
    public class Doctor_Patient_Repo 
    {
        private readonly AppDbContext context;

        public Doctor_Patient_Repo(AppDbContext context)
        {
            this.context = context;
        }

        public List<Doctor_patient_Dto> GetAll()
        {
            var result = context.doctor_Patients.
                Select(e => new Doctor_patient_Dto
                {
                    DoctorId = e.Doctor_Id,
                    PatientId = e.Patient_Id,
                }).ToList();
            return result;
        }

        public Doctor_patient_Dto GetById(string doctorid, string patientid)
        {
            var result = context.doctor_Patients.
                //Include(e => e.Doctors).
                //Include(e => e.Patients).
                Select(e => new Doctor_patient_Dto
                {
                    PatientId = e.Patient_Id,
                    DoctorId = e.Doctor_Id,
                }).FirstOrDefault(e=> e.DoctorId == doctorid &&  e.PatientId == patientid);
            return result;
        }

        public void Add(Doctor_patient_Dto entity)
        {
            var doctor_patient = new Doctor_patient
            {
                Patient_Id = entity.PatientId,
                Doctor_Id = entity.DoctorId,
            };
            context.doctor_Patients.Add(doctor_patient);
            context.SaveChanges();
        }

        public void Update(string doctorid, string patientid, Doctor_patient_Dto entity)
        {
            var doctor_patient = context.doctor_Patients.FirstOrDefault(e => e.Doctor_Id == doctorid && e.Patient_Id == patientid);
            doctor_patient.Doctor_Id = entity.DoctorId;
            doctor_patient.Patient_Id = entity.PatientId;
            context.SaveChanges();
        }

        public void Delete(string doctorid, string patientid)
        {
            var doctor_patient = context.doctor_Patients.FirstOrDefault(e => e.Doctor_Id == doctorid && e.Patient_Id == patientid);
            context.Remove(doctor_patient);
            context.SaveChanges();
        }

    }
}
