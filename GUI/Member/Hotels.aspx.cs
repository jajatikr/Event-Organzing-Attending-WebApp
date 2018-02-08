using System;
using System.Drawing;
using System.Linq;
using System.Text;

/*
* Details: Provides form to display user input nearby hotels details
*/

namespace GUI.Member
{
    public partial class Hotels : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check user in cookies. If user is not present - redirect to homepage
            if (!Request.Cookies.AllKeys.Contains("Login"))
            {
                Response.Redirect("~/");
                return;
            }
        }

        protected void HotelsResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate whether fields are empty
                if (!string.IsNullOrWhiteSpace(LocationTextBox.Text))
                {
                    // Create Flight and Hotel service reference proxy
                    FlightHotelServiceReference.Service1Client proxy = new FlightHotelServiceReference.Service1Client();

                    // Get hotel details
                    FlightHotelServiceReference.Hotel[] AllHotels = proxy.GetNearbyHotels(LocationTextBox.Text);

                    // Create HTML table string to display hotel details
                    StringBuilder hotels = new StringBuilder("<table class=\"tg\"><tr><th class=\"tg-bwhq\">Name</th><th class=\"tg-bwhq\">Address</th><th class=\"tg-bwhq\">Rating</th></tr>");
                    foreach (FlightHotelServiceReference.Hotel hotel in AllHotels)
                    {
                        hotels.Append("<tr>");
                        hotels.Append("<td class=\"tg-yw4l\">" + hotel.Name + "</td>");
                        hotels.Append("<td class=\"tg-yw4l\">" + hotel.Address + "</td>");
                        hotels.Append("<td class=\"tg-yw4l\">" + hotel.Rating + "</td>");
                        hotels.Append("</tr>");
                    }
                    hotels.Append("</table>");

                    // Display nearby hotel details HTML string
                    HotelsResultLabel.Text = hotels.ToString();
                }
                else
                {
                    // Display error if empty fields detected
                    HotelsResultLabel.Text = "Empty fields detected";
                    HotelsResultLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                // Display exceptions message if error occurs
                HotelsResultLabel.Text = ex.Message;
                HotelsResultLabel.ForeColor = Color.Red;
            }
        }
    }
}