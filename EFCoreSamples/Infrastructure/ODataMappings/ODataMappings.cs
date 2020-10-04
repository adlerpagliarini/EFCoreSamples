using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Query;
using Microsoft.OData.Edm;
using EFCoreSamples.Domain;
using System;

namespace EFCoreSamples.Infrastructure.ODataMappings
{
    public class ODataMappings
    {
        public static IEdmModel GetEdmModel(IServiceProvider provider)
        {
            var builder = new ODataConventionModelBuilder(provider);

            builder.EntitySet<Developer>(nameof(Developer)).EntityType
                   .Select()
                   .Filter()
                   .OrderBy()
                   .Count()
                   .Page()
                   .Expand(SelectExpandType.Automatic)
                   .HasMany(t => t.TasksToDo).Select().Filter();

            return builder.GetEdmModel();
        }
    }
}
