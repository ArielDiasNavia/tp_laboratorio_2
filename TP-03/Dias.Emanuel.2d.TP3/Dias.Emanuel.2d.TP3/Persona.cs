using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;


namespace ClasesAbstractas
{
    public abstract class Persona
    {


        protected string _nombre;
        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;



        public string Nombre
        {
            get { 
                return _nombre;
            }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    _nombre = value;
            }
        }

        public string Apellido
        {
            get { return _apellido; }
            set
            {
                if (ValidarNombreApellido(value) != null)
                    _apellido = value;
            }
        }

        public int DNI
        {
            get { 
                return _dni; 
            }
            set
            {
                _dni = ValidarDni(Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return _nacionalidad; }
            set { _nacionalidad = value; }
        }

        public string StringToDNI
        {
            set
            {
                _dni = ValidarDni(Nacionalidad, value);
            }
        }


        public Persona() { }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("");
            str.Append("NOMBRE COMPLETO: " + this.Apellido + ", " + this.Nombre + "\n");
            str.Append("NACIONALIDAD: " + this.Nacionalidad.ToString() + "\n\n");
            return str.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            try
            {
                if ((dato < 1 || dato > 89999999) && !(nacionalidad.Equals(ENacionalidad.Argentino)))
                {
                    throw new DniInvalidoException();
                }
            }
            catch (DniInvalidoException e)
            {
              Console.WriteLine("La nacionalidad no se condice con el numero de DNI");
              return -1;
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            return ValidarDni(nacionalidad, int.Parse(dato));
        }

        private string ValidarNombreApellido(string dato)
        {

            bool isLetra = true;
            foreach( Char c in dato)
            {
                if(char.IsLetter(c))
                    isLetra=false;

            }

            if (isLetra)
                return dato;
            else
                return "";

        }

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

    }
}
