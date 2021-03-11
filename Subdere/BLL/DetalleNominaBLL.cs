using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class DetalleNominaBLL {

        DBSubdereEntities context;

        public bool GetDetalle(string placa) {
            context = new DBSubdereEntities();
            return (from l in context.DetalleNomina where l.Patente == placa select l).Any();
        }

        public void InsertDetalle(Nominas nomina, List<Vehiculos> vehiculos) {
            context = new DBSubdereEntities();
            foreach (Vehiculos item in vehiculos) {
                context.DetalleNomina.Add(new DetalleNomina() { Patente = item.Patente, IdNomina = nomina.IdNomina });
            }
            context.SaveChanges();
        }
    }
}
