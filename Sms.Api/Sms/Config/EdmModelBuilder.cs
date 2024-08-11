using Domain.Models;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Sms.Config
{
    public class EdmModelBuilder
    {
        public static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<User>(nameof(User)).EntityType.HasKey(x => x.UserId);
            builder.EntitySet<Standard>(nameof(Standard)).EntityType.HasKey(x => x.StandardId);
            return builder.GetEdmModel();
        }
    }
}
