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
    }
}
