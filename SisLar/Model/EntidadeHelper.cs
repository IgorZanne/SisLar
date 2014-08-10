using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace SisLar.Model
{
    public class EntidadeHelper
    {
        public static List<String> GetListaPropriedades<T>()
        {
            List<String> retorno = new List<string>();
            Type type = typeof(T);

            foreach (PropertyInfo pInfo in type.GetProperties())
            {
                DisplayNameAttribute attr = (DisplayNameAttribute)Attribute
                    .GetCustomAttribute(pInfo, typeof(DisplayNameAttribute));

                if (attr != null && !String.IsNullOrEmpty(attr.DisplayName) && attr.DisplayName != "Senha")
                    retorno.Add(attr.DisplayName);
            }
            return retorno.OrderBy(e => e).ToList();
        }

        public static PropertyInfo GetNomePropriedade<T>(String display)
        {
            Type type = typeof(T);

            foreach (PropertyInfo pInfo in type.GetProperties())
            {
                DisplayNameAttribute attr = (DisplayNameAttribute)Attribute
                    .GetCustomAttribute(pInfo, typeof(DisplayNameAttribute));

                if (attr != null && !String.IsNullOrEmpty(attr.DisplayName) && attr.DisplayName.Equals(display))
                    return pInfo;
            }
            return null;
        }

        /// <summary>
        /// Gets the Display Name for the property descriptor passed in
        /// </summary>
        /// <param name="descriptor"></param>
        /// <returns></returns>
        public static string GetPropertyDisplayName(object descriptor)
        {

            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                DisplayNameAttribute displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }

            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        DisplayNameAttribute displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }
    }
}
