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
        private string cadenaConexion = "Server=ae9ca6de-d177-4ed1-9f2a-a74b00e16461.sqlserver.sequelizer.com;Database=dbae9ca6ded1774ed19f2aa74b00e16461;User ID=daqpvbwzmtktbvkg;Password=BgH6oxQtJGWMGfHxyq53ujmgYpDMNAyuNfT4dGuSsuarpovxmauV4E4s4Bg82cMi;";

        public PromotionBE Crear(PromotionBE promocionACrear)
        {
            PromotionBE productoCreado = null;
            string sql = "INSERT INTO PROMOTIONS (CODE, NAME, DESCRIPTION, PATHIMAGE, STATE) VALUES (@Codigo, @Nombre, @Descripcion, @RutaImagen, @Estado)";
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
            string sql = "SELECT * FROM PROMOTIONS WHERE CODE = @Codigo";

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
                                Code = (string)resultado["Code"],
                                Name = (string)resultado["Name"],
                                Description = (string)resultado["Description"],
                                PathImage = (string)resultado["PathImage"],
                                State = (int)resultado["State"],
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
            string sql = "SELECT * FROM PROMOTIONS WHERE ID = @Id";

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
                                Code = (string)resultado["Code"],
                                Name = (string)resultado["Name"],
                                Description = (string)resultado["Description"],
                                PathImage = (string)resultado["PathImage"],
                                State = (int)resultado["State"],
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
            string sql = "SELECT * FROM PROMOTIONS WHERE STATE = 1";
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
                                Code = (string)resultado["Code"],
                                Name = (string)resultado["Name"],
                                Description = (string)resultado["Description"],
                                PathImage = (string)resultado["PathImage"],
                                State = (int)resultado["State"]
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
