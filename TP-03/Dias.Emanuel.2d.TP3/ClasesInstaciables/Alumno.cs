using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClasesAbstractas;

namespace ClasesInstaciables
{
    public sealed class Alumno : Universitario
    {

        private EEstadoDeCuenta _estadoCuenta;
        private Universidad.EClases _claseQueToma;
        public enum EEstadoDeCuenta { aldia, Deudor, Becado }

        public Alumno() : base() { }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoDeCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (!(a._estadoCuenta.Equals(EEstadoDeCuenta.Deudor)) && a._claseQueToma.Equals(clase));
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a._claseQueToma.Equals(clase));
        }

        protected override string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder("");

            texto.Append(base.MostrarDatos());
            texto.Append("ESTADO DE CUENTA: " + this._estadoCuenta + "\n");
            texto.Append(this.ParticiparEnClase());

            return texto.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this._claseQueToma + "\n";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
