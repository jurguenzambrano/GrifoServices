using GrifoServices.BusinessEntity;
using GrifoServices.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Serialization;

namespace GrifoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PromocionesServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PromocionesServices.svc o PromocionesServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PromocionesServices : IPromotionsServices
    {
        private PromotionBE producto = new PromotionBE();
        private PromotionsDA promociones = new PromotionsDA();

        public PromotionBE CrearPromociones(PromotionBE promocion)
        {
            if (promociones.Obtener(promocion.Code) != null){
                throw new WebFaultException<string>("Código de Producto ya registrado.", HttpStatusCode.Conflict);
            }
            producto = promociones.Crear(promocion);
            if (producto != null)
            {
                return producto;
            }else
            {
                throw new WebFaultException<string>("Error al crear producto.", HttpStatusCode.InternalServerError);
            }
        }

        public List<PromotionBE> ListarPromociones()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Obtener Usuario
            req = (HttpWebRequest)WebRequest.Create("http://api.fuel.maraquya.com/users/3");
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
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();

                return promociones.Listar();
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                throw new WebFaultException<string>("Error al validar token.", HttpStatusCode.InternalServerError);
            }

            
        }

        public PromotionBE ObtenerPromocion(string id)
        {
            producto = promociones.Obtener(int.Parse(id));
            if (producto != null)
            {
                return producto;
            }
            else
            {
                throw new WebFaultException<string>("Error al obtener promocion.", HttpStatusCode.NotFound);
            }
        }
    }
}
