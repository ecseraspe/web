//-----------------------------------------------------------------------------------------
// <copyright file="YoufferLogger.cs" company="Think Future Technologies Private Limited">
//     Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>27-Jan-2015</datecreated>
// <summary>
//      Defines the YoufferLogger type
// </summary>
//-----------------------------------------------------------------------------------------

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Helper
{
    public sealed class YoufferLogger
    {
        /// <summary>
        /// Gets the youffer logger.
        /// </summary>
        /// <value>
        /// The youffer logger.
        /// </value>
        public static ILog Log { get { return LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); } }
    }
}
