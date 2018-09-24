namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Services;
    using LearningSystem.Web.Helpers;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private IApplicationService applicationService;
        private IUserService userService;

        public ApplicationController(IApplicationService applicationService, IUserService userService)
        {
            this.applicationService = applicationService;
            this.userService = userService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Post([FromForm]ApplicationRequest application)
        {
            var applicationDto = Mapper.Map<ApplicationDto>(application);
            this.applicationService.InsertApplication(applicationDto);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet]
        public IActionResult Get()
        {
            var applications = this.applicationService.GetAll();
            return Ok(applications);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPost("approve/{id}")]
        public IActionResult Approve(int id)
        {
            var application = this.applicationService.ApproveApplication(id);
            this.userService.MakeStudent(application.UserId);
            return this.Ok();
        }
    }
}
