using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Calculadora
    {
        /// <summary>
        /// Esta funcion se encarga de realizar la operacion matematica recibiendo el operador validado previamente
        /// Tambien se previamente valida que en el segundo parametro de entrada (n2) no reciba un 0
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <param name="operador"></param>
        /// <returns>Res</returns>
        public double operar(Numero n1, Numero n2, string operador)
        {
            double res = 0;
            switch (operador)
            {
                case "+":
                    res = n1.getNumero() + n2.getNumero();
                    break;

                case "-":
                    res = n1.getNumero() - n2.getNumero();
                    break;

                case "*":
                    res = n1.getNumero() * n2.getNumero();
                    break;

                case "/":
                    res = n1.getNumero() / n2.getNumero();
                    break;
            }
            return res;
        }
        /// <summary>
        /// Recibe un String y valida que sea un operador valido, en caso contrario retorna el operador "+"
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>operador o "+"</returns>
        public String validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                return "+";
            else return operador;

        }
    }
}
