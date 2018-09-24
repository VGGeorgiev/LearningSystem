namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Core.Services;
    using System;
    using System.Collections.Generic;

    public class LectureService : ILectureService
    {
        private IRepository<Lecture> lectureRepository;

        public LectureService(IRepository<Lecture> lectureRepository)
        {
            this.lectureRepository = lectureRepository;
        }

        public void Delete(int id)
        {
            var lecture = this.lectureRepository.Get(id);
            this.lectureRepository.Delete(lecture);
        }

        public void Edit(Lecture lecture)
        {
            this.lectureRepository.Update(lecture);
        }

        public IEnumerable<LectureShortDto> GetAll()
        {
            var lectures = this.lectureRepository
                .Include(x => x.Course)
                .GetAll();
            var lecturesDto = Mapper.Map<IEnumerable<LectureShortDto>>(lectures);
            return lecturesDto;
        }

        public LectureShortDto GetLecture(int id)
        {
            var lecture = this.lectureRepository
                .Include(x => x.Course)
                .Get(id);
            var lectureDto = Mapper.Map<LectureShortDto>(lecture);
            return lectureDto;
        }

        public void Insert(Lecture lecture)
        {
            this.lectureRepository.Insert(lecture);
        }
    }
}
