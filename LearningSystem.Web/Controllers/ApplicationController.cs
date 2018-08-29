namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private IApplicationService applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPost("add")]
        public IActionResult Post([FromBody]ApplicationDto application)
        {
            this.applicationService.InsertApplication(application);
            return Ok();
        }
    }
}
