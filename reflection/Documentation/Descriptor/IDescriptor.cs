using JetBrains.Annotations;

namespace Documentation.Descriptior
{
    public interface IDescriptor<T>
    {
        [CanBeNull]
        string GetApiDescription();

        [ItemNotNull]
        [NotNull]
        string[] GetApiMethodNames();

        [CanBeNull]
        string GetApiMethodDescription([NotNull] string methodName);

        [ItemNotNull]
        [NotNull]
        string[] GetApiMethodParamNames([NotNull] string methodName);

        [CanBeNull]
        string GetApiMethodParamDescription([NotNull] string methodName, [NotNull] string paramName);

        [NotNull]
        ApiParamDescription GetApiMethodParamFullDescription([NotNull] string methodName, [NotNull] string paramName);

        [CanBeNull]
        ApiMethodDescription GetFullApiMethodDescription([NotNull] string methodName);

        [NotNull]
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