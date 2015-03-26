//-----------------------------------------------------------------------------------------
// <copyright file="XmlSerializerHelper.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the XmlSerializerHelper type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// Class XmlSerializerHelper. This class cannot be inherited.
    /// </summary>
    public sealed class XmlSerializerHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Des the serialize.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="xml">The XML.</param>
        /// <returns>Type value</returns>
        public static T DeSerialize<T>(string xml)
        {
            var xs = new XmlSerializer(typeof(T));
            var textReader = new StringReader(xml);
            return (T)xs.Deserialize(textReader);
        }

        /// <summary>
        /// Serializes the specified object.
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>String value.</returns>
        public static string Serialize<T>(T obj)
        {
            var writer = new StringWriter();
            var xs = new XmlSerializer(typeof(T));
            xs.Serialize(writer, obj);
            return writer.ToString();
        }

        #endregion
    }
}