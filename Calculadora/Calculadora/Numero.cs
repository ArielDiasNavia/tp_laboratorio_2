using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Numero
    {
        private double _numero;

        /// <summary>
        /// Metodo que devuelve el atributo _numero
        /// </summary>
        /// <returns>this._numero</returns>
        public double getNumero()
        {
            return this._numero;
        }
        /// <summary>
        /// inicializa  el atributo numero en cero en 0
        /// </summary>
        public Numero()
        {
            this._numero = 0;
        }

        /// <summary>
        /// recibe un double y carga en el atributo numero
        /// </summary>
        /// <param name="num"></param>
        public Numero(double num)
        {
            this._numero = num;
        }

        /// <summary>
        /// recibe un String que validará y cargará en el atributo numero
        /// </summary>
        /// <param name="num"></param>
        public Numero(String num)
        {
            this.setNumero(num);
           
        }

        /// <summary>
        /// carga el atributo _numero con el parametro entrada
        /// se valida previamente con el metodo validarNumero
        /// </summary>
        /// <param name="num"></param>
        private void setNumero(string num)
        {
            this._numero = validarNumero(num);
        }

        /// <summary>
        /// valida el numero recibido por string con la funcion TryParse
        /// si el numero se pudo parsear a double lo devuelve si no devuelve 0
        /// </summary>
        /// <param name="num"></param>
        /// <returns>number o 0</returns>
        private double validarNumero(string num)
        {
            double number;
            bool result = double.TryParse(num, out number);
            if (result)
                return number;
            else return 0;
        }
    }

    
}
