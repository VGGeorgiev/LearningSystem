namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Services;
    using LearningSystem.Web.Helpers;
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

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var lecture = this.lectureService.GetLecture(id);
            return Ok(lecture);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var lectures = this.lectureService.GetAll();
            return Ok(lectures);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPost("insert")]
        public IActionResult Insert(LectureRequest lecture)
        {
            var lectureModel = Mapper.Map<Lecture>(lecture);
            this.lectureService.Insert(lectureModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPut("edit/{id}")]
        public IActionResult Edit(LectureRequest lecture)
        {
            var lectureModel = Mapper.Map<Lecture>(lecture);
            this.lectureService.Edit(lectureModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            this.lectureService.Delete(id);
            return Ok();
        }
    }
}
