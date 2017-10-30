using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAbstractas
{

    public abstract class Universitario : Persona
    {
        protected int _legajo;

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            return (((Universitario)obj) == this);
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder("");

            texto.Append(base.ToString());
            texto.Append("LEGAJO NUMERO: " + this._legajo + "\n");

            return texto.ToString();
        }


        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return ((pg1._legajo == pg2._legajo || pg1.DNI == pg2.DNI) && (pg1 is Universitario && pg2 is Universitario));
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


        public Universitario() : base() { }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }


    }
}
