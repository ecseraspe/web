//-----------------------------------------------------------------------------------------
// <copyright file="Logger.cs" company="Think Future Technologies Private Limited">
//     Copyright (c) Think Future Technologies Private Limited. All rights reserved.
// </copyright>
// <author>Gaurav Shankar</author>
// <datecreated>17-Nov-2014</datecreated>
// <summary>
//      Defines the Logger type
// </summary>
//-----------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Youffer.Web.Common.Helper;

namespace Youffer.Web.Common
{
    /// <summary>
    /// Defines type Logger
    /// </summary>
    public static class Logger
    {

        /// <summary>
        /// The default_ eventlog_ source.
        /// </summary>
        private const String DefaultEventlogSource = GlobalConstants.DefaultEventlogSource;

        /// <summary>
        /// The initialize logger.
        /// </summary>
        public static void InitializeLogger()
        {
            try
            {
                bool logToEventlog = AppSettings.Get("LogToEventlog", true);
                if (logToEventlog)
                {
                    String source = AppSettings.Get("EventLogName", DefaultEventlogSource);
                    if (!EventLog.SourceExists(source))
                    {
                        EventSourceCreationData escd = new EventSourceCreationData(source, source);
                        EventLog.CreateEventSource(escd);
                    }
                }
            }
            catch (Exception ex)
            {
                bool logToEventlog = AppSettings.Get("LogToEventlog", true);
                var message = ex.Message.ToLower() == "requested registry access is not allowed." ? "Unable to initialize Event Viewer log, 'requested registry access is not allowed' please visit http://support.microsoft.com/kb/842795 to add permission for user." : ex.Message;
                if (logToEventlog)
                {
                    LogToEmail(EventLogEntryType.Error, "Tracker Global.asax", "Initialize Logger", 1, message, string.Empty);
                }
            }
        }

        /// <summary>
        /// The log information.
        /// </summary>
        /// <param name="message"> The message. </param>
        public static void LogInformation(String message)
        {
            LogException(message, EventLogEntryType.Information, 1);
        }

        /// <summary>
        /// The log success audit.
        /// </summary>
        /// <param name="message">  The message. </param>
        public static void LogSuccessAudit(String message)
        {
            LogException(message, EventLogEntryType.SuccessAudit, 1);
        }

        /// <summary>
        /// The log failure audit.
        /// </summary>
        /// <param name="message"> The message. </param>
        public static void LogFailureAudit(String message)
        {
            LogException(message, EventLogEntryType.FailureAudit, 1);
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="message">  The message. </param>
        public static void LogException(String message)
        {
            LogException(message, EventLogEntryType.Error, 1);
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        public static void LogException(Exception ex)
        {
            LogException(ex, EventLogEntryType.Error, 1);
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        /// <param name="frame"> The frame. </param>
        public static void LogException(Exception ex, int frame)
        {
            LogException(ex, EventLogEntryType.Error, frame);
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex">  The ex. </param>
        /// <param name="level"> The level. </param>
        public static void LogException(Exception ex, EventLogEntryType level)
        {
            LogException(ex.InnerException != null ? ex.InnerException.Message : ex.Message, level, 1);
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="ex">  The ex. </param>
        ///  <param name="level"> The level. </param>
        /// <param name="frame"> The frame. </param>
        public static void LogException(Exception ex, EventLogEntryType level, int frame)
        {
            LogException(ex.InnerException != null ? ex.InnerException.Message : ex.Message, level, frame);
        }

        /// <summary>
        /// The log exception.
        /// </summary>
        /// <param name="message"> The message. </param>
        /// <param name="level">The level. </param>
        /// <param name="frame">The frame. </param>
        public static void LogException(String message, EventLogEntryType level, int frame)
        {
            try
            {
                StackFrame callStack = new StackFrame(frame, true);
                String filename = string.Empty;
                try
                {
                    filename = callStack.GetFileName();
                }
                catch (Exception)
                {
                }

                String method = callStack.GetMethod().ToString();
                int linenumber = callStack.GetFileLineNumber();
                String stackTrace = string.Empty;

                if (level == EventLogEntryType.Error)
                {
                    stackTrace = "Stack Trace: " + Environment.StackTrace;
                }
                else
                {
                    method = string.Empty;
                    linenumber = 0;
                }

                #region "Log to Eventlog"
                bool logToEventlog = AppSettings.Get("LogToEventlog", true);
                if (logToEventlog)
                {
                    try
                    {
                        String auditMessage = "Level: " + level + Environment.NewLine;
                        if (level == EventLogEntryType.Error)
                        {
                            auditMessage += "Machine :" + Environment.MachineName + Environment.NewLine;
                            auditMessage += "File: " + filename + Environment.NewLine;
                            auditMessage += "Method: " + method + Environment.NewLine;
                            auditMessage += "line: " + linenumber + Environment.NewLine + Environment.NewLine;
                            auditMessage += "Message: " + message + Environment.NewLine + Environment.NewLine;
                        }

                        String source = AppSettings.Get("EventLogName", DefaultEventlogSource);
                        EventLog trackerLog = new EventLog { Source = source, Log = source };
                        trackerLog.WriteEntry(auditMessage + Environment.NewLine + stackTrace, level, 0);
                    }
                    catch
                    {
                    }
                }
                #endregion

                #region "Log to Database"
                bool logToDb = AppSettings.Get("LogToDB", true);
                if (logToDb)
                {
                    LogToDb(level, filename, method, linenumber, message, stackTrace);
                }
                #endregion

                #region "Log to Email"
                bool logToMail = AppSettings.Get("LogToEmail", false);
                if (logToMail)
                {
                    LogToEmail(level, filename, method, linenumber, message, stackTrace);
                }
                #endregion
            }
            catch (Exception)
            {
                ////Do nothing since logging is unavailable
            }
        }

        /// <summary>
        /// The log to db.
        /// </summary>
        /// <param name="level"> The level. </param>
        /// <param name="machineName"> The machine name. </param>
        /// <param name="filename"> The filename. </param>
        /// <param name="method"> The method. </param>
        /// <param name="linenumber"> The linenumber. </param>
        /// <param name="exceptionMessage"> The exception message. </param>
        /// <param name="stackTrace"> The stack trace. </param>
        /// <param name="sessionId"> The session id. </param>
        public static void LogToDB(int level, String machineName, String filename, string method, int linenumber, String exceptionMessage, String stackTrace, Guid sessionId)
        {
            const String TrackerConnectionString = GlobalConstants.TrackerConnectionString;

            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon.ConnectionString = ConfigurationManager.ConnectionStrings[TrackerConnectionString].ToString();
                SqlCommand sqlCmd = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "InsertIntoLogger_v1"
                };
                sqlCmd.Parameters.AddWithValue("@EnumLevel", level);
                sqlCmd.Parameters.AddWithValue("@Machine", machineName + string.Empty);
                sqlCmd.Parameters.AddWithValue("@Filename", filename + string.Empty);
                sqlCmd.Parameters.AddWithValue("@Method", method + string.Empty);
                sqlCmd.Parameters.AddWithValue("@LineNumber", linenumber);
                sqlCmd.Parameters.AddWithValue("@Stacktrace", stackTrace + string.Empty);
                sqlCmd.Parameters.AddWithValue("@Message", exceptionMessage + string.Empty);
                sqlCmd.Parameters.Add("@SessionId", SqlDbType.UniqueIdentifier).Value = sessionId;
                sqlCmd.Connection = sqlCon;
                sqlCon.Open();
                sqlCmd.ExecuteNonQuery();
            }
            catch
            {
                ////Don't log since here since we are in the logger itself
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Dispose();
                }
            }
        }

        /// <summary>
        /// The log to email.
        /// </summary>
        /// <param name="level"> The level. </param>
        /// <param name="filename"> The filename. </param>
        ///  <param name="method"> The method. </param>
        ///  <param name="linenumber"> The linenumber. </param>
        /// <param name="message"> The message. </param>
        /// <param name="stackTrace"> The stack trace. </param>
        private static void LogToEmail(EventLogEntryType level, String filename, string method, int linenumber, String message, String stackTrace)
        {
            const int ErrorThrottleLimit = 10;
            Int32 rollingErrorCnt = 0;
            if (level != EventLogEntryType.SuccessAudit && level != EventLogEntryType.Information)
            {
                if (HttpContext.Current != null)
                {
                    String errorId = filename + "_" + method + "_" + linenumber;

                    if (HttpContext.Current.Cache[errorId + "_cnt"] != null)
                    {
                        rollingErrorCnt = Convert.ToInt32(HttpContext.Current.Cache[errorId + "_cnt"].ToString()) + 1;
                        HttpContext.Current.Cache[errorId + "_cnt"] = rollingErrorCnt;
                    }
                    else
                    {
                        rollingErrorCnt = 1;
                        HttpContext.Current.Cache.Insert(errorId + "_cnt", rollingErrorCnt, null, DateTime.UtcNow.AddMinutes(10), System.Web.Caching.Cache.NoSlidingExpiration);
                    }

                    if (rollingErrorCnt > ErrorThrottleLimit)
                    {
                        ////More than 10 of the same error have occurred in a sliding 10 minute window so do not blast more emails
                        return;
                    }
                }
            }

            bool sendToEmail = false;
            switch (level)
            {
                case EventLogEntryType.Error:
                    sendToEmail = AppSettings.Get("LogEmailErrors", false);
                    break;
                case EventLogEntryType.FailureAudit:
                    sendToEmail = AppSettings.Get("LogEmailFailureAudits", false);
                    break;
                case EventLogEntryType.Information:
                    sendToEmail = AppSettings.Get("LogEmailInformation", false);
                    break;
                case EventLogEntryType.SuccessAudit:
                    sendToEmail = AppSettings.Get("LogEmailSuccessAudits", false);
                    break;
                case EventLogEntryType.Warning:
                    sendToEmail = AppSettings.Get("LogEmailWarnings", false);
                    break;
            }

            if (sendToEmail)
            {
                try
                {
                    ////Check to see if the exception can be sent via email
                    string[] excludeEmailExceptions = null;
                    if (System.Configuration.ConfigurationManager.AppSettings["ExcludeEmailExceptions"] != null)
                    {
                        excludeEmailExceptions = System.Configuration.ConfigurationManager.AppSettings["ExcludeEmailExceptions"].Split('|');
                    }

                    if (excludeEmailExceptions != null && excludeEmailExceptions.Length > 0)
                    {
                        if (excludeEmailExceptions.Any(excludeEmailException => message.ToLower().StartsWith(excludeEmailException.ToLower())))
                        {
                            return;
                        }
                    }

                    String mailingList = AppSettings.Get("ErrorMessageRecipients", string.Empty);

                    if (!string.IsNullOrEmpty(mailingList))
                    {
                        string[] mailTokens = mailingList.Split('|');

                        MailMessage emailMsg = new MailMessage();

                        foreach (string sTo in mailTokens)
                        {
                            emailMsg.To.Add(new MailAddress(sTo));
                        }

                        if (level == EventLogEntryType.SuccessAudit || level == EventLogEntryType.Information)
                        {
                            emailMsg.Subject = "MaveRickMailMail Logger (" + level + ")";
                        }
                        else
                        {
                            if (rollingErrorCnt == ErrorThrottleLimit)
                            {
                                emailMsg.Subject = "MaveRickMailMail Logger (" + level + ") - Error rate limited for 10 min";
                            }
                            else
                            {
                                emailMsg.Subject = "MaveRickMailMail Logger (" + level + ") - Error Cnt:" + rollingErrorCnt;
                            }
                        }

                        emailMsg.IsBodyHtml = true;

                        emailMsg.Body += "<br /><b>Level:</b> " + level;
                        emailMsg.Body += "<br /><b>Machine:</b> " + Environment.MachineName;
                        emailMsg.Body += "<br /><b>File:</b> " + filename;
                        if (method.Length > 0)
                        {
                            emailMsg.Body += "<br /><b>Method:</b> " + method;
                        }

                        if (linenumber > 0)
                        {
                            emailMsg.Body += "<br /><b>Line:</b> " + linenumber;
                        }

                        if (message.Length > 0)
                        {
                            emailMsg.Body += "<br /><b>Message:</b> " + message;
                        }

                        if (stackTrace.Length > 0)
                        {
                            emailMsg.Body += "<br /><br /><b>StackTrace...</b><br />" + Environment.NewLine + stackTrace;
                        }

                        ////MailRouter.Send(emailMsg);
                    }
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// The log to db.
        /// </summary>
        /// <param name="level"> The level. </param>
        /// <param name="filename"> The filename. </param>
        /// <param name="method"> The method. </param>
        /// <param name="linenumber"> The linenumber. </param>
        /// <param name="exceptionMessage"> The exception message. </param>
        /// <param name="stackTrace"> The stack trace. </param>
        private static void LogToDb(EventLogEntryType level, String filename, string method, int linenumber, String exceptionMessage, String stackTrace)
        {
            Guid sessionId = Guid.Empty;
            try
            {
                LogToDB(Convert.ToInt32(level), Environment.MachineName, filename, method, linenumber, exceptionMessage, stackTrace, sessionId);
            }
            catch
            {
                ////Don't log since here since we are in the logger itself
            }
        }
    }
}
