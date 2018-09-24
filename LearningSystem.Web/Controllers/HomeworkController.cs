namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Services;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;

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
        [HttpGet("getRandomHomeworkId/{id}")]
        public IActionResult GetRandomHomeworkId(int id)
        {
            var userId = int.Parse(this.User.Identity.Name);
            var homeworkId = this.homeworkSubmissionService.GetRandomHomeworkId(id, userId);
            return this.Ok(homeworkId);
        }

        [HttpGet("download/{id}")]
        public IActionResult DownloadHomework(int id)
        {
            byte[] homework = this.homeworkSubmissionService.DownloadHomework(id);
            var contentType = "application/octet-stream";
            var fileName = $"homework_{id}.txt";
            return File(homework, contentType, fileName);
        }

        [HttpPost("evaluate")]
        public IActionResult EvaluateHomework(HomeworkEvaluationDto homeworkEvaluation)
        {
            this.homeworkEvaluationService.EvaluateHomework(homeworkEvaluation);
            return this.Ok();
        }

        [HttpGet("getAllAssignments")]
        public IActionResult GetAllHomeworkAssignments()
        {
            var homeworkAssignments = this.homeworkAssignmentService.GetAll();
            return Ok(homeworkAssignments);
        }

        [HttpGet("getAssignmentById/{id}")]
        public IActionResult GetHomeworkAssignmentById(int id)
        {
            var homeworkAssignment = this.homeworkAssignmentService.GetById(id);
            return Ok(homeworkAssignment);
        }

        [HttpPut("editAssignment")]
        public IActionResult EditHomeworkAssignmentById(HomeworkAssignmentRequest homeworkAssignment)
        {
            var homeworkAssignmentModel = Mapper.Map<HomeworkAssignment>(homeworkAssignment);
            this.homeworkAssignmentService.Edit(homeworkAssignmentModel);
            return Ok();
        }

        [HttpDelete("deleteAssignment/{id}")]
        public IActionResult DeleteHomeworkAssignmentById(int id)
        {
            this.homeworkAssignmentService.Delete(id);
            return Ok();
        }

        [HttpPost("insertAssignment")]
        public IActionResult InsertHomeworkAssignment(HomeworkAssignmentRequest homeworkAssignment)
        {
            var homeworkAssignmentModel = Mapper.Map<HomeworkAssignment>(homeworkAssignment);
            this.homeworkAssignmentService.Insert(homeworkAssignmentModel);
            return Ok();
        }
    }
}
