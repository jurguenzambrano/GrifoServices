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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFuelStationServices" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFuelStationServices
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "fuelstations", ResponseFormat = WebMessageFormat.Json)]
        List<FuelStationBE> ListarEstaciones();
    }
}
