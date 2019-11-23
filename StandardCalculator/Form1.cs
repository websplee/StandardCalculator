using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardCalculator
{
    public partial class frmMainForm : Form
    {
        bool lastChrOperator = false;
        char[] operators;        

        public frmMainForm()
        {
            InitializeComponent();
            InitializeOperators();
        }

        private void InitializeOperators()
        {
            operators = new char[6];
            // Take NOTE of BODMAS rules in indexes of array
            //operators[0] = '(';
            // operators[1] = ')';
            operators[0] = '/';
            operators[1] = '*';
            operators[2] = '+';
            operators[3] = '-';
        }
        // General number click handler
        private void GeneralBtnClick(string btnValue)
        {
            if (txtScreen.Text == "0" && txtScreen.Text != null)
                txtScreen.Text = btnValue;
            else
                txtScreen.Text += btnValue;
            lastChrOperator = false;
        }

        // Operator handler
        private void OperatorHandler(string btnValue)
        {
            if (lastChrOperator)
                txtScreen.Text.Remove(txtScreen.Text.Length - 1);

            if (txtScreen.Text == "0" && txtScreen.Text != null)
                return;
            else
                txtScreen.Text += btnValue;
            lastChrOperator = true;
        }
        
        // Button 7 click
        private void btn7_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("9");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("6");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("3");
        }        

        private void btn0_Click(object sender, EventArgs e)
        {
            this.GeneralBtnClick("0");
        }

        private void btnSymbol_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "0";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            this.OperatorHandler("/");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            this.OperatorHandler("*");
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            this.OperatorHandler("-");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            this.OperatorHandler("+");
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            string answer = null;
            IBaseCalculator calculator = new CalculatorCore(this.operators);
            try
            {
                answer = calculator.EvaluateEquation(txtScreen.Text);
            }
            catch(ArithmeticException ex)
            {
                answer = "0";
                MessageBox.Show(ex.Message, "Standard Calculator Error");
                throw ex;
            }
            finally
            {
                txtScreen.Text = answer;
            }                        
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text != "0" && txtScreen.Text != null)
            txtScreen.Text = txtScreen.Text.Remove(txtScreen.Text.Length - 1);
        }
    }
}
