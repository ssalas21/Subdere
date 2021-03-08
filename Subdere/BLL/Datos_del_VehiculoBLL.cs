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

    }
}
