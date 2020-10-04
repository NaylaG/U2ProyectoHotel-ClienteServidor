using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteHotel
{ 
    public class DatosReservacion
    {
public string ClaveReservacion { get; set; }
    public string Nombre { get; set; }
   
        private DateTime fechaEntrada;

        public DateTime FechaEntrada
        {
            get
            {
                if (fechaEntrada == DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return fechaEntrada;
                }
            }

            set { fechaEntrada = value; }
        }



        private DateTime fechaSalida;

        public DateTime FechaSalida
        {
            get { 
                if(fechaSalida==DateTime.MinValue)
                {
                    return DateTime.Now;
                }
                else
                {
                    return fechaSalida;
                }                 
            }

            set { fechaSalida = value; }
        }


        public string TipoHabitacion { get; set; }
    public string NumPersonas { get; set; }
    }
    
}
