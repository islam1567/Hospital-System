using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IRepository<PaymentDto> repo;

        public PaymentController(IRepository<PaymentDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("get-all-payment")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet]
        [Route("get-payment-by-id", Name = "PaymentRoute")]
        public IActionResult GetById(string id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        [Route("add-payment")]
        public IActionResult Add(PaymentDto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Add(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            var url = Url.Link("PaymentRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut]
        [Route("update-payment")]
        public IActionResult Update(string id, PaymentDto dto)
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
        [Route("delete-payment")]
        public IActionResult Delete(string id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
