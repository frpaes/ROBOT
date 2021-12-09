using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Becomex.Robot.Application.Helper
{
    public static class Helper
    {
        public static string GetDescription(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            MemberInfo member = type.GetMembers().Where(w => w.Name == Enum.GetName(type, enumValue)).FirstOrDefault();
            var attribute = member?.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute?.Description != null ? attribute.Description : enumValue.ToString();
        }
    }
}
