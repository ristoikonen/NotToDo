using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace NotToDo.OutlookAccess
{
    public static class Remind
    {


        public static void ReminderExample(int userid, int todoid, DateTime startDate)
        {
            Microsoft.Office.Interop.Outlook.Application appt = null; ;
            try
            {
                appt = new Microsoft.Office.Interop.Outlook.Application();
                NameSpace outlookNamespace = appt.GetNamespace("MAPI");
                outlookNamespace.Logon();


                var apt = (Microsoft.Office.Interop.Outlook.AppointmentItem)appt.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);

                apt.Subject = "Test";
                apt.Body = "body";

                apt.Start = startDate;
                apt.End = startDate.AddHours(1);

                apt.ReminderMinutesBeforeStart = 60; // * 60 * 7 * 1;  // One week reminder

                apt.BusyStatus = Outlook.OlBusyStatus.olTentative;

                apt.AllDayEvent = false;
                apt.Location = "loc";

                apt.Close(OlInspectorClose.olSave);

                appt = null; 
            }
            catch (System.Exception ex)
            {

                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                if (appt != null)
                    appt = null;
            }

        }
    }
}

