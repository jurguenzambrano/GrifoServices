using GrifoServices.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrifoServices.DataAccess
{
    public class PromocionesDA
    {
        private string cadenaConexion = "Server=b1f92bbf-b111-4b5d-ac78-a74401748837.sqlserver.sequelizer.com;Database=dbb1f92bbfb1114b5dac78a74401748837;User ID = otqqdsefejjhblan; Password=ypEaPchU6ejzYVzD6Pe4MLFSsUMGqHXSLuW7Ee8EMZRdHTvv52uwvf3URUP3wGCv;";

        public PromocionBE Crear(PromocionBE promocionACrear)
        {
            PromocionBE productoCreado = null;
            string sql = "INSERT INTO PROMOCIONES (CODIGO, NOMBRE, DESCRIPCION, RUTAIMAGEN, ESTADO) VALUES (@Codigo, @Nombre, @Descripcion, @RutaImagen, @Estado)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Codigo", promocionACrear.Codigo));
                    comando.Parameters.Add(new SqlParameter("@Nombre", promocionACrear.Nombre));
                    comando.Parameters.Add(new SqlParameter("@Descripcion", promocionACrear.Descripcion));
                    comando.Parameters.Add(new SqlParameter("@RutaImagen", promocionACrear.RutaImagen));
                    comando.Parameters.Add(new SqlParameter("@Estado", promocionACrear.Estado));
                    comando.ExecuteNonQuery();
                }
            }
            productoCreado = Obtener(promocionACrear.Codigo);
            return productoCreado;
        }

        public PromocionBE Obtener(string Codigo)
        {
            PromocionBE productoEncontrado = null;
            string sql = "SELECT * FROM PROMOCIONES WHERE CODIGO = @Codigo";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Codigo", Codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            productoEncontrado = new PromocionBE()
                            {
                                Codigo = (string)resultado["Codigo"],
                                Nombre = (string)resultado["Nombre"],
                                Descripcion = (string)resultado["Descripcion"],
                                RutaImagen = (string)resultado["RutaImagen"],
                                Estado = (int)resultado["Estado"],
                                Id = (int)resultado["Id"]
                            };

                        }
                    }
                }
            }
            return productoEncontrado;
        }

        public PromocionBE Obtener(int Id)
        {
            PromocionBE productoEncontrado = null;
            string sql = "SELECT * FROM PROMOCIONES WHERE ID = @Id";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Id", Id));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            productoEncontrado = new PromocionBE()
                            {
                                Codigo = (string)resultado["Codigo"],
                                Nombre = (string)resultado["Nombre"],
                                Descripcion = (string)resultado["Descripcion"],
                                RutaImagen = (string)resultado["RutaImagen"],
                                Estado = (int)resultado["Estado"],
                                Id = (int)resultado["Id"]
                            };

                        }
                    }
                }
            }
            return productoEncontrado;
        }

        public List<PromocionBE> Listar()
        {
            List<PromocionBE> promocionesEncontrados = new List<PromocionBE>();
            PromocionBE promocionEncontrado = null;
            string sql = "SELECT * FROM PROMOCIONES WHERE ESTADO = 1";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    //comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            promocionEncontrado = new PromocionBE()
                            {
                                Id = (int)resultado["Id"],
                                Codigo = (string)resultado["Codigo"],
                                Nombre = (string)resultado["Nombre"],
                                Descripcion = (string)resultado["Descripcion"],
                                RutaImagen = (string)resultado["rutaImagen"],
                                Estado = (int)resultado["Estado"]
                            };
                            promocionesEncontrados.Add(promocionEncontrado);
                        }
                    }
                }
            }
            return promocionesEncontrados;
        }
    }
}