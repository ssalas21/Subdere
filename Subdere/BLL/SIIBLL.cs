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

        public List<SII> FindCodigo(string codigo, int anno, string marca, string modelo, string version, int cilindrada) {
            context = new Permisos_de_CirculacionEntities();
            string codSii = codigo + anno.ToString().Substring(2, 2);
            return (from l in context.SII where l.Codigo.Contains(codSii) && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) && l.Version.Contains(version) && l.Cilindrada == cilindrada select l).ToList();
        }

        public List<SII> FindCodigoAnno(int anno) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno select l).ToList();
        }

        public List<SII> FindCodigoMarca(string marca) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Marca.Contains(marca) select l).ToList();
        }

        public List<SII> FindCodigoModelo(string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Modelo.Contains(modelo) select l).ToList();
        }

        public List<SII> FindCodigoVersion(string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoAnnoVersion(int anno, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoAnnoMarca(int anno, string marca) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Marca.Contains(marca) select l).ToList();
        }

        public List<SII> FindCodigoAnnoModelo(int anno, string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Modelo.Contains(modelo) select l).ToList();
        }

        public List<SII> FindCodigoAnnoModeloVersion(int anno, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoAnnoMarcaModelo(int anno, string marca, string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) select l).ToList();
        }

        public List<SII> FindCodigoAnnoMarcaVersion(int anno, string marca, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Marca.Contains(marca) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoAnnoMarcaModeloVersion(int anno, string marca, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Año_Fabricacion == anno && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoMarcaModelo(string marca, string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Marca.Contains(marca) && l.Modelo.Contains(modelo) select l).ToList();
        }

        public List<SII> FindCodigoMarcaVersion(string marca, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Marca.Contains(marca) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoMarcaModeloVersion(string marca, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Marca.Contains(marca) && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodigoModeloVersion(string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindOnlyCode(string code) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) select l).ToList();
        }

        public List<SII> FindCodeVersion(string code, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodeModel(string code, string model) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Modelo.Contains(model) select l).ToList();
        }

        public List<SII> FindCodeMarca(string code, string marca) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Marca.Contains(marca) select l).ToList();
        }

        public List<SII> FindCodeAnno(string code, int anno) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Año_Fabricacion == anno select l).ToList();
        }

        public List<SII> FindCodeModeloVersion(string code, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodeMarcaVersion(string code, string marca, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Marca.Contains(marca) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodeAnnoVersion(string code, string version, int anno) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Version.Contains(version) && l.Año_Fabricacion == anno select l).ToList();
        }

        public List<SII> FindCodeMarcaModelo(string code, string marca, string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) select l).ToList();
        }

        public List<SII> FindCodeAnnoModelo(string code, int anno, string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Año_Fabricacion == anno && l.Modelo.Contains(modelo) select l).ToList();
        }

        public List<SII> FindCodeMarcaAnno(string code, string marca, int anno) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Marca.Contains(marca) && l.Año_Fabricacion == anno select l).ToList();
        }

        public List<SII> FindCodeMarcaModeloVersion(string code, string marca, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodeAnnoModeloVersion(string code, int anno, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Año_Fabricacion == anno && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodeAnnoMarcaVersion(string code, int anno, string marca, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Año_Fabricacion == anno && l.Marca.Contains(marca) && l.Version.Contains(version) select l).ToList();
        }

        public List<SII> FindCodeAnnoMarcaModelo(string code, int anno, string marca, string modelo) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Año_Fabricacion == anno && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) select l).ToList();

        }

        public List<SII> FindCodeAnnoMarcaModeloVersion(string code, int anno, string marca, string modelo, string version) {
            context = new Permisos_de_CirculacionEntities();
            return (from l in context.SII where l.Codigo.Contains(code) && l.Año_Fabricacion == anno && l.Marca.Contains(marca) && l.Modelo.Contains(modelo) && l.Version.Contains(version) select l).ToList();
        }

    }
}
