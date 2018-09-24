namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface IApplicationService
    {
        void InsertApplication(ApplicationDto application);

        IEnumerable<ApplicationDto> GetAll();

        Application ApproveApplication(int id);
    }
}
