using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardCalculator
{
    interface IBaseCalculator
    {
        string EvaluateEquation(string equation);
        string EvaluateOperation(string equation, char op);
        double EvaluateAddition(double a, double b);
        double EvaluateSubtraction(double a, double b);
        double EvaluateMultiplication(double a, double b);
        double EvaluateDivision(double a, double b);
    }
}
