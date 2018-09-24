namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;

    public interface IHomeworkEvaluationService
    {
        void EvaluateHomework(HomeworkEvaluationDto homeworkEvaluation);
    }
}
