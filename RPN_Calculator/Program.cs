using System.Text;

namespace Calc_RP;

using System.Globalization;

class CalcRP
{
    static void Main(string[] args)
    {
        string expression = Console.ReadLine();
        StringBuilder currentNumber = new StringBuilder();

        Stack<string> expr_obj = new Stack<string>();
        string rpn_expression = null;
        List<string> RPN_expression = new List<string>();

        foreach (char c in expression) //Конвертацию сделать отдельным методом
        {
            if (char.IsDigit(c))
                currentNumber.Append(c);
            else
            {
                if (currentNumber.Length > 0) //Добавляем число в лист постфиксной записи
                {
                    RPN_expression.Add(currentNumber.ToString());
                    currentNumber.Clear();
                }

                switch (c) //Отработка операторов (надо вынести в отдельный метод)
                {
                    case '+':
                    case '-':
                        expr_obj.Push(c.ToString());
                        break;
                    case '/':
                    case '*':
                        if (expr_obj.Peek() == "/" || expr_obj.Peek() == "*" || expr_obj.Peek() == "^")
                            RPN_expression.Add(expr_obj.Pop());
                        expr_obj.Push(c.ToString());
                        break;
                    case '^':
                        if (expr_obj.Peek() == "^")
                            RPN_expression.Add(expr_obj.Pop());
                        expr_obj.Push(c.ToString());
                        break;
                    case '(':
                        expr_obj.Push(c.ToString());
                        break;
                    case ')':
                        try
                        {
                            while (expr_obj.Peek() != "(")
                            {
                                RPN_expression.Add(expr_obj.Pop());
                            }

                            expr_obj.Pop();
                        }
                        catch
                        {
                            Console.WriteLine("Отсутствует в выражении '('");
                        }

                        break;
                }
            }
        }

        if (currentNumber.Length > 0) //Добавляем число в лист постфиксной записи
        {
            RPN_expression.Add(currentNumber.ToString());
            currentNumber.Clear();
        }

        while (expr_obj.Count > 0)
        {
            RPN_expression.Add(expr_obj.Pop());
        }

        foreach (string item in RPN_expression)
        {
            rpn_expression += item.ToString() + " ";
        }

        Console.WriteLine(rpn_expression);
    }
}