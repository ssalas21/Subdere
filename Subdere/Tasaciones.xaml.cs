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
using System.Windows.Shapes;
using Subdere.BLL;

namespace Subdere {
    /// <summary>
    /// Lógica de interacción para Tasaciones.xaml
    /// </summary>
    public partial class Tasaciones : Window {
        MainWindow mainWindow;

        public Tasaciones(MainWindow aux) {
            InitializeComponent();
            mainWindow = aux;
            DgLivianos.ItemsSource = new SIIBLL().GetSII();
            DgLivianos.SelectedIndex = 0;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e) {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtAnno_TextChanged(object sender, TextChangedEventArgs e) {
            if (TxtAnno.Text.Length == 4) BuscarCodigo();
        }

        private void TxtMarca_TextChanged(object sender, TextChangedEventArgs e) {
            BuscarCodigo();
        }

        private void TxtModelo_TextChanged(object sender, TextChangedEventArgs e) {
            BuscarCodigo();
        }

        private void TxtVersion_TextChanged(object sender, TextChangedEventArgs e) {
            BuscarCodigo();
        }

        private void TxtAnno_LostFocus(object sender, RoutedEventArgs e) {
            if (TxtAnno.Text.Length < 4) {
                TxtAnno.Text = "";
                BuscarCodigo();
            }
        }

        public void BuscarCodigo() {
            bool flagMarca = false, flagModelo = false, flagAnno = false, flagVersion = false;
            if (TxtAnno.Text.Length > 0) flagAnno = true;
            if (TxtMarca.Text.Length > 0) flagMarca = true;
            if (TxtModelo.Text.Length > 0) flagModelo = true;
            if (TxtVersion.Text.Length > 0) flagVersion = true;
            if (flagAnno == true && flagMarca == false && flagModelo == false && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnno(Convert.ToInt32(TxtAnno.Text));
            if (flagAnno == true && flagMarca == true && flagModelo == false && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoMarca(Convert.ToInt32(TxtAnno.Text), TxtMarca.Text);
            if (flagAnno == true && flagMarca == true && flagModelo == true && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoMarcaModelo(Convert.ToInt32(TxtAnno.Text), TxtMarca.Text, TxtModelo.Text);
            if (flagAnno == true && flagMarca == true && flagModelo == false && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoMarcaVersion(Convert.ToInt32(TxtAnno.Text), TxtMarca.Text, TxtVersion.Text);
            if (flagAnno == true && flagMarca == true && flagModelo == true && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoMarcaModeloVersion(Convert.ToInt32(TxtAnno.Text), TxtMarca.Text, TxtModelo.Text, TxtVersion.Text);
            if (flagAnno == true && flagMarca == false && flagModelo == true && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoModelo(Convert.ToInt32(TxtAnno.Text), TxtModelo.Text);
            if (flagAnno == true && flagMarca == false && flagModelo == true && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoModeloVersion(Convert.ToInt32(TxtAnno.Text), TxtModelo.Text, TxtVersion.Text);
            if (flagAnno == true && flagMarca == false && flagModelo == false && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoAnnoVersion(Convert.ToInt32(TxtAnno.Text), TxtVersion.Text);
            if (flagAnno == false && flagMarca == true && flagModelo == false && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoMarca(TxtMarca.Text);
            if (flagAnno == false && flagMarca == true && flagModelo == true && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoMarcaModelo(TxtMarca.Text, TxtModelo.Text);
            if (flagAnno == false && flagMarca == true && flagModelo == true && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoMarcaModeloVersion(TxtMarca.Text, TxtModelo.Text, TxtVersion.Text);
            if (flagAnno == false && flagMarca == false && flagModelo == true && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().FindCodigoModelo(TxtModelo.Text);
            if (flagAnno == false && flagMarca == false && flagModelo == true && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoModeloVersion(TxtModelo.Text, TxtVersion.Text);
            if (flagAnno == false && flagMarca == false && flagModelo == false && flagVersion == true) DgLivianos.ItemsSource = new SIIBLL().FindCodigoVersion(TxtVersion.Text);
            if (flagAnno == false && flagMarca == false && flagModelo == false && flagVersion == false) DgLivianos.ItemsSource = new SIIBLL().GetSII();
            DgLivianos.SelectedIndex = 0;
        }

        private void BtnSeleccionar_Click(object sender, RoutedEventArgs e) {
            SII sii = DgLivianos.SelectedItem as SII;
            mainWindow.TxtAnno.Text = sii.Año_Fabricacion.ToString();
            mainWindow.TxtCilindrada.Text = sii.Cilindrada.ToString();
            mainWindow.TxtCodigo.Text = sii.Codigo.Substring(0, 9);
            mainWindow.TxtCombustible.Text = sii.Combustible;
            mainWindow.TxtEquipamiento.Text = sii.Equipamiento;
            mainWindow.CmbMarcas.SelectedValue = new MarcasBLL().GetMarcas(sii.Marca);
            mainWindow.TxtModelo.Text = sii.Modelo;
            mainWindow.TxtTasacion.Text = sii.Tasacion.ToString();
            mainWindow.TxtTransmision.Text = sii.Transmision;
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
            mainWindow.CmbTipo.SelectedValue = tipo;
            this.Close();            
        }
    }
}
