namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Services.Abstractions;
    using System.Collections.Generic;

    public class HomeworkAssignmentService : IHomeworkAssignmentService
    {
        private IRepository<HomeworkAssignment> homeworkAssignmentRepository;

        public HomeworkAssignmentService(IRepository<HomeworkAssignment> homeworkAssignmentRepository)
        {
            this.homeworkAssignmentRepository = homeworkAssignmentRepository;
        }

        public void Delete(int id)
        {
            var homeworkAssignment = this.homeworkAssignmentRepository.Get(id);
            this.homeworkAssignmentRepository.Delete(homeworkAssignment);
        }

        public void Edit(HomeworkAssignment homeworkAssignment)
        {
            this.homeworkAssignmentRepository.Update(homeworkAssignment);
        }

        public IEnumerable<HomeworkAssignmentDto> GetAll()
        {
            var homeworkAssignments = this.homeworkAssignmentRepository
                .Include(x => x.Lecture)
                .GetAll();
            var homeworkAssignmentsDto = Mapper.Map<IEnumerable<HomeworkAssignmentDto>>(homeworkAssignments);
            return homeworkAssignmentsDto;
        }

        public HomeworkAssignmentDto GetById(int id)
        {
            var homeworkAssignment = this.homeworkAssignmentRepository
                .Include(x => x.Lecture)
                .Get(id);
            var homeworkAssignmentDto = Mapper.Map<HomeworkAssignmentDto>(homeworkAssignment);
            return homeworkAssignmentDto;
        }

        public void Insert(HomeworkAssignment homeworkAssignment)
        {
            this.homeworkAssignmentRepository.Insert(homeworkAssignment);
        }
    }
}
