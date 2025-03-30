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

            Calls tomCalls = new Calls
            {
                Abonent = tom,
                CostPerMinute = 1.5m,
                FreeMinutes = 100,
                UsedMinutes = 150
            };

            TextMessage tomTextMessages = new TextMessage
            {
                Abonent = tom,
                CostPerMessage = 0.5m,
                FreeMessages = 50,
                SentMessages = 60
            };

            Internet tomInternet = new Internet
            {
                Abonent = tom,
                CostPerMb = 0.1m,
                FreeTraffic = 1000,
                UsedTraffic = 1200
            };

            Calls magnusCalls = new Calls
            {
                Abonent = magnus,
                CostPerMinute = 2.0m,
                FreeMinutes = 200,
                UsedMinutes = 250
            };

            TextMessage magnusTextMessages = new TextMessage
            {
                Abonent = magnus,
                CostPerMessage = 0.6m,
                FreeMessages = 100,
                SentMessages = 120
            };

            Internet magnusInternet = new Internet
            {
                Abonent = magnus,
                CostPerMb = 0.15m,
                FreeTraffic = 1500,
                UsedTraffic = 1800
            };

            Console.WriteLine("\nОплата услуг для Тома:");
            Console.WriteLine($"Звонки: {tomCalls.Payment()}");
            Console.WriteLine($"Текстовые сообщения: {tomTextMessages.Payment()}");
            Console.WriteLine($"Интернет: {tomInternet.Payment()}");

            Console.WriteLine("\nОплата услуг для Магнуса:");
            Console.WriteLine($"Звонки: {magnusCalls.Payment()}");
            Console.WriteLine($"Текстовые сообщения: {magnusTextMessages.Payment()}");
            Console.WriteLine($"Интернет: {magnusInternet.Payment()}");

            Console.ReadKey();
        }
    }
}