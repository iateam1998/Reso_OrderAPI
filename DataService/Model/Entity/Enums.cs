using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DataService.Model.ViewModel
{
    public static partial class Enums
    {
        public static IDictionary<int, string> Get<Type>()
        {
            var type = typeof(Type);
            var enumType = typeof(Enum);
            var enums = type.GetFields().Where(f => f.FieldType.IsSubclassOf(enumType));
            var dict = new Dictionary<int, string>();
            foreach (var e in enums)
            {
                dict[(int)e.GetRawConstantValue()] = e.FieldType.DisplayName(e.Name);
            }
            return dict;
        }

        public static string DisplayName(this Enum enumVal)
        {
            var enumType = enumVal.GetType();
            var name = Enum.GetName(enumType, enumVal);
            var displayNameAttr = enumType.GetField(name).GetCustomAttributes(false)
                .OfType<DisplayAttribute>().SingleOrDefault();
            if (displayNameAttr != null)
                return displayNameAttr.Name;
            return null;
        }

        public static String DisplayName(this Type enumType, string enumName)
        {
            var displayNameAttr = enumType.GetField(enumName).GetCustomAttributes(false)
                .OfType<DisplayAttribute>().SingleOrDefault();
            if (displayNameAttr != null)
                return displayNameAttr.Name;
            return null;
        }
    }
}
