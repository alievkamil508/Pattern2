using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    interface ICalculator
    {
        int Add(int left, int right);
        int Subtract(int left, int right);
        int Multiply(int left, int by);
        int Divide(int left, int by);
    }

    interface ICalculatorImplementation
    {
        int Add(int left, int right);
        int Subtract(int left, int right);
        int Multiply(int left, int by);
        int Divide(int left, int by);
    }


    class ChineesImplementation : ICalculatorImplementation
    {
        public int Add(int left, int right)
        {
            return left + right;
        }


        public int Subtract(int left, int right)
        {
            int count = 0;
            for (int i = right; i < left; i++)
            {
                count++;
            }
            return count;
        }


        // Можно и так

        /*
        public int Subtract(int left, int right)
        {
            return left + (~right) + 1;
        }
        */

        public int Multiply(int left, int by)
        {
            int leftconst = left;

            for (int i = 1; i < by; i++)
            {
                left += leftconst;
            }
            return left;
        }

        public int Divide(int left, int by)
        {

            int count = 1;

            while(left>by)
            {
                left -= by;
                count++;
            }

            return count;
            
        }
    }

    class IndianImplementation : ICalculatorImplementation
    {
        public int Add(int left, int right)
        {
            return left + right;
        }

        public int Subtract(int left, int right)
        {
            return left - right;
        }

        public int Multiply(int left, int by)
        {
            return left * by;
        }

        public int Divide(int left, int by)
        {
            return left / by;
        }
    }


    interface IScienceCalculator
    {
        double log2(double left);
    }

    class SimpleCalculator<T>: ICalculator where T: ICalculatorImplementation, new()
    {
        T implementation ;

        public SimpleCalculator()
        {
            implementation = new T();
        }



        public int Add(int left, int right)
        {
            return implementation.Add(left, right);
        }

        public int Subtract(int left, int right)
        {
            return implementation.Subtract(left, right);
        }

        public int Multiply(int left, int by)
        {
            return implementation.Multiply(left, by);
        }

        public int Divide(int left, int by)
        {
            return implementation.Divide(left, by);
        }
    }

    class ScientificCalculator : ICalculator, IScienceCalculator
    {
        public int Add(int left, int right)
        {
            return left + right;
        }

        public int Subtract(int left, int right)
        {
            return left - right;
        }

        public int Multiply(int left, int by)
        {
            return left * by;
        }

        public int Divide(int left, int by)
        {
            return left / by;
        }


        public double log2(double left)
        {
            return Math.Log(left);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calc = new SimpleCalculator<ChineesImplementation>();

            Console.WriteLine(calc.Add(2, 5));
            Console.WriteLine(calc.Subtract(20, 5));
            Console.WriteLine(calc.Divide(60, 12));
            Console.WriteLine(calc.Multiply(7,3));
            
        }
    }
}
