using mySampleBackend.Domain;

namespace mySampleBackend.Interfaces
{
    public interface IFloopClient
    {
        Task<FloopResponse> CompareFloopInfo(FloopRequest floopRequest);
    }
}
