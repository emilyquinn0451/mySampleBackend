using AutoMapper;
using mySampleBackend.Domain;
using mySampleBackend.Infrastructure;
using mySampleBackend.Interfaces;
using mySampleBackend.Repositories;

namespace mySampleBackend.Implementations
{
    public class DbAccessService : IDbAccessService
    {
        private readonly FloopRepository _floopRepository;
        private readonly IMapper _mapper;

        public DbAccessService(FloopRepository floopRepository, IMapper mapper)
        {
            _floopRepository = floopRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Accessing DB to retrieve Floop details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FloopResponse GetFloop(int id)
        {
            try
            {
                var floopDbEntity = _floopRepository.GetFloopByFloopId(id);
                FloopResponse floopResponse = new FloopResponse()
                {
                    Floop = _mapper.Map<Floop>(floopDbEntity)
                };

                return floopResponse;

            }
            catch
            {
                return new FloopResponse()
                {
                    ErrorReason = "No Floop by Id " + id + " found"
                };
            }

        }
        /// <summary>
        /// Adding Floop to DB
        /// </summary>
        /// <param name="floop"></param>
        public int AddFloop(Floop floop)
        {
            FloopDbEntity floopDb = _mapper.Map<FloopDbEntity>(floop);
            var x = _floopRepository.AddFloop(floopDb);
            return x.floop_id;

        }
        /// <summary>
        /// Removing Floop from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteFloop(int id)
        {
            try
            {
                _floopRepository.DeleteFloop(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
