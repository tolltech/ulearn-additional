using System.Reflection;
using Documentation.Api;

namespace Solves
{
    public static class Extensions
    {
        public static T FindAttribute<T>(this Type type, string methodName) where T : Attribute
        {
            return type
                .GetPublicApiMethods()
                .FirstOrDefault(x => x.Name == methodName)?
                .GetCustomAttribute<T>(true);
        }

        public static T FindAttribute<T>(this Type type, string methodName, string paramName, bool isReturn)
            where T : Attribute
        {
            var method = type
                .GetPublicApiMethods()
                .FirstOrDefault(x => x.Name == methodName);

            var param = isReturn
                ? method?.ReturnParameter
                : method?.GetParameters().FirstOrDefault(x => x.Name == paramName);

            return param?.GetCustomAttribute<T>(true);
        }

        public static MethodInfo[] GetPublicApiMethods(this Type type)
        {
            return type
                .GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute<ApiMethodAttribute>() != null)
                .ToArray();
        }
    }
}