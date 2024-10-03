using mySampleBackend.Domain;
using mySampleBackend.Infrastructure;

namespace mySampleBackend.Interfaces
{
    public interface IDbAccessService
    {
        FloopResponse GetFloop(int id);
        int AddFloop(Floop floop);
        bool DeleteFloop(int id);
    }
}
