using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GrifoServices.BusinessEntity
{
    [DataContract]
    public class FuelStationBE
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public decimal altitude { get; set; }
        [DataMember]
        public decimal latitude { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public string type { get; set; }
    }
}