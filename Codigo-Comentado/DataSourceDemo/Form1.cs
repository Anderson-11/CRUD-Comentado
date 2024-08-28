using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Inicializa los componentes del formulario
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate(); // Valida los datos del formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición de los datos enlazados
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los datos en el conjunto de datos "northwindDataSet"
        }

        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate(); // Valida los datos del formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición de los datos enlazados
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los datos en el conjunto de datos "northwindDataSet"
        }

        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate(); // Valida los datos del formulario
            this.customersBindingSource.EndEdit(); // Finaliza la edición de los datos enlazados
            this.tableAdapterManager.UpdateAll(this.northwindDataSet); // Actualiza todos los datos en el conjunto de datos "northwindDataSet"
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Esta línea carga los datos en la tabla 'northwindDataSet.Customers'. Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers); // Carga los datos de clientes en el conjunto de datos "northwindDataSet"
        }

        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Aquí puedes agregar código para responder a los clics en las celdas del DataGridView "customersDataGridView"
        }
    }
}
