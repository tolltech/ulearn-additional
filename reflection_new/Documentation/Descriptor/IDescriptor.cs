using System.Diagnostics.CodeAnalysis;

namespace Documentation.Descriptior
{
    public interface IDescriptor<T>
    {
        string GetApiDescription();

        string[] GetApiMethodNames();

        string GetApiMethodDescription([NotNull] string methodName);

        string[] GetApiMethodParamNames([NotNull] string methodName);

        string GetApiMethodParamDescription([NotNull] string methodName, [NotNull] string paramName);

        ApiParamDescription GetApiMethodParamFullDescription([NotNull] string methodName, [NotNull] string paramName);

        ApiMethodDescription GetFullApiMethodDescription([NotNull] string methodName);

        ApiClassDescription GetFullApiClassDescription();
    }

    public class CommonDescription
    {
        public CommonDescription()
        {
            
        }

        public CommonDescription(string name, string description = null)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ApiMethodDescription
    {
        public CommonDescription MethodDescription { get; set; }
        public ApiParamDescription[] ParamDescriptions { get; set; }
        public ApiParamDescription ReturnDescription { get; set; }
    }

    public class ApiParamDescription
    {
        public CommonDescription ParamDescription { get; set; }

        public bool Required { get; set; }
        public object MinValue { get; set; }
        public object MaxValue { get; set; }
    }

    public class ApiClassDescription
    {
        public ApiMethodDescription[] MethodDescriptions { get; set; }
    }
}