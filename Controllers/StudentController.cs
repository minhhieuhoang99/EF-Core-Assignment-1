using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EFCore.Models;
using EFCore.Services;
namespace EFCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentService;
        public StudentController(IStudentServices studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("/student")]
        public List<Student> Get()
        {
            var result = _studentService.GetStudent();
            return result;
        }
        [HttpPost("/student")]
        public ActionResult Post(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var existStudent =  _studentService.Add(student);
                    if (existStudent > 0)
                    {
                        return Ok(existStudent);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPut("/student")]
        public ActionResult Put(Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                     _studentService.Edit(student);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpDelete("/student/{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);
            return NoContent();
        }

    }
}
