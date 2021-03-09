using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class SIIBLL {
        Permisos_de_CirculacionEntities context;

        public List<SII> GetSII() {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII select l).ToList();
        }

        public SII GetSII(string codigo) {
            context = new Permisos_de_CirculacionEntities();            
            return (from l in context.SII where l.Codigo == codigo select l).FirstOrDefault();            
        }

        public bool CheckSII(string codigo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo == codigo select l).Any();
        }
    }
}
