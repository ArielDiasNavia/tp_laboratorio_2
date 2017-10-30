using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            StreamWriter stream = new StreamWriter(archivo, false);
            XmlSerializer xml = new XmlSerializer(typeof(T));

            try
            {
                xml.Serialize(stream, datos);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            finally
            {
                stream.Close();
            }

            return true;
        }

        public bool leer(string archivo, out T datos) { datos = default(T); return true; }
    }
}
