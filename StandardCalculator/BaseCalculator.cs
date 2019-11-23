using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardCalculator
{
    public abstract class BaseCalculator : IBaseCalculator
    {
        private char[] Operators { get; set; }
        private double answer = 0;

        public BaseCalculator(char[] operators)
        {
            this.Operators = operators;
        }

        public string EvaluateOperation(string equation, char op)
        {
            int i = 0;

            if (equation.Contains(op))
                i = equation.IndexOf(op);
            switch (op)
            {
                case '(':
                    throw new NotImplementedException();
                case ')':
                    throw new NotImplementedException();
                case '/':
                    answer = EvaluateDivision(Double.Parse(equation[i - 1].ToString()),
                             Double.Parse(equation[i + 1].ToString()));
                    break;
                case '*':
                    answer = EvaluateMultiplication(Double.Parse(equation[i - 1].ToString()),
                             Double.Parse(equation[i + 1].ToString()));
                    break;
                case '+':
                    answer = EvaluateAddition(Double.Parse(equation[i - 1].ToString()),
                             Double.Parse(equation[i + 1].ToString()));
                    break;
                case '-':
                    answer = EvaluateSubtraction(Double.Parse(equation[i - 1].ToString()),
                             Double.Parse(equation[i + 1].ToString()));
                    break;
            }

            // remove the evaluated equation
            equation = equation.Remove(i - 1, 3);

            // insert the answer
            equation = equation.Insert(i - 1, answer.ToString());

            return equation;
        }

        public double EvaluateAddition(double a, double b)
        {
            try
            {
                answer = a + b;
            }
            catch(ArithmeticException ex)
            {
                throw ex;
            }
            return answer;
        }

        public double EvaluateSubtraction(double a, double b)
        {
            try
            {
                answer = a - b;
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
            return answer;
        }

        public double EvaluateMultiplication(double a, double b)
        {
            try
            {
                answer = a * b;
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
            return answer;
        }

        public double EvaluateDivision(double a, double b)
        {
            try
            {
                answer = a / b;
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
            return answer;
        }

        public abstract string EvaluateEquation(string equation);
    }
}
