using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace servidor_hotel
{
    public class Huesped : INotifyPropertyChanged
    {
        private string claveReservacion;

        public string ClaveReservacion
        {
            get { return claveReservacion; }
            set { claveReservacion = value;
                AlHaberCambio("ClaveReservacion");
            }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                AlHaberCambio("Nombre");
            }
        }

        private DateTime fechaEntrada;

        public DateTime FechaEntrada
        {
            get { return fechaEntrada; }
            set { fechaEntrada = value;
                AlHaberCambio("FechaEntrada");
            }
        }


        private DateTime fechaSalida;

        public DateTime FechaSalida
        {
            get { return fechaSalida; }
            set { fechaSalida = value;
                AlHaberCambio("FechaSalida");
            }
        }


        private string tipoHabitacion;

        public string TipoHabitacion
        {
            get { return tipoHabitacion; }
            set { tipoHabitacion = value;
                AlHaberCambio("TipoHabitacion");
            }
        }

        private int numPersonas;

        public int NumPersonas
        {
            get { return numPersonas; }
            set { numPersonas = value;
                AlHaberCambio("NumPersonas");
            }
        }


       
        public event PropertyChangedEventHandler PropertyChanged;

        private void AlHaberCambio(string propiedad)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
