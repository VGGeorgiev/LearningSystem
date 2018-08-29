namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SemestersController : ControllerBase
    {
        private ISemesterService semesterService;

        public SemestersController(ISemesterService semesterService)
        {
            this.semesterService = semesterService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var semesters = this.semesterService.GetSemestersWithCourses();
            return Ok(semesters);
        }
    }
}
