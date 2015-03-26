//-----------------------------------------------------------------------------------------
// <copyright file="ObjectUtil.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the ObjectUtil type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Defines type ObjectUtil
    /// </summary>
    public static class ObjectUtil
    {
        #region Public Methods and Operators

        /// <summary>
        /// The encode xml.
        /// </summary>
        /// <param name="s">  The s. </param>
        /// <returns> The <see cref="string"/>. </returns>
        public static String EncodeXml(String s)
        {
            return SecurityElement.Escape(s);
        }

        /// <summary>
        /// The object to xml string.
        /// </summary>
        /// <param name="rootName"> The root name. </param>
        /// <param name="obj"> The obj. </param>
        /// <returns> The <see cref="string"/>. </returns>
        public static string ObjectToXmlString(String rootName, Object obj)
        {
            var sb = new StringBuilder();
            sb.Append("<" + rootName + ">");
            Type type = obj.GetType(); // Get the type of the object.
            foreach (PropertyInfo property in type.GetProperties())
            {
                sb.Append(
                    "<" + property.Name + ">" + EncodeXml(property.GetValue(obj, null).ToString()) + "</"
                    + property.Name + ">");
            }

            sb.Append("</" + rootName + ">");
            return sb.ToString();
        }
        #endregion
    }
}