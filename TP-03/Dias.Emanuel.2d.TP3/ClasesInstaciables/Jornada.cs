using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
namespace ClasesInstaciables
{
    public class Jornada : Texto
    {
        private Profesor _instructor;
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        
        public Universidad.EClases Clase
        {
            get { 
                return _clase; 
            }
            set { 
                _clase = value; 
            }
        }
        public List<Alumno> Alumnos
        {
            get { 
                return _alumnos;
            }
            set { 
                _alumnos = value; 
            }
        }

        public Profesor Instructor
        {
            get { 
                return _instructor;
            }
            set { 
                _instructor = value;
            }
        }

        public string Leer()
        {
            string retorno = "";

            Texto.leer("Jornada.txt", out retorno);

            return retorno;
        }

     

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");

            sb.Append("Jornada: \n");
            sb.Append("clase " + this.Clase + "\n");

            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }

            sb.Append(this.Instructor.ToString());
            sb.Append("<---------------------------------------------------------------->\n\n");

            return sb.ToString();
        }

        public static bool Guardar(Jornada jornada)
        {
            bool lretorno;
            lretorno = Texto.guardar( "Jornada.txt", jornada.ToString());
            return lretorno;
        }

        public static bool operator ==(Jornada j, Alumno a)
       { 
            foreach (Alumno alum in j._alumnos)
            {
                if (alum == a)
                    return true;
            }

            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);

            return j;
        }
    }
}
