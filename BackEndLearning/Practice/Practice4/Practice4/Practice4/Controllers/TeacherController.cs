using Microsoft.AspNetCore.Mvc;
using Practice4.Filters;
using Practice4.Models;
using Practice4.ViewModels;
using System.Text;

namespace Practice4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomActionFilter]
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
        //http://localhost:5252/api/teacher/1
        public CommonResult<Teacher> Get(int id)
        {
            var _teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (_teacher == null)
            {
                //throw new NotFoundException("Teacher not found");  //this is only for ExceptionFilter
                return new CommonResult<Teacher>() { Success = false, Message = "Failed", Error = "Teacher not found" };
            }

            return new CommonResult<Teacher>() { Success = true, Message = "Success", Data = _teacher };
        }

        //query string parameters
        [HttpGet]
        //http://localhost:5252/api/teacher/?specialty=react
        public CommonResult<List<Teacher>> Get([FromQuery] string specialty = null)
        {
            //checkt query string parameters
            if (!string.IsNullOrEmpty(specialty))
            {
                var _teacher = Teachers.FirstOrDefault(t => t.Specialty == specialty);
                if (_teacher == null)
                {
                    //throw new NotFoundException("Teacher not found");  //this is only for ExceptionFilter
                    return new CommonResult<List<Teacher>>() { Success = false, Message = "Failed", Error = "Teacher not found" };
                }

                return new CommonResult<List<Teacher>>() { Success = true, Message = "Success", Data = new List<Teacher> { _teacher } };
            }

            return new CommonResult<List<Teacher>>() { Success = true, Message = "Success", Data = Teachers };
        }
        #endregion

        #region Post
        [HttpPost("json")]
        //http://localhost:5252/api/teacher/json
        //{
        //    "TeacherId": "4",
        //    "Department": "FrontEnd", 
        //    "Description": "BackEnd tutor", 
        //    "Specialty": "java", 
        //    "UserId": "1"
        //}
        public CommonResult<Teacher> PostJson([FromBody] Teacher teacher)
        {
            return AddTeacher(teacher);
        }

        [HttpPost("form")]
        //http://localhost:5252/api/teacher/form
        public CommonResult<Teacher> PostForm([FromForm] Teacher teacher)
        {
            return AddTeacher(teacher);
        }
        #endregion

        #region Put
        [HttpPut("json")]
        public CommonResult<Teacher> PutJson([FromBody] Teacher teacher)
        {
            return UpdateTeacher(teacher);
        }

        [HttpPut("form")]
        public CommonResult<Teacher> PutForm([FromForm] Teacher teacher)
        {
            return UpdateTeacher(teacher);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        //http://localhost:5252/api/teacher/2
        public CommonResult<Teacher> Delete(int id)
        {
            var _teacher = Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (_teacher == null)
            {
                //throw new NotFoundException("Teacher not found");  //this is only for ExceptionFilter
                return new CommonResult<Teacher>() { Success = false, Message = "Failed", Error = "Teacher not found" };
            }
            Teachers.Remove(_teacher);
            return new CommonResult<Teacher>() { Success = true, Message = "Success", Data = _teacher };
        }
        #endregion

        #region Helper Method
        //make codes DRY
        private CommonResult<Teacher> AddTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var _teacher = Teachers.FirstOrDefault(t => t.TeacherId == teacher.TeacherId);
                if (_teacher == null)
                {
                    Teachers.Add(teacher);
                    return new CommonResult<Teacher>() { Success = true, Message = "Success", Data = teacher };
                }
                //throw new NotFoundException("TeacherId has been taken");  //this is only for ExceptionFilter
                return new CommonResult<Teacher>() { Success = false, Message = "Failed", Error = "TeacherId has been taken" };
            }
            StringBuilder errors = new StringBuilder();
            foreach (var key in ModelState.Keys)
            {
                errors.Append(key + ":");
                foreach (var error in ModelState[key].Errors)
                {
                    errors.Append(error.ErrorMessage + " ");
                }
                errors.AppendLine();
            }
            //throw new NotFoundException(errors.ToString());  //this is only for ExceptionFilter
            return new CommonResult<Teacher>() { Success = false, Message = errors.ToString() };
        }

        public CommonResult<Teacher> UpdateTeacher(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                var _teacherIndex = Teachers.FindIndex(u => u.TeacherId == teacher.TeacherId);
                if (_teacherIndex == -1)
                {
                    //throw new NotFoundException("Teacher not found");  //this is only for ExceptionFilter
                    return new CommonResult<Teacher> { Success = false, Message = "Failed", Error = "Teacher not found" };
                }
                Teachers[_teacherIndex] = teacher;
                return new CommonResult<Teacher> { Success = true, Message = "Success", Data = teacher };
            }
            StringBuilder errors = new StringBuilder();
            foreach (var key in ModelState.Keys)
            {
                errors.Append(key + ":");
                foreach (var error in ModelState[key].Errors)
                {
                    errors.Append(error.ErrorMessage + " ");
                }
                errors.AppendLine();
            }
            //throw new NotFoundException(errors.ToString());  //this is only for ExceptionFilter
            return new CommonResult<Teacher>() { Success = false, Message = "Failed", Error = errors.ToString() };
        }
        #endregion
    }
}
