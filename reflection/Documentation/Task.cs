using Documentation.Api;
using Documentation.Descriptior;

namespace Documentation
{
    public class Descriptor : IDescriptor<VkApi>
    {
        public string GetApiDescription()
        {
            throw new System.NotImplementedException();
        }

        public string[] GetApiMethodNames()
        {
            throw new System.NotImplementedException();
        }

        public string GetApiMethodDescription(string methodName)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            throw new System.NotImplementedException();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            throw new System.NotImplementedException();
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            throw new System.NotImplementedException();
        }

        public ApiMethodDescription GetFullApiMethodDescription(string methodName)
        {
            throw new System.NotImplementedException();
        }

        public ApiClassDescription GetFullApiClassDescription()
        {
            throw new System.NotImplementedException();
        }
    }
}