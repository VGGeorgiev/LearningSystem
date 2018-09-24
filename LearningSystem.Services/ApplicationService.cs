namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Core.Services;
    using System.Collections.Generic;

    public class ApplicationService : IApplicationService
    {
        private IRepository<Application> applicationRepository;

        public ApplicationService(IRepository<Application> applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public Application ApproveApplication(int id)
        {
            var application = this.applicationRepository.Get(id);
            application.IsApproved = true;
            this.applicationRepository.Update(application);

            return application;
        }

        public IEnumerable<ApplicationDto> GetAll()
        {
            var applications = this.applicationRepository
                .Include(x => x.Season)
                .GetAll();
            var applicationsDto = Mapper.Map<IEnumerable<ApplicationDto>>(applications);
            return applicationsDto;
        }

        public void InsertApplication(ApplicationDto applicationDto)
        {
            var application = Mapper.Map<Application>(applicationDto);
            this.applicationRepository.Insert(application);
        }
    }
}
