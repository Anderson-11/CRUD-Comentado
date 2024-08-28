using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo // Espacio de nombres del proyecto (DataSourceDemo)
{
    public partial class Form2 : Form // Clase parcial para el formulario Form2
    {
        public Form2() // Constructor del formulario
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e) // Evento clic del botón "Guardar" del control BindingNavigator para "customers"
        {
            this.Validate(); // Valida los datos del formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición de los datos enlazados
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los datos en el conjunto de datos "northwindDataSet"
        }

        private void Form2_Load(object sender, EventArgs e) // Evento "Load" (carga) del formulario
        {
            // TODO: Esta línea carga los datos en la tabla 'northwindDataSet.Customers'. Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers); // Carga los datos de clientes en el conjunto de datos "northwindDataSet"
        }

        private void cajaTextoID_Click(object sender, EventArgs e) // Evento clic del cuadro de texto "cajaTextoID" (Aún no implementado)
        {

        }

        private void cajaTextoID_KeyPress(object sender, KeyPressEventArgs e) // Evento "KeyPress" (presionar tecla) del cuadro de texto "cajaTextoID"
        {
            if (e.KeyChar == (char)13) // Si la tecla presionada es "Enter" (código ASCII 13)
            {
                var index = customersBindingSource.Find("customerID", cajaTextoID.Text); // Busca el cliente por "customerID" con el texto ingresado
                if (index > -1) // Si se encontró el cliente
                {
                    customersBindingSource.Position = index; // Muestra el cliente encontrado en el control vinculado
                    return; // Termina la ejecución del método
                }
                else // Si no se encontró el cliente
                {
                    MessageBox.Show("Elemento no encontrado"); // Muestra un mensaje de error
                }
            }
        }
    }
}
