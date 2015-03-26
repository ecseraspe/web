using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Youffer.Web.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var description = value.ToString();
            var fieldInfo = value.GetType().GetField(description);
            if (fieldInfo == null)
                return "";
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;

            return description;
        }

        public static string GetDescription<T>(this int value)
        {
            return GetDescription((Enum)(object)((T)(object)value));
        }

        public static string GetDescription<T>(this short value)
        {
            return GetDescription((Enum)(object)((T)(object)value));
        }

        public static T GetValueFromDescription<T>(string description)
        {
            if (description == null)
                throw new ArgumentNullException("description");

            var type = typeof(T);
            if (!type.IsEnum)
                throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attr = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                if (attr != null)
                {
                    if (attr.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not Found.", "description");
        }

        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }

        public static short ToShort(this Enum enumValue)
        {
            return Convert.ToInt16(enumValue);
        }

        public static string ToIntString(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue).ToString();
        }

        public static IList<int> ToIntList(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var list = new BindingList<int>();
            var enumValues = Enum.GetValues(type);

            foreach (var value in enumValues)
                list.Add((int)value);

            return list;
        }
        public static IList<string> ToStringList(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var list = new BindingList<string>();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
                list.Add(GetDescription(value));

            return list;
        }

        public static IList ToList(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var list = new ArrayList();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }

        public static IList<SelectListItem> ToSelectList<TEnum>() where TEnum : struct
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var r = (from Enum value in Enum.GetValues(enumType) select new SelectListItem { Value = value.ToInt().ToString(), Text = GetDescription(value) }).ToList();
            return r;
        }

        public static IList<SelectListItem> ToSelectList<TEnum>(object selectedValue) where TEnum : struct
        {
            var enumType = typeof(TEnum);
            if (!enumType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var r = (from Enum value in Enum.GetValues(enumType) select new SelectListItem { Value = value.ToInt().ToString(), Text = GetDescription(value), Selected = value.Equals(selectedValue) }).ToList();
            return r;
        }

        public static IEnumerable<dynamic> ToDynObjList(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            var list = new List<dynamic>();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new { Value = value.ToInt(), Text = GetDescription(value) });
            }

            return list;
        }

        public static T ParseEnum<T>(this int valueToParse) where T : struct, IConvertible
        {
            return EnumParse<T>(valueToParse);
        }

        public static T ParseEnum<T>(this short valueToParse) where T : struct, IConvertible
        {
            return EnumParse<T>(valueToParse);
        }

        public static T ParseEnum<T>(this byte valueToParse) where T : struct, IConvertible
        {
            return EnumParse<T>(valueToParse);
        }

        public static T ParseEnum<T>(this string valueToParse) where T : struct, IConvertible
        {
            return EnumParse<T>(valueToParse);
        }

        private static T EnumParse<T>(object valueToParse) where T : struct, IConvertible
        {
            T defaultValue = default(T);

            if (valueToParse != null && Enum.IsDefined(typeof(T), valueToParse))
            {
                try
                {
                    return (T)valueToParse;
                }
                catch
                {
                    Enum.TryParse<T>(valueToParse.ToString(), out defaultValue);
                }
            }

            return defaultValue;
        }

    }
}
