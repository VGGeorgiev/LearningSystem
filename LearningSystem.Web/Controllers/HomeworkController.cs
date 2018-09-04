namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Services;
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

        public HomeworkController(IHomeworkSubmissionService homeworkSubmissionService, IHomeworkEvaluationService homeworkEvaluationService)
        {
            this.homeworkSubmissionService = homeworkSubmissionService;
            this.homeworkEvaluationService = homeworkEvaluationService;
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
    }
}
