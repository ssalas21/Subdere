using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class DetalleNominaBLL {

        DBSubdereEntities1 context;

        public void InsertDetalle(Nominas aux) {
            context = new DBSubdereEntities1();
            List<Vehiculos> vehiculos = new VehiculosBLL().GetVehiculosOff();
            foreach (Vehiculos item in vehiculos) {
                context.DetalleNominas.Add(new DetalleNominas() { IdNomina = aux.IdNomina, IdSubdere = item.IdSubdere });
                context.SaveChanges();
            }
            
        }
    }
}
