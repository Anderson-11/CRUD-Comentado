using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DatosLayer
{
    public class DataBase
    {
        // Cadena de conexión a la base de datos
        public static string ConnectionString
        {
            get
            {
                // Obtiene la cadena de conexión del archivo de configuración
                string CadenaConexion = ConfigurationManager
                    .ConnectionStrings["NWConnection"]
                    .ConnectionString;

                // Construye un objeto SqlConnectionStringBuilder
                SqlConnectionStringBuilder conexionBuilder =
                    new SqlConnectionStringBuilder(CadenaConexion);

                // Establece el nombre de la aplicación (opcional)
                conexionBuilder.ApplicationName =
                    ApplicationName ?? conexionBuilder.ApplicationName;

                // Establece el tiempo de espera de conexión (opcional)
                conexionBuilder.ConnectTimeout = (ConnectionTimeout > 0)
                    ? ConnectionTimeout : conexionBuilder.ConnectTimeout;

                // Devuelve la cadena de conexión formateada
                return conexionBuilder.ToString();
            }
        }

        // Tiempo de espera de conexión (en segundos)
        public static int ConnectionTimeout { get; set; }

        // Nombre de la aplicación que se conecta (opcional)
        public static string ApplicationName { get; set; }

        // Obtiene una conexión abierta a la base de datos
        public static SqlConnection GetSqlConnection()
        {
            // Crea una conexión con la cadena de conexión
            SqlConnection conexion = new SqlConnection(ConnectionString);

            // Abre la conexión
            conexion.Open();

            // Devuelve la conexión abierta
            return conexion;
        }
    }
}
