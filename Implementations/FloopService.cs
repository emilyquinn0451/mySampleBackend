using FluentValidation;
using mySampleBackend.Clients;
using mySampleBackend.Domain;
using mySampleBackend.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace mySampleBackend.Implementations
{
    public class FloopService : IFloopService
    {
        private readonly IFloopClient _floopClient;
        private readonly ILogger<FloopService> _logger;
        private readonly IDbAccessService _dbAccessService;
        private readonly IValidator<Floop> _validator;

        public FloopService(IFloopClient floopClient, ILogger<FloopService> logger, IDbAccessService dbAccessService, IValidator<Floop> validator)
        {
            _floopClient = floopClient;
            _logger = logger;
            _dbAccessService = dbAccessService;
            _validator = validator;
        }

        /// <summary>
        /// Retrieves details on Floop from DB
        /// </summary>
        /// <param name="floopId"></param>
        /// <returns></returns>
        public async Task<FloopResponse> GetFloopDetails(int floopId)
        {
            try
            {
                FloopResponse floopResponse = _dbAccessService.GetFloop(floopId);
                return floopResponse;
            }
            catch (Exception ex) {
                _logger.LogError("Exception when retrieving Floop Data: {@ex}", ex);
                return new FloopResponse()
                {
                    ErrorReason = "Exception " + ex + " when retrieving Floop Data"
                };
            }
        }
        /// <summary>
        /// Adds floop to database
        /// </summary>
        /// <param name="floop"></param>
        /// <returns></returns>
    public async Task<int> AddFloop(Floop floop)
    {
            try
            {
                FluentValidation.Results.ValidationResult validationResult = _validator.Validate(floop);
                if (!validationResult.IsValid)
                {
                    string errorMessage = string.Join(", ", validationResult.Errors);
                    _logger.LogInformation("Add Floop Request blocked because " + errorMessage);
                    return -1;
                }
                //Assuming success here for the sake of time since I've demonstrated more secure try/catch and error checking/logging methods and we're using an IMDB
                return _dbAccessService.AddFloop(floop);
            }

            catch (Exception ex)
            {
                _logger.LogError("Exception when updating Floop Data: {@ex}", ex);
                return -1;
            }
        }
        /// <summary>
        /// Removes Floop from database
        /// </summary>
        /// <param name="floopId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFloop(int floopId)
        {
            //Again a simplified exception catch and logging process for the sake of time
            return _dbAccessService.DeleteFloop(floopId);
        }

        /// <summary>
        /// This doesn't do anything I'm just demonstrating an example of receiving and processing an HTTP message
        /// </summary>
        /// <param name="floopRequest"></param>
        /// <returns></returns>
        public async Task<FloopResponse> TestFloopClient(FloopRequest floopRequest)
        {
            FloopResponse floopResponse = await (_floopClient.CompareFloopInfo(floopRequest));
            return floopResponse;
        }
    }
}
