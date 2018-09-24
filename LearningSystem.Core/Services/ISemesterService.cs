using LearningSystem.Core.Dtos;
using LearningSystem.Core.Entities;
using System.Collections.Generic;

namespace LearningSystem.Core.Services
{
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
