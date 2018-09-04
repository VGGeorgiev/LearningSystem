using AutoMapper;
using LearningSystem.Core.Dtos;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Repositories;
using LearningSystem.Core.Services;

namespace LearningSystem.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IRepository<Feedback> feedbackRepository;

        public FeedbackService(IRepository<Feedback> feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public FeedbackDto InsertFeedback(FeedbackDto feedbackDto)
        {
            var feedback = Mapper.Map<Feedback>(feedbackDto);
            this.feedbackRepository.Insert(feedback);
            return Mapper.Map<FeedbackDto>(feedback);
        }
    }
}
