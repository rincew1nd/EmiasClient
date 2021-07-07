using System;

namespace EmiasClient.API.Helpers
{
    public static class AttributeHelper
    {
        public static T2 GetAttribute<T1, T2>() where T2 : Attribute
        {
            return (T2) Attribute.GetCustomAttribute(typeof(T1), typeof(T2));
        }
    }
}