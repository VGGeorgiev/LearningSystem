namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Services;
    using LearningSystem.Web.Models;
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
        
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var semesters = this.semesterService.GetById(id);
            return Ok(semesters);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var semesters = this.semesterService.GetAll();
            return Ok(semesters);
        }
        
        //[Authorize(Policy = "Trainer")]
        [HttpPost("insert")]
        public IActionResult InsertSeason(SemesterRequest semester)
        {
            var semesterModel = Mapper.Map<Semester>(semester);
            this.semesterService.InsertSemester(semesterModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPut("edit/{id}")]
        public IActionResult EditSeason(SemesterRequest semester)
        {
            var semesterModel = Mapper.Map<Semester>(semester);
            this.semesterService.EditSemester(semesterModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSeason(int id)
        {
            this.semesterService.DeleteSemester(id);
            return Ok();
        }
    }
}
