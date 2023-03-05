using AssignmentTaskCleanCode.Models;

namespace AssignmentTaskCleanCode.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> SaveToDatebase(User user);
        Task<List<User>> GetUserList();
    }
}
