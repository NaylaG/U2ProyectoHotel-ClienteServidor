using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteHotel
{
   public class HotelCliente
    {


        public delegate void movimiento();
        public event movimiento AlHaberMovimiento;
        HttpClient cliente = new HttpClient();

        public HotelCliente()
        {
            cliente.BaseAddress = new Uri("http://localhost:8080/Hotel/");
        }

        public async void Agregar(DatosReservacion r)
        {

            //if (r.FechaEntrada <= DateTime.Now.Date || r.FechaSalida <= DateTime.Now.Date)
            //    throw new ArgumentException("No puede agregar una fecha posterior a la actual");
            //if (r.FechaSalida <= r.FechaEntrada)
            //    throw new ArgumentException("La fecha de salida no puede ser anterior a la de entrada");

            var json = JsonConvert.SerializeObject(r);
            var result = await cliente.PostAsync("/Hotel/Reservaciones", new StringContent(json, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public async void Editar(DatosReservacion r)
        {
            var json = JsonConvert.SerializeObject(r);
            var result = await cliente.PutAsync("/Hotel/Reservaciones", new StringContent(json, Encoding.UTF8, "application/json"));
            result.EnsureSuccessStatusCode();
        }

        public async void Eliminar(DatosReservacion r)
        {
            var json = JsonConvert.SerializeObject(r);
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Delete, "/Hotel/Reservaciones");
            message.Content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await cliente.SendAsync(message);
            result.EnsureSuccessStatusCode();
        }


        public IEnumerable<DatosReservacion> Model { get; set; }

        public async void Get()
        {

            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8080/Hotel/Reservaciones");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Model = JsonConvert.DeserializeObject<IEnumerable<DatosReservacion>>(jsonString);
                AlHaberMovimiento?.Invoke();
            }
        }
    }
}
