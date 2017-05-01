using GrifoServices.BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GrifoServices.DataAccess
{
    public class FuelStationsDA
    {
        private string cadenaConexion = "Server=ae9ca6de-d177-4ed1-9f2a-a74b00e16461.sqlserver.sequelizer.com;Database=dbae9ca6ded1774ed19f2aa74b00e16461;User ID=daqpvbwzmtktbvkg;Password=BgH6oxQtJGWMGfHxyq53ujmgYpDMNAyuNfT4dGuSsuarpovxmauV4E4s4Bg82cMi;";
        public List<FuelStationBE> Listar()
        {
            List<FuelStationBE> fuelStationEncontrados = new List<FuelStationBE>();
            FuelStationBE fuelStationEncontrado = null;
            string sql = "SELECT * FROM FUELSTATIONS";
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
                            fuelStationEncontrado = new FuelStationBE()
                            {
                                id = (int)resultado["Id"],
                                name = (string)resultado["Name"],
                                address = (string)resultado["Address"],
                                altitude = (decimal)resultado["Altitude"],
                                latitude = (decimal)resultado["Latitude"],
                                type = (string)resultado["Type"]
                            };
                            fuelStationEncontrados.Add(fuelStationEncontrado);
                        }
                    }
                }
            }
            return fuelStationEncontrados;
        }
    }
}