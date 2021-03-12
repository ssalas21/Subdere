//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Subdere
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculos()
        {
            this.DetalleNominas = new HashSet<DetalleNominas>();
        }
    
        public int IdSubdere { get; set; }
        public string Rut { get; set; }
        public string Patente { get; set; }
        public Nullable<System.DateTime> FechaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaFactura { get; set; }
        public Nullable<System.DateTime> FechaEmisionHomologacion { get; set; }
        public Nullable<long> ValorNetoFactura { get; set; }
        public string DigitoVerificador { get; set; }
        public string CodigoSII { get; set; }
        public Nullable<int> Anno { get; set; }
        public Nullable<long> Tasacion { get; set; }
        public string NroMotor { get; set; }
        public string NroChasis { get; set; }
        public string Color { get; set; }
        public Nullable<int> NroAsientos { get; set; }
        public Nullable<int> Tara { get; set; }
        public string NombrePropietario { get; set; }
        public string DomicilioPropietario { get; set; }
        public string ComunaPropietario { get; set; }
        public string TelefonoPropietario { get; set; }
        public string SelloVerde { get; set; }
        public Nullable<System.DateTime> FechaPlazoHomologacion { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string TipoVehiculo { get; set; }
        public Nullable<int> Cilindrada { get; set; }
        public string Combustible { get; set; }
        public string Transmision { get; set; }
        public string Equipamiento { get; set; }
        public Nullable<int> NroPuertas { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleNominas> DetalleNominas { get; set; }
    }
}
