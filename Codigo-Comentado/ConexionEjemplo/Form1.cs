using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    public partial class Form1 : Form
    {
        // Repositorio de clientes (se encarga de la lógica de acceso a datos)
        private CustomerRepository customerRepository = new CustomerRepository();

        public Form1()
        {
            InitializeComponent();
        }

        // Evento clic del botón Cargar
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene todos los clientes del repositorio
            var Clientes = customerRepository.ObtenerTodos();
            // Asigna la lista de clientes como fuente de datos del dataGrid
            dataGrid.DataSource = Clientes;
        }

        // Evento cambio de texto del textBox1 (filtro)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Obtiene todos los clientes del repositorio
            var Clientes = customerRepository.ObtenerTodos();
            // Filtra los clientes que inicien con el texto del filtro
            var filtro = Clientes.FindAll(X => X.CompanyName.StartsWith(tbFiltro.Text));
            // Asigna la lista filtrada como fuente de datos del dataGrid
            dataGrid.DataSource = filtro;
        }

        // Evento Load del formulario (se ejecuta al cargar el formulario)
        private void Form1_Load(object sender, EventArgs e)
        {
            /* 
            ** Este código está comentado, posiblemente se use para configurar la conexión 
            ** a la base de datos en un archivo externo (DatosLayer).
            */
        }

        // Evento clic del botón Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca un cliente por su ID en el repositorio
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);

            // Si el cliente existe, llena los textbox con sus datos
            if (cliente != null)
            {
                tboxCustomerID.Text = cliente.CustomerID;
                tboxCompanyName.Text = cliente.CompanyName;
                tboxContacName.Text = cliente.ContactName;
                tboxContactTitle.Text = cliente.ContactTitle;
                tboxAddress.Text = cliente.Address;
                tboxCity.Text = cliente.City;
            }
            else
            {
                // Mensaje en caso de no encontrar el cliente
                MessageBox.Show("Cliente no encontrado");
            }
        }

        // Evento clic de la etiqueta label4 (aparentemente no tiene funcionalidad)
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Evento clic del botón Insertar
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Variable para almacenar el resultado de la inserción
            var resultado = 0;

            // Crea un nuevo objeto cliente con los datos de los textbox
            var nuevoCliente = ObtenerNuevoCliente();

            // Valida que ningún campo del cliente esté vacío
            if (validarCampoNull(nuevoCliente) == false)
            {
                // Inserta el nuevo cliente en el repositorio
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                // Muestra un mensaje con el número de filas afectadas
                MessageBox.Show("Guardado" + " Filas modificadas = " + resultado);
            }
            else
            {
                // Mensaje en caso de campos vacíos
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Método para validar si algún campo del objeto es nulo o vacío
        public Boolean validarCampoNull(Object objeto)
        {
            // Recorre las propiedades del objeto
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                // Obtiene el valor de la propiedad
                object value = property.GetValue(objeto, null);

                // Valida si el valor es un string vacío
                if ((string)value == "")
                {
                    return true; // Hay un campo vacío
                }
            }
            return false; // No hay campos vacíos
        }

        // Evento clic de la etiqueta label5 (aparentemente no tiene funcionalidad)
        private void label5_Click(object sender, EventArgs e)
        {

        }

        // Evento clic del botón Modificar
        private void btModificar_Click(object sender, EventArgs e)
        {
            // Crea un nuevo objeto cliente con los datos de los textbox para modificación
            var actualizarCliente = ObtenerNuevoCliente();

            // Actualiza el cliente en el repositorio
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Crea un nuevo objeto cliente a partir de los datos de los TextBox
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers  // Crea una nueva instancia del objeto Customers
            {
                CustomerID = tboxCustomerID.Text,  // Asigna el texto del TextBox al CustomerID
                CompanyName = tboxCompanyName.Text, // Asigna el texto del TextBox al CompanyName
                ContactName = tboxContacName.Text,  // Asigna el texto del TextBox al ContactName
                ContactTitle = tboxContactTitle.Text,// Asigna el texto del TextBox al ContactTitle
                Address = tboxAddress.Text,        // Asigna el texto del TextBox al Address
                City = tboxCity.Text               // Asigna el texto del TextBox al City
            };

            return nuevoCliente;  // Retorna el nuevo objeto cliente
        }

        // Elimina un cliente de la base de datos por su ID
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int eliminadas = customerRepository.EliminarCliente(tboxCustomerID.Text);  // Elimina el cliente por su ID
            MessageBox.Show("Filas eliminadas = " + eliminadas);  // Muestra mensaje con el número de filas eliminadas
        }
    }
}
