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
    
    public partial class Transacciones_ImpExp
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Fecha_Exp { get; set; }
        public string Id_Usuario_Exp { get; set; }
        public string Estacion_Trabajo_Exp { get; set; }
        public string Periodo_Exp { get; set; }
        public string StringConexion_Exp { get; set; }
        public byte[] Archivo_Exp { get; set; }
        public string Version_Exp { get; set; }
        public Nullable<System.DateTime> Fecha_Imp { get; set; }
        public string Id_Usuario_Imp { get; set; }
        public string Estacion_Trabajo_Imp { get; set; }
        public string StringConexion_Imp { get; set; }
        public byte[] Archivo_Imp { get; set; }
        public string Version_Imp { get; set; }
    }
}
