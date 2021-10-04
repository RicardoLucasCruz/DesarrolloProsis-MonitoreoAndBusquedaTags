using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Net.NetworkInformation;
using System.IO;
using System.Configuration;

namespace Monitoreo
{
    class Metodos
    {
        static public string ValidarRuta(string Ruta)
        {
            //Intancia de un objeto de la clase UserImpersonation para obtener el permiso de entrar a la carpeta compartida
            //UserImpersonation user = new UserImpersonation("Administrador", "10.1.1.87", "Cz1GvqqWR3");
            string Variable = "";
            try
            {
                string[] Directorio = Directory.GetFiles($@"{Ruta}\\PARAM\\ACTUEL\\");

                foreach (var item in Directorio)
                {
                    if (/*item.Substring(34, 8) */item.Contains("LSTABINT"))
                    {
                        return Variable = item.Substring(item.Length - 12, 12);
                    }
                }
            }
            catch (Exception)
            {
                try
                {
                    string[] Directorio = Directory.GetFiles($@"{Ruta}\PARAM\ACTUEL\");

                    foreach (var item in Directorio)
                    {
                        if (/*item.Substring(34, 8) */item.Contains("LSTABINT"))
                        {
                            return Variable = item.Substring(item.Length - 12, 12);
                        }
                    }
                }
                catch (Exception)
                {
                    return Variable = "Sin conexion, o ruta no encontrada";
                    throw;
                }
            }

            return Variable;
        }
        static public string ValidarRutaLarga(string Ruta)
        {
            //Intancia de un objeto de la clase UserImpersonation para obtener el permiso de entrar a la carpeta compartida
            //UserImpersonation user = new UserImpersonation("Administrador", "10.1.1.87", "Cz1GvqqWR3");
            string Variable = "";
            try
            {
                string[] Directorio = Directory.GetFiles($@"{Ruta}");

                foreach (var item in Directorio)
                {
                    if (/*item.Substring(34, 8) */item.Contains("LSTABINT"))
                    {
                        return Variable = item.Substring(item.Length - 12, 12);
                    }
                }
            }
            catch (Exception)
            {
                return Variable = "Sin conexion, o ruta no encontrada";
                throw;
            }

            return Variable;
        }

        static public string BuscarTag(string ruta, string tag)
        {
            try
            {
                foreach (string item in File.ReadAllLines(ruta, Encoding.Default))
                {
                    if (item.Contains(tag))
                        return item;
                }
                return "No se encontro la ruta";
            }
            catch (Exception)
            {

                return "No se encontro la ruta";
                throw;
            }

        }
        /// <summary>
        /// Metodo para traer el nombre del archivo lstbint
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        static public string NombreLSTABINT(string IP)
        {
            //Intancia de un objeto de la clase UserImpersonation para obtener el permiso de entrar a la carpeta compartida
            //UserImpersonation user = new UserImpersonation("Administrador", "10.1.1.87", "Cz1GvqqWR3");
            try
            {
                string[] Directorio = Directory.GetFiles($@"{IP}\\PARAM\\ACTUEL\\");

                foreach (var item in Directorio)
                {
                    if (/*item.Substring(34, 8) */item.Contains("LSTABINT"))
                    {
                        return item.Substring(item.Length - 12, 12);
                    }
                }

                return "";
            }
            catch (Exception)
            {
                string[] Directorio2 = Directory.GetFiles($@"{IP}\PARAM\ACTUEL\");

                foreach (var item in Directorio2)
                {
                    if (/*item.Substring(34, 8) */item.Contains("LSTABINT"))
                    {
                        return item.Substring(item.Length - 12, 12);
                    }
                }

                return "";
                throw;
            }           
        }
        /// <summary>
        /// Metodo que hace actualizaciones a la bandera de esa plaza dependiendo de el codigo que se le mande
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Codigo"></param>
       static public void InsertLog(string IP, int Codigo)
       {
           try
           {
               SqlConnection conn = new SqlConnection(Convert.ToString(ConfigurationManager.ConnectionStrings["Global"]));
               conn.Open();

               switch (Codigo)
               {
                   case 100:
                       string conConexion = $"UPDATE Flag SET Conexion = 0 WHERE IP = '{IP}'";

                       SqlCommand cmdDos = new SqlCommand();
                       cmdDos.CommandText = conConexion;
                       cmdDos.Connection = conn;
                       cmdDos.ExecuteScalar();
                       break;
                   case 101:
                       string conConexion2 = $"UPDATE Flag SET Conexion = 1 WHERE IP = '{IP}'";

                       SqlCommand cmdDos2 = new SqlCommand();
                       cmdDos2.CommandText = conConexion2;
                       cmdDos2.Connection = conn;
                       cmdDos2.ExecuteScalar();
                       break;
                   case 200:
                       string conConexion3 = $"UPDATE Flag SET Listas = 0 WHERE IP = '{IP}'";

                       SqlCommand cmdDos3 = new SqlCommand();
                       cmdDos3.CommandText = conConexion3;
                       cmdDos3.Connection = conn;
                       cmdDos3.ExecuteScalar();
                       break;
                   case 201:
                       string conConexion4 = $"UPDATE Flag SET Listas = 1 WHERE IP = '{IP}'";

                       SqlCommand cmdDos4 = new SqlCommand();
                       cmdDos4.CommandText = conConexion4;
                       cmdDos4.Connection = conn;
                       cmdDos4.ExecuteScalar();
                       break;
                   case 400:
                       string conConexion5 = $"UPDATE Flag SET WS = 0 WHERE IP = '{IP}'";

                       SqlCommand cmdDos5 = new SqlCommand();
                       cmdDos5.CommandText = conConexion5;
                       cmdDos5.Connection = conn;
                       cmdDos5.ExecuteScalar();
                       break;
                   case 401:
                       string conConexion6 = $"UPDATE Flag SET WS = 1 WHERE IP = '{IP}'";

                       SqlCommand cmdDos6 = new SqlCommand();
                       cmdDos6.CommandText = conConexion6;
                       cmdDos6.Connection = conn;
                       cmdDos6.ExecuteScalar();
                       break;
                   case 500:
                       string conConexion7 = $"UPDATE Flag SET LSTABINT = 0 WHERE IP = '{IP}'";
                       SqlCommand cmdDos7 = new SqlCommand();
                       cmdDos7.CommandText = conConexion7;
                       cmdDos7.Connection = conn;
                       cmdDos7.ExecuteScalar();
                       break;
                   case 501:
                       string conConexion8 = $"UPDATE Flag SET LSTABINT = 1 WHERE IP = '{IP}'";
                       SqlCommand cmdDos8 = new SqlCommand();
                       cmdDos8.CommandText = conConexion8;
                       cmdDos8.Connection = conn;
                       cmdDos8.ExecuteScalar();
                       break;
                   case 600:
                       string conConexion9 = $"UPDATE Flag SET Tamaño = 0 WHERE IP = '{IP}'";

                       SqlCommand cmdDos9 = new SqlCommand();
                       cmdDos9.CommandText = conConexion9;
                       cmdDos9.Connection = conn;
                       cmdDos9.ExecuteScalar();
                       break;
                   case 601:
                       string conConexion10 = $"UPDATE Flag SET Tamaño = 1 WHERE IP = '{IP}'";

                       SqlCommand cmdDos10 = new SqlCommand();
                       cmdDos10.CommandText = conConexion10;
                       cmdDos10.Connection = conn;
                       cmdDos10.ExecuteScalar();
                       break;

                   default:
                       break;
               }
               conn.Close();
           }
           catch (Exception )
           {

               throw;
           }
       }
    }
}
