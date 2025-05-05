using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperatorName;

namespace OperatorProg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tom = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var magnus = new Subscriber("Магнус", "Чейз", "98765", "5678", "Premium", PaymentTypeCl.Credit, 0);
            var alice = new Subscriber("Алиса", "Селезнёва", "89234", "2345", "Ultra", PaymentTypeCl.Predoplata, 200);
            var boba = new Subscriber("Боба", "Фетт", "88007", "3456", "Pro", PaymentTypeCl.Credit, 50);
            var charlie = new Subscriber("Чарли", "Чаплин", "88009", "7890", "Standard", PaymentTypeCl.Predoplata, 150);
            var david = new Subscriber("Дэвид", "Ричардсон", "88001", "0000", "Light", PaymentTypeCl.Credit, 30);

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

            var mts = new Operator(OrganizationName.MTS, "1234567890", new List<Subscriber> { tom, boba, david });
            var beeline = new Operator(OrganizationName.Beeline, "0987654321", new List<Subscriber> { magnus, charlie });
            var megafon = new Operator(OrganizationName.Megafon, "1122334455", new List<Subscriber> { alice });

            PrintOperatorInfo(mts);
            PrintOperatorInfo(beeline);
            PrintOperatorInfo(megafon);

            Console.ReadKey();
        }

        static void PrintOperatorInfo(Operator op)
        {
            Console.WriteLine();
            Console.WriteLine($"Оператор: {op.OrgName}, ИНН: {op.INN}");
            Console.WriteLine($"Количество абонентов: {op.AbonentCount}");
            Console.WriteLine("Абоненты:");

            foreach (var sub in op)
            {
                Console.WriteLine($" - {sub.Surname} {sub.Name}, Номер: {sub.PhoneNumber}");
            }
        }
    }
}