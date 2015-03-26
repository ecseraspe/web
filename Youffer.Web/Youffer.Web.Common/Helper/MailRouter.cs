//-----------------------------------------------------------------------------------------
// <copyright file="MailRouter.cs" company="Think Future Technologies Private Limited">
//     Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the MailRouter type
// </summary>
//-----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace Youffer.Web.Common.Helper
{
    /// <summary>
    /// The mail router.
    /// </summary>
    public static class MailRouter
    {
        /// <summary>
        /// The ConstErrorFrame.
        /// </summary>
        private const int ConstErrorFrame = 3; ////errors are in frame 3

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="m">
        /// The m.
        /// </param>
        /// <param name="forceSmtp">
        /// The force smtp.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static Boolean Send(MailMessage m, Boolean forceSmtp = false)
        {
            try
            {
                return SendSmtpEmail(m);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, ConstErrorFrame);
                return false;
            }
        }

        /// <summary>
        /// The send smtp email.
        /// </summary>
        /// <param name="mailMessage"> The mail message. </param>
        /// <returns> The <see cref="bool"/>. </returns>
        public static bool SendSmtpEmail(MailMessage mailMessage)
        {
            try
            {
                MailSettingsSectionGroup mailSettings = GetMailSettingGroup();

                SmtpClient smtpMail = new SmtpClient();
                NetworkCredential credentials = new NetworkCredential();
                if (mailSettings != null)
                {
                    credentials.UserName = mailSettings.Smtp.Network.UserName;
                    credentials.Password = mailSettings.Smtp.Network.Password;
                    smtpMail.Host = mailSettings.Smtp.Network.Host;
                    smtpMail.Port = mailSettings.Smtp.Network.Port;
                    smtpMail.EnableSsl = mailSettings.Smtp.Network.EnableSsl;
                    smtpMail.Credentials = credentials;
                }
                smtpMail.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

            return false;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="mailMessage">  The mail message. </param>
        /// <param name="errMsg"> The err msg. </param>
        /// <param name="forceSmtp"> The force smtp. </param>
        /// <returns> The <see cref="bool"/>.
        /// </returns>
        public static Boolean Send(MailMessage mailMessage, ref String errMsg, Boolean forceSmtp = false)
        {
            errMsg = string.Empty;
            try
            {
                return SendSmtpEmail(mailMessage);
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                Logger.LogException(ex, ConstErrorFrame);
                return false;
            }
        }

        /// <summary>
        /// The get mail setting group.
        /// </summary>
        /// <returns> The <see cref="MailSettingsSectionGroup"/>. </returns>
        private static MailSettingsSectionGroup GetMailSettingGroup()
        {
            try
            {
                if (HttpContext.Current != null)
                {
                    return WebConfigurationManager.OpenWebConfiguration("~/web.config").GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
                }

                return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
            }
            catch
            {
            }

            return null;
        }
    }
}
