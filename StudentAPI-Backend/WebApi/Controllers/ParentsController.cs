using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        IParentService _parentService;

        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _parentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid/{parentId}")]
        public IActionResult GetById(int parentId)
        {
            var result = _parentService.Get(parentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Parent parent)
        {
            var result = _parentService.Add(parent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int parent)
        {
            var result = _parentService.Delete(parent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Parent parent)
        {
            var result = _parentService.Update(parent);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
