using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace FlightHotel
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Flight> GetFlights(string Origin, string Destination, string Date, int Adults, string Cabin);

        [OperationContract]
        List<Hotel> GetNearbyHotels(string Location);
    }


    [MessageContract]
    public class Flight
    {
        [MessageBodyMember]
        public string TotalPrice { get; set; }

        [MessageBodyMember]
        public List<LegDetails> FlightDetails { get; set; }
    }

    [DataContract]
    public class LegDetails
    {
        [DataMember]
        public string FlightNumber { get; set; }

        [DataMember]
        public string Src { get; set; }

        [DataMember]
        public string Dst { get; set; }

        [DataMember]
        public string SrcTime { get; set; }

        [DataMember]
        public string DstTime { get; set; }
    }

    [MessageContract]
    public class Hotel
    {
        [MessageBodyMember]
        public string Name { get; set; }

        [MessageBodyMember]
        public string Address { get; set; }

        [MessageBodyMember]
        public string Rating { get; set; }
    }
}
