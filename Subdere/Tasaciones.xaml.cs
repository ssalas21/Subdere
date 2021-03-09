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

namespace Subdere {
    /// <summary>
    /// Lógica de interacción para Tasaciones.xaml
    /// </summary>
    public partial class Tasaciones : Window {
        public Tasaciones() {
            InitializeComponent();
            DgLivianos.ItemsSource = new SIIBLL().GetSII();
        }

        private void TxtAnno_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void TxtMarca_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void TxtModelo_TextChanged(object sender, TextChangedEventArgs e) {

        }

        private void TxtVersion_TextChanged(object sender, TextChangedEventArgs e) {

        }

        public void BuscarCodigo() {
            int flagMarca = 0, flagModelo = 0, flagAnno = 0, flagVersion = 0;
            if (TxtAnno.Text.Length > 0) flagAnno = 1;
            if (TxtMarca.Text.Length > 0) flagMarca = 1;
            if (TxtModelo.Text.Length > 0) flagModelo = 1;
            if (TxtVersion.Text.Length > 0) flagVersion = 1;
        }
    }
}
