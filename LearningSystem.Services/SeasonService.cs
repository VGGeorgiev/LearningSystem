using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Repositories;
using LearningSystem.Core.Services;
using LearningSystem.Core.Dtos;

namespace LearningSystem.Services
{
    public class SeasonService : ISeasonService
    {
        private IRepository<Season> seasonsRepository;

        public SeasonService(IRepository<Season> seasonsRepository)
        {
            this.seasonsRepository = seasonsRepository;
        }

        public IEnumerable<SeasonDto> GetAvailableSeasons()
        {
            var seasons = this.seasonsRepository
                .Include(x => x.Applications)
                .GetAll()
                .Where(x => x.StartDate > DateTime.Now);
            var availableSeasons = Mapper.Map<IEnumerable<SeasonDto>>(seasons);
            return availableSeasons;
        }

        public SeasonDto GetById(int id)
        {
            var season = this.seasonsRepository.Get(id);
            var seasonDto = Mapper.Map<SeasonDto>(season);
            return seasonDto;
        }
    }
}
