using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethods
{
    public class MyMath
    {
        private int m_accumulateNumber;
        public void ResetAccumulate( int a_number = 0 )
        {
            this.m_accumulateNumber = a_number;
        }
        public void Accumulate(int a_number)
        {
            this.m_accumulateNumber += a_number;
        }
        public int GetAccumulate()
        {
            return this.m_accumulateNumber;
        }

        public static int AddNumber( int a_num1, int a_num2 )
        {
            return a_num1 + a_num2;
        }
    }

    public class MyMathPlan : MyMath
    {
        public virtual void Execute()
        {
            // Reset
            this.ResetAccumulate();
            // Accumulate
            this.Accumulate(1);
            // Output
            Console.WriteLine(this.GetAccumulate());
        }
    }
}
