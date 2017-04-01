using GrifoServices.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GrifoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IPromocionesServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IPromocionesServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "promociones", ResponseFormat = WebMessageFormat.Json)]
        List<PromocionBE> ListarPromociones();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "promociones/{id}", ResponseFormat = WebMessageFormat.Json)]
        PromocionBE ObtenerPromocion(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "promociones", ResponseFormat = WebMessageFormat.Json)]
        PromocionBE CrearPromociones(PromocionBE Promocion);
    }
}
