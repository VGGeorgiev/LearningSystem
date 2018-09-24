namespace LearningSystem.Web.Helpers
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Services.Abstractions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.Extensions.DependencyInjection;

    public class AuthorizeUserTypeAttribute : ActionFilterAttribute
    {
        private UserType userType;

        public AuthorizeUserTypeAttribute(UserType userType)
        {
            this.userType = userType;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userService = context.HttpContext.RequestServices.GetService<IUserService>();
            var userId = int.Parse(context.HttpContext.User.Identity.Name);
            var user = userService.GetById(userId);
            if (user.Type < userType)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
