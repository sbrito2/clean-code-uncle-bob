using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Decorators
{
    public class LoggingDecorator : BeverageDecorator, ILog
    {
        private const string _description = "";
        private const decimal _cost = 0M;

        public LoggingDecorator(Beverage b) : base(b)
        {
        }

        public override string Description
        {
            get
            {
                return this.GetWrappedEntity().Description;
            }
        }

        public override decimal Cost
        {
            get
            {
                return this.GetWrappedEntity().Cost;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"Logging : {message}");
        }

        public void Action()
        {
            Log("Logging Start");
            Console.WriteLine("Executing LogDecorator Action()");
            Log("Logging Finish");
        }

        public bool HasLogging()
        {
            return true;
        }
    }
}
