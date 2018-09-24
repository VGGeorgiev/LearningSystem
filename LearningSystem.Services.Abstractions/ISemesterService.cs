namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface ISemesterService
    {
        IEnumerable<SemesterDto> GetSemestersWithCourses();

        SemesterShortDto GetById(int id);

        IEnumerable<SemesterShortDto> GetAll();

        void InsertSemester(Semester seasonModel);

        void EditSemester(Semester semesterModel);

        void DeleteSemester(int id);
    }
}
