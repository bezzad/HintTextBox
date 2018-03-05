using System;
using System.Collections;
using System.Collections.Generic;

namespace Windows.Forms
{
    public class MathParser
    {
        private readonly List<String> _operationOrder = new List<string>();


        public MathParser()
        {
            _operationOrder.Add("/");
            _operationOrder.Add("*");
            _operationOrder.Add("-");
            _operationOrder.Add("+");
        }

        public decimal Calculate(string formula)
        {
            try
            {
                while (formula.LastIndexOf("(", StringComparison.Ordinal) > -1)
                {
                    var lastOpenPhrantesisIndex = formula.LastIndexOf("(", StringComparison.Ordinal);
                    var firstClosePhrantesisIndexAfterLastOpened = formula.IndexOf(")", lastOpenPhrantesisIndex, StringComparison.Ordinal);
                    var result = ProcessOperation(formula.Substring(lastOpenPhrantesisIndex + 1, firstClosePhrantesisIndexAfterLastOpened - lastOpenPhrantesisIndex - 1));
                    var appendAsterix = false;
                    if (lastOpenPhrantesisIndex > 0)
                    {
                        if (formula.Substring(lastOpenPhrantesisIndex - 1, 1) != "(" && !_operationOrder.Contains(formula.Substring(lastOpenPhrantesisIndex - 1, 1)))
                        {
                            appendAsterix = true;
                        }
                    }

                    formula = formula.Substring(0, lastOpenPhrantesisIndex) + (appendAsterix ? "*" : "") + result + formula.Substring(firstClosePhrantesisIndexAfterLastOpened + 1);

                }
                return ProcessOperation(formula);
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occurred While Calculating. Check Syntax", ex);
            }
        }

        private decimal ProcessOperation(string operation)
        {
            var arr = new ArrayList();
            var s = "";
            for (var i = 0; i < operation.Length; i++)
            {
                var currentCharacter = operation.Substring(i, 1);
                if (_operationOrder.IndexOf(currentCharacter) > -1)
                {
                    if (s != "")
                    {
                        arr.Add(s);
                    }
                    arr.Add(currentCharacter);
                    s = "";
                }
                else
                {
                    s += currentCharacter;
                }
            }
            arr.Add(s);
            foreach (var op in _operationOrder)
            {
                while (arr.IndexOf(op) > -1)
                {
                    var operatorIndex = arr.IndexOf(op);
                    var digitBeforeOperator = Convert.ToDecimal(arr[operatorIndex - 1]);
                    decimal digitAfterOperator;
                    if (arr[operatorIndex + 1].ToString() == "-")
                    {
                        arr.RemoveAt(operatorIndex + 1);
                        digitAfterOperator = Convert.ToDecimal(arr[operatorIndex + 1]) * -1;
                    }
                    else
                    {
                        digitAfterOperator = Convert.ToDecimal(arr[operatorIndex + 1]);
                    }
                    arr[operatorIndex] = CalculateByOperator(digitBeforeOperator, digitAfterOperator, op);
                    arr.RemoveAt(operatorIndex - 1);
                    arr.RemoveAt(operatorIndex);
                }
            }
            return Convert.ToDecimal(arr[0]);
        }

        private decimal CalculateByOperator(decimal number1, decimal number2, string op)
        {
            switch (op)
            {
                case "/":
                    return number1 / number2;
                case "*":
                    return number1 * number2;
                case "-":
                    return number1 - number2;
                case "+":
                    return number1 + number2;
                default:
                    return 0;
            }
        }
    }
}
