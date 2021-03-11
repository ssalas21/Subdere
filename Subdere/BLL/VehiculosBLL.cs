using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class VehiculosBLL {
        DBSubdereEntities context;

        public List<Vehiculos> GetVehiculosOff() {
            context = new DBSubdereEntities();
            return (from l in context.Vehiculos where l.DetalleNomina.Any() == false select l).ToList();
        }

        public List<Vehiculos> GetVehiculosOn() {
            context = new DBSubdereEntities();
            return (from l in context.Vehiculos where l.DetalleNomina.Any() == true select l).ToList();
        }

        public void InsertVehiculo(string patente, string rut, DateTime fechaVencimiento, DateTime fechaFactura, DateTime fechaHomologacion, int valorFactura, DateTime fechaPlazoHomologacion, int tasacion, string codigo) {
            context = new DBSubdereEntities();
            Vehiculos aux = new Vehiculos() { Patente = patente, FechaFactura = fechaFactura, FechaHomologacion = fechaHomologacion, FechaPlazoHomologacion = fechaPlazoHomologacion, FechaVencimiento = fechaVencimiento, Rut = rut, ValorFactura = valorFactura };
            context.Vehiculos.Add(aux);
            context.SaveChanges();
        }

        public void InsertVehiculo(string patente, string rut, DateTime fechaVencimiento, DateTime fechaHomologacion, DateTime fechaPlazoHomologacion, int tasacion, string codigo) {
            context = new DBSubdereEntities();
            Vehiculos aux = new Vehiculos() { Patente = patente, FechaHomologacion = fechaHomologacion, FechaPlazoHomologacion = fechaPlazoHomologacion, FechaVencimiento = fechaVencimiento, Rut = rut};
            context.Vehiculos.Add(aux);
            context.SaveChanges();
        }

        public void InsertVehiculo(string patente, string rut, DateTime fechaVencimiento, int tasacion, string codigo) {
            context = new DBSubdereEntities();
            Vehiculos aux = new Vehiculos() { Patente = patente, FechaVencimiento = fechaVencimiento, Rut = rut };
            context.Vehiculos.Add(aux);
            context.SaveChanges();
        }
    }
}
