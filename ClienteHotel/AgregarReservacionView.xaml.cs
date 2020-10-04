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
using System.Windows.Shapes;

namespace ClienteHotel
{
    /// <summary>
    /// Lógica de interacción para AgregarReservacionView.xaml
    /// </summary>
    public partial class AgregarReservacionView : Window
    {
        public AgregarReservacionView()
        {
            InitializeComponent();
            dtpFechaEntrada.SelectedDate = dtpFechaSalida.SelectedDate= DateTime.Now.Date;
        }
        HotelCliente cliente = new HotelCliente();
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            DatosReservacion reservacion = this.DataContext as DatosReservacion;
            try
            {
                cliente.Agregar(reservacion);
                this.Close();
            }
            catch (Exception n)
            {

                MessageBox.Show(n.Message);
            }
        }
    }
}
