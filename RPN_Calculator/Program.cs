namespace Calc_RP;
using System.Globalization;
class CalcRP
{   
    static void Main(string[] args)
    {
        var expression = Console.ReadLine();
        char[] numbers = expression.ToCharArray();
        Stack<char> expr_obj = new Stack<char>();
        string rpn_expression = null;
        List<char> RPN_numbers=new List<char>();
        foreach (char c in numbers)
        {
            switch (c)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    RPN_numbers.Add(c);
                    break;
                case '+':
                case '-':
                    expr_obj.Push(c);
                    break;
                case '/':
                case '*':
                    if (expr_obj.Peek() == '/' || expr_obj.Peek() == '*' || expr_obj.Peek() == '^')
                        RPN_numbers.Add(expr_obj.Pop());
                    expr_obj.Push(c);
                    break;
                case '^':
                    if (expr_obj.Peek() == '^')
                        RPN_numbers.Add(expr_obj.Pop());
                    expr_obj.Push(c);
                    break;
                case '(':
                    expr_obj.Push(c);
                    break;
                case ')':
                    try
                    {
                        while (expr_obj.Peek() != '(')
                        {
                            RPN_numbers.Add(expr_obj.Pop());
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
        while (expr_obj.Count > 0)
        {
            RPN_numbers.Add(expr_obj.Pop());
        }
        foreach (char item in RPN_numbers)
        {
            rpn_expression += item.ToString() + " ";
        }
        Console.WriteLine(rpn_expression);
        
    }
}