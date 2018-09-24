using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Core.Dtos;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Repositories;
using LearningSystem.Core.Services;

namespace LearningSystem.Services
{
    public class SemesterService : ISemesterService
    {
        private IRepository<Semester> semesterRepository;

        public SemesterService(IRepository<Semester> semesterRepository)
        {
            this.semesterRepository = semesterRepository;
        }

        public IEnumerable<SemesterDto> GetSemestersWithCourses()
        {
            var semesters = this.semesterRepository
                .Include(x => x.Courses)
                .GetAll();
            var semestersDto = semesters.Select(x => new SemesterDto() {
                Id = x.Id,
                Name = x.Name,
                Courses = x.Courses.Select(c => new CourseDto() {
                    Id = c.Id,
                    Name = c.Name,
                    Credits = c.Credits
                })
            });
            return semestersDto;
        }

        public void InsertSemester(Semester semester)
        {
            this.semesterRepository.Insert(semester);
        }

        public void DeleteSemester(int id)
        {
            var semester = this.semesterRepository.Get(id);
            this.semesterRepository.Delete(semester);
        }

        public void EditSemester(Semester semester)
        {
            this.semesterRepository.Update(semester);
        }

        public IEnumerable<SemesterShortDto> GetAll()
        {
            var semesters = this.semesterRepository.GetAll();
            var semestersDto = Mapper.Map<IEnumerable<SemesterShortDto>>(semesters);
            return semestersDto;
        }

        public SemesterShortDto GetById(int id)
        {
            var semester = this.semesterRepository.Get(id);
            var semesterDto = Mapper.Map<SemesterShortDto>(semester);
            return semesterDto;
        }
    }
}
