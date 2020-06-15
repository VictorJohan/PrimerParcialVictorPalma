using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PrimerParcial.BLL;
using PrimerParcial.Entidades;
namespace PrimerParcial.UI.Registros
{
    /// <summary>
    /// Interaction logic for rRegistroVehiculo.xaml
    /// </summary>
    public partial class rArticulos : Window
    {
        int existencia = 0;
        double costo = 0;
        private Articulos Articulos = new Articulos();
        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = this.Articulos;
        }

        private void buscarCarroButton_Click(object sender, RoutedEventArgs e)
        {
            var articulo = ArticulosBLL.Buscar(int.Parse())
        }

        private void nuevoButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void guardarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ExistenciaTextBox.Text == "")
            {
                existencia = 0;
            }
            else
            {
                existencia = int.Parse(ExistenciaTextBox.Text);
            }
            
            
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double total = 0;

            if(CostoTextBox.Text == "")
            {
                costo = 0;

            }
            else
            {
                costo = int.Parse(CostoTextBox.Text);
                ValorInventarioTextBox.Text = total.ToString();
            }

            total = costo * existencia;
            ValorInventarioTextBox.Text = total.ToString();
        }

        
    }
}
