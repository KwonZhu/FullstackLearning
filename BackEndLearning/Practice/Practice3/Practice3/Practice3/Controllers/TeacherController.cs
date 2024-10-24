using Microsoft.AspNetCore.Mvc;
using Practice3.Models;
using System.ComponentModel.DataAnnotations;

namespace Practice3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public static List<Teacher> Teachers = new List<Teacher>()
        {
            new Teacher {TeacherId = 1, Department = "FrontEnd", Description = "FrontEnd teacher", Specialty = "javascript", UserId=1},
            new Teacher { TeacherId = 2, Department = "BackEnd", Description = "BackEnd teacher", Specialty = "c#", UserId=2 },
               new Teacher { TeacherId = 3, Department = "FrontEnd", Description = "FrontEnd tutor", Specialty = "react", UserId=3 },
        };

        #region Get
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(Teachers);
        }
        [HttpGet("{id}")]
        //http://localhost:5289/api/teacher/1
        public JsonResult Get(int id)
        {
            var teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            return new JsonResult(teacher == null ? "Teacher not found" : teacher);
        }
        #endregion

        #region
        #endregion
    }
}
