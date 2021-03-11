using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class MarcasBLL {

        Permisos_de_CirculacionEntities context;

        public List<Marcas> GetMarcas() {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.Marcas orderby l.Descripcion ascending select l).ToList();
        }

        public Marcas GetMarcas(string marca) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.Marcas where l.Descripcion.Contains(marca) select l).FirstOrDefault();
        }
    }
}
