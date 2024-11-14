using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Doctor_PatientController : ControllerBase
    {
        private readonly Doctor_Patient_Repo repo;

        public Doctor_PatientController(Doctor_Patient_Repo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("get-all-doctor_patient")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet]
        [Route("get-doctor_patient-by-id", Name = "Doctor_PatientRoute")]
        public IActionResult GetById(string doctorid, string patientid)
        {
            return Ok(repo.GetById(doctorid, patientid));
        }

        [HttpPost]
        [Route("add-doctor_patient")]
        public IActionResult Add(Doctor_patient_Dto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Add(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            var url = Url.Link("Doctor_PatientRoute", new { id = dto.DoctorId});
            return Created(url, dto);
        }

        [HttpPut]
        [Route("update-doctor_patient")]
        public IActionResult Update(string doctorid, string patientid, Doctor_patient_Dto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Update(doctorid, patientid, dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok(dto);
        }

        [HttpDelete]
        [Route("delete-doctor")]
        public IActionResult Delete(string doctorid, string patientid)
        {
            repo.Delete(doctorid, patientid);
            return Ok();
        }
    }
}
