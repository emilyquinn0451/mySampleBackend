using mySampleBackend.Clients;
using mySampleBackend.Domain;
using mySampleBackend.Implementations;

namespace mySampleBackend.Interfaces
{
    public interface IFloopService
    {
    Task<FloopResponse> GetFloopDetails(int floopId);
    Task<int> AddFloop(Floop floop);
    Task<bool> DeleteFloop(int floopId);
    Task<FloopResponse> TestFloopClient(FloopRequest floopRequest);
}
}
