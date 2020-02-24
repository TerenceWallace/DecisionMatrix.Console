
using DecisionMatrix.Common;
using Economy.Common;
using Economy.Framework;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Data;
using System.Drawing;
using System;

namespace Economy.Common
{
	 public class Logger
	 {
		  private const string FILE_EXT = ".log";
		  private readonly string datetimeFormat;
		  private readonly string logFilename;

		  /// <summary>
		  /// Initiate an instance of SimpleLogger class constructor.
		  /// If log file does not exist, it will be created automatically.
		  /// </summary>
		  public Logger()
		  {
			   datetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
			   logFilename = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + FILE_EXT;

			   // Log file header line
			   string logHeader = logFilename + " is created.";
			   if (!System.IO.File.Exists(logFilename))
			   {
					WriteLine(DateTime.Now.ToString(datetimeFormat) + " " + logHeader, false);
			   }
		  }

		  /// <summary>
		  /// Log a DEBUG message
		  /// </summary>
		  /// <param name="text">Message</param>
		  public void Debug(string text)
		  {
			   WriteFormattedLog(LogLevel.DEBUG, text);
		  }

		  /// <summary>
		  /// Log an ERROR message
		  /// </summary>
		  /// <param name="text">Message</param>
		  public void Error(string text)
		  {
			   WriteFormattedLog(LogLevel.ERROR, text);
		  }

		  /// <summary>
		  /// Log a FATAL ERROR message
		  /// </summary>
		  /// <param name="text">Message</param>
		  public void Fatal(string text)
		  {
			   WriteFormattedLog(LogLevel.FATAL, text);
		  }

		  /// <summary>
		  /// Log an INFO message
		  /// </summary>
		  /// <param name="text">Message</param>
		  public void Info(string text)
		  {
			   WriteFormattedLog(LogLevel.INFO, text);
		  }

		  /// <summary>
		  /// Log a TRACE message
		  /// </summary>
		  /// <param name="text">Message</param>
		  public void Trace(string text)
		  {
			   WriteFormattedLog(LogLevel.TRACE, text);
		  }

		  /// <summary>
		  /// Log a WARNING message
		  /// </summary>
		  /// <param name="text">Message</param>
		  public void Warning(string text)
		  {
			   WriteFormattedLog(LogLevel.WARNING, text);
		  }

		  private void WriteLine(string text, bool append = true)
		  {
			   try
			   {
					using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilename, append, System.Text.Encoding.UTF8))
					{
						 if (!string.IsNullOrEmpty(text))
						 {
							  writer.WriteLine(text);
						 }
					}
			   }
			   catch
			   {
					throw;
			   }
		  }

		  private void WriteFormattedLog(LogLevel level, string text)
		  {
			   string pretext = null;
			   switch (level)
			   {
					case LogLevel.TRACE:
						 pretext = DateTime.Now.ToString(datetimeFormat) + " [TRACE]   ";
						 break;
					case LogLevel.INFO:
						 pretext = DateTime.Now.ToString(datetimeFormat) + " [INFO]    ";
						 break;
					case LogLevel.DEBUG:
						 pretext = DateTime.Now.ToString(datetimeFormat) + " [DEBUG]   ";
						 break;
					case LogLevel.WARNING:
						 pretext = DateTime.Now.ToString(datetimeFormat) + " [WARNING] ";
						 break;
					case LogLevel.ERROR:
						 pretext = DateTime.Now.ToString(datetimeFormat) + " [ERROR]   ";
						 break;
					case LogLevel.FATAL:
						 pretext = DateTime.Now.ToString(datetimeFormat) + " [FATAL]   ";
						 break;
					default:
						 pretext = "";
						 break;
			   }

			   WriteLine(pretext + text);
		  }

		  [System.Flags]
		  private enum LogLevel
		  {
			   TRACE,
			   INFO,
			   DEBUG,
			   WARNING,
			   ERROR,
			   FATAL
		  }
	 }
}