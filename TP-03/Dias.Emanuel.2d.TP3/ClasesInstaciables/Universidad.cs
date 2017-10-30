using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Excepciones;
using System.IO;
namespace ClasesInstaciables
{
    public class Universidad
    {
        private List<Jornada> _jornada;
        private List<Profesor> _profesores;
        private List<Alumno> _alumnos;

        public enum EClases { Laboratorio, Legislacion, Programacion, SPD }

        public List<Profesor> Instructores
        {
            get
            {
                return _profesores;
            }
            set
            {
                _profesores = value;
            }
        }



        public List<Alumno> Alumnos
        {
            get
            {
                return _alumnos;
            }
            set
            {
                _alumnos = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return _jornada;
            }
            set
            {
                _jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return _jornada[i];
            }
            set
            {
                _jornada[i] = value;
            }
        }

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Instructores = new List<Profesor>();
            this.Jornadas = new List<Jornada>();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                    retorno = true;
            }

            return retorno;
        }

        public static Profesor operator ==(Universidad Universidad, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor profesor in Universidad.Instructores)
            {
                if (profesor == clase)
                    retorno = profesor;
            }
            return retorno;
        }

        public static bool operator ==(Universidad Universidad, Profesor prof)
        {
            bool retorno = false;

            foreach (Profesor profesor in Universidad.Instructores)
            {
                if (profesor == prof)
                    retorno = true;
            }

            return retorno;
        }

        public static bool operator !=(Universidad universidad, Alumno a)
        {
            return !(universidad == a);
        }

        public static Profesor operator !=(Universidad universidad, EClases clase)
        {
            Profesor retorno = null;

            foreach (Profesor profesor in universidad.Instructores)
            {
                if (!profesor.Equals(clase))
                    retorno = profesor;
            }

            return retorno;
        }

        public static bool operator !=(Universidad Universidad, Profesor prof)
        {
            return !(Universidad == prof);
        }

        public static Universidad operator +(Universidad Universidad, Alumno a)
        {
            try
            {
                if (Universidad != a)
                {
                    Universidad.Alumnos.Add(a);
                }
                else
                {
                    throw new AlumnoRepetidoException();
                }
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
                return Universidad;
            }
            return Universidad;
        }

        public static Universidad operator +(Universidad Universidad, EClases clase)
        {
            Profesor profe = (Universidad == clase);
            List<Alumno> alumnos = new List<Alumno>();
            Jornada jornada = null;

            if (!(Object.Equals(profe, null)))
            {
                jornada = new Jornada(clase, profe);
            }
            if (!(Object.Equals(jornada, null)))
            {
                foreach (Alumno al in Universidad.Alumnos)
                {
                    if (al == clase)
                        jornada = jornada + al;
                }

                Universidad.Jornadas.Add(jornada);
            }

            return Universidad;
        }

       

        public static Universidad operator +(Universidad universidad, Profesor i)
        {
            try
            {
                if (universidad != i)
                {
                    universidad.Instructores.Add(i);
                }
                else
                {
                    throw new SinProfesorException();
                }
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }

            return universidad;
        }

        public static bool Guardar(Universidad gim)
        {
            StreamWriter texto = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", false);
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            try
            {
                xml.Serialize(texto, gim);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                texto.Close();
            }

            return true;
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static Universidad Leer()
        {
            StreamReader texto = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Universidad));

            Universidad universidad = (Universidad)xml.Deserialize(texto);

            texto.Close();

            return universidad;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder texto = new StringBuilder("");
            /*
            foreach (Alumno alumno in gim.Alumnos)
            {
                texto.Append(alumno.ToString());
            }
            */
            foreach (Jornada jornada in gim.Jornadas)
            {
                texto.Append(jornada.ToString());
            }

            foreach (Profesor profesor in gim.Instructores)
            {
                texto.Append(profesor.ToString());
            }

            return texto.ToString();
        }
    }
}
