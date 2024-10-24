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
            new Teacher { TeacherId = 1, Department = "FrontEnd", Description = "FrontEnd teacher", Specialty = "javascript", UserId = 1},
            new Teacher { TeacherId = 2, Department = "BackEnd", Description = "BackEnd teacher", Specialty = "c#", UserId = 2 },
            new Teacher { TeacherId = 3, Department = "FrontEnd", Description = "FrontEnd tutor", Specialty = "react", UserId = 3 },
        };

        #region Get
        [HttpGet("{id}")]
        //http://localhost:5289/api/teacher/1
        public JsonResult Get(int id)
        {
            var teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            return new JsonResult(teacher == null ? "Teacher not found" : teacher);
        }

        //query string parameters
        [HttpGet]
        public JsonResult Get([FromQuery] string specialty = null)
        {
            //checkt query string parameters
            if (!string.IsNullOrEmpty(specialty))
            {
                var teacher = Teachers.FirstOrDefault(t => t.Specialty == specialty);
                return new JsonResult(teacher == null ? "Teacher not found" : teacher);
            }
            //return all
            return new JsonResult(Teachers);
        }
        #endregion

        #region Post
        [HttpPost("json")]
        //http://localhost:5289/api/teacher/json
        //{
        //    "TeacherId": "4",
        //    "Department": "FrontEnd", 
        //    "Description": "BackEnd tutor", 
        //    "Specialty": "java", 
        //    "UserId": "1"
        //}
        public JsonResult PostJson([FromBody] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var _teacher = Teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
                if (_teacher == null)
                {
                    Teachers.Add(teacher);
                    return new JsonResult(teacher);
                }
                return new JsonResult("TeacherId has been taken");
            }
            return new JsonResult("ModelState.IsValid false");
        }

        [HttpPost("form")]
        //http://localhost:5289/api/teacher/form
        public JsonResult PostForm([FromForm] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var _teacher = Teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
                if (_teacher == null)
                {
                    Teachers.Add(teacher);
                    return new JsonResult(teacher);
                }
                return new JsonResult("TeacherId has been taken");
            }
            return new JsonResult("ModelState.IsValid false");
        }
        #endregion

        #region Put
        [HttpPut("json")]
        public JsonResult PutJson([FromBody] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var _teacherIndex = Teachers.FindIndex(u => u.TeacherId == teacher.TeacherId);
                if (_teacherIndex == -1)
                {
                    return new JsonResult("User not found");
                }
                Teachers[_teacherIndex] = teacher;
                return new JsonResult(teacher);
            }
            return new JsonResult("ModelState.IsValid false");
        }

        [HttpPut("form")]
        public JsonResult PutForm([FromForm] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var _teacherIndex = Teachers.FindIndex(u => u.TeacherId == teacher.TeacherId);
                if (_teacherIndex == -1)
                {
                    return new JsonResult("User not found");
                }
                Teachers[_teacherIndex] = teacher;
                return new JsonResult(teacher);
            }
            return new JsonResult("ModelState.IsValid false");
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var _teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (_teacher == null)
            {
                return new JsonResult("Teacher not found");
            }
            Teachers.Remove(_teacher);
            return new JsonResult(_teacher);
        }
        #endregion
    }
}
