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
            propietario.Comuna = new ComunasBLL().GetComunas(comuna).Descripcion;
            propietario.Telefono = telefono;
            string query = "UPDATE Propietarios SET Nombre = '" + propietario.Nombre + "', Direccion = '" + propietario.Direccion + "', Comuna = '" + propietario.Comuna + "', Telefono = '" + propietario.Telefono + "' WHERE Rut = '" + propietario.Rut + "'";
            new Connection().Coneccion(query);
        }

        public void InsertPropietario(string rut, string nombre, string domicilio, string comuna, string telefono) {
            context = new Permisos_de_CirculacionEntities();
            Propietarios propietario = new Propietarios();
            if (rut.Length == 9) rut = "00" + rut;
            if (rut.Length == 10) rut = "0" + rut;
            if (rut.Length == 8) rut = "000" + rut;
            propietario.Rut = rut;
            propietario.Nombre = nombre;
            propietario.Direccion = domicilio;
            propietario.Comuna = new ComunasBLL().GetComunas(comuna).Descripcion;
            propietario.Telefono = telefono;
            string query = "INSERT INTO Propietarios (Rut, Nombre, Direccion, Comuna, Telefono) VALUES ('" + propietario.Rut + "', '" + propietario.Nombre + "', '" + propietario.Direccion + "', '" + propietario.Comuna + "', '" + propietario.Telefono + "')";
            new Connection().Coneccion(query);
        }
    }
}
