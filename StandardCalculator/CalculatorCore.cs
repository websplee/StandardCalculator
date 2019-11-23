using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandardCalculator
{
    public class CalculatorCore : BaseCalculator
    {
        private char[] operators;

        public CalculatorCore(char[] _operators) : base(_operators) {
            this.operators = _operators;
        }       

        public override string EvaluateEquation(string equation)
        {            
            for (int i = 0; i < this.operators.Length; i++)
            {
                while (equation.Contains(this.operators[i]))
                    try
                    {
                        equation = EvaluateOperation(equation, operators[i]);
                    }
                    catch (ArithmeticException ex)
                    {
                        equation = 0.ToString();
                        MessageBox.Show(ex.Message, "Standard Calculator Error");
                        throw ex;
                    }
            }
            return equation;
        }                       
    }
}
