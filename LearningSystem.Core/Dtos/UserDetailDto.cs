namespace LearningSystem.Core.Dtos
{
    using System.Collections.Generic;

    public class UserDetailDto : UserDto
    {
        public IEnumerable<FeedbackDto> Feedbacks { get; set; }
    }
}
