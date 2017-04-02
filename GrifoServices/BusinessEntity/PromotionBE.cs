using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GrifoServices.BusinessEntity
{
    [DataContract]
    public class PromotionBE
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string PathImage { get; set; }
        [DataMember]
        public int State { get; set; }
    }
}