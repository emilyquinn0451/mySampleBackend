using Microsoft.AspNetCore.Mvc;
using mySampleBackend.Domain;
using mySampleBackend.Interfaces;
using System.Security;

namespace mySampleBackend.Controllers
{
    [ApiController]
    public class FloopController : ControllerBase
    {
        private readonly IFloopService _floopService;
        private readonly ILogger<FloopController> _logger;

        public FloopController(IFloopService floopService, ILogger<FloopController> logger)
        {
            _floopService = floopService;
            _logger = logger;
        }
        /// <summary>
        /// Gets floop from in memory database. 
        /// </summary>
        /// <param name="floopId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getFloop/{floopId:int}")]
        public async Task<FloopResponse> GetFloopDetails(int floopId)
        {
            _logger.LogInformation("attempting to retrieve floop details {@floopId}", floopId);
            return await _floopService.GetFloopDetails(floopId);
        }
        /// <summary>
        /// Adds floop to in memory database. Returns -1 if error occurs and the Floop ID if it is successfully added
        /// </summary>
        /// <param name="floop"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("addFloop")]
        public async Task<int> AddFloop(Floop floop)
        {
            _logger.LogInformation("attempting to add new floop  {@floop}", floop);
            return await _floopService.AddFloop(floop);
        }
        /// <summary>
        /// Tests our Floop Rest Client
        /// </summary>
        /// <param name="floopRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("testClient")]
        public async Task<FloopResponse> TestFloopClient(FloopRequest floopRequest)
        {
            _logger.LogInformation("Testing Floop Client with request  {@floop}", floopRequest);
            return await _floopService.TestFloopClient(floopRequest);
        }
        /// <summary>
        /// Removes floop from IMDB. Returns true if success and false if failure/ no such floop found
        /// </summary>
        /// <param name="floopId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("removeFloop/{floopId:int}")]
        public async Task<bool> RemoveFloop(int floopId)
        {
            _logger.LogInformation("attempting to remove floop {@floop}", floopId);
            return await _floopService.DeleteFloop(floopId);
        }
    }
    }
    


