using mySampleBackend.Constants;
using mySampleBackend.Domain;

namespace mySampleBackend.Mocks
{
    public class FloopMocks
    {
        public static readonly FloopRequest floopRequestMock = new()
        {

            TestFlag = true,

        };

        public static readonly FloopResponse floopResponseMock = new()
        {

            Floop = new Floop()
            {
                FloopValue = 4.44,
                FloopType = "Angry",
                FloopSafetyCode = FloopConstants.floopSafetyCode1,
                FloopName = "Jackie"
            }

        };
    }
}
