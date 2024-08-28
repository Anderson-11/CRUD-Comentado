using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo // Espacio para el proyecto
{
    internal static class Program // Punto de entrada
    {
        [STAThread]
        static void Main()
        {
            // Habilitar estilos visuales
            Application.EnableVisualStyles();

            // Mejorar representación de texto
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la aplicación
            Application.Run(new Form1());
        }
    }
}
