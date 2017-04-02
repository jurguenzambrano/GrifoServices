using GrifoServices.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrifoServices.DataAccess
{
    public class PromotionsDA
    {
        private string cadenaConexion = "Server=b1f92bbf-b111-4b5d-ac78-a74401748837.sqlserver.sequelizer.com;Database=dbb1f92bbfb1114b5dac78a74401748837;User ID = otqqdsefejjhblan; Password=ypEaPchU6ejzYVzD6Pe4MLFSsUMGqHXSLuW7Ee8EMZRdHTvv52uwvf3URUP3wGCv;";

        public PromotionBE Crear(PromotionBE promocionACrear)
        {
            PromotionBE productoCreado = null;
            string sql = "INSERT INTO PROMOCIONES (CODIGO, NOMBRE, DESCRIPCION, RUTAIMAGEN, ESTADO) VALUES (@Codigo, @Nombre, @Descripcion, @RutaImagen, @Estado)";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Codigo", promocionACrear.Code));
                    comando.Parameters.Add(new SqlParameter("@Nombre", promocionACrear.Name));
                    comando.Parameters.Add(new SqlParameter("@Descripcion", promocionACrear.Description));
                    comando.Parameters.Add(new SqlParameter("@RutaImagen", promocionACrear.PathImage));
                    comando.Parameters.Add(new SqlParameter("@Estado", promocionACrear.State));
                    comando.ExecuteNonQuery();
                }
            }
            productoCreado = Obtener(promocionACrear.Code);
            return productoCreado;
        }

        public PromotionBE Obtener(string Codigo)
        {
            PromotionBE productoEncontrado = null;
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
                            productoEncontrado = new PromotionBE()
                            {
                                Code = (string)resultado["Codigo"],
                                Name = (string)resultado["Nombre"],
                                Description = (string)resultado["Descripcion"],
                                PathImage = (string)resultado["RutaImagen"],
                                State = (int)resultado["Estado"],
                                Id = (int)resultado["Id"]
                            };

                        }
                    }
                }
            }
            return productoEncontrado;
        }

        public PromotionBE Obtener(int Id)
        {
            PromotionBE productoEncontrado = null;
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
                            productoEncontrado = new PromotionBE()
                            {
                                Code = (string)resultado["Codigo"],
                                Name = (string)resultado["Nombre"],
                                Description = (string)resultado["Descripcion"],
                                PathImage = (string)resultado["RutaImagen"],
                                State = (int)resultado["Estado"],
                                Id = (int)resultado["Id"]
                            };

                        }
                    }
                }
            }
            return productoEncontrado;
        }

        public List<PromotionBE> Listar()
        {
            List<PromotionBE> promocionesEncontrados = new List<PromotionBE>();
            PromotionBE promocionEncontrado = null;
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
                            promocionEncontrado = new PromotionBE()
                            {
                                Id = (int)resultado["Id"],
                                Code = (string)resultado["Codigo"],
                                Name = (string)resultado["Nombre"],
                                Description = (string)resultado["Descripcion"],
                                PathImage = (string)resultado["rutaImagen"],
                                State = (int)resultado["Estado"]
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