using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreWebApi.Models; 
using CoreWebApi.Context;
using Microsoft.AspNetCore.Authorization;

namespace CoreWebApi.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly MyDbContext dc;
        private readonly ILogger<StudentController> logger;
        
        public StudentController(MyDbContext _dc,ILogger<StudentController> _logger)
        {
            dc = _dc;
            logger = _logger;
        }
        [HttpGet()]
        public IActionResult Get()
        {
            var students = dc.Students.ToList();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = dc.Students.Find(id);
            return Ok(student);
        }
        [HttpPost]
        public IActionResult Post(Student student)
        {
            logger.LogInformation($"Post {student.Name} Called {DateTime.UtcNow.ToLongTimeString()}");
            if (student == null)
            {
                return BadRequest();
            }
            dc.Students.Add(student);
            dc.SaveChanges();
           // return Created(new Uri("https://localhost:5001/Student/"+student.id),student);
           return CreatedAtAction(nameof(Get),new { id = student.Id }, student);
        }
    }
}
