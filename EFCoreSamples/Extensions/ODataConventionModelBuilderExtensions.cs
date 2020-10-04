using EFCoreSamples.Domain.Entity;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using System;
using System.Linq;

namespace EFCoreSamples.Extensions
{
    public static class ODataConventionModelBuilderExtensions
    {
        public static void MapODataEntity<TEntity, TId>(this ODataConventionModelBuilder builder)
            where TEntity : Identity<TEntity, TId>
        {
            builder.EntitySet<TEntity>(typeof(TEntity).Name).EntityType.HasKey(e => e.Id).Select().Filter().OrderBy().Expand();

            var structuralTypes = builder.StructuralTypes.First(e => e.ClrType == typeof(TEntity));
            var props = typeof(TEntity).GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType.IsEnum())
                {
                    structuralTypes.AddEnumProperty(prop);
                    builder.AddEnumType(prop.PropertyType);
                }
                else if (!prop.PropertyType.IsNonStringClass() && !prop.PropertyType.IsGenericAndIsEnumerable())
                    structuralTypes.AddProperty(prop);
                else if (prop.PropertyType.IsGenericAndIsEnumerable())
                    structuralTypes.AddNavigationProperty(prop, EdmMultiplicity.Many);
                else if (prop.PropertyType.IsNonStringClass())
                    structuralTypes.AddNavigationProperty(prop, EdmMultiplicity.ZeroOrOne);
                else
                    throw new ArgumentException("Prop info not mapped into OData");
            }
        }

        public static void MapODataDto<Translator>(this ODataConventionModelBuilder builder)
            where Translator : class
        {
            builder.EntitySet<Translator>(typeof(Translator).Name);
        }
    }
}
