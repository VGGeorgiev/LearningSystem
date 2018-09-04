using LearningSystem.Core.Dtos;

namespace LearningSystem.Core.Services
{
    public interface IFeedbackService
    {
        FeedbackDto InsertFeedback(FeedbackDto feedback);
    }
}
