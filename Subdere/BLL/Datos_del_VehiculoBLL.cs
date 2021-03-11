using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public void UpdateDatos(string placa, string digito, string rut, int tipo, string codigo, string modelo, int anno, string color, string nroMotor, string nroChassis, int puertas, int tasacion, int cilindrada, string combustible, string transmision, string equipamiento, string version, int codigoMarca) {
            context = new Permisos_de_CirculacionEntities();
            string placa2;
            if (placa.IndexOf("0").Equals(2) || placa.IndexOf("1").Equals(2) || placa.IndexOf("2").Equals(2) || placa.IndexOf("3").Equals(2) || placa.IndexOf("4").Equals(2) || placa.IndexOf("5").Equals(2) || placa.IndexOf("6").Equals(2) || placa.IndexOf("7").Equals(2) || placa.IndexOf("8").Equals(2) || placa.IndexOf("9").Equals(2)) placa2 = placa.Substring(0, 2) + "-" + placa[2] + placa[3] + placa[4] + placa[5];
            else placa2 = placa.Substring(0, 4) + "-" + placa[4] + placa[5];
            Datos_del_Vehiculo vehiculo = GetDatos(placa);
            if (rut.Length == 9) rut = "00" + rut;
            if (rut.Length == 10) rut = "0" + rut;
            if (rut.Length == 8) rut = "000" + rut;
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
            vehiculo.Codigo_Marca = Convert.ToInt16(codigoMarca);
            string query = "UPDATE [Datos_del_Vehiculo] SET Digito='" + vehiculo.Digito + "', Rut='" + vehiculo.Rut + "', Tipo_Vehiculo = " + vehiculo.Tipo_Vehiculo + ", Codigo_SII = '" + vehiculo.Codigo_SII + "', Modelo = '" + vehiculo.Modelo + "', Año_Fabricacion = " + vehiculo.Año_Fabricacion + ", Color='" + vehiculo.Color + "', Numero_Motor='" + vehiculo.Numero_Motor + "', Numero_Chasis = '" + vehiculo.Numero_Chasis + "', Numero_Chassis='" + vehiculo.Numero_Chassis + "', Numero_Puertas = " + vehiculo.Numero_Puertas + ", Tasacion = " + vehiculo.Tasacion + ", Cilindrada = " + vehiculo.Cilindrada + ", Combustible = '" + vehiculo.Combustible + "', Transmision = '" + vehiculo.Transmision + "', Equipamiento = '" + vehiculo.Equipamiento + "', Version = '" + vehiculo.Version + "', Codigo_Marca = " + vehiculo.Codigo_Marca + " WHERE Placa = '" + vehiculo.Placa + "'";
            new Connection().Coneccion(query);
        }

        public void InsertDatos(string placa, string digito, string rut, int tipo, string codigo, string modelo, int anno, string color, string nroMotor, string nroChassis, int puertas, int tasacion, int cilindrada, string combustible, string transmision, string equipamiento, string version, int codigoMarca) {
            context = new Permisos_de_CirculacionEntities();
            string placa2;
            if (placa.IndexOf("0").Equals(2) || placa.IndexOf("1").Equals(2) || placa.IndexOf("2").Equals(2) || placa.IndexOf("3").Equals(2) || placa.IndexOf("4").Equals(2) || placa.IndexOf("5").Equals(2) || placa.IndexOf("6").Equals(2) || placa.IndexOf("7").Equals(2) || placa.IndexOf("8").Equals(2) || placa.IndexOf("9").Equals(2)) placa2 = placa.Substring(0, 2) + "-" + placa[2] + placa[3] + placa[4] + placa[5];
            else placa2 = placa.Substring(0, 4) + "-" + placa[4] + placa[5];
            Datos_del_Vehiculo vehiculo = new Datos_del_Vehiculo();
            if (rut.Length == 9) rut = "00" + rut;
            if (rut.Length == 10) rut = "0" + rut;
            if (rut.Length == 8) rut = "000" + rut;
            vehiculo.Placa = placa2;
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
            vehiculo.Codigo_Marca = Convert.ToInt16(codigoMarca);
            string query = "INSERT INTO Datos_del_Vehiculo (Placa, Digito, Rut, Tipo_Vehiculo, Codigo_SII, Modelo, Año_Fabricacion, Color, Numero_Motor, Numero_Chasis, Numero_Chassis, Numero_Puertas, Tasacion, Cilindrada, Combustible, Transmision, Equipamiento, Version, Tipo_Sello, Usar_para_envio_de_Correo, Asimilado, Tasado, Codigo_Marca) VALUES ('" + vehiculo.Placa + "', '" + vehiculo.Digito + "', '" + vehiculo.Rut + "', " + vehiculo.Tipo_Vehiculo + ", '" + vehiculo.Codigo_SII + "', '" + vehiculo.Modelo + "', " + vehiculo.Año_Fabricacion + ", '" + vehiculo.Color + "', '" + vehiculo.Numero_Motor + "', '" + vehiculo.Numero_Chasis + "', '" + vehiculo.Numero_Chassis + "', " + vehiculo.Numero_Puertas + ", " + vehiculo.Tasacion + ", " + vehiculo.Cilindrada + ", '" + vehiculo.Combustible + "', '" + vehiculo.Transmision + "', '" + vehiculo.Equipamiento + "', '" + vehiculo.Version + "', 0, 0, 0, 0," + vehiculo.Codigo_Marca +")";
            new Connection().Coneccion(query);            
        }

    }
}
