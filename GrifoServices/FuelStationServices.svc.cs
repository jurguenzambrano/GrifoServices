using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GrifoServices.BusinessEntity;
using GrifoServices.DataAccess;
using System.ServiceModel.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace GrifoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FuelStationServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FuelStationServices.svc o FuelStationServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FuelStationServices : IFuelStationServices
    {
        private FuelStationBE producto = new FuelStationBE();
        private FuelStationsDA fuelStations = new FuelStationsDA();

        public List<FuelStationBE> ListarEstaciones()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            HttpWebRequest req;
            StreamReader reader;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Obtener Usuario
            
            req = (HttpWebRequest)WebRequest.Create("http://api.fuel.maraquya.com/users/" + headers["id"]);
            req.Method = "GET";
            req.Headers.Add("token", headers["token"]);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                HttpStatusCode code = res.StatusCode;
                string message = res.StatusDescription;
                if (message != "OK")
                {
                    throw new WebFaultException<string>(message, code);
                }
                //throw new WebFaultException<string>("OK", HttpStatusCode.InternalServerError);
                return fuelStations.Listar();
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                MessageResponse mensajeResponse = js.Deserialize<MessageResponse>(error);
                
                throw new WebFaultException<string>(mensajeResponse.message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
