using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
   public  class Texto
    {
        public static bool guardar(string arch, string datos)
        {
            StreamWriter stream = new StreamWriter(arch, false);

            try
            {
                stream.Write(datos);
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
                return false;
            }
            finally
            {
                stream.Close();
            }

            return true;
        }

        public static bool leer(string arch, out string d)
        {
            StreamReader stream = new StreamReader(arch);
            d = stream.ReadToEnd();
            stream.Close();

            return true;
        }
    }
}
