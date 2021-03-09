using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class ComunasBLL {
        Permisos_de_CirculacionEntities context;

        public List<Comunas> GetComunas() {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.Comunas select l).ToList();
        }

        public Comunas GetComunas(string comuna) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.Comunas where l.Descripcion.Contains(comuna) select l).FirstOrDefault();
        }
    }
}
