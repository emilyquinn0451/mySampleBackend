using mySampleBackend.Domain;
using mySampleBackend.Interfaces;
using mySampleBackend.Mocks;
using Newtonsoft.Json;
using System.Net;
using System.Web.Helpers;

namespace mySampleBackend.Clients
{
    public class FloopClient(HttpClient httpClient, ILogger<FloopClient> logger) : IFloopClient
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly ILogger<FloopClient> _logger = logger;

        /// <summary>
        /// Returns hypothetical Floop object to compare against our Floop request
        /// </summary>
        /// <param name="floopRequest"></param>
        /// <returns>fake FloopResponse from Server</returns>
        public Task<FloopResponse> CompareFloopInfo(FloopRequest floopRequest)
        {
            try
            {
                _logger.LogInformation("FloopClient: Compare Floop Info - Connecting to external floop service to validate data for floop with value of {@floop}", floopRequest.TestFlag);
                //If this was a real API this would be a call to another service. For our purposes we return a mock, with two mocks for demonstration of error catching.

                //var request = new HttpRequestMessage(HttpMethod.Get, "exampleApiUrl");
                //string serializedFloop = JsonConvert.SerializeObject(floopRequest);
                //request.Content = new StringContent(JsonConvert.SerializeObject(floopRequest), Encoding.UTF8, text/json);
                //var result = await _httpClient.SendAsync(floopRequest);
                HttpResponseMessage result;
                string floopJson = JsonConvert.SerializeObject(FloopMocks.floopResponseMock);
                if (floopRequest.TestFlag)
                {
                    result = new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(floopJson) };
                }
                else
                {
                    result = new HttpResponseMessage(HttpStatusCode.BadGateway) { Content = null};
                }
                _logger.LogInformation("FloopClient: Compare Floop Info - Response code for floopRequest {@code}", result.StatusCode);
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception($"FloopClient: Compare Floop Info - Response Error {result.StatusCode}");

                }
                //Casting to task since we aren't returning from a real async call
                //Reusing the floop object for a JSON response to demonstrate HTML interactions since this isn't returning any real data and the operations of this API are simplistic
                var mockFloopResponse = JsonConvert.DeserializeObject<FloopResponse>(floopJson);
                return Task.FromResult(mockFloopResponse);

            }
            catch (Exception ex)
            {
                {
                    _logger.LogError("FloopClient: Compare Floop Info - Exception when comparing Floop info {@ex}", ex);
                    return Task.FromResult(new FloopResponse() {ErrorReason = "Exception when comparing Floop info - " + ex});
                    }
            }
        }
    }
}
