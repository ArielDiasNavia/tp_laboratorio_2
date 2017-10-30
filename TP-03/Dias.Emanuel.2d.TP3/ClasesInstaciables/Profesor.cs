using ClasesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClasesInstaciables
{
    public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        public Profesor()
            : base()
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this()
        {
            this._legajo = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
            this.StringToDNI = dni;
        }
        private void _randomClases()
        {
            Array values = Enum.GetValues(typeof(Universidad.EClases));

            for (int i = 0; i < 2; i++)
            {
                Universidad.EClases randomBar = (Universidad.EClases)values.GetValue(_random.Next(values.Length));
                this._clasesDelDia.Enqueue(randomBar);
            }
        }
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases cl in i._clasesDelDia)
            {
                if (cl.Equals(clase))
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        protected override string MostrarDatos()
        {
            StringBuilder texto = new StringBuilder("");

            texto.Append(base.MostrarDatos());
            texto.Append(this.ParticiparEnClase());

            return texto.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder texto = new StringBuilder("");

            texto.Append("Clase: \n");

            foreach (Universidad.EClases clase in this._clasesDelDia)
            {
                texto.Append(clase.ToString() + " \n");
            }

            return texto.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
    }
}
