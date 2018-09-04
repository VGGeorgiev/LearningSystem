using AutoMapper;
using LearningSystem.Core.Dtos;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Repositories;
using LearningSystem.Core.Services;

namespace LearningSystem.Services
{
    public class HomeworkEvaluationService : IHomeworkEvaluationService
    {
        private IRepository<HomeworkEvaluation> homeworkEvaluationRepository;

        public HomeworkEvaluationService(IRepository<HomeworkEvaluation> homeworkEvaluationRepository)
        {
            this.homeworkEvaluationRepository = homeworkEvaluationRepository;
        }
        public void EvaluateHomework(HomeworkEvaluationDto homeworkEvaluationDto)
        {
            var homeworkEvaluation = Mapper.Map<HomeworkEvaluation>(homeworkEvaluationDto);
            this.homeworkEvaluationRepository.Insert(homeworkEvaluation);
        }
    }
}
