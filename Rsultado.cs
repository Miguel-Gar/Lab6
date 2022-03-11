using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    internal class Rsultado
    {
        //Nombre del cliente, los datos del automóvil,  la fecha de devolución, y el total a pagar,  de todos los vehículos que están alquilados.
        //Muestre en una etiqueta, el alquiler que haya recorrido más kilómetros(despliegue solo el valor de esos kilómetros).
        public string nombre { get; set; }
        public string Nit { get; set; }
        public string Placa { get; set; }
        public int klmRecorridos { get; set; }
        public DateTime fechaAlquiler { get; set; }
        public decimal Total_a_Pagar { get; set; }

    }
}
