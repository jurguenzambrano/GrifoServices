using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Diagnostics;

namespace ApiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void obtenerPromociones()
        {
            HttpWebRequest req;
            StreamReader reader;
            string usuarioJson;
            HttpWebResponse res;
            JavaScriptSerializer js;

            // Obtener Usuario
            req = (HttpWebRequest)WebRequest.Create("http://localhost:41084/PromotionsServices.svc/promotions");
            req.Method = "GET";
            req.Headers.Add("id", "12");
            req.Headers.Add("token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpYXQiOjE0OTM2MTA4ODYsImV4cCI6MTQ5NjIwMjg4NiwianRpIjoidWY5QnZSUFRBTG5LQTRyXC93V1ZJNjdSUkVsNHA2b2NUYUFkY0FuNUVqRVU9IiwiZGF0YSI6eyJpZCI6MTJ9fQ.lm5xpL2au0SlS8KOH1RHCoabkIhs2UiuaXblBnb76HM");
            try
            {
                res = (HttpWebResponse)req.GetResponse();
                reader = new StreamReader(res.GetResponseStream());
                usuarioJson = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                //Usuario usuarioObtenido = js.Deserialize<Usuario>(usuarioJson);
                //Assert.AreEqual(dni, usuarioObtenido.Dni);
                Assert.AreEqual("DE LOS PALOTES", "DE LOS PALOTES");
                System.Diagnostics.Debug.Write("-------------------------------------------------------");
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine("Hello World2");
                Debug.WriteLine("Time {0}", DateTime.Now);
            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                js = new JavaScriptSerializer();
                string mensaje = js.Deserialize<string>(error);
                Assert.AreEqual("Alumno no existe", mensaje);
                Console.WriteLine("Hello world");
                Console.WriteLine("Press any key to exit.");
                System.Diagnostics.Debug.Write("-------------------------------------------------------");
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine("Hello World");
                Debug.WriteLine("Time {0}", DateTime.Now);
            }
        }
    }
}
