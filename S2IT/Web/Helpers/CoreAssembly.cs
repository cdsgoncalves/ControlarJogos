using System;
using System.Reflection;

namespace Web.Helpers
{
    public class CoreAssembly
    {
        public static string GetAssemblyAttribute<T>(Func<T, string> value) where T : Attribute
        {
            var attribute = (T)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(T));
            return value.Invoke(attribute);
        }

        public static readonly string Version = GetAssemblyAttribute<AssemblyInformationalVersionAttribute>(a => a.InformationalVersion);
        public static readonly string Copyright = GetAssemblyAttribute<AssemblyCopyrightAttribute>(a => a.Copyright) + (DateTime.Now.Year == 2017 ? string.Empty : $"-{DateTime.Now.Year}");
        public static readonly string Company = GetAssemblyAttribute<AssemblyCompanyAttribute>(a => a.Company);
    }
}