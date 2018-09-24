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
    public class LecturesController : ControllerBase
    {
        private ILectureService lectureService;

        public LecturesController(ILectureService lectureService)
        {
            this.lectureService = lectureService;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var lecture = this.lectureService.GetLecture(id);
            return Ok(lecture);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var lectures = this.lectureService.GetAll();
            return Ok(lectures);
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPost("insert")]
        public IActionResult InsertSeason(LectureRequest lecture)
        {
            var lectureModel = Mapper.Map<Lecture>(lecture);
            this.lectureService.Insert(lectureModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPut("edit/{id}")]
        public IActionResult EditSeason(LectureRequest lecture)
        {
            var lectureModel = Mapper.Map<Lecture>(lecture);
            this.lectureService.Edit(lectureModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSeason(int id)
        {
            this.lectureService.Delete(id);
            return Ok();
        }
    }
}
