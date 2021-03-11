using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class NominasBLL {

        DBSubdereEntities context;

        public List<Nominas> GetNominas() {
            context = new DBSubdereEntities();
            return (from l in context.Nominas select l).ToList();
        }

        public List<Nominas> GetNominas(int nomina) {
            context = new DBSubdereEntities();
            return (from l in context.Nominas where l.IdNomina == nomina select l).ToList();
        }

        public void InsertNomina() {
            context = new DBSubdereEntities();
            context.Nominas.Add(new Nominas() { FechaCreacion = DateTime.Now });
            context.SaveChanges();
        }
    }
}
