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
    /// Lógica de interacción para EditarReservacionView.xaml
    /// </summary>
    public partial class EditarReservacionView : Window
    {
        HotelCliente cliente = new HotelCliente();
        public EditarReservacionView()
        {
            InitializeComponent();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            DatosReservacion reservacion = this.DataContext as DatosReservacion;
            try
            {

                cliente.Editar(reservacion);
                this.Close();
            }
            catch (Exception n)
            {

                MessageBox.Show(n.Message);
            }
        }
    }
}
