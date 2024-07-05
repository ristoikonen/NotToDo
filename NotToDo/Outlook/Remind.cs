using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using Outlook = Microsoft.Office.Interop.Outlook;


namespace NotToDo.OutlookAccess
{
    public static class Remind
    {


        public static void ReminderExample(int empid, DateTime startDate)
        {
            //try
            //{
            Microsoft.Office.Interop.Outlook.Application appt = new Microsoft.Office.Interop.Outlook.Application();
            // Log in to Outlook
            NameSpace outlookNamespace = appt.GetNamespace("MAPI");
            outlookNamespace.Logon();


            var apt = (Microsoft.Office.Interop.Outlook.AppointmentItem) appt.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);


            //appt.CreateItem(Outlook.OlItemType.olAppointmentItem);

            // Use the Outlook application object to create an appointment
            //Outlook.AppointmentItem apt = (Outlook.AppointmentItem)
            //var apt = (Microsoft.Office.Interop.Outlook.AppointmentItem)appt.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);

            //apt.CreateItem(Outlook.OlItemType.olAppointmentItem);


            apt.Subject = "sub";
            apt.Body = "body";

            apt.Start = startDate; //DateTime.Now.AddHours(1);
            apt.End = startDate.AddHours(1);
            
            apt.ReminderMinutesBeforeStart = 60; // * 60 * 7 * 1;  // One week reminder

            // Makes it appear bold in the calendar - which I like!
            apt.BusyStatus = Outlook.OlBusyStatus.olTentative;

            apt.AllDayEvent = false;
            apt.Location = "loc";

           // Outlook.RecurrencePattern myPattern = apt.GetRecurrencePattern();
           // myPattern.RecurrenceType = Outlook.OlRecurrenceType.olRecursYearly;
           // myPattern.Interval = 1;
            apt.Save();
/*
                //Outlook.MailItem mailItem = (Outlook.MailItem)
                // this.Application.CreateItem(Outlook.OlItemType.olMailItem);

            Outlook.MailItem mailItem = appt.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "Reminder subject";
            mailItem.To = "risto@gmx.com";
            mailItem.Body = "Reminder body";
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(false);
            mailItem.Send();

            outlookNamespace.Logoff();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookNamespace);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appt);
*/
/*
                // Get the Inbox folder
                MAPIFolder inboxFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

            // Retrieve the emails in the Inbox folder
            Items emails = inboxFolder.Items;

            foreach (MailItem email in emails)
            {
                try
                {
                    Console.WriteLine("Subject: " + email.Subject);
                    Console.WriteLine("Sender: " + email.SenderName);
                    Console.WriteLine();
                }
                catch (System.Exception ex)
                {
                    // Handle specific exceptions related to email processing
                    Console.WriteLine("Error processing email: " + ex.Message);
                }
            }

            // Log out and release resources
            outlookNamespace.Logoff();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(outlookNamespace);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(appt);
        }
            catch (System.Exception ex)
            {
                // Handle general exceptions related to Outlook connection or login
                Console.WriteLine("Error connecting to Outlook: " + ex.Message);
            }
            finally
            {
                // Ensure resources are properly released even in case of exceptions
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            .Save();
            */
        }
    }
}

