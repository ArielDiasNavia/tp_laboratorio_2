using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
        public interface IArchivo<T>
        {
            bool guardar(string arch, T d);
            
            bool leer(string arch, out T d); 
        }
    
}
