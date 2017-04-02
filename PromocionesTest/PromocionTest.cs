using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using GrifoServices.BusinessEntity;

namespace PromocionesTest
{
    [TestClass]
    public class PromocionTest
    {
        
        [TestMethod]
        public void insertarPromocion()
        {
            string usuario;
            byte[] data;
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Prueba de creación de usuario 
            usuario = "{\"Id\":\"0\",\"Code\":\"PROMOCION01\",\"Name\":\"PROMOCION DE VERANO 2017\",\"Description\":\"Promoción valida del 28 de diciembre del 2016 al 30 de Abril del 2017\",\"PathImage\":\"rutaimagen.jpg\",\"State\":\"1\"}";
            data = Encoding.UTF8.GetBytes(usuario);

            req = (HttpWebRequest)WebRequest.Create("http://localhost:41084/PromotionsServices.svc/promotions");
            req.Method = "POST";
            req.ContentLength = data.Length;
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                PromotionBE promocion = js.Deserialize<PromotionBE>(usuarioJson);
                Assert.AreEqual("PROMOCION01", promocion.Code);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Código de Producto ya registrado.", mensaje);
            }
        }
        
    }
}
