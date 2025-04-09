using System.Reflection;
using Documentation.Api;
using Documentation.Descriptior;

namespace Solves.SolvedClasses
{
    public class RightDescriptor : IDescriptor<VkApi>
    {
        private readonly Type vkApiType;

        public RightDescriptor()
        {
            vkApiType = typeof(VkApi);
        }

        public string GetApiDescription()
        {
            return vkApiType.GetCustomAttribute<ApiDescriptionAttribute>()?.Description;
        }

        public string[] GetApiMethodNames()
        {
            return vkApiType.GetPublicApiMethods()
                .Select(x => x.Name)
                .ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            return vkApiType.FindAttribute<ApiDescriptionAttribute>(methodName)?.Description;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            return vkApiType.GetPublicApiMethods()
                       .FirstOrDefault(x => x.Name == methodName)
                       ?.GetParameters()
                       .Select(x => x.Name)
                       .ToArray() ?? Array.Empty<string>();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            return vkApiType.FindAttribute<ApiDescriptionAttribute>(methodName, paramName, false)?.Description;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            return GetApiMethodParamFullDescription(methodName, paramName, false);
        }

        private ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName, bool isReturn)
        {
            var description = vkApiType.FindAttribute<ApiDescriptionAttribute>(methodName, paramName, isReturn)
                ?.Description;
            var required = vkApiType.FindAttribute<ApiRequiredAttribute>(methodName, paramName, isReturn)?.Required;
            var validation = vkApiType.FindAttribute<ApiIntValidationAttribute>(methodName, paramName, isReturn);

            return new ApiParamDescription
            {
                MaxValue = validation?.MaxValue,
                MinValue = validation?.MinValue,
                Required = required ?? false,
                ParamDescription = new CommonDescription
                {
                    Name = paramName,
                    Description = description
                }
            };
        }

        public ApiMethodDescription GetFullApiMethodDescription(string methodName)
        {
            var method = vkApiType.GetPublicApiMethods().FirstOrDefault(x => x.Name == methodName);
            if (method == null)
            {
                return null;
            }

            var description = vkApiType.FindAttribute<ApiDescriptionAttribute>(methodName);

            return new ApiMethodDescription
            {
                MethodDescription = new CommonDescription(methodName, description?.Description),
                ParamDescriptions = method.GetParameters()
                    .Select(x => GetApiMethodParamFullDescription(methodName, x.Name))
                    .ToArray(),
                ReturnDescription = method.ReturnParameter?.ParameterType == typeof(void)
                    ? null
                    : GetApiMethodParamFullDescription(methodName, null, true)
            };
        }

        //todo: доделать или удалить
        public ApiClassDescription GetFullApiClassDescription()
        {
            throw new System.NotImplementedException();
        }
    }
}