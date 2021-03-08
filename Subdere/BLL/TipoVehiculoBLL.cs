using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class TipoVehiculoBLL {
        Permisos_de_CirculacionEntities context;

        public List<Tipos_de_Vehiculos> getTipos() {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.Tipos_de_Vehiculos orderby l.Descripcion ascending select l).Distinct().ToList();
        }
    }
}
