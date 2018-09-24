namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Services.Abstractions;
    using LearningSystem.Web.Helpers;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworkController : ControllerBase
    {
        private IHomeworkSubmissionService homeworkSubmissionService;
        private IHomeworkEvaluationService homeworkEvaluationService;
        private IHomeworkAssignmentService homeworkAssignmentService;

        public HomeworkController(
            IHomeworkSubmissionService homeworkSubmissionService, 
            IHomeworkEvaluationService homeworkEvaluationService,
            IHomeworkAssignmentService homeworkAssignmentService)
        {
            this.homeworkSubmissionService = homeworkSubmissionService;
            this.homeworkEvaluationService = homeworkEvaluationService;
            this.homeworkAssignmentService = homeworkAssignmentService;
        }

        /// <param name="id">Homework Assignment Id</param>
        [AuthorizeUserType(UserType.Student)]
        [HttpPost("upload/{id}")]
        public IActionResult UploadHomework(int id, IFormFile file)
        {
            var userId = int.Parse(this.User.Identity.Name);
            var fileByteArray = Mapper.Map<byte[]>(file);
            this.homeworkSubmissionService.UploadHomework(id, userId, fileByteArray);

            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Homework Assignment Id</param>
        /// <returns></returns>
        [AuthorizeUserType(UserType.Student)]
        [HttpGet("getRandomHomeworkId/{id}")]
        public IActionResult GetRandomHomeworkId(int id)
        {
            var userId = int.Parse(this.User.Identity.Name);
            var homeworkId = this.homeworkSubmissionService.GetRandomHomeworkId(id, userId);
            return this.Ok(homeworkId);
        }

        [AuthorizeUserType(UserType.Student)]
        [HttpGet("download/{id}")]
        public IActionResult DownloadHomework(int id)
        {
            byte[] homework = this.homeworkSubmissionService.DownloadHomework(id);
            var contentType = "application/octet-stream";
            var fileName = $"homework_{id}.txt";
            return File(homework, contentType, fileName);
        }

        [AuthorizeUserType(UserType.Student)]
        [HttpPost("evaluate")]
        public IActionResult EvaluateHomework(HomeworkEvaluationDto homeworkEvaluation)
        {
            this.homeworkEvaluationService.EvaluateHomework(homeworkEvaluation);
            return this.Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("getAllAssignments")]
        public IActionResult GetAllHomeworkAssignments()
        {
            var homeworkAssignments = this.homeworkAssignmentService.GetAll();
            return Ok(homeworkAssignments);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("getAssignmentById/{id}")]
        public IActionResult GetHomeworkAssignmentById(int id)
        {
            var homeworkAssignment = this.homeworkAssignmentService.GetById(id);
            return Ok(homeworkAssignment);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPut("editAssignment")]
        public IActionResult EditHomeworkAssignmentById(HomeworkAssignmentRequest homeworkAssignment)
        {
            var homeworkAssignmentModel = Mapper.Map<HomeworkAssignment>(homeworkAssignment);
            this.homeworkAssignmentService.Edit(homeworkAssignmentModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpDelete("deleteAssignment/{id}")]
        public IActionResult DeleteHomeworkAssignmentById(int id)
        {
            this.homeworkAssignmentService.Delete(id);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPost("insertAssignment")]
        public IActionResult InsertHomeworkAssignment(HomeworkAssignmentRequest homeworkAssignment)
        {
            var homeworkAssignmentModel = Mapper.Map<HomeworkAssignment>(homeworkAssignment);
            this.homeworkAssignmentService.Insert(homeworkAssignmentModel);
            return Ok();
        }
    }
}
