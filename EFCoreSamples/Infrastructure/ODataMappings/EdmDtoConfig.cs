using Microsoft.OData.Edm;
using EFCoreSamples.Dtos;
using EFCoreSamples.Extensions;
using System;

namespace EFCoreSamples.Infrastructure.ODataMappings
{
    public class EdmDtoConfig
    {
        private static object _thisLockEdmModel = new object();
        private static bool _initializedEdmModel = false;

        public static IEdmModel GetEdmModel(IServiceProvider provider)
        {
            var builder = EdmModelConfig.GetEdmModelConvention(provider);
            lock (_thisLockEdmModel)
            {
                if (!_initializedEdmModel)
                {
                    builder.MapODataDto<DeveloperDto>();
                }
                _initializedEdmModel = true;
            }
            return EdmModelConfig.GetEdmModel();
        }
    }
}
