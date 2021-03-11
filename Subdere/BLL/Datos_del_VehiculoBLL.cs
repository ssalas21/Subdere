using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subdere.BLL {
    class Datos_del_VehiculoBLL {
        Permisos_de_CirculacionEntities context;

        public Datos_del_Vehiculo GetDatos(string placa) {
            context = new Permisos_de_CirculacionEntities();
            string placa2;
            if (placa.IndexOf("0").Equals(2) || placa.IndexOf("1").Equals(2) || placa.IndexOf("2").Equals(2) || placa.IndexOf("3").Equals(2) || placa.IndexOf("4").Equals(2) || placa.IndexOf("5").Equals(2) || placa.IndexOf("6").Equals(2) || placa.IndexOf("7").Equals(2) || placa.IndexOf("8").Equals(2) || placa.IndexOf("9").Equals(2)) placa2 = placa.Substring(0, 2) + "-" + placa[2] + placa[3] + placa[4] + placa[5];
            else placa2 = placa.Substring(0, 4) + "-" + placa[4] + placa[5];
            return (from l in context.Datos_del_Vehiculo where l.Placa == placa2 select l).FirstOrDefault();
        }

        public bool CheckDatos(string placa) {
            context = new Permisos_de_CirculacionEntities();
            string placa2;
            if (placa.IndexOf("0").Equals(2) || placa.IndexOf("1").Equals(2) || placa.IndexOf("2").Equals(2) || placa.IndexOf("3").Equals(2) || placa.IndexOf("4").Equals(2) || placa.IndexOf("5").Equals(2) || placa.IndexOf("6").Equals(2) || placa.IndexOf("7").Equals(2) || placa.IndexOf("8").Equals(2) || placa.IndexOf("9").Equals(2)) placa2 = placa.Substring(0, 2) + "-" + placa[2] + placa[3] + placa[4] + placa[5];
            else placa2 = placa.Substring(0, 4) + "-" + placa[4] + placa[5];
            return (from l in context.Datos_del_Vehiculo where l.Placa == placa2 select l).Any();
        }

        public void UpdateDatos(string placa, string digito, string rut, int tipo, string codigo, string modelo, int anno, string color, string nroMotor, string nroChassis, int puertas, int tasacion, int cilindrada, string combustible, string transmision, string equipamiento, string version) {
            context = new Permisos_de_CirculacionEntities();
            string placa2;
            if (placa.IndexOf("0").Equals(2) || placa.IndexOf("1").Equals(2) || placa.IndexOf("2").Equals(2) || placa.IndexOf("3").Equals(2) || placa.IndexOf("4").Equals(2) || placa.IndexOf("5").Equals(2) || placa.IndexOf("6").Equals(2) || placa.IndexOf("7").Equals(2) || placa.IndexOf("8").Equals(2) || placa.IndexOf("9").Equals(2)) placa2 = placa.Substring(0, 2) + "-" + placa[2] + placa[3] + placa[4] + placa[5];
            else placa2 = placa.Substring(0, 4) + "-" + placa[4] + placa[5];
            Datos_del_Vehiculo vehiculo = GetDatos(placa);
            vehiculo.Digito = digito;
            vehiculo.Rut = rut;
            vehiculo.Tipo_Vehiculo = tipo;
            vehiculo.Codigo_SII = codigo;
            vehiculo.Modelo = modelo;
            vehiculo.Año_Fabricacion =Convert.ToInt16(anno);
            vehiculo.Color = color;
            vehiculo.Numero_Motor = nroMotor;
            vehiculo.Numero_Chasis = nroChassis;
            vehiculo.Numero_Chassis = nroChassis;
            vehiculo.Numero_Puertas = Convert.ToInt16(puertas);
            vehiculo.Tasacion = tasacion;
            vehiculo.Cilindrada = Convert.ToInt16(cilindrada);
            vehiculo.Combustible = combustible;
            vehiculo.Transmision = transmision;
            vehiculo.Equipamiento = equipamiento;
            vehiculo.Version = version;
            context.SaveChanges();
        }

        public void InsertDatos(string placa, string digito, string rut, int tipo, string codigo, string modelo, int anno, string color, string nroMotor, string nroChassis, int puertas, int tasacion, int cilindrada, string combustible, string transmision, string equipamiento, string version) {
            context = new Permisos_de_CirculacionEntities();
            string placa2;
            if (placa.IndexOf("0").Equals(2) || placa.IndexOf("1").Equals(2) || placa.IndexOf("2").Equals(2) || placa.IndexOf("3").Equals(2) || placa.IndexOf("4").Equals(2) || placa.IndexOf("5").Equals(2) || placa.IndexOf("6").Equals(2) || placa.IndexOf("7").Equals(2) || placa.IndexOf("8").Equals(2) || placa.IndexOf("9").Equals(2)) placa2 = placa.Substring(0, 2) + "-" + placa[2] + placa[3] + placa[4] + placa[5];
            else placa2 = placa.Substring(0, 4) + "-" + placa[4] + placa[5];
            Datos_del_Vehiculo vehiculo = new Datos_del_Vehiculo();
            vehiculo.Digito = digito;
            vehiculo.Rut = rut;
            vehiculo.Tipo_Vehiculo = tipo;
            vehiculo.Codigo_SII = codigo;
            vehiculo.Modelo = modelo;
            vehiculo.Año_Fabricacion = Convert.ToInt16(anno);
            vehiculo.Color = color;
            vehiculo.Numero_Motor = nroMotor;
            vehiculo.Numero_Chasis = nroChassis;
            vehiculo.Numero_Chassis = nroChassis;
            vehiculo.Numero_Puertas = Convert.ToInt16(puertas);
            vehiculo.Tasacion = tasacion;
            vehiculo.Cilindrada = Convert.ToInt16(cilindrada);
            vehiculo.Combustible = combustible;
            vehiculo.Transmision = transmision;
            vehiculo.Equipamiento = equipamiento;
            vehiculo.Version = version;
            context.Datos_del_Vehiculo.Add(vehiculo);
            context.SaveChanges();
        }

    }
}
