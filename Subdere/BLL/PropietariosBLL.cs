using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class PropietariosBLL {
        Permisos_de_CirculacionEntities context;

        public Propietarios GetPropietarios(string rut) {
            context = new Permisos_de_CirculacionEntities();
            if (rut.Length == 9) rut = "00" + rut;
            if (rut.Length == 10) rut = "0" + rut;
            if (rut.Length == 8) rut = "000" + rut;
            return (from l in context.Propietarios where l.Rut == rut select l).FirstOrDefault();
        }

        public bool CheckPropietarios(string rut) {
            context = new Permisos_de_CirculacionEntities();
            if (rut.Length == 9) rut = "00" + rut;
            if (rut.Length == 10) rut = "0" + rut;
            if (rut.Length == 8) rut = "000" + rut;
            return (from l in context.Propietarios where l.Rut == rut select l).Any();
        }

        public void UpdatePropietario(string rut, string nombre, string domicilio, string comuna, string telefono) {
            context = new Permisos_de_CirculacionEntities();
            Propietarios propietario = GetPropietarios(rut);
            propietario.Nombre = nombre;
            propietario.Direccion = domicilio;
            propietario.Comuna = comuna;
            propietario.Telefono = telefono;
            context.SaveChanges();
        }

        public void InsertPropietario(string rut, string nombre, string domicilio, string comuna, string telefono) {
            context = new Permisos_de_CirculacionEntities();
            Propietarios propietario = new Propietarios();
            propietario.Nombre = nombre;
            propietario.Direccion = domicilio;
            propietario.Comuna = new ComunasBLL().GetComunas(comuna).Descripcion;
            propietario.Telefono = telefono;
            context.Propietarios.Add(propietario);
            context.SaveChanges();
        }
    }
}
