//-----------------------------------------------------------------------------------------
// <copyright file="GlobalConstants.cs" company="Think Future Technologies Private Limited">
// Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the GlobalConstants type
// </summary>
//-----------------------------------------------------------------------------------------    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    ///  Defines type GlobalConstants
    /// </summary>
    public sealed class GlobalConstants
    {

        /// <summary>
        /// The email regular ex.
        /// </summary>
        public const string EmailRegEx = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
                                     + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        /// <summary>
        /// The URL regular expression
        /// </summary>
        public const string UrlRegEx = @"((http|https)(:\/\/[\w\-_]+)((\.[\w\-_]+)+)([\w\-\.,@?^=%&amp;%\$:/~\+#]*[\w\-\@?^=%&amp;%\$/~\+#])?)";

        /// <summary>
        /// The default eventlog source
        /// </summary>
        public const string DefaultEventlogSource = "YoufferLog";

        /// <summary>
        /// The tracker connection string
        /// </summary>
        public const string TrackerConnectionString = "YoufferDB";

        /// <summary>
        /// The facebook provider
        /// </summary>
        public const string FacebookProvider = "Facebook";

        /// <summary>
        /// The external login client identifier
        /// </summary>
        public const string ExternalLoginClientId = "compWeb";

        /// <summary>
        /// The youffer user session
        /// </summary>
        public const string YoufferUserSession = "YoufferUser";

        /// <summary>
        /// The time zone cookie
        /// </summary>
        public const string TimeZoneCookie = "timezoneoffset";

        /// <summary>
        /// The sort direction ascending
        /// </summary>
        public const string SortDirectionAscending = "asc";

        /// <summary>
        /// The sort direction descending
        /// </summary>
        public const string SortDirectionDescending = "desc";

        /// <summary>
        /// The online image
        /// </summary>
        public const string OnlineImage = "/img/greenMark.png";

        /// <summary>
        /// The offline image
        /// </summary>
        public const string OfflineImage = "/img/redMark.png";

        /// <summary>
        /// The mark as purchased confirmation icon
        /// </summary>
        public const string MarkAsPurchasedConfirmationIcon = "/img/Check_mark_green.png";

        /// <summary>
        /// The attachment media Path
        /// </summary>
        public const string AttachmentMediaPath = "UserContent/MessageMedia/";

        /// <summary>
        /// The valid image extensions
        /// </summary>
        public const string ValidImageExtensions = "ValidImageExtensions";

        /// <summary>
        /// The domain key
        /// </summary>
        public const string DomainKey = "domain";

        /// <summary>
        /// The is dummy key
        /// </summary>
        public const string IsDummyKey = "IsDummy";

        /// <summary>
        /// The super admin
        /// </summary>
        public const string SuperAdmin = "YoufferAdmin";
    }
}
