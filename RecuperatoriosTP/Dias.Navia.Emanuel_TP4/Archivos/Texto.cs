using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _nomArhc;

        /// <summary>
        /// constructor que recibe el nombre del archivo
        /// </summary>
        /// <param name="archivo"></param>
        public Texto(string archivo)
        {
            this._nomArhc = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter sw = new StreamWriter(this._nomArhc, true);
                sw.WriteLine(datos);

                sw.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Si no falla, lee todos los datos del Arhivo.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader sr = new StreamReader(this._nomArhc);

                datos = new List<string>();

                while (!sr.EndOfStream)
                {
                    datos.Add(sr.ReadLine());
                }

                sr.Close();

                return true;
            }
            catch (Exception)
            {
                datos = default(List<string>);
                return false;
            }
        }

    }

}
