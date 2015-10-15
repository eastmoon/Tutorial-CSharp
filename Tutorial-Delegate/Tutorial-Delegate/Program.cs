using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_Delegate
{
    class Program
    {
        // Declare delegate type
        public delegate void StringDelegat( string a_info );
        public delegate void MathDelegate( int a_num1, int a_num2 );
        
        // Main Process
        static void Main(string[] args)
        {
            Program root = new Program();
            StringDelegat text = root.OutputString;
            MathDelegate math = root.OutputAdd;
            text("It is Test 1 : 5 + 5");
            math(5, 5);

            math = root.OutputSub;
            text("It is Test 2 : 10 + 5");
            math(10, 5);
        }

        // Text out function
        public void OutputString( string a_info )
        {
            Console.WriteLine("Out : " + a_info);
        }
        // Math calculate function
        public void OutputAdd( int a_num1, int a_num2 )
        {
            Console.WriteLine("Add : " + ( a_num1 + a_num2 ).ToString());
        }
        public void OutputSub(int a_num1, int a_num2)
        {
            Console.WriteLine("Sub : " + ( a_num1 - a_num2 ).ToString());
        }
    }
}
