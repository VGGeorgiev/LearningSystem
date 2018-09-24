using LearningSystem.Core.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningSystem.Web.Helpers
{
    public class UserTypeAuthorizationHandler : AuthorizationHandler<UserTypeRequirement>
    {
        private IUserService userService;

        public UserTypeAuthorizationHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserTypeRequirement requirement)
        {
            var userId = int.Parse(context.User.Identity.Name);
            var user = this.userService.GetById(userId);
            if (user.Type == requirement.UserType)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
