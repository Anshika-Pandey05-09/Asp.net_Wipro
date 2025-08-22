// using System.Reflection.Metadata.Ecma335;
using StudentApp.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{

    public class StudentController : ControllerBase
    {
        // Your action methods go here
        [HttpGet]
        [Route("Student/details")]
        // [Authorize]  // authorization filter
        [ServiceFilter(typeof(CustomAuthorizationFilter))]
        public IActionResult GetStudents()
        {
            // Example action method to get students
            return Ok("Students details can only be seen by authorized users");
        }

        [ServiceFilter(typeof(StudentApp.Filters.ValidateStudentFilter))]
        // this filter validates the student name
        [HttpGet("Student/add/{name}")]
        public IActionResult Add(string name)
        {
            // Example action method to add a student
            return Ok($"Student {name} added successfully.");
        }

        // Errortest
        [HttpGet("Student/error")]
        public IActionResult ErrorTest()
        {
            throw new Exception("This is a test exception");
            // This exception will be caught by the custom exception filter, instead of crashing the application
        }
    }
}