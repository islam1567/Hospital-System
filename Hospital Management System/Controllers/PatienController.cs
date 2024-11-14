using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatienController : ControllerBase
    {
        private readonly IRepository<PatientsDto> repo;

        public PatienController(IRepository<PatientsDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("get-all-patient")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet]
        [Route("get-patient-by-id", Name = "PatientRoute")]
        public IActionResult GetById(string id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        [Route("add-patient")]
        public IActionResult Add(PatientsDto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Add(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            var url = Url.Link("PatientRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut]
        [Route("update-patient")]
        public IActionResult Update(string id, PatientsDto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Update(id, dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok(dto);
        }

        [HttpDelete]
        [Route("delete-patient")]
        public IActionResult Delete(string id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
