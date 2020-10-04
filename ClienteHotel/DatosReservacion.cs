using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteHotel
{ 
    public class DatosReservacion
    {
public string ClaveReservacion { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public string TipoHabitacion { get; set; }
    public string NumPersonas { get; set; }
    }
    
}
