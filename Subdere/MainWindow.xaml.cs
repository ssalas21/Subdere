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
using Subdere.BLL;

namespace Subdere {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            CmbTipo.ItemsSource = new TipoVehiculoBLL().getTipos();
            CmbTipo.DisplayMemberPath = "Descripcion";
            CmbTipo.SelectedValuePath = "Codigo";
        }

        private void TxtPlaca_LostFocus(object sender, RoutedEventArgs e) {
           
        }

        private void TxtPlaca_KeyUp(object sender, KeyEventArgs e) {            
            if (TxtPlaca.Text.Length == 6) {
                if((new Datos_del_VehiculoBLL().CheckDatos(TxtPlaca.Text.ToUpper().Trim()) ==true)) {
                    TxtPlaca.Text = TxtPlaca.Text.ToUpper().Trim();
                    Datos_del_Vehiculo vehiculo = new Datos_del_VehiculoBLL().GetDatos(TxtPlaca.Text.ToUpper().Trim());
                    TxtDigito.Text = vehiculo.Digito.ToUpper();
                    TxtCodigo.Text = vehiculo.Codigo_SII.Substring(0, 9);
                    TxtAnno.Text = vehiculo.Año_Fabricacion.ToString();
                    if(DateTime.Now.Year == vehiculo.Año_Fabricacion) {
                        LblFechaFactura.IsEnabled = true;
                        LblValorFactura.IsEnabled = true;
                        DpFechaFactura.IsEnabled = true;
                        DpFechaEmisionHomologacion.IsEnabled = true;
                    } else {
                        LblFechaFactura.IsEnabled = false;
                        LblValorFactura.IsEnabled = false;
                        DpFechaFactura.IsEnabled = false;
                        TxtValorNetoFactura.IsEnabled = false;
                        SII sii = new SIIBLL().GetSII(vehiculo.Codigo_SII);
                        TxtTasacion.Text = sii.Tasacion.Value.ToString();
                        TxtColor.Text = vehiculo.Color;
                        TxtModelo.Text = sii.Modelo + " " + sii.Version;
                        TxtCilindrada.Text = sii.Cilindrada.ToString();
                        TxtTransmision.Text = sii.Transmision;
                        TxtNroMotor.Text = vehiculo.Numero_Motor;
                        TxtNroChassis.Text = vehiculo.Numero_Chassis;
                        TxtMarca.Text = sii.Marca;
                        int tipo = 0;
                        if (sii.Tipo.Equals("Cabriolet")) tipo = 46;
                        if (sii.Tipo.Equals("Camioneta")) tipo = 3;
                        if (sii.Tipo.Equals("Comercial")) tipo = 47;
                        if (sii.Tipo.Equals("Cuatrimoto")) tipo = 43;
                        if (sii.Tipo.Equals("Hatchback")) tipo = 48;
                        if (sii.Tipo.Equals("Motor Home")) tipo = 49;
                        if (sii.Tipo.Equals("Motos")) tipo = 50;
                        if (sii.Tipo.Equals("Sedán")) tipo = 51;
                        if (sii.Tipo.Equals("Suv")) tipo = 52;
                        if (sii.Tipo.Equals("Van")) tipo = 53;
                        CmbTipo.SelectedValue = tipo;
                        TxtCombustible.Text = sii.Combustible;
                        TxtEquipamiento.Text = sii.Equipamiento;
                    }
                    Propietarios propietario = new PropietariosBLL().GetPropietarios(vehiculo.Rut);
                    TxtRut.Text = propietario.Rut;
                    TxtNombre.Text = propietario.Nombre;
                    TxtDomicilio.Text = propietario.Direccion;
                    TxtTelefono.Text = propietario.Telefono;
                    TxtComuna.Text = propietario.Comuna;
                } else {
                    MessageBox.Show("No se encontraron coincidencias");
                }               
            }
        }

        private void TxtRut_LostFocus(object sender, RoutedEventArgs e) {
            TxtNombre.Text = "lalalala";
        }
    }
}
