using LearningSystem.Core.Dtos;
using LearningSystem.Core.Entities;
using System.Collections.Generic;

namespace LearningSystem.Core.Services
{
    public interface IApplicationService
    {
        void InsertApplication(ApplicationDto application);

        IEnumerable<ApplicationDto> GetAll();

        Application ApproveApplication(int id);
    }
}
