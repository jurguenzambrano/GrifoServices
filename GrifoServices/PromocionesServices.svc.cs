using GrifoServices.BusinessEntity;
using GrifoServices.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GrifoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "PromocionesServices" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione PromocionesServices.svc o PromocionesServices.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class PromocionesServices : IPromocionesServices
    {
        private PromocionBE producto = new PromocionBE();
        private PromocionesDA promociones = new PromocionesDA();

        public PromocionBE CrearPromociones(PromocionBE promocion)
        {
            if (promociones.Obtener(promocion.Codigo) != null){
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

        public List<PromocionBE> ListarPromociones()
        {
            return promociones.Listar();
        }

        public PromocionBE ObtenerPromocion(string id)
        {
            producto = promociones.Obtener(int.Parse(id));
            if (producto != null)
            {
                return producto;
            }
            else
            {
                throw new WebFaultException<string>("Error al obtener producto.", HttpStatusCode.NotFound);
            }
        }
    }
}
