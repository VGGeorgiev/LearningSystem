namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface ILectureService
    {
        LectureShortDto GetLecture(int id);

        IEnumerable<LectureShortDto> GetAll();

        void Insert(Lecture lecture);

        void Edit(Lecture lecture);

        void Delete(int id);
    }
}
