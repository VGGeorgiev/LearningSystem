namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Core.Services;

    public class ApplicationService : IApplicationService
    {
        private IRepository<Application> applicationRepository;

        public ApplicationService(IRepository<Application> applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public void InsertApplication(ApplicationDto applicationDto)
        {
            var application = Mapper.Map<Application>(applicationDto);
            this.applicationRepository.Insert(application);
        }
    }
}
