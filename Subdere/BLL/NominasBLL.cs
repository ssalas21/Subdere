using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class NominasBLL {

        DBSubdereEntities1 context;

        public List<Nominas> GetNominas() {
            context = new DBSubdereEntities1();
            return (from l in context.Nominas orderby l.IdNomina descending select l).ToList();
        }

        public Nominas CreateNomina() {
            context = new DBSubdereEntities1();
            Nominas aux = new Nominas() {FechaCreacion = DateTime.Now };
            context.Nominas.Add(aux);
            context.SaveChanges();
            new DetalleNominaBLL().InsertDetalle(aux);
            return aux;
        }
    }
}
