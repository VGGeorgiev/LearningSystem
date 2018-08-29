using LearningSystem.Core.Dtos;
using System.Collections.Generic;

namespace LearningSystem.Core.Services
{
    public interface ISemesterService
    {
        IEnumerable<SemesterDto> GetSemestersWithCourses();
    }
}
