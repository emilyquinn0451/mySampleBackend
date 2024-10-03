using mySampleBackend.Data;
using mySampleBackend.Infrastructure;
using mySampleBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using mySampleBackend.Constants;
using mySampleBackend.Domain;
namespace mySampleBackend.Repositories
{
    public class FloopRepository : IFloopRepository
    {
        public FloopRepository()
        {
            using (var context = new ApiContext())
            {
                var floops = new List<FloopDbEntity>
                {
                new FloopDbEntity
                {
                    floop_name ="Kevin",
                    floop_safety_code = FloopConstants.floopSafetyCode1,
                    floop_type_code = "Angry"
                },
                new FloopDbEntity
                {
                    floop_name ="John",
                    floop_safety_code =FloopConstants.floopSafetyCode2,
                    floop_type_code = "Sad"
                }
                };

                context.Floops.AddRange(floops);
                context.SaveChanges();
            }
        }
        public FloopDbEntity GetFloopByFloopId(int floopId)
        {
            using (var context = new ApiContext())
            {
                return context.Floops.Single(x=> (x.floop_id ==floopId));
            }
                
        }
        public FloopDbEntity AddFloop(FloopDbEntity floopDb)
        {
            using (var context = new ApiContext())
            {
                context.Floops.Add(floopDb);
                context.SaveChanges();
            }
            return floopDb;

        }
        public Boolean DeleteFloop(int floopId)
        {
            using (var context = new ApiContext())
            {
                var floopToRemove = GetFloopByFloopId(floopId);
                if (floopToRemove != null)
                {
                    context.Floops.Remove(floopToRemove);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

    }
}