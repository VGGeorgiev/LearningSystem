namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface ISeasonService
    {
        IEnumerable<SeasonDto> GetAvailableSeasons();

        IEnumerable<SeasonShortDto> GetAll();

        SeasonDto GetById(int id);

        void InsertSeason(Season season);

        void EditSeason(Season season);

        void DeleteSeason(int id);
    }
}
