using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _studentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid/{studentId}")]
        public IActionResult GetById(int studentId)
        {
            var result = _studentService.Get(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getstudentsbyparentid/{parentId}")]
        public IActionResult GetStudentsByParentId(int parentId)
        {
            var result = _studentService.GetStudentsByParentId(parentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getstudentsbyschoolid/{schoolId}")]
        public IActionResult GetStudentsBySchoolId(int schoolId)
        {
            var result = _studentService.GetStudentsBySchoolId(schoolId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getstudentdetaildtos")]
        public IActionResult GetStudentDetailDto()
        {
            var result = _studentService.GetStudentDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getstudentdetaildtosbyid/{studentId}")]
        public IActionResult GetStudentDetailDtoById(int studentId)
        {
            var result = _studentService.GetStudentDetailDtoById(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            var result = _studentService.Add(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("delete/{studentId}")]
        public IActionResult Delete(int studentId)
        {
            var result = _studentService.Delete(studentId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Student student)
        {
            var result = _studentService.Update(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
