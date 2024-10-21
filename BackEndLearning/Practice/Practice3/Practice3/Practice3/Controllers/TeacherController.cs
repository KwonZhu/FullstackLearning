using Microsoft.AspNetCore.Mvc;
using Practice3.Models;
using System.ComponentModel.DataAnnotations;

namespace Practice3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        List<Teacher> teachers = new List<Teacher>()
        {
            new Teacher {UserId = 1, Department = "FrontEnd", Description = "FrontEnd teacher", Specialty = "javascript" },
            new Teacher { UserId = 2, Department = "BackEnd", Description = "BackEnd teacher", Specialty = "c#" },
            new Teacher { UserId = 3, Department = "FrontEnd", Description = "FrontEnd teacher", Specialty = "react" },
        };
    }
}
