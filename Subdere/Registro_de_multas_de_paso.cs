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
    
    public partial class Registro_de_multas_de_paso
    {
        public string Fecha_Informe { get; set; }
        public string Placa { get; set; }
        public string Nombres { get; set; }
        public string Rut { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Codigo_Comuna { get; set; }
        public string JPL { get; set; }
        public string Codigo_Juzgado { get; set; }
        public string ID_Multa { get; set; }
        public string Rol { get; set; }
        public Nullable<short> Año_RolCausa { get; set; }
        public string Fecha_Ingreso { get; set; }
        public string Fecha_Sentencia { get; set; }
        public string Monto_Multa { get; set; }
        public short Moneda { get; set; }
        public string Motivo_Multa { get; set; }
        public string Arancel { get; set; }
        public string Fecha_Registro { get; set; }
        public Nullable<int> TAG { get; set; }
    }
}