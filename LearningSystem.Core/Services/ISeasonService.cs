namespace LearningSystem.Core.Services
{
    using LearningSystem.Core.Dtos;
    using System.Collections.Generic;

    public interface ISeasonService
    {
        IEnumerable<SeasonDto> GetAvailableSeasons();

        SeasonDto GetById(int id);
    }
}
