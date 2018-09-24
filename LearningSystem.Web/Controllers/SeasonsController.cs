namespace LearningSystem.Web.Controllers
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Services;
    using LearningSystem.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

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

        [HttpGet("get")]
        public IActionResult Get()
        {
            var seasons = this.seasonService.GetAll();
            return Ok(seasons);
        }

        [HttpGet("available")]
        public IActionResult GetAvailableSeasons()
        {
            var seasons = this.seasonService.GetAvailableSeasons();
            return Ok(seasons);
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPost("insert")]
        public IActionResult InsertSeason(SeasonRequest season)
        {
            var seasonModel = Mapper.Map<Season>(season);
            this.seasonService.InsertSeason(seasonModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpPut("edit/{id}")]
        public IActionResult EditSeason(SeasonRequest season)
        {
            var seasonModel = Mapper.Map<Season>(season);
            this.seasonService.EditSeason(seasonModel);
            return Ok();
        }

        //[Authorize(Policy = "Trainer")]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteSeason(int id)
        {
            this.seasonService.DeleteSeason(id);
            return Ok();
        }
    }
}
