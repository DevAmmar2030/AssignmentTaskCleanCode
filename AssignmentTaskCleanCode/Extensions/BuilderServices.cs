using AssignmentTaskCleanCode.Service.Business;
using AssignmentTaskCleanCode.Service.Interfaces;

namespace AssignmentTaskCleanCode.Extensions
{
    public static class BuilderServices
    {
        public static void Service(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<IUserService, UserService>();
        }
    }
}
