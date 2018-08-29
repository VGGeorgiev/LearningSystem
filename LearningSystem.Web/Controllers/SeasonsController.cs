namespace LearningSystem.Web.Controllers
{
    using LearningSystem.Core.Services;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonsController : ControllerBase
    {
        private ISeasonService seasonService;

        public SeasonsController(ISeasonService seasonService)
        {
            this.seasonService = seasonService;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var season = this.seasonService.GetById(id);
            return Ok(season);
        }

        [HttpGet("available")]
        public IActionResult GetAvailableSeasons()
        {
            var seasons = this.seasonService.GetAvailableSeasons();
            return Ok(seasons);
        }
    }
}
