using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace GUI.Member
{
    public partial class MemberHome : System.Web.UI.Page
    {
        // File locations for Events.xml and Member.xml
        protected string fileLoc = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", @"Events.xml");
        protected string memberFileLoc = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data", @"Member.xml");

        private bool isAlreadyRegistered(XmlNode ev, string user)
        {
            // Function to check if member is already registered for an event.
            XmlNode Attendees = ev.LastChild;
            XmlNode memberAdded = Attendees.SelectSingleNode(@"Name[text()='" + user + "']");
            if(memberAdded == null)
            {
                return false;
            }
            return true;
        }
        private string fillUrl(string url, string[] parameters)
        {
            // Helper function to populate the rest url for sms sending
            Regex rgx = new Regex("!");
            for (int i = 0; i < parameters.Length; i++)
            {
                url = rgx.Replace(url, parameters[i], 1);
            }
            return url;
        }
        protected void Page_Load()
        {
            // Check if anyone is logged in. If not logged in redirect him to default page.
            if (!Request.Cookies.AllKeys.Contains("Login"))
            {
                Response.Redirect("~/");
                return;
            // If logge in and is not member redirect to staff page.
            }else if (((string)Session["loginuser"] != "Member"))
            {
                Response.Redirect("~/Staff/StaffHome");
            }
            // If logged in and is member then display home page feed of events.
            else if (File.Exists(fileLoc))
            {
                // Load event.xml aand parse elements
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fileLoc);
                XmlNodeList events = xmldoc.SelectNodes(@"//Events/Event");
                int j = 0;
                TableHeaderRow th = new TableHeaderRow();
                string[] theaders = { "Title", "Location", "Time", "Description", "Attendees Count", "Attend Button" };
                int numcells = theaders.Length;
                // Add headers.
                for (int i = 0; i < numcells; i++)
                {
                    TableCell c = new TableCell();
                    c.Controls.Add(new LiteralControl(theaders[i]));
                    th.Cells.Add(c);
                }
                th.BackColor = Color.LightBlue;
                feedTable.Rows.Add(th);
                string user = Request.Cookies["Login"]["username"];
                // Populate table with the elements from xml.
                foreach (XmlNode ev in events)
                {
                    j++;
                    TableRow tr = new TableRow();
                    XmlNode title = ev.FirstChild;
                    string Title = title.InnerText;
                    TableCell c2 = new TableCell();
                    c2.Controls.Add(new LiteralControl(Title));
                    tr.Cells.Add(c2);
                    XmlNode location = title.NextSibling;
                    string Location = location.InnerText;
                    TableCell c3 = new TableCell();
                    c3.Controls.Add(new LiteralControl(Location));
                    tr.Cells.Add(c3);
                    XmlNode time = location.NextSibling;
                    string Time = time.InnerText;
                    TableCell c4 = new TableCell();
                    c4.Controls.Add(new LiteralControl(Time));
                    tr.Cells.Add(c4);
                    XmlNode description = time.NextSibling;
                    string Description = description.InnerText;
                    TableCell c5 = new TableCell();
                    c5.Controls.Add(new LiteralControl(Description));
                    tr.Cells.Add(c5);
                    XmlNode attendees = description.NextSibling;
                    XmlNode count = attendees.FirstChild;
                    string Count = count.InnerText;
                    TableCell c7 = new TableCell();
                    c7.Controls.Add(new LiteralControl(Count));
                    tr.Cells.Add(c7);
                    TableCell c8 = new TableCell();
                    // If already attending do not display button.
                    if (isAlreadyRegistered(ev, user))
                    {
                        c8.Controls.Add(new LiteralControl("Attending"));
                    }
                    // If not then display a button to attend.
                    else
                    {
                        Button button = new Button();
                        button.Text = "Attend";
                        button.CommandArgument = Title + "~" + j.ToString();
                        button.CommandName = "EventId";
                        button.Click += new EventHandler(AttendEvent);
                        c8.Controls.Add(button);
                    }
                    tr.Cells.Add(c8);
                    tr.BackColor = Color.FloralWhite;
                    feedTable.Rows.Add(tr);
                }
            }
        }

        // Button event handler to process attend event.
        protected void AttendEvent(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.CommandName == "EventId")
            {
                // Get the event id and add it to xml file.
                string cmd = btn.CommandArgument.ToString();
                string[] splitCmd = cmd.Split('~');
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fileLoc);
                XmlNode ev = xmldoc.SelectSingleNode(@"//Events/Event/Title[text()='" + splitCmd[0] + "']");
                XmlElement elem = xmldoc.CreateElement("Name");
                string user = Request.Cookies["Login"]["username"];
                elem.InnerText = user;
                XmlNode Attendees = ev.ParentNode.LastChild;
                XmlNode Count = Attendees.FirstChild;
                int count = Convert.ToInt32(Count.InnerText);
                count++;
                Count.InnerText = count.ToString();
                Attendees.AppendChild(elem);
                xmldoc.Save(fileLoc);
                int j = Convert.ToInt32(splitCmd[1]);
                feedTable.Rows[j].Cells[5].Controls.RemoveAt(0);
                feedTable.Rows[j].Cells[5].Controls.Add(new LiteralControl("Attending"));
                feedTable.Rows[j].Cells[4].Text = count.ToString();
                string message = "Success. You are attending " + splitCmd[0];
                
                // Display a message in the page indicating response.
                feedTableLabel.Text = message;
            }
        }
    }
}