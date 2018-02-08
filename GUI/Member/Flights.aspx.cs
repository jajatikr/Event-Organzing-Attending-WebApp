using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

/*
* Provides form to display user input flight details
*/

namespace GUI.Member
{
    public partial class Flights : System.Web.UI.Page
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

        protected void FlightServiceSubmit_Click(object sender, EventArgs e)
        {
            try
            {   
                // Save all user-input fields data in string array
                string[] Fields = new string[5] { OriginTextBox.Text, DestinationTextBox.Text, DateTextBox.Text, AdultsDropDownList.SelectedValue, CabinDropDownList.SelectedValue };

                // Validate whether fields are empty
                if (!Fields.Any(eachField => string.IsNullOrWhiteSpace(eachField)))
                {
                    // Create Flight and Hotel service reference proxy
                    FlightHotelServiceReference.Service1Client proxy = new FlightHotelServiceReference.Service1Client();

                    // Get flight details
                    FlightHotelServiceReference.Flight[] AllTheFlights = proxy.GetFlights(Fields[0], Fields[1], Fields[2], Convert.ToInt32(Fields[3]), Fields[4]);
                    List<FlightHotelServiceReference.LegDetails> legsDetails = new List<FlightHotelServiceReference.LegDetails>();

                    // Create HTML table string to display flight details
                    StringBuilder flights = new StringBuilder("<table class=\"tg\"><tr><th class=\"tg-bwhq\">Price</th><th class=\"tg-bwhq\">Flight Number</th><th class=\"tg-bwhq\">Departure Time</th><th class=\"tg-bwhq\">Origin</th><th class=\"tg-bwhq\">Destination</th><th class=\"tg-bwhq\">Arrival Time</th></tr>");
                    foreach (FlightHotelServiceReference.Flight flight in AllTheFlights)
                    {
                        int count = 0;
                        foreach (FlightHotelServiceReference.LegDetails legDetail in flight.FlightDetails)
                        {
                            if (count == 0)
                            {
                                flights.Append("<tr><td class=\"tg-yw4l\" rowspan=" + flight.FlightDetails.Length + ">" + flight.TotalPrice + "</td>");
                            }
                            else
                            {
                                flights.Append("<tr>");
                            }
                            count++;
                            flights.Append("<td class=\"tg-yw4l\">" + legDetail.FlightNumber + "</td>");
                            flights.Append("<td class=\"tg-yw4l\">" + DateTime.Parse(legDetail.SrcTime) + "</td>");
                            flights.Append("<td class=\"tg-yw4l\">" + legDetail.Src + "</td>");
                            flights.Append("<td class=\"tg-yw4l\">" + legDetail.Dst + "</td>");
                            flights.Append("<td class=\"tg-yw4l\">" + DateTime.Parse(legDetail.DstTime) + "</td>");
                            flights.Append("</tr>");
                        }
                    }
                    flights.Append("</table>");

                    // Display flight details HTML string
                    ResultLabel.Text = flights.ToString();
                }
                else
                {
                    // Display error if empty fields detected
                    ResultLabel.Text = "Empty fields detected";
                    ResultLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                // Display exceptions message if error occurs
                ResultLabel.Text = ex.Message;
                ResultLabel.ForeColor = Color.Red;
            }
        }
    }
}