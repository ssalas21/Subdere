using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Inicializar();
        }

        public void Inicializar() {
            LblFechaFactura.IsEnabled = false;
            LblValorFactura.IsEnabled = false;
            DpFechaFactura.IsEnabled = false;
            TxtValorNetoFactura.IsEnabled = false;
            TxtRut.Text = "";
            TxtTasacion.Text = "";
            TxtTasacion.IsEnabled = false;
            TxtPlaca.Text = "";
            TxtDigito.Text = "";
            TxtCodigo.Text = "";
            TxtAnno.Text = "0";
            TxtColor.Text = "";
            TxtModelo.Text = "";
            TxtCilindrada.Text = "";
            TxtTransmision.Text = "";
            DpFechaEmisionHomologacion.SelectedDate = null;
            DpFechaFactura.SelectedDate = null;
            DpPlazoHomologacion.SelectedDate = null;
            TxtValorNetoFactura.Text = "";
            TxtNroChassis.Text = "";
            TxtNroMotor.Text = "";            
            TxtCombustible.Text = "";
            TxtEquipamiento.Text = "";
            TxtNombre.Text = "";
            TxtDomicilio.Text = "";
            TxtTelefono.Text = "";
            CmbTipo.ItemsSource = new TipoVehiculoBLL().getTipos();
            CmbTipo.DisplayMemberPath = "Descripcion";
            CmbTipo.SelectedValuePath = "Codigo";
            CmbTipo.SelectedIndex = 0;
            CmbComuna.ItemsSource = new ComunasBLL().GetComunas();
            CmbComuna.DisplayMemberPath = "Descripcion";
            CmbComuna.SelectedValuePath = "Codigo";
            CmbComuna.SelectedValue = 220;
            CmbMarcas.ItemsSource = new MarcasBLL().GetMarcas();
            CmbMarcas.SelectedValuePath = "Codigo";
            CmbMarcas.DisplayMemberPath = "Descripcion";
            CmbMarcas.SelectedIndex = 0;
            DgFaltantes.ItemsSource = new VehiculosBLL().GetVehiculosOff();
        }

        private void TxtPlaca_LostFocus(object sender, RoutedEventArgs e) {

        }

        private void TxtPlaca_KeyUp(object sender, KeyEventArgs e) {
            if (TxtPlaca.Text.Length == 6) {
                if ((new Datos_del_VehiculoBLL().CheckDatos(TxtPlaca.Text.ToUpper().Trim()) == true)) {
                    TxtPlaca.Text = TxtPlaca.Text.ToUpper().Trim();
                    Datos_del_Vehiculo vehiculo = new Datos_del_VehiculoBLL().GetDatos(TxtPlaca.Text.ToUpper().Trim());
                    TxtDigito.Text = vehiculo.Digito.ToUpper();
                    TxtCodigo.Text = vehiculo.Codigo_SII.Substring(0, 9);
                    TxtAnno.Text = vehiculo.Año_Fabricacion.ToString();
                    if (DateTime.Now.Year == vehiculo.Año_Fabricacion) {
                        LblFechaFactura.IsEnabled = true;
                        LblValorFactura.IsEnabled = true;
                        DpFechaFactura.IsEnabled = true;
                        DpFechaEmisionHomologacion.IsEnabled = true;
                        TxtTasacion.IsEnabled = true;
                    } else {
                        LblFechaFactura.IsEnabled = false;
                        LblValorFactura.IsEnabled = false;
                        DpFechaFactura.IsEnabled = false;
                        TxtValorNetoFactura.IsEnabled = false;
                        if ((new SIIBLL().CheckSII(vehiculo.Codigo_SII))) {
                            SII sii = new SIIBLL().GetSII(vehiculo.Codigo_SII);
                            TxtTasacion.Text = sii.Tasacion.Value.ToString();
                            TxtColor.Text = vehiculo.Color;
                            TxtModelo.Text = sii.Modelo + " " + sii.Version;
                            TxtCilindrada.Text = sii.Cilindrada.ToString();
                            TxtTransmision.Text = sii.Transmision;
                            TxtNroMotor.Text = vehiculo.Numero_Motor;
                            TxtNroChassis.Text = vehiculo.Numero_Chassis;
                            CmbMarcas.SelectedValue = new MarcasBLL().GetMarcas(sii.Marca).Codigo;
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
                        } else {
                            MessageBox.Show("El vehículo no cuenta con un codigo del SII valido, por lo que debera buscar uno.");
                        }
                    }
                    try {
                        Propietarios propietario = new PropietariosBLL().GetPropietarios(vehiculo.Rut);
                        TxtRut.Text = propietario.Rut;
                        TxtNombre.Text = propietario.Nombre;
                        TxtDomicilio.Text = propietario.Direccion;
                        TxtTelefono.Text = propietario.Telefono;
                        CmbComuna.SelectedValue = new ComunasBLL().GetComunas(propietario.Comuna).Codigo;
                    } catch (Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }

                } else {
                    TxtPlaca.Text = TxtPlaca.Text.ToUpper().Trim();
                    MessageBox.Show("No se encontraron coincidencias");

                }
            }
        }

        private void TxtRut_LostFocus(object sender, RoutedEventArgs e) {
            if (new PropietariosBLL().CheckPropietarios(TxtRut.Text.ToUpper().Trim())) {
                Propietarios propietario = new PropietariosBLL().GetPropietarios(TxtRut.Text.ToUpper().Trim());
                TxtRut.Text = propietario.Rut;
                TxtNombre.Text = propietario.Nombre;
                TxtDomicilio.Text = propietario.Direccion;
                TxtTelefono.Text = propietario.Telefono;
                CmbComuna.SelectedValue = new ComunasBLL().GetComunas(propietario.Comuna).Codigo;
            } else {
                if (TxtRut.Text.IndexOf("-") < 0) {
                    MessageBox.Show("Ingrese un rut valido, con el siguiente formato XXXXXXXX-X");
                    TxtRut.Text = "";
                } else {
                    MessageBox.Show("Ingrese datos del contribuyente");
                }

            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e) {
            Tasaciones tasaciones = new Tasaciones(this);
            tasaciones.Show();
        }

        private void TxtAnno_TextChanged(object sender, TextChangedEventArgs e) {
            if (Convert.ToInt32(TxtAnno.Text) == DateTime.Now.Year) {
                TxtTasacion.IsEnabled = true;
                LblFechaFactura.IsEnabled = true;
                LblValorFactura.IsEnabled = true;
                DpFechaFactura.IsEnabled = true;
                DpFechaEmisionHomologacion.IsEnabled = true;
                TxtValorNetoFactura.IsEnabled = true;
            } else {
                LblFechaFactura.IsEnabled = false;
                LblValorFactura.IsEnabled = false;
                DpFechaFactura.IsEnabled = false;
                TxtValorNetoFactura.IsEnabled = false;
                TxtTasacion.IsEnabled = false;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtValorNetoFactura_TextChanged(object sender, TextChangedEventArgs e) {
            if (TxtValorNetoFactura.Text != "") {
                int factura = Convert.ToInt32(TxtValorNetoFactura.Text);
                TxtTasacion.Text = (factura * 1.19 * 0.95).ToString();
            }
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e) {
            if (new Datos_del_VehiculoBLL().CheckDatos(TxtPlaca.Text)) {
                if (Convert.ToInt32(TxtAnno.Text) == 2021) {
                    string codigo = TxtCodigo.Text + TxtAnno.Text.Substring(2, 2);
                    new Datos_del_VehiculoBLL().UpdateDatos(TxtPlaca.Text, TxtDigito.Text, TxtRut.Text, Convert.ToInt32(CmbTipo.SelectedValue), codigo, TxtModelo.Text, Convert.ToInt32(TxtAnno.Text), TxtColor.Text, TxtNroMotor.Text, TxtNroChassis.Text, 0, Convert.ToInt32(TxtTasacion.Text), Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, " ", Convert.ToInt32(CmbMarcas.SelectedValue));
                    if (new PropietariosBLL().CheckPropietarios(TxtRut.Text)) {
                        new PropietariosBLL().UpdatePropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    } else {
                        new PropietariosBLL().InsertPropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    }
                    new VehiculosBLL().InsertVehiculo(TxtRut.Text, TxtPlaca.Text, TxtDigito.Text, TxtCodigo.Text, Convert.ToInt32(TxtAnno.Text), Convert.ToInt32(TxtTasacion.Text), TxtNroMotor.Text, TxtNroChassis.Text, TxtColor.Text, 0, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text, TxtModelo.Text, CmbMarcas.Text, CmbTipo.Text, Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, 0, DpFechaEmisionHomologacion.SelectedDate.Value, DpPlazoHomologacion.SelectedDate.Value, DpFechaFactura.SelectedDate.Value, Convert.ToInt32(TxtValorNetoFactura.Text));
                } else {
                    string codigo = TxtCodigo.Text + TxtAnno.Text.Substring(2, 2);
                    SII sii = new SIIBLL().GetSII(codigo);
                    new Datos_del_VehiculoBLL().UpdateDatos(TxtPlaca.Text, TxtDigito.Text, TxtRut.Text, Convert.ToInt32(CmbTipo.SelectedValue), codigo, sii.Modelo, Convert.ToInt32(TxtAnno.Text), TxtColor.Text, TxtNroMotor.Text, TxtNroChassis.Text, 0, Convert.ToInt32(TxtTasacion.Text), Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, sii.Version, Convert.ToInt32(CmbMarcas.SelectedValue));
                    if (new PropietariosBLL().CheckPropietarios(TxtRut.Text)) {
                        new PropietariosBLL().UpdatePropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    } else {
                        new PropietariosBLL().InsertPropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    }
                    if (DpFechaEmisionHomologacion.SelectedDate.HasValue) {
                        new VehiculosBLL().InsertVehiculo(TxtRut.Text, TxtPlaca.Text, TxtDigito.Text, TxtCodigo.Text, Convert.ToInt32(TxtAnno.Text), Convert.ToInt32(TxtTasacion.Text), TxtNroMotor.Text, TxtNroChassis.Text, TxtColor.Text, 0, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text, TxtModelo.Text, CmbMarcas.Text, CmbTipo.Text, Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, 0, DpFechaEmisionHomologacion.SelectedDate.Value, DpPlazoHomologacion.SelectedDate.Value);
                    } else {
                        new VehiculosBLL().InsertVehiculo(TxtRut.Text, TxtPlaca.Text, TxtDigito.Text, TxtCodigo.Text, Convert.ToInt32(TxtAnno.Text), Convert.ToInt32(TxtTasacion.Text), TxtNroMotor.Text, TxtNroChassis.Text, TxtColor.Text, 0, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text, TxtModelo.Text, CmbMarcas.Text, CmbTipo.Text, Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, 0);
                    }                    
                }
            } else {
                if (Convert.ToInt32(TxtAnno.Text) == 2021) {
                    string codigo = TxtCodigo.Text + TxtAnno.Text.Substring(2, 2);
                    new Datos_del_VehiculoBLL().InsertDatos(TxtPlaca.Text, TxtDigito.Text, TxtRut.Text, Convert.ToInt32(CmbTipo.SelectedValue), codigo, TxtModelo.Text, Convert.ToInt32(TxtAnno.Text), TxtColor.Text, TxtNroMotor.Text, TxtNroChassis.Text, 0, Convert.ToInt32(TxtTasacion.Text), Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, " " , Convert.ToInt32(CmbMarcas.SelectedValue));
                    if (new PropietariosBLL().CheckPropietarios(TxtRut.Text)) {
                        new PropietariosBLL().UpdatePropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    } else {
                        new PropietariosBLL().InsertPropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    }
                    new VehiculosBLL().InsertVehiculo(TxtRut.Text, TxtPlaca.Text, TxtDigito.Text, TxtCodigo.Text, Convert.ToInt32(TxtAnno.Text), Convert.ToInt32(TxtTasacion.Text), TxtNroMotor.Text, TxtNroChassis.Text, TxtColor.Text, 0, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text, TxtModelo.Text, CmbMarcas.Text, CmbTipo.Text, Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, 0, DpFechaEmisionHomologacion.SelectedDate.Value, DpPlazoHomologacion.SelectedDate.Value, DpFechaFactura.SelectedDate.Value, Convert.ToInt32(TxtValorNetoFactura.Text));
                } else {
                    string codigo = TxtCodigo.Text + TxtAnno.Text.Substring(2, 2);
                    SII sii = new SIIBLL().GetSII(codigo);
                    new Datos_del_VehiculoBLL().InsertDatos(TxtPlaca.Text, TxtDigito.Text, TxtRut.Text, Convert.ToInt32(CmbTipo.SelectedValue), codigo, sii.Modelo, Convert.ToInt32(TxtAnno.Text), TxtColor.Text, TxtNroMotor.Text, TxtNroChassis.Text, 0, Convert.ToInt32(TxtTasacion.Text), Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, sii.Version, Convert.ToInt32(CmbMarcas.SelectedValue));
                    if (new PropietariosBLL().CheckPropietarios(TxtRut.Text)) {
                        new PropietariosBLL().UpdatePropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    } else {
                        new PropietariosBLL().InsertPropietario(TxtRut.Text, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text);
                    }
                    if (DpFechaEmisionHomologacion.SelectedDate.HasValue) {
                        new VehiculosBLL().InsertVehiculo(TxtRut.Text, TxtPlaca.Text, TxtDigito.Text, TxtCodigo.Text, Convert.ToInt32(TxtAnno.Text), Convert.ToInt32(TxtTasacion.Text), TxtNroMotor.Text, TxtNroChassis.Text, TxtColor.Text, 0, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text, TxtModelo.Text, CmbMarcas.Text, CmbTipo.Text, Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, 0, DpFechaEmisionHomologacion.SelectedDate.Value, DpPlazoHomologacion.SelectedDate.Value);
                    } else {
                        new VehiculosBLL().InsertVehiculo(TxtRut.Text, TxtPlaca.Text, TxtDigito.Text, TxtCodigo.Text, Convert.ToInt32(TxtAnno.Text), Convert.ToInt32(TxtTasacion.Text), TxtNroMotor.Text, TxtNroChassis.Text, TxtColor.Text, 0, TxtNombre.Text, TxtDomicilio.Text, CmbComuna.Text, TxtTelefono.Text, TxtModelo.Text, CmbMarcas.Text, CmbTipo.Text, Convert.ToInt32(TxtCilindrada.Text), TxtCombustible.Text, TxtTransmision.Text, TxtEquipamiento.Text, 0);
                    }
                }
            }
            MessageBox.Show("Carga completa");
            Inicializar();
        }
    }
}
