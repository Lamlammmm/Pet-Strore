using System.ComponentModel;
using System.Reflection;

namespace PetStore.Common.Extensions
{
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), inherit: false);
            return (array.Length != 0) ? array[0].Description : enumValue.ToString();
        }
    }
}