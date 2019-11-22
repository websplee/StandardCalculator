using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardCalculator
{
    class CaculatorCore
    {
        public string EvaluateEquation(string equation)
        {

            while (equation.Contains('/'))
                equation = EvaluateDivision(equation);
            while (equation.Contains('*'))
                equation = EvaluateMultiplication(equation);
            while (equation.Contains('+'))
                equation = EvaluateAddition(equation);
            while (equation.Contains('-'))
                equation = EvaluationSubtration(equation);

            return equation;
        }
        private string EvaluateDivision(string equation)
        {
            Double answer;
            string newEquation;
            int i = 0;
            if (equation.Contains('/'))
                i = equation.IndexOf('/');
            answer = Double.Parse(equation[i - 1].ToString()) / Double.Parse(equation[i + 1].ToString());
            if (equation.Length < 4)
                return answer.ToString();
            newEquation = answer.ToString() + equation.Substring(equation.IndexOf('/') + 1);
            return newEquation;
        }

        private string EvaluateMultiplication(string equation)
        {
            Double answer;
            string newEquation;
            int i = 0;
            if (equation.Contains('*'))
                i = equation.IndexOf('*');
            answer = Double.Parse(equation[i - 1].ToString()) * Double.Parse(equation[i + 1].ToString());
            if (equation.Length < 4)
                return answer.ToString();
            newEquation = answer.ToString() + equation.Substring(equation.IndexOf('*') + 1);
            return newEquation;
        }

        private string EvaluateAddition(string equation)
        {
            Double answer;
            string newEquation;
            int i = 0;
            if (equation.Contains('+'))
                i = equation.IndexOf('+');
            answer = Double.Parse(equation[i - 1].ToString()) + Double.Parse(equation[i + 1].ToString());
            if (equation.Length < 4)
                return answer.ToString();
            newEquation = answer.ToString() + equation.Substring(equation.IndexOf('+') + 1);
            return newEquation;
        }

        private string EvaluationSubtration(string equation)
        {
            Double answer;
            string newEquation;
            int i = 0;
            if (equation.Contains('-'))
                i = equation.IndexOf('-');
            answer = Double.Parse(equation[i - 1].ToString()) - Double.Parse(equation[i + 1].ToString());
            if (equation.Length < 4)
                return answer.ToString();
            newEquation = answer.ToString() + equation.Substring(equation.IndexOf('-') + 1);
            return newEquation;
        }
    }
}
