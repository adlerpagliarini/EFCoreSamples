using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EFCoreSamples.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsNonStringClass(this Type type)
         => (type == null || type == typeof(string)) ? false : type.IsClass;

        public static bool IsEnum(this Type type) => type.IsEnum;
        public static bool IsGenericList(this Type type) => type.IsGenericType && typeof(List<>) == type.GetGenericTypeDefinition();
        public static bool IsGenericCollection(this Type type) => type.IsGenericType && typeof(Collection<>) == type.GetGenericTypeDefinition();
        public static bool IsGenericAndIsEnumerable(this Type type) => type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type);
    }
}
