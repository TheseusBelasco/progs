using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operator;

namespace OperatorProg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subscriber tom = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);

            Subscriber magnus = new Subscriber("Магнус", "Чейз", "98765", "5678", "Premium", PaymentTypeCl.Credit, 0);

            Console.WriteLine(tom.GetInfo());
            Console.WriteLine(magnus.GetInfo());

            Console.ReadKey();
        }
    }
}
