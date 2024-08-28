using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class Customers
    {
        // Identificador único del cliente
        public string CustomerID { get; set; }

        // Nombre de la empresa del cliente
        public string CompanyName { get; set; }

        // Nombre del contacto de la empresa
        public string ContactName { get; set; }

        // Título del contacto de la empresa
        public string ContactTitle { get; set; }

        // Dirección de la empresa
        public string Address { get; set; }

        // Ciudad de la empresa
        public string City { get; set; }

        // Región de la empresa
        public string Region { get; set; }

        // Código postal de la empresa
        public string PostalCode { get; set; }

        // País de la empresa
        public string Country { get; set; }

        // Número de teléfono de la empresa
        public string Phone { get; set; }

        // Número de fax de la empresa
        public string Fax { get; set; }
    }
}
