using Tranzact.Premium.Domain;

namespace Tranzact.Premium.Application.Contracts.Persistence;

public interface ICarrierRepository : IGenericRepository<Carrier>
{
    //Task<Carrier> GetLeaveAllocationWithDetails(int id);
    //Task<List<Carrier>> GetLeaveAllocationsWithDetails();
    //Task<List<Carrier>> GetLeaveAllocationsWithDetails(string userId);
    //Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
    //Task AddAllocations(List<Carrier> allocations);
    //Task<Carrier> GetUserAllocations(string userId, int leaveTypeId);
}
