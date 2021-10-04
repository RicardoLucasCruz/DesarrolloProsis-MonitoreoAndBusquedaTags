using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Monitoreo
{
    class getBanderas
    {
        /// <summary>
        /// Metodo para traer todas las banderas de las bases de datos
        /// </summary>
        /// <param name="strinConexion"></param>
        /// <returns></returns>
        public static List<Flag> GetAll(string strinConexion)
        {
            List<Flag> getBanderas = new List<Flag>();

            try
            {
                SqlConnection conn = new SqlConnection(strinConexion);
                {
                    conn.Open();

                    const string sqlQuery = "select id_Flag, Conexion, LSTABINT, WS, Tamaño from Flag";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            Flag flag = new Flag
                            {
                                id_flag = Convert.ToInt16(dataReader["id_flag"]),
                                conexion = Convert.ToBoolean(dataReader["conexion"]),
                                LSTABINT = Convert.ToBoolean(dataReader["LSTABINT"]),
                                WS = Convert.ToBoolean(dataReader["WS"]),
                                tam = Convert.ToBoolean(dataReader["Tamaño"]),
                            };
                            getBanderas.Add(flag);
                        }
                    }
                    conn.Close();
                    return getBanderas;
                }
            }
            catch (Exception)
            {
                return getBanderas;
                throw;
            }
        }
        ///// <summary>
        ///// Metodo que se utiliza para traer el id de plaza mediante el ip
        ///// </summary>
        ///// <param name="IP"></param>
        ///// <param name="StringdeConexion"></param>
        ///// <returns></returns>
        //public static Flag GetByIP(string IP, string StringdeConexion)
        //{
        //    SqlConnection conn = new SqlConnection(StringdeConexion);

        //    conn.Open();

        //    const string sqlGetByUsuAlum = "select * from flag where ip = @ip";
        //    using (SqlCommand cmd = new SqlCommand(sqlGetByUsuAlum, conn))
        //    {
        //        cmd.Parameters.AddWithValue("@ip", IP);
        //        SqlDataReader dataReader = cmd.ExecuteReader();
        //        if (dataReader.Read())
        //        {
        //            Flag flag = new Flag
        //            {
        //                id_PLaza = Convert.ToInt32(dataReader["id_Plaza"]),
        //            };

        //            return flag;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }

        //}
    }
}
