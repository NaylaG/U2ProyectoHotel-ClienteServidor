using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClienteHotel
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelCliente cliente = new HotelCliente();
        DatosReservacion reservacion = new DatosReservacion();
        //DatosReservacion reservacion2 = new DatosReservacion();
        private int time = 0;
        private DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();
            //cliente.Get();
            this.DataContext = reservacion;
            cliente.AlHaberMovimiento += Cliente_AlHaberMovimiento;
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 5);
            Timer.Tick += Timer_Tick;
            Timer.Start();        
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (time >= 0)
            {
                cliente.Get();
                time++;
            }
        }

        private void Cliente_AlHaberMovimiento()
        {
            dtgListaReservaciones.ItemsSource = cliente.Model;   
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgListaReservaciones.SelectedIndex != -1)
            {
                try
                {
                    DatosReservacion r = new DatosReservacion();
                    r = dtgListaReservaciones.SelectedItem as DatosReservacion;
                    if (MessageBox.Show($"La reservación del huseped {r.Nombre} está a punto de ser eliminada. ¿Desea continuar?", "Atencion",
                        MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        cliente.Eliminar(r);
                    //    txtClave.Text = txtNombre.Text =
                    //txtNumeroPersonas.Text =
                    //cmbTipoHabitacion.Text = "";
                        //cliente.Get();
                        //Timer.Start();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Es necesario que elijas un elemento para ser eliminado.", "Atencion", MessageBoxButton.OK);
            }

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //reservacion.ClaveReservacion = txtClave.Text;
                ////reservacion.FechaEntrada = dtpFechaEntrada.SelectedDate.ToString();
                ////reservacion.FechaSalida = dtpFechaEntrada.SelectedDate;
                //reservacion.Nombre = txtNombre.Text;
                //reservacion.TipoHabitacion = cmbTipoHabitacion.Text;
                //reservacion.NumPersonas = txtNumeroPersonas.Text;
                //cliente.Editar(reservacion);
                //cliente.Get();
                //Timer.Start();
                if(dtgListaReservaciones.SelectedIndex!=-1)
                {
                    EditarReservacionView vn = new EditarReservacionView();
                    DatosReservacion datos = dtgListaReservaciones.SelectedItem as DatosReservacion;
                    vn.DataContext = datos;
                    vn.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una reservacion", "Atención", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                DatosReservacion nuevosdatos = new DatosReservacion();
                AgregarReservacionView ad = new AgregarReservacionView();
                ad.DataContext = nuevosdatos;
                ad.ShowDialog();
                }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //this.DataContext = reservacion;
            //dtpFechaEntrada.SelectedDate = DateTime.Now.Date;
            //dtpFechaSalida.SelectedDate = DateTime.Now.Date;
            //btnAgregar.IsEnabled = true;
        }

        private void dtgListaReservaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (dtgListaReservaciones.SelectedItem != null)
            //{
            //    //Timer.Stop();
            //    //reservacion = dtgListaReservaciones.SelectedItem as DatosReservacion;
            //    //txtClave.Text = reservacion.ClaveReservacion;
            //    //dtpFechaEntrada.SelectedDate = reservacion.FechaEntrada;
            //    //dtpFechaSalida.SelectedDate = reservacion.FechaSalida;
            //    //txtNombre.Text = reservacion.Nombre;
            //    //txtNumeroPersonas.Text = reservacion.NumPersonas;
            //    //cmbTipoHabitacion.Text = reservacion.TipoHabitacion;

            //}
        }
    }
}
