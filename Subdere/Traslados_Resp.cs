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
    
    public partial class Traslados_Resp
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public Nullable<System.DateTime> Fecha_Solicitud { get; set; }
        public Nullable<System.DateTime> Fecha_Emision { get; set; }
        public Nullable<short> Tipo { get; set; }
        public string Numero_Documento { get; set; }
        public Nullable<short> Codigo_Comuna { get; set; }
        public string Nota { get; set; }
        public string Observaciones { get; set; }
        public Nullable<bool> Imprimir { get; set; }
        public Nullable<int> Estado { get; set; }
        public string Usuario_Ingreso_Traslado { get; set; }
        public string hash { get; set; }
        public string Usuario_Transaccion { get; set; }
        public Nullable<System.DateTime> Fecha_Transaccion { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public string Equipo { get; set; }
    }
}
