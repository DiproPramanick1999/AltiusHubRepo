using AltiusHubTestData;
using AltiusHubTestRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AltiusHubTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private IRepository repository;
        public CRUDController(IRepository _repository)
        {
            repository = _repository;
        }

        [HttpGet]
        [Route("get-all")]
        //[Authorize]
        public IActionResult GetHeader()
        {
            try
            {
                var data = repository.GetAllHeader().Result;
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("getOneHeader/{Id}")]
        public IActionResult GetHeaderByJson(int Id)
        {
            try
            {
                return Ok(repository.GetInvoiceHeaderByJSON(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Create-Header")]
        public IActionResult CreateHeaderByJson(InvoiceHeader invoice)
        {
            try
            {
                return Ok(repository.CreateInvoiceHeaderByJSON(invoice).Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
