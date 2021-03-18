using Subdere.BLL;
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
using Subdere.BLL;
using System.IO;
using System.Diagnostics;

namespace Subdere {
    /// <summary>
    /// Lógica de interacción para CrearNomina.xaml
    /// </summary>
    public partial class CrearNomina : Window {
        public CrearNomina() {
            InitializeComponent();
            DgVehiculosNominas.ItemsSource = new VehiculosBLL().GetVehiculosOff();
            DgNominasCreadas.ItemsSource = new NominasBLL().GetNominas();
            DgNominasCreadas.SelectedIndex = 0;
        }

        private void BtnCrear_Click(object sender, RoutedEventArgs e) {
            Directory.CreateDirectory("C:\\Nominas");
            Nominas aux = new NominasBLL().CreateNomina();
            List<Vehiculos> listado = new VehiculosBLL().GetVehiculosNomina(aux);
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            Microsoft.Office.Interop.Excel.Range celLrangE;
            excel = new Microsoft.Office.Interop.Excel.Application();
            worKbooK = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
            worKsheeT.Name = "Nomina de pago " + aux.IdNomina;
            worKsheeT.Cells[1, 1] = "Rut";
            worKsheeT.Cells[1, 2] = "Patente";
            worKsheeT.Cells[1, 3] = "Fecha_vencimiento";
            worKsheeT.Cells[1, 4] = "Nro_serie_documento";
            worKsheeT.Cells[1, 5] = "Fecha_factura";
            worKsheeT.Cells[1, 6] = "Fecha_emision_homologacion";
            worKsheeT.Cells[1, 7] = "Valor_neto_factura";
            worKsheeT.Cells[1, 8] = "Digito_verificador_patente";
            worKsheeT.Cells[1, 9] = "Codigo_sii";
            worKsheeT.Cells[1, 10] = "Ano";
            worKsheeT.Cells[1, 11] = "Tasacion";
            worKsheeT.Cells[1, 12] = "Motor";
            worKsheeT.Cells[1, 13] = "Chasis";
            worKsheeT.Cells[1, 14] = "Color";
            worKsheeT.Cells[1, 15] = "Nro_asientos";
            worKsheeT.Cells[1, 16] = "Tara";
            worKsheeT.Cells[1, 17] = "Nombre_propietario";
            worKsheeT.Cells[1, 18] = "Domicilio_propietario";
            worKsheeT.Cells[1, 19] = "Comuna_propietario";
            worKsheeT.Cells[1, 20] = "Telefono_propietario";
            worKsheeT.Cells[1, 21] = "Sello_verde";
            worKsheeT.Cells[1, 22] = "Fecha_plazo_homologacion";
            worKsheeT.Cells[1, 23] = "Modelo";
            worKsheeT.Cells[1, 24] = "Marca";
            worKsheeT.Cells[1, 25] = "Tipo_vehiculo";
            worKsheeT.Cells[1, 26] = "Cilindrada";
            worKsheeT.Cells[1, 27] = "Combustible";
            worKsheeT.Cells[1, 28] = "Transmision";
            worKsheeT.Cells[1, 29] = "Equipamiento";
            worKsheeT.Cells[1, 30] = "Nro_puertas";
            worKsheeT.Cells[1, 31] = "Zona_franca";
            worKsheeT.Cells[1, 32] = "Tonelaje";
            int i = 2;
            foreach (Vehiculos item in listado) {
                worKsheeT.Cells[i, 1] = item.Rut;
                worKsheeT.Cells[i, 2] = item.Patente;
                worKsheeT.Cells[i, 3] = item.FechaVencimiento.Value.ToString("dd/MM/yyyy");
                worKsheeT.Cells[i, 4] = "";
                if (item.FechaFactura.HasValue) worKsheeT.Cells[i, 5] = item.FechaFactura.Value.ToString("dd/MM/yyyy");
                if (item.FechaEmisionHomologacion.HasValue) worKsheeT.Cells[i, 6] = item.FechaEmisionHomologacion.Value.ToString("dd/MM/yyyy");
                if (item.ValorNetoFactura.HasValue) worKsheeT.Cells[i, 7] = item.ValorNetoFactura;
                worKsheeT.Cells[i, 8] = item.DigitoVerificador;
                worKsheeT.Cells[i, 9] = item.CodigoSII;
                worKsheeT.Cells[i, 10] = item.Anno;
                worKsheeT.Cells[i, 11] = item.Tasacion;
                worKsheeT.Cells[i, 12] = item.NroMotor;
                worKsheeT.Cells[i, 13] = item.NroChasis;
                worKsheeT.Cells[i, 14] = item.Color;
                worKsheeT.Cells[i, 15] = item.NroAsientos;
                worKsheeT.Cells[i, 16] = "0";
                worKsheeT.Cells[i, 17] = item.NombrePropietario;
                worKsheeT.Cells[i, 18] = item.DomicilioPropietario;
                worKsheeT.Cells[i, 19] = item.ComunaPropietario;
                worKsheeT.Cells[i, 20] = item.TelefonoPropietario;
                worKsheeT.Cells[i, 21] = "Si";
                if (item.FechaPlazoHomologacion.HasValue) worKsheeT.Cells[i, 22] = item.FechaPlazoHomologacion.Value.ToString("dd/MM/yyyy");
                worKsheeT.Cells[i, 23] = item.Modelo;
                worKsheeT.Cells[i, 24] = item.Marca;
                worKsheeT.Cells[i, 25] = item.TipoVehiculo;
                worKsheeT.Cells[i, 26] = item.Cilindrada;
                worKsheeT.Cells[i, 27] = item.Combustible;
                worKsheeT.Cells[i, 28] = item.Transmision;
                worKsheeT.Cells[i, 29] = item.Equipamiento;
                worKsheeT.Cells[i, 30] = item.NroPuertas;
                worKsheeT.Cells[i, 31] = "";
                worKsheeT.Cells[i, 32] = "";
                i++;
            }
            string file = "C:\\Nominas\\nomina" + aux.IdNomina + ".xlsx";
            if (File.Exists(file)) {
                File.Delete(file);
                worKbooK.SaveAs(file);
            } else {
                worKbooK.SaveAs(file);
            }
            worKbooK.Close();
            excel.Quit();
            Process.Start(file);
            DgVehiculosNominas.ItemsSource = new VehiculosBLL().GetVehiculosOff();
            DgNominasCreadas.ItemsSource = new NominasBLL().GetNominas();
        }

        private void BtnRecrear_Click(object sender, RoutedEventArgs e) {
            Nominas aux = DgNominasCreadas.SelectedItem as Nominas;
            string file = "C:\\Nominas\\nomina" + aux.IdNomina + ".xlsx";
            Directory.CreateDirectory("C:\\Nominas");
            if (File.Exists(file)) {
                Process.Start(file);
            } else {
                List<Vehiculos> listado = new VehiculosBLL().GetVehiculosNomina(aux);
                Microsoft.Office.Interop.Excel.Application excel;
                Microsoft.Office.Interop.Excel.Workbook worKbooK;
                Microsoft.Office.Interop.Excel.Worksheet worksheet;
                Microsoft.Office.Interop.Excel.Range celLrangE;
                excel = new Microsoft.Office.Interop.Excel.Application();
                worKbooK = excel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel.Worksheet worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "Nomina de pago " + aux.IdNomina;
                worKsheeT.Cells[1, 1] = "Rut";
                worKsheeT.Cells[1, 2] = "Patente";
                worKsheeT.Cells[1, 3] = "Fecha_vencimiento";
                worKsheeT.Cells[1, 4] = "Nro_serie_documento";
                worKsheeT.Cells[1, 5] = "Fecha_factura";
                worKsheeT.Cells[1, 6] = "Fecha_emision_homologacion";
                worKsheeT.Cells[1, 7] = "Valor_neto_factura";
                worKsheeT.Cells[1, 8] = "Digito_verificador_patente";
                worKsheeT.Cells[1, 9] = "Codigo_sii";
                worKsheeT.Cells[1, 10] = "Ano";
                worKsheeT.Cells[1, 11] = "Tasacion";
                worKsheeT.Cells[1, 12] = "Motor";
                worKsheeT.Cells[1, 13] = "Chasis";
                worKsheeT.Cells[1, 14] = "Color";
                worKsheeT.Cells[1, 15] = "Nro_asientos";
                worKsheeT.Cells[1, 16] = "Tara";
                worKsheeT.Cells[1, 17] = "Nombre_propietario";
                worKsheeT.Cells[1, 18] = "Domicilio_propietario";
                worKsheeT.Cells[1, 19] = "Comuna_propietario";
                worKsheeT.Cells[1, 20] = "Telefono_propietario";
                worKsheeT.Cells[1, 21] = "Sello_verde";
                worKsheeT.Cells[1, 22] = "Fecha_plazo_homologacion";
                worKsheeT.Cells[1, 23] = "Modelo";
                worKsheeT.Cells[1, 24] = "Marca";
                worKsheeT.Cells[1, 25] = "Tipo_vehiculo";
                worKsheeT.Cells[1, 26] = "Cilindrada";
                worKsheeT.Cells[1, 27] = "Combustible";
                worKsheeT.Cells[1, 28] = "Transmision";
                worKsheeT.Cells[1, 29] = "Equipamiento";
                worKsheeT.Cells[1, 30] = "Nro_puertas";
                worKsheeT.Cells[1, 31] = "Zona_franca";
                worKsheeT.Cells[1, 32] = "Tonelaje";
                int i = 2;
                foreach (Vehiculos item in listado) {
                    worKsheeT.Cells[i, 1] = item.Rut;
                    worKsheeT.Cells[i, 2] = item.Patente;
                    worKsheeT.Cells[i, 3] = item.FechaVencimiento.Value.ToString("dd/MM/yyyy");
                    worKsheeT.Cells[i, 4] = "";
                    if (item.FechaFactura.HasValue) worKsheeT.Cells[i, 5] = item.FechaFactura.Value.ToString("dd/MM/yyyy");
                    if (item.FechaEmisionHomologacion.HasValue) worKsheeT.Cells[i, 6] = item.FechaEmisionHomologacion.Value.ToString("dd/MM/yyyy");
                    if (item.ValorNetoFactura.HasValue) worKsheeT.Cells[i, 7] = item.ValorNetoFactura;
                    worKsheeT.Cells[i, 8] = item.DigitoVerificador;
                    worKsheeT.Cells[i, 9] = item.CodigoSII;
                    worKsheeT.Cells[i, 10] = item.Anno;
                    worKsheeT.Cells[i, 11] = item.Tasacion;
                    worKsheeT.Cells[i, 12] = item.NroMotor;
                    worKsheeT.Cells[i, 13] = item.NroChasis;
                    worKsheeT.Cells[i, 14] = item.Color;
                    worKsheeT.Cells[i, 15] = item.NroAsientos;
                    worKsheeT.Cells[i, 16] = "0";
                    worKsheeT.Cells[i, 17] = item.NombrePropietario;
                    worKsheeT.Cells[i, 18] = item.DomicilioPropietario;
                    worKsheeT.Cells[i, 19] = item.ComunaPropietario;
                    worKsheeT.Cells[i, 20] = item.TelefonoPropietario;
                    worKsheeT.Cells[i, 21] = "Si";
                    if (item.FechaPlazoHomologacion.HasValue) worKsheeT.Cells[i, 22] = item.FechaPlazoHomologacion.Value.ToString("dd/MM/yyyy");
                    worKsheeT.Cells[i, 23] = item.Modelo;
                    worKsheeT.Cells[i, 24] = item.Marca;
                    worKsheeT.Cells[i, 25] = item.TipoVehiculo;
                    worKsheeT.Cells[i, 26] = item.Cilindrada;
                    worKsheeT.Cells[i, 27] = item.Combustible;
                    worKsheeT.Cells[i, 28] = item.Transmision;
                    worKsheeT.Cells[i, 29] = item.Equipamiento;
                    worKsheeT.Cells[i, 30] = item.NroPuertas;
                    worKsheeT.Cells[i, 31] = "";
                    worKsheeT.Cells[i, 32] = "";
                    i++;
                }
                worKbooK.SaveAs(file);
                worKbooK.Close();
                excel.Quit();
                Process.Start(file);
            }
        }
    }
}
