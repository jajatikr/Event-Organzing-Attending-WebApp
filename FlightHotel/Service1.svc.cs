using Google.Apis.QPXExpress.v1;
using Google.Apis.QPXExpress.v1.Data;
using Google.Apis.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;

namespace FlightHotel
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<Flight> GetFlights(string OriginVal, string DestinationVal, string DateVal, int AdultsVal, string CabinVal)
        {
            try
            {
                // Google QPX Flights API
                Int32 NumberOfResults = 5;
                QPXExpressService service = new QPXExpressService(new BaseClientService.Initializer()
                {
                    ApiKey = "AIzaSyAK6ZE-nAY0tIAku_LB9C3INCK45oSyYHQ",
                    ApplicationName = "Flight WCF Service",
                });
                TripsSearchRequest requestBody = new TripsSearchRequest();
                requestBody.Request = new TripOptionsRequest();
                requestBody.Request.Passengers = new PassengerCounts { AdultCount = AdultsVal };
                requestBody.Request.Slice = new List<SliceInput>();
                requestBody.Request.Slice.Add(new SliceInput() { Origin = OriginVal, Destination = DestinationVal, Date = DateVal, PreferredCabin = CabinVal });
                requestBody.Request.Solutions = NumberOfResults;
                TripsSearchResponse result = service.Trips.Search(requestBody).Execute();

                List<Flight> AllFlights = new List<Flight>();

                foreach (var trip in result.Trips.TripOption)
                {
                    Flight IndividualFlight = new Flight();
                    IndividualFlight.TotalPrice = trip.SaleTotal;
                    IndividualFlight.FlightDetails = new List<LegDetails>();
                    foreach (var tripSlice in trip.Slice)
                    {
                        foreach (var tripSliceSegment in tripSlice.Segment)
                        {
                            foreach (var tripSliceSegmentLeg in tripSliceSegment.Leg)
                            {
                                LegDetails EachLegDetail = new LegDetails();
                                EachLegDetail.FlightNumber = tripSliceSegment.Flight.Carrier + " " + tripSliceSegment.Flight.Number;
                                EachLegDetail.SrcTime = tripSliceSegmentLeg.DepartureTime;
                                EachLegDetail.Src = tripSliceSegmentLeg.Origin;
                                EachLegDetail.Dst = tripSliceSegmentLeg.Destination;
                                EachLegDetail.DstTime = tripSliceSegmentLeg.ArrivalTime;
                                IndividualFlight.FlightDetails.Add(EachLegDetail);
                            }
                        }

                    }
                    AllFlights.Add(IndividualFlight);
                }
                return AllFlights;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // GetFlights ends

        public List<Hotel> GetNearbyHotels(string Location)
        {
            WebClient webClient = new WebClient();
            List<Hotel> AllHotels = new List<Hotel>();
            try
            {
                // Find latitude and longitude
                String baseUrl = "http://maps.googleapis.com/maps/api/geocode/json?address=" + Location;
                string response = webClient.DownloadString(baseUrl);
                JObject jsonObject = JObject.Parse(response);
                JToken jsonLatLong = jsonObject["results"][0]["geometry"]["location"];
                string latitude = jsonLatLong["lat"].ToString();
                string longitude = jsonLatLong["lng"].ToString();

                // Find nearest store
                baseUrl = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latitude + "," + longitude + "&rankby=distance&type=lodging&key=AIzaSyAK6ZE-nAY0tIAku_LB9C3INCK45oSyYHQ";
                response = webClient.DownloadString(baseUrl);
                jsonObject = JObject.Parse(response);
                foreach (JToken result in jsonObject["results"])
                {
                    Hotel IndividualHotel = new Hotel();
                    IndividualHotel.Name = result["name"].ToString();
                    IndividualHotel.Address = result["vicinity"].ToString();
                    if (result["rating"] == null)
                    {
                        IndividualHotel.Rating = "No rating";
                    }
                    else
                    {
                        IndividualHotel.Rating = result["rating"].ToString();
                    }
                    AllHotels.Add(IndividualHotel);
                }
                return AllHotels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // GetNearbyHotels ends
    }
}
