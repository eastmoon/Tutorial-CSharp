using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMethods;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // default Plan
            Console.WriteLine("Default :");
            MyMathPlan plan = new MyMathPlan();
            plan.Execute();

            // Reset plan
            Console.WriteLine("New :");
            plan = new NewMathPlan();
            plan.Execute();
        }
    }

    class NewMathPlan : MyMathPlan
    {
        public override void Execute()
        {
            this.ResetAccumulate(1);

            for(int i = 0 ; i < 10 ; i++ )
            {
                this.Accumulate(i);
                Console.WriteLine(this.GetAccumulate());
            }
        }
    }
}
