using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_LambdaExpressions
{
    class Program
    {
        delegate int del(int i);
        static void Main(string[] args)
        {
            // Reference : https://msdn.microsoft.com/en-us/library/bb397687.aspx
            // Reference : C# 筆記：Expression Trees, http://huan-lin.blogspot.com/2011/08/csharp-expression-trees.html
            // expression lambda：(input parameters) => expression
            // delegate type : public delegate TResult Func<TArg0, TResult>(TArg0 arg0)
            // delegate-type var-name = expression-lambda
            del multiply = x => x * x;
            // Func<T, TResult> = expression-lambda
            Func<int, int, int> add = (x, y) => x + y;
            // 
            Func<string, int, bool> stringSize = (string s, int l) => s.Length > l;

            Console.WriteLine("+ Output : " + add(5, 5));
            Console.WriteLine("* Output : " + multiply(5));
            Console.WriteLine("XXXX size more than 3 : "+ stringSize("XXXX", 3));

        }
    }
}
