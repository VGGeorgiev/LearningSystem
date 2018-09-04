using LearningSystem.Core.Dtos;

namespace LearningSystem.Core.Services
{
    public interface IHomeworkEvaluationService
    {
        void EvaluateHomework(HomeworkEvaluationDto homeworkEvaluation);
    }
}
