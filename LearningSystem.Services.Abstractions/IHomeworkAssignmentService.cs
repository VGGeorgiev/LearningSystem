namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface IHomeworkAssignmentService
    {
        void Insert(HomeworkAssignment homeworkAssignmentModel);

        void Delete(int id);

        void Edit(HomeworkAssignment homeworkAssignmentModel);

        HomeworkAssignmentDto GetById(int id);

        IEnumerable<HomeworkAssignmentDto> GetAll();
    }
}
