﻿namespace LearningSystem.Core.Services
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface ICourseService
    {
        CourseDetailDto GetCourse(int id);

        IEnumerable<CourseWithSemesterDto> GetAll();

        void Insert(Course courseModel);

        void Edit(Course courseModel);

        void Delete(int id);
    }
}
