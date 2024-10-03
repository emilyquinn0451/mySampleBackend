using mySampleBackend.Data;
using mySampleBackend.Domain;
using mySampleBackend.Infrastructure;

namespace mySampleBackend.Interfaces
{
    public interface IFloopRepository
    {
        public FloopDbEntity GetFloopByFloopId(int floopId);
        public FloopDbEntity AddFloop(FloopDbEntity floopDb);
        public Boolean DeleteFloop(int floopId);

        

    }
}
