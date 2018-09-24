namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Entities;
    using LearningSystem.Services.Abstractions;
    using LearningSystem.Web.Helpers;
    using LearningSystem.Web.Models;
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

        [HttpGet("available")]
        public IActionResult GetAvailableSeasons()
        {
            var seasons = this.seasonService.GetAvailableSeasons();
            return Ok(seasons);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var season = this.seasonService.GetById(id);
            return Ok(season);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("get")]
        public IActionResult Get()
        {
            var seasons = this.seasonService.GetAll();
            return Ok(seasons);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPost("insert")]
        public IActionResult InsertSeason(SeasonRequest season)
        {
            var seasonModel = Mapper.Map<Season>(season);
            this.seasonService.InsertSeason(seasonModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPut("edit/{id}")]
        public IActionResult EditSeason(SeasonRequest season)
        {
            var seasonModel = Mapper.Map<Season>(season);
            this.seasonService.EditSeason(seasonModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSeason(int id)
        {
            this.seasonService.DeleteSeason(id);
            return Ok();
        }
    }
}
