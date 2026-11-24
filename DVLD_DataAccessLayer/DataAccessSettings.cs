using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace DVLD_DataAccessLayer
{
    internal class DataAccessSettings
    {
        private static readonly string APP_NAME = "DVLD_APP";
        public static readonly string DataConnection = "Server=.; Database = DVLD; Integrated Security=true; trustservercertificate=true;";

        public static void WriteMessageOnEventViewer (string Message, EventLogEntryType type)
        {
            if (!EventLog.SourceExists(APP_NAME))
            {
                EventLog.CreateEventSource(APP_NAME, "Application");
            }

            EventLog.WriteEntry(APP_NAME, Message, type);
        }

    }
}
