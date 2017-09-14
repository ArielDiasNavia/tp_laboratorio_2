using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class CalculadoraForm : Form
    {
        public CalculadoraForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Calculadora_Load(object sender, EventArgs e)
        {

        }
        
       /// <summary>
       /// Accion del boton operar
       /// Se obtienen los nros ingresados
       /// Se valida el operador ingresado
       /// Se valida que si el segundo operador es 0 y el operador es / se retorna 0 como resultado
       /// se realiza la operacion 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            Calculadora calc = new Calculadora();
            Numero n1 = new Numero(txtNumero1.Text);
            Numero n2 = new Numero(txtNumero2.Text);
            this.cmbOperacion.Text = calc.validarOperador(this.cmbOperacion.Text);

            if (n2.getNumero() == 0 && this.cmbOperacion.Text == "/")
                this.lblResultado.Text = "0";
            else
                this.lblResultado.Text = calc.operar(n1, n2, this.cmbOperacion.Text).ToString();
                    
        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// Se valida que por teclado no se pueda ingresar caracteres que no sean ,- o digito
        /// para evitar errores al ingreso de datos
        /// todo se realiza en el ingreso de caracteres del text 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // valido si es numero o letra para el dia
            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == '-' || e.KeyChar == ',') && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// Se valida que por teclado no se pueda ingresar caracteres que no sean ,- o digito
        /// para evitar errores al ingreso de datos
        /// todo se realiza en el ingreso de caracteres del text 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // valido si es numero o letra para el dia
            if (!Char.IsNumber(e.KeyChar) && !(e.KeyChar == '-' || e.KeyChar == ',') && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// limpia los valores del resultado, los numeros y operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = null;
            txtNumero1.Text = null;
            txtNumero2.Text = null;
            cmbOperacion.Text = null;
        }
    }
}
