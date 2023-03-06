using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmationsController : ControllerBase
    {
        IConfirmationService _confirmationService;
        public ConfirmationsController(IConfirmationService confirmationService)
        {
            _confirmationService = confirmationService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _confirmationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet("verifyconfirmation")]
        public IActionResult VerifyConfirmation(int confirmId,string code)
        {
            var result = _confirmationService.VerifyConfirm(confirmId,code);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("sendnewconfirmation")]
        public IActionResult SendNewConfirmation(int parentId)
        {
            var result = _confirmationService.Create(parentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
