using AutoMapper;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Services;
using LearningSystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var course = this.courseService.GetCourse(id);
            return Ok(course);
        }
        
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var courses = this.courseService.GetAll();
            return Ok(courses);
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPost("insert")]
        public IActionResult InsertSeason(CourseRequest course)
        {
            var courseModel = Mapper.Map<Course>(course);
            this.courseService.Insert(courseModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPut("edit/{id}")]
        public IActionResult EditSeason(CourseRequest course)
        {
            var courseModel = Mapper.Map<Course>(course);
            this.courseService.Edit(courseModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSeason(int id)
        {
            this.courseService.Delete(id);
            return Ok();
        }
    }
}
