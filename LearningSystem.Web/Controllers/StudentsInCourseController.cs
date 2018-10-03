namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Services.Abstractions;
    using LearningSystem.Web.Helpers;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsInCourseController : ControllerBase
    {
        private IStudentsInCourseService studentsInCourseService;

        public StudentsInCourseController(IStudentsInCourseService studentsInCourseService)
        {
            this.studentsInCourseService = studentsInCourseService;
        }
        
        [HttpPost("enroll")]
        [AuthorizeUserType(UserType.Trainer)]
        public IActionResult EnrollStudentsInCourse(EnrollStudentsInCourseRequest model)
        {
            this.studentsInCourseService.EnrollStudentsInCourse(model.CourseId, model.SeasonId);
            return this.Ok();
        }
        
        [HttpGet("get/{id}")]
        public IActionResult GetUserInCourses(int id)
        {
            var userInCourses = this.studentsInCourseService.GetUserInCourses(id);
            return Ok(userInCourses);
        }
        
        [HttpPost("changeGrade")]
        [AuthorizeUserType(UserType.Trainer)]
        public IActionResult ChangeGrade(ChangeGradeRequest model)
        {
            this.studentsInCourseService.ChangeGrade(model.Id, model.Grade);
            return this.Ok();
        }
    }
}
