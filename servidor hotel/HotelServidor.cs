using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace servidor_hotel
{
    public class HotelServidor
    {
        public CatalogoHuespedes Huespedes { get; set; } = new CatalogoHuespedes();
        HttpListener servidor;
        Dispatcher dispatcher;

        public HotelServidor()
        {
            dispatcher = Dispatcher.CurrentDispatcher;
            servidor = new HttpListener();
            servidor.Prefixes.Add("http://*:8080/Hotel/");
            servidor.Start();
            servidor.BeginGetContext(OnContext, null);
        }

        private void OnContext(IAsyncResult ar)
        {
            var context = servidor.EndGetContext(ar);
            servidor.BeginGetContext(OnContext, null);

            if (context.Request.Url.LocalPath == "/Hotel/Reservaciones")
            {
                if (context.Request.HttpMethod == "GET")
                {
                    var datos = JsonConvert.SerializeObject(Huespedes.Huespedes);
                    byte[] buffer = Encoding.UTF8.GetBytes(datos);
                    context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                    context.Response.StatusCode = 200;
                }
                else
                {
                    if(context.Request.ContentType.StartsWith("application/json")&& context.Request.ContentLength64>0)
                    {
                        StreamReader reader = new StreamReader(context.Request.InputStream);
                        var datos = reader.ReadToEnd();
                        var huesped = JsonConvert.DeserializeObject<Huesped>(datos);

                        dispatcher.Invoke(new Action(() =>
                        {
                            if (context.Request.HttpMethod == "POST")
                            {
                                Huespedes.Agregar(huesped);
                            }
                            else if(context.Request.HttpMethod=="PUT")
                            {
                                Huespedes.Editar(huesped);
                            }
                            else if(context.Request.HttpMethod=="DELETE")
                            {
                                Huespedes.Eliminar(huesped);
                            }

                        }));
                        context.Response.StatusCode = 200;
                    }
                }
            }
            else
            {
                context.Response.StatusCode = 404;
            }

            context.Response.Close();
        }
    }
}
