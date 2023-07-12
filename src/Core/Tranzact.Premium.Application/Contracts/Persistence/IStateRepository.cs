using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Contracts.Persistence;

public interface IStateRepository : IGenericRepository<State>
{
    //Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    //Task<List<LeaveRequest>> GetLeaveRequestsWithDetails();
    //Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
}
