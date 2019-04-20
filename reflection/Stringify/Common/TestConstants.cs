using System.Linq;

namespace Stringify.Common
{
    public static class TestConstants
    {
        //Constructors
        private const string ConstructorsCount = "Constructors count: 4";
        private const string HasParameterlessConstructor = "Has parameterless constructor: True";
        public static readonly string[] ConstructorsInfo = { ConstructorsCount, HasParameterlessConstructor };

        //Fields
        private const string PrivateFieldsHeadline = "NonPublic fields:";
        private const string CountField = "System.Int32 count";
        private const string StaticFieldsHeadline = "Static, Public fields:";
        private const string NumberField = "System.Int32 number: 42";
        private const string VersionField = "System.String version: Version: 1.0";
        public static readonly string[] FieldsInfo =
        {
            PrivateFieldsHeadline, CountField,
            StaticFieldsHeadline, NumberField, VersionField
        };

        //Properties
        private const string PropertiesHeadline = "Properties:";
        private const string RecordProperty = "System.String Record";
        private const string MagicNumberProperty = "System.Int32 MagicNumber";
        public static readonly string[] PropertiesInfo = { PropertiesHeadline, RecordProperty, MagicNumberProperty };

        //Public Methods
        private const string PublicMethodsHeadline = "Public methods:";
        private const string RecordGetter = "String get_Record";
        private const string RecordSetter = "Void set_Record";
        private const string MagicNumberGetter = "Int32 get_MagicNumber";
        private const string MagicNumberSetter = "Void set_MagicNumber";
        private const string SetCountFieldMethod = "Void SetCountField";
        private const string ToStringMethod = "String ToString";
        private const string EqualsMethod = "Boolean Equals";
        private const string GetHashCodeMethod = "Int32 GetHashCode";
        private const string GetTypeMethod = "Type GetType";
        private static readonly string[] PublicMethodsInfo =
        {
            PublicMethodsHeadline, RecordGetter, RecordSetter,
            MagicNumberGetter, MagicNumberSetter, SetCountFieldMethod,
            ToStringMethod, EqualsMethod, GetHashCodeMethod, GetTypeMethod
        };

        //Private Methods
        private const string PrivateMethodsHeadline = "NonPublic methods:";
        private const string ResetRecordMethod = "Void ResetRecord";
        private const string FinalizeMethod = "Void Finalize";
        private const string MemberwiseCloneMethod = "Object MemberwiseClone";
        private static readonly string[] PrivateMethodsInfo =
        {
            PrivateMethodsHeadline, ResetRecordMethod,
            FinalizeMethod, MemberwiseCloneMethod
        };

        public static readonly string[] ClassMethodsInfo = PublicMethodsInfo.Concat(PrivateMethodsInfo).ToArray();

        //BackingFields
        private const string RecordBackingField = "System.String <Record>k__BackingField";
        private const string MagicNumberBackingField = "System.Int32 <MagicNumber>k__BackingField";
        private static readonly string[] BackingFieldsInfo = { RecordBackingField, MagicNumberBackingField };

        public static readonly string[] AllClassInfo = BackingFieldsInfo
            .Concat(ClassMethodsInfo)
            .Concat(PropertiesInfo)
            .Concat(FieldsInfo)
            .Concat(ConstructorsInfo)
            .ToArray();
    }
}