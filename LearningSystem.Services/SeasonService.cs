namespace LearningSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Services.Abstractions;

    public class SeasonService : ISeasonService
    {
        private IRepository<Season> seasonsRepository;

        public SeasonService(IRepository<Season> seasonsRepository)
        {
            this.seasonsRepository = seasonsRepository;
        }

        public IEnumerable<SeasonShortDto> GetAll()
        {
            var seasons = this.seasonsRepository.GetAll();
            var seasonsDto = Mapper.Map<IEnumerable<SeasonShortDto>>(seasons);
            return seasonsDto;
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

        public void InsertSeason(Season season)
        {
            this.seasonsRepository.Insert(season);
        }

        public void EditSeason(Season season)
        {
            this.seasonsRepository.Update(season);
        }

        public void DeleteSeason(int id)
        {
            var season = this.seasonsRepository.Get(id);
            this.seasonsRepository.Delete(season);
        }
    }
}
