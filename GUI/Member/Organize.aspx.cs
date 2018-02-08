using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Drawing;

/*
* Team: Team_gc_Desert
* Author: Jajati Keshari Routray
* ASU ID: 1211086640
* Email: jroutray@asu.edu
* 
* Details: Provides form to save event details provided by Event organizer
*/

namespace GUI
{
    public partial class Organize : System.Web.UI.Page
    {
        // Get file path
        protected string fileLoc = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", @"Events.xml");

        protected void Page_Load(object sender, EventArgs e)
        {   
            // Check user in cookies. If user is not present - redirect to homepage
            if (!Request.Cookies.AllKeys.Contains("Login"))
            {
                Response.Redirect("~/");
                return;
            }
            // Create Events XML file with root element if it doesn't exist
            if (!File.Exists(fileLoc))
            {
                XDocument EventsXMLdoc = new XDocument();
                EventsXMLdoc.Add(new XElement("Events"));
                EventsXMLdoc.Save(fileLoc);
            }
        }

        protected void eventsubmitButton_Click(object sender, EventArgs e)
        {
            try
            {   
                // Validate whether fields are empty and append to XML file
                string[] Fields = new string[4] { titleTextBox.Text , locTextBox.Text , datetimeTextBox.Text , descriptionTextBox.Text };
                if (!Fields.Any(eachField => string.IsNullOrWhiteSpace(eachField)))
                {
                    // Save input to XML file
                    XElement Event = new XElement("Event",
                         new XElement("Title", Fields[0]),
                         new XElement("Location", Fields[1]),
                         new XElement("Time", Fields[2]),
                         new XElement("Description", Fields[3]),
                         new XElement("Attendees",
                            new XElement("Count",0)));

                    XDocument EventsXMLdoc = XDocument.Load(fileLoc);
                    EventsXMLdoc.Root.Add(Event);
                    EventsXMLdoc.Save(fileLoc);

                    // Redirect on successfull event creation
                    Response.Redirect("~/Member/MemberHome");
                }
                else
                {
                    // Display error if empty fields detected
                    resultLabel.Text = "Empty fields detected";
                    resultLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                // Display exceptions message if error occurs
                resultLabel.Text = ex.Message;
                resultLabel.ForeColor = Color.Red;
            }
        }
    }
}