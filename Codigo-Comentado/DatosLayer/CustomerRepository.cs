using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {
        // Este método obtiene todos los clientes de la base de datos
        public List<Customers> ObtenerTodos()
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String selectFrom = "";

                // Construye la sentencia SQL SELECT para recuperar datos de clientes
                selectFrom += "SELECT [CustomerID], \n";
                selectFrom += "       [CompanyName], \n";
                selectFrom += "       [ContactName], \n";
                selectFrom += "       [ContactTitle], \n";
                selectFrom += "       [Address], \n";
                selectFrom += "       [City], \n";
                selectFrom += "       [Region], \n";
                selectFrom += "       [PostalCode], \n";
                selectFrom += "       [Country], \n";
                selectFrom += "       [Phone], \n";
                selectFrom += "       [Fax] \n";
                selectFrom += "FROM [dbo].[Customers]";

                using (SqlCommand comando = new SqlCommand(selectFrom, conexion)) // Crea un objeto de comando
                {
                    SqlDataReader reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene el lector
                    List<Customers> clientes = new List<Customers>(); // Crea una lista para almacenar clientes

                    while (reader.Read()) // Recorre cada fila del conjunto de resultados
                    {
                        var cliente = LeerDelDataReader(reader); // Lee los datos del cliente del lector
                        clientes.Add(cliente); // Agrega el objeto de cliente a la lista
                    }

                    return clientes; // Devuelve la lista de clientes
                }
            }
        }
        public Customers ObtenerPorID(string id) // Este método obtiene un cliente por su ID
        {
            using (var conexion = DataBase.GetSqlConnection()) // Abre una conexión a la base de datos
            {
                String selectForID = "";

                // Construye la sentencia SQL SELECT para recuperar datos de cliente por ID
                selectForID += "SELECT [CustomerID], \n";
                selectForID += "       [CompanyName], \n";
                selectForID += "       [ContactName], \n";
                selectForID += "       [ContactTitle], \n";
                selectForID += "       [Address], \n";
                selectForID += "       [City], \n";
                selectForID += "       [Region], \n";
                selectForID += "       [PostalCode], \n";
                selectForID += "       [Country], \n";
                selectForID += "       [Phone], \n";
                selectForID += "       [Fax] \n";
                selectForID += "FROM [dbo].[Customers] \n";
                selectForID += $"Where CustomerID = @customerId"; // Agrega parámetro para ID

                using (SqlCommand comando = new SqlCommand(selectForID, conexion)) // Crea un objeto de comando
                {
                    comando.Parameters.AddWithValue("customerId", id); // Agrega el valor de ID al parámetro

                    var reader = comando.ExecuteReader(); // Ejecuta la consulta y obtiene el lector
                    Customers customers = null;

                    // Verifica si se encontró un registro de cliente
                    if (reader.Read())
                    {
                        customers = LeerDelDataReader(reader); // Lee los datos del cliente del lector
                    }

                    return customers; // Devuelve el objeto de cliente (o null si no se encontró)
                }
            }
        }
        public Customers LeerDelDataReader(SqlDataReader reader) // Lee los datos del cliente del lector de datos
        {
            Customers customers = new Customers();

            // Verifica y maneja valores nulos del lector
            customers.CustomerID = reader["CustomerID"] == DBNull.Value ? " " : (String)reader["CustomerID"];
            customers.CompanyName = reader["CompanyName"] == DBNull.Value ? "" : (String)reader["CompanyName"];
            customers.ContactName = reader["ContactName"] == DBNull.Value ? "" : (String)reader["ContactName"];
            customers.ContactTitle = reader["ContactTitle"] == DBNull.Value ? "" : (String)reader["ContactTitle"];
            customers.Address = reader["Address"] == DBNull.Value ? "" : (String)reader["Address"];
            customers.City = reader["City"] == DBNull.Value ? "" : (String)reader["City"];
            customers.Region = reader["Region"] == DBNull.Value ? "" : (String)reader["Region"];
            customers.PostalCode = reader["PostalCode"] == DBNull.Value ? "" : (String)reader["PostalCode"];
            customers.Country = reader["Country"] == DBNull.Value ? "" : (String)reader["Country"];
            customers.Phone = reader["Phone"] == DBNull.Value ? "" : (String)reader["Phone"];
            customers.Fax = reader["Fax"] == DBNull.Value ? "" : (String)reader["Fax"];

            return customers;
        }
        //-------------
        public int InsertarCliente(Customers customer)
        {
            // Conecta a la base de datos
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para insertar un nuevo cliente
                String insertInto = "";
                insertInto = insertInto + "INSERT INTO [dbo].[Customers] " + "\n";
                insertInto = insertInto + "           ([CustomerID] " + "\n";
                insertInto = insertInto + "           ,[CompanyName] " + "\n";
                insertInto = insertInto + "           ,[ContactName] " + "\n";
                insertInto = insertInto + "           ,[ContactTitle] " + "\n";
                insertInto = insertInto + "           ,[Address] " + "\n";
                insertInto = insertInto + "           ,[City]) " + "\n";
                insertInto = insertInto + "     VALUES " + "\n";
                insertInto = insertInto + "           (@CustomerID " + "\n";
                insertInto = insertInto + "           ,@CompanyName " + "\n";
                insertInto = insertInto + "           ,@ContactName " + "\n";
                insertInto = insertInto + "           ,@ContactTitle " + "\n";
                insertInto = insertInto + "           ,@Address " + "\n";
                insertInto = insertInto + "           ,@City)";

                // Ejecuta la consulta SQL
                using (var comando = new SqlCommand(insertInto, conexion))
                {
                    // Agrega los parámetros del cliente a la consulta
                    int insertados = parametrosCliente(customer, comando);
                    return insertados;
                }
            }
        }
        //-------------
        public int ActualizarCliente(Customers customer)
        {
            // Conecta a la base de datos
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para actualizar un cliente
                String ActualizarCustomerPorID = "";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "UPDATE [dbo].[Customers] " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "   SET [CustomerID] = @CustomerID " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[CompanyName] = @CompanyName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactName] = @ContactName " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[ContactTitle] = @ContactTitle " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[Address] = @Address " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + "      ,[City] = @City " + "\n";
                ActualizarCustomerPorID = ActualizarCustomerPorID + " WHERE CustomerID= @CustomerID";

                // Ejecuta la consulta SQL
                using (var comando = new SqlCommand(ActualizarCustomerPorID, conexion))
                {
                    // Agrega los parámetros del cliente a la consulta
                    int actualizados = parametrosCliente(customer, comando);
                    return actualizados;
                }
            }
        }

        public int parametrosCliente(Customers customer, SqlCommand comando)
        {
            // Agrega los parámetros del cliente a la consulta SQL
            comando.Parameters.AddWithValue("CustomerID", customer.CustomerID);
            comando.Parameters.AddWithValue("CompanyName", customer.CompanyName);
            comando.Parameters.AddWithValue("ContactName", customer.ContactName);
            comando.Parameters.AddWithValue("ContactTitle", customer.ContactTitle);
            comando.Parameters.AddWithValue("Address", customer.Address);
            comando.Parameters.AddWithValue("City", customer.City);

            // Ejecuta la consulta y obtiene el número de registros afectados
            var insertados = comando.ExecuteNonQuery();
            return insertados;
        }

        public int EliminarCliente(string id)
        {
            // Conecta a la base de datos
            using (var conexion = DataBase.GetSqlConnection())
            {
                // Construye la consulta SQL para eliminar un cliente
                String EliminarCliente = "";
                EliminarCliente = EliminarCliente + "DELETE FROM [dbo].[Customers] " + "\n";
                EliminarCliente = EliminarCliente + "      WHERE CustomerID = @CustomerID";

                // Ejecuta la consulta SQL
                using (SqlCommand comando = new SqlCommand(EliminarCliente, conexion))
                {
                    // Agrega el ID del cliente como parámetro
                    comando.Parameters.AddWithValue("@CustomerID", id);

                    // Ejecuta la consulta y obtiene el número de registros eliminados
                    int eliminados = comando.ExecuteNonQuery();
                    return eliminados;
                }
            }
        }
    }
}
