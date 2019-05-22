using Documentation.Api;
using Documentation.Descriptior;

namespace Documentation
{
    //В файле Descriptor реализуйте класс, умеющий возвращать структурированное описание АПИ по размеченным атрибутами методам класса.
    //Такое описание можно использовать для генерации и вывода документации в читаемом виде.
    //Обычно для этих целей используется [xml-разметка]
    //(https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/xmldoc/xml-documentation-comments)
    //и синтаксический анализ кода, но этот вариант подохдит,
    //только если АПИ распространяется в виде подключаемой библиотеки, например, с помощью nuget-пакета.
    //Если же доступ к АПИ осуществляется, например, по сети, то такой вариант не подойдет,
    //т.к. доступа к кодовой базе у пользователя нет.
    //В этом случае удобнее сделать автогенерируемое описание с помощью релфексии,
    //которое будет обновляться автоматически при обновлении сервера АПИ.

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