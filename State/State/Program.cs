using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    enum Light { Green, Yello, Red }

    class TrafficLight
    {
        /*
        Green
        Yello
        Red
        Yello
        */

        interface IState
        {
            IState Next(TrafficLight t);
            


        }

        class ToRedState: IState
        {

            private static ToRedState _trsInstance;
            private ToRedState() { }

            public static ToRedState GetInstance()
            {
                if (_trsInstance == null)
                    _trsInstance = new ToRedState();
                return _trsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Red;
                return RedState.GetInstance();
            }

        }

       
        class GreenState : IState
        {

            private static GreenState _gsInstance;
            private GreenState() { }

            public static GreenState GetInstance()
            {
                if (_gsInstance == null)
                    _gsInstance = new GreenState();
                return _gsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Yello;
                return ToRedState.GetInstance();
            }
        }

        class RedState : IState
        {
            private static RedState _rsInstance;
            private RedState() { }
            public static RedState GetInstance()
            {
                if (_rsInstance == null)
                    _rsInstance = new RedState();
                return _rsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Yello;
                return ToGreenState.GetInstance();
            }
        }

        class ToGreenState : IState
        {
            private static ToGreenState _tgsInstance;
            private ToGreenState() { }
            public static ToGreenState GetInstance()
            {
                if (_tgsInstance == null)
                    _tgsInstance = new ToGreenState();
                return _tgsInstance;
            }

            public IState Next(TrafficLight tl)
            {
                tl.CurrentLight = Light.Green;
                return GreenState.GetInstance();
            }
        }

        public Light CurrentLight { get; private set; } = Light.Green;

        private IState state = GreenState.GetInstance(); 

        public void Next()
        {
            state = state.Next(this);
        }

     
        public void Manuals(string str)
        {

            int value = 0;

            

            if (CurrentLight == Light.Green)
            {
                if (str == "Yello")
                {
                    value = 1;
                }
                else if(str == "Red")
                {
                    value = 2;
                }
                else if (str == "Green")
                {
                    value = 0;
                }
            }

            if (CurrentLight == Light.Red)
            {
                if (str == "Yello")
                {
                    value = 1;
                }
                else if (str == "Red")
                {
                    value = 0;
                }
                else if (str == "Green")
                {
                    value = 2;
                }

            }

            /*
            Green
            Yello
            Red
            Yello
            */

            if (CurrentLight == Light.Yello)
            {
                state = state.Next(this);

                if (CurrentLight == Light.Green)
                {
                    if (str == "Yello")
                    {
                        value = 0;
                    }
                    else if (str == "Red")
                    {
                        value = 3;
                    }
                    else if (str == "Green")
                    {
                        value = 1;
                    }
                }

                if (CurrentLight == Light.Red)
                {
                    if (str == "Yello")
                    {
                        value = 0;
                    }
                    else if (str == "Red")
                    {
                        value = 1;
                    }
                    else if (str == "Green")
                    {
                        value = 3;
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    state = state.Next(this);
                }
            }

            

            for (int i = 0; i < value; i++)
            {
                state = state.Next(this);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            TrafficLight tl = new TrafficLight();

            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();

            Console.WriteLine("----------");

            Console.WriteLine(tl.CurrentLight);
            tl.Manuals("Red");
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Manuals("Yello");
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Next();
            Console.WriteLine(tl.CurrentLight);
            tl.Manuals("Green");
            Console.WriteLine(tl.CurrentLight);

        }
    }
}
