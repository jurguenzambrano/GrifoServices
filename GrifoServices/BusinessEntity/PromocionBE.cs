using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace GrifoServices.BusinessEntity
{
    [DataContract]
    public class PromocionBE
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string RutaImagen { get; set; }
        [DataMember]
        public int Estado { get; set; }
    }
}