namespace LearningSystem.Web.Helpers
{
    using LearningSystem.Core.Entities;
    using Microsoft.AspNetCore.Authorization;

    public class UserTypeRequirement : IAuthorizationRequirement
    {
        public UserTypeRequirement(UserType userType)
        {
            this.UserType = userType;
        }

        public UserType UserType { get; private set; }
    }
}
