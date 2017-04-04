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
    public interface IPromotionsServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "v1/promotions", ResponseFormat = WebMessageFormat.Json)]
        List<PromotionBE> ListarPromociones();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "v1/promotions/{id}", ResponseFormat = WebMessageFormat.Json)]
        PromotionBE ObtenerPromocion(string id);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "v1/promotions", ResponseFormat = WebMessageFormat.Json)]
        PromotionBE CrearPromociones(PromotionBE Promocion);
    }
}
