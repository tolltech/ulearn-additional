using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stringify
{
    public static class CustomConvert
    {
        public static string Serialize<T>(T serializedObject)
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
            var formattedStaticFields = FormatStaticMemberOutput(GetStaticFieldsInfo(type, BindingFlags.Static | BindingFlags.Public));

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

        private static string FormatStaticMemberOutput(IEnumerable<(string MemberType, string MemberName, string MemberValue)> memberInfos)
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
            return $"Constructors count: {type.GetConstructors().Length}\r\n" +
                   $"Has parameterless constructor: {type.GetConstructor(Type.EmptyTypes) != null}\r\n\r\n";
        }

        private static (string MemberType, string MemberName)[] GetPropertiesInfo(Type type)
        {
            return type.GetProperties()
                .Select(p => (MemberType: p.PropertyType.ToString(), MemberName: p.Name))
                .ToArray();
        }

        private static (string MemberType, string MemberName)[] GetFieldsInfo(Type type, BindingFlags scope)
        {
            return type.GetFields(BindingFlags.Instance | scope)
                .Select(f => (MemberType: f.FieldType.ToString(), MemberName: f.Name))
                .ToArray();
        }

        private static (string MemberType, string MemberName, string MemberValue)[] GetStaticFieldsInfo(Type type, BindingFlags scope)
        {
            return type.GetFields(scope)
                .Select(f => (MemberType: f.FieldType.ToString(), MemberName: f.Name, MemberValue: f.GetValue(null).ToString()))
                .ToArray();
        }

        private static (string MemberType, string MemberName)[] GetMethodsInfo(Type type, BindingFlags scope)
        {
            return type.GetMethods(BindingFlags.Instance | scope)
                .Select(m => (MemberType: m.ReturnType.Name, MemberName: m.Name))
                .ToArray();
        }
    }
}