using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace servidor_hotel
{
    public class CatalogoHuespedes
    {
        public ObservableCollection<Huesped> Huespedes { get; set; } = new ObservableCollection<Huesped>();


        public void Agregar(Huesped h)
        {

            //if (h.TipoHabitacion != "SENCILLA" || h.TipoHabitacion != "DOBLE" || h.TipoHabitacion != "TRIPLE" || h.TipoHabitacion != "PRESIDENCIAL")
            //    h.TipoHabitacion = "";
            
            //if (h.FechaEntrada <= DateTime.Now.Date || h.FechaSalida <= DateTime.Now.Date)
            //    throw new ArgumentException("No puede agregar una fecha posterior a la actual");
            //if (h.FechaSalida <= h.FechaEntrada)
            //    throw new ArgumentException("La fecha de salida no puede ser anterior a la de entrada");
            Huespedes.Add(h);
            Guardar();
        }


        public void Editar(Huesped h)
        {
            var huesped = Huespedes.FirstOrDefault(x => x.ClaveReservacion == h.ClaveReservacion);
            if(huesped!=null)
            {
                huesped.Nombre = h.Nombre;
                huesped.FechaEntrada = h.FechaEntrada;
                huesped.FechaSalida = h.FechaSalida;
                huesped.NumPersonas = h.NumPersonas;
                huesped.TipoHabitacion = h.TipoHabitacion;
                Guardar();
            }
        }

        public void Eliminar(Huesped h)
        {
            var huesped = Huespedes.FirstOrDefault(x => x.ClaveReservacion == h.ClaveReservacion);
            if(huesped!=null)
            {
                Huespedes.Remove(huesped);
                Guardar();
                
            }
        }

        public void Guardar()
        {
            string datos = JsonConvert.SerializeObject(Huespedes);
            File.WriteAllText("huespedes.json", datos);

        }

        public void Cargar()
        {
            if (File.Exists("huespedes.json"))
            {
                var nuevo = JsonConvert.DeserializeObject<ObservableCollection<Huesped>>(File.ReadAllText("huespedes.json"));

                foreach (var item in nuevo)
                {
                    Huespedes.Add(item);
                }

            }
        }

        public CatalogoHuespedes()
        {
            Cargar();
        }
    }
}
