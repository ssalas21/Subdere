using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class VehiculosBLL {
        DBSubdereEntities1 context;

        public void InsertVehiculo(string rut, string placa, string digito, string codigoSII, int anno, int tasacion, string nroMotor, string nroChasis, string color, int asientos, string nombre, string domicilio, string comuna, string telefono, string modelo, string marca, string tipoVehiculo, int cilindrada, string combustible, string transmision, string equipamiento, int puertas) { 
            context = new DBSubdereEntities1();
            Vehiculos vehiculo = new Vehiculos() {Rut = rut, Anno = anno, Cilindrada = cilindrada, CodigoSII = codigoSII, Color = color, Combustible = combustible, ComunaPropietario = comuna, DigitoVerificador = digito, DomicilioPropietario = domicilio, Equipamiento = equipamiento, FechaVencimiento = new DateTime(DateTime.Now.Year, 3, 31), Marca = marca, Modelo = modelo, NombrePropietario = nombre, NroAsientos = asientos, NroChasis = nroChasis, NroMotor = nroMotor, NroPuertas = puertas, Patente = placa, SelloVerde = "Si", Tara = 0, Tasacion = tasacion, TelefonoPropietario = telefono, TipoVehiculo = tipoVehiculo, Transmision = transmision };
            context.Vehiculos.Add(vehiculo);
            context.SaveChanges();
        }

        public void InsertVehiculo(string rut, string placa, string digito, string codigoSII, int anno, int tasacion, string nroMotor, string nroChasis, string color, int asientos, string nombre, string domicilio, string comuna, string telefono, string modelo, string marca, string tipoVehiculo, int cilindrada, string combustible, string transmision, string equipamiento, int puertas, DateTime fechaEmisionHologacion, DateTime fechaPlazoHomologacion) {
            context = new DBSubdereEntities1();
            Vehiculos vehiculo = new Vehiculos() { Rut = rut, Anno = anno, Cilindrada = cilindrada, CodigoSII = codigoSII, Color = color, Combustible = combustible, ComunaPropietario = comuna, DigitoVerificador = digito, DomicilioPropietario = domicilio, Equipamiento = equipamiento, FechaVencimiento = new DateTime(DateTime.Now.Year, 3, 31), Marca = marca, Modelo = modelo, NombrePropietario = nombre, NroAsientos = asientos, NroChasis = nroChasis, NroMotor = nroMotor, NroPuertas = puertas, Patente = placa, SelloVerde = "Si", Tara = 0, Tasacion = tasacion, TelefonoPropietario = telefono, TipoVehiculo = tipoVehiculo, Transmision = transmision, FechaEmisionHomologacion = fechaEmisionHologacion, FechaPlazoHomologacion = fechaPlazoHomologacion };
            context.Vehiculos.Add(vehiculo);
            context.SaveChanges();
        }

        public void InsertVehiculo(string rut, string placa, string digito, string codigoSII, int anno, int tasacion, string nroMotor, string nroChasis, string color, int asientos, string nombre, string domicilio, string comuna, string telefono, string modelo, string marca, string tipoVehiculo, int cilindrada, string combustible, string transmision, string equipamiento, int puertas, DateTime fechaEmisionHologacion, DateTime fechaPlazoHomologacion, DateTime fechaFactura, int valorNetoFactura) {
            context = new DBSubdereEntities1();
            Vehiculos vehiculo = new Vehiculos() { Rut = rut, Anno = anno, Cilindrada = cilindrada, CodigoSII = codigoSII, Color = color, Combustible = combustible, ComunaPropietario = comuna, DigitoVerificador = digito, DomicilioPropietario = domicilio, Equipamiento = equipamiento, FechaVencimiento = new DateTime(DateTime.Now.Year, 3, 31), Marca = marca, Modelo = modelo, NombrePropietario = nombre, NroAsientos = asientos, NroChasis = nroChasis, NroMotor = nroMotor, NroPuertas = puertas, Patente = placa, SelloVerde = "Si", Tara = 0, Tasacion = tasacion, TelefonoPropietario = telefono, TipoVehiculo = tipoVehiculo, Transmision = transmision, FechaEmisionHomologacion = fechaEmisionHologacion, FechaPlazoHomologacion = fechaPlazoHomologacion, FechaFactura = fechaFactura, ValorNetoFactura = valorNetoFactura };
            context.Vehiculos.Add(vehiculo);
            context.SaveChanges();
        }

        public List<Vehiculos> GetVehiculosOff() {
            context = new DBSubdereEntities1();
            return (from l in context.Vehiculos where l.DetalleNominas.Any() == false select l).ToList();
        }

        public List<Vehiculos> GetVehiculosNomina(Nominas aux) {
            context = new DBSubdereEntities1();
            return (from l in context.DetalleNominas where l.IdNomina == aux.IdNomina select l.Vehiculos).ToList();
        }

    }
}
