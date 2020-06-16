using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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

        int existencia = 0;//variables para los calculos
        double costo = 0;//variables para los calculos
        double total = 0;//variables para los calculos
        private Articulos Articulos = new Articulos();//instancia de la entidad
        public rArticulos()
        {
            InitializeComponent();
            this.DataContext = this.Articulos;
        }

        //ESTE METODO BUSCA UN REGISTRO
        private void BuscarCarroButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarId())
            {
                return;
            }

            var articulo = ArticulosBLL.Buscar(int.Parse(ArticuloIdTextBox.Text));

            if(articulo != null)
            {
                this.Articulos = articulo;
            }
            else
            {
                this.Articulos = new Articulos();
            }

            this.DataContext = this.Articulos;

        }

        //ESTE METODO LIMPIA EL FORMULARIO PARA CREAR UN NUEVO REGISTRO
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //ESTE METODO GUARDA UN REGISTRO EN LA BASE DE DATOS
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            bool ok = ArticulosBLL.Guardar(Articulos);

            if (ok)
            {
                MessageBox.Show("Guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //ESTE METODO ELIMINA UN REGISTRO
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarId())
            {
                return;
            }

            if (ArticulosBLL.Eliminar(int.Parse(ArticuloIdTextBox.Text)))
            {
                MessageBox.Show("Eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Algo salio mal, no se pudo eliminar el registro.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //LOS SIGUIENTES METODOS  DE ABAJO ESTAN ENCARGADOS DEL COMPORTAMIEENTO DE LOS TEXTBOX
        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ExistenciaTextBox.Text == "" || Regex.IsMatch(ExistenciaTextBox.Text, "^[a-zA-Z]+$"))
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
            total = 0;

            if(CostoTextBox.Text == "" || Regex.IsMatch(ExistenciaTextBox.Text, "^[a-zA-Z]+$"))
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

        
        private void ValorInventarioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValorInventarioTextBox.Text = total.ToString();
        }
        //LOS SIGUIENTES METODOS  DE ARRIBA ESTAN ENCARGADOS DEL COMPORTAMIEENTO DE LOS TEXTBOX


        //ESTE METODO LIMPIA EL FORMULARIO
        public void Limpiar()
        {
            this.Articulos = new Articulos();
            this.DataContext = this.Articulos;
        }

        //ESTE METODO VALIDA LOS CAMPOS
        public bool Validar()
        {
            if(!Regex.IsMatch(ArticuloIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("El  campo ProductoId solo puede contener digitos.", "Ese id de producto no es valido.", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }else if(!Regex.IsMatch(ExistenciaTextBox.Text, "^[0-9]+$")){
                MessageBox.Show("El  campo Existencia solo puede contener digitos.", "Ese existencia de producto no valido.", MessageBoxButton.OK,
                   MessageBoxImage.Warning);
                return false;
            }
            else if (!Regex.IsMatch(CostoTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("El  campo Costo solo puede contener digitos.", "Ese costo de producto no valido.", MessageBoxButton.OK,
                   MessageBoxImage.Warning);
                return false;
            }else if(DescripcionTextBox.Text == "")
            {
                MessageBox.Show("El  campo Descripcion no puede estar vacio.", "Todos los campos son obligatorios.", MessageBoxButton.OK,
                   MessageBoxImage.Warning);
                return false;

            }

            return true;
        }

        //ESTE METODO VALIDA ESPECIFICAMENTE EL CAMPO ARTICULOID
        public bool ValidarId()
        {
            if (!Regex.IsMatch(ArticuloIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("El  campo ArticuloId solo puede contener digitos.", "Ese id de producto no es valido.", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
