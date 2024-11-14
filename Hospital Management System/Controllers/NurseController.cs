using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly IRepository<NursesDto> repo;

        public NurseController(IRepository<NursesDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("get-all-nurse")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet]
        [Route("get-nurse-by-id", Name = "NurseRoute")]
        public IActionResult GetById(string id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        [Route("add-nurse")]
        public IActionResult Add(NursesDto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Add(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            var url = Url.Link("NurseRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut]
        [Route("update-nurse")]
        public IActionResult Update(string id, NursesDto dto)
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
        [Route("delete-nurse")]
        public IActionResult Delete(string id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
