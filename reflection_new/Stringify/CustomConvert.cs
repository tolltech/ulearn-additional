using System.Reflection;
using System.Text;

namespace Stringify
{
    public class CustomConvert
    {
        // В языке программирования Python существует функция dir(), возвращающая список компонент указанного объекта.
        //Т.е., вызвав, например, dir(math), мы получим имена полей и методов класса math.
        //    Используя рефлексию, попробуйте сделать утилиту, работающую похожим образом - принимая на вход имя типа, программа должна
        //выводить строку, описывающую объект (список его конструкторов, полей, методов...)

        public virtual string Serialize<T>(T serializedObject)
        {
            var type = serializedObject.GetType();
            var stringBuilder = new StringBuilder();

            stringBuilder.Append($"{type.Name}:\r\n\r\n");
            stringBuilder.Append(GetConstructorsInfo(type));
            stringBuilder.Append(SerializeProperties(type));
            stringBuilder.Append(SerializeFields(type));
            stringBuilder.Append(SerializeMethods(type));

            return stringBuilder.ToString();
        }

        private static string SerializeProperties(Type type)
        {
            var formattedTypeProperties = FormatMemberOutput(GetPropertiesInfo(type));
            return $"Properties:\r\n{formattedTypeProperties}";
        }

        private static string SerializeFields(Type type)
        {
            var formattedPublicFields = FormatMemberOutput(GetFieldsInfo(type, BindingFlags.Public));
            var formattedPrivateFields = FormatMemberOutput(GetFieldsInfo(type, BindingFlags.NonPublic));
            var formattedStaticFields =
                FormatStaticMemberOutput(GetStaticFieldsInfo(type, BindingFlags.Static | BindingFlags.Public));

            return $"{BindingFlags.Public} fields:\r\n{formattedPublicFields}" +
                   $"{BindingFlags.NonPublic} fields:\r\n{formattedPrivateFields}" +
                   $"{BindingFlags.Static | BindingFlags.Public} fields:\r\n{formattedStaticFields}";
        }

        private static string SerializeMethods(Type type)
        {
            var formattedPublicMethods = FormatMemberOutput(GetMethodsInfo(type, BindingFlags.Public));
            var formattedPrivateMethods = FormatMemberOutput(GetMethodsInfo(type, BindingFlags.NonPublic));

            return $"{BindingFlags.Public} methods:\r\n{formattedPublicMethods}" +
                   $"{BindingFlags.NonPublic} methods:\r\n{formattedPrivateMethods}";
        }

        private static string FormatMemberOutput(IEnumerable<(string MemberType, string MemberName)> memberInfos)
        {
            var stringBuilder = new StringBuilder();
            foreach (var (memberType, memberName) in memberInfos)
            {
                stringBuilder.Append($"{memberType} {memberName}\r\n");
            }

            return stringBuilder.Append("\r\n").ToString();
        }

        private static string FormatStaticMemberOutput(
            IEnumerable<(string MemberType, string MemberName, string MemberValue)> memberInfos)
        {
            var stringBuilder = new StringBuilder();
            foreach (var (memberType, memberName, memberValue) in memberInfos)
            {
                stringBuilder.Append($"{memberType} {memberName}: {memberValue}\r\n");
            }

            return stringBuilder.Append("\r\n").ToString();
        }

        private static string GetConstructorsInfo(Type type)
        {
            throw new NotImplementedException();        }

        private static (string MemberType, string MemberName)[] GetPropertiesInfo(Type type)
        {
            throw new NotImplementedException();
        }

        private static (string MemberType, string MemberName)[] GetFieldsInfo(Type type, BindingFlags scope)
        {
            throw new NotImplementedException();
        }

        private static (string MemberType, string MemberName, string MemberValue)[] GetStaticFieldsInfo(Type type, BindingFlags scope)
        {
            throw new NotImplementedException();
        }

        private static (string MemberType, string MemberName)[] GetMethodsInfo(Type type, BindingFlags scope)
        {
            throw new NotImplementedException();
        }
    }
}