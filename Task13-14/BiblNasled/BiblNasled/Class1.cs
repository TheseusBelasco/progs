using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorName
{
    public class Subscriber : IComparable<Subscriber>
    {
        private readonly string contractNumber;
        private decimal accountBalance;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string ContractNumber => contractNumber;
        public string TarifName { get; set; }
        public PaymentTypeCl PaymentType { get; set; }
        public decimal AccountBalance
        {
            get => accountBalance;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Сумма на личном счёте не может быть меньше ноля");
                }
                accountBalance = value;
            }
        }

        public Subscriber(string name, string surname,
            string phoneNumber, string contractNumber,
            string tarifName, PaymentTypeCl paymentType, decimal accountBalance)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            this.contractNumber = contractNumber;
            TarifName = tarifName;
            PaymentType = paymentType;
            AccountBalance = accountBalance;
        }

        public string GetInfo()
        {
            return $"Имя: {Name} {Surname}, Телефон: {PhoneNumber}, " +
                   $"Договор: {ContractNumber}, Тариф: {TarifName}, " +
                   $"Тип оплаты: {PaymentType}, Баланс: {AccountBalance}";
        }

        public int CompareTo(Subscriber other)
        {
            if (other == null) return 1;

            int surnameComparison = Surname.CompareTo(other.Surname);
            if (surnameComparison != 0)
                return surnameComparison;

            return Name.CompareTo(other.Name);
        }
    }

    public enum PaymentTypeCl
    {
        Predoplata,
        Credit
    }

    public abstract class Service
    {
        public Subscriber Abonent { get; set; }

        public abstract decimal Payment();
    }

    public class Calls : Service
    {
        public decimal CostPerMinute { get; set; }
        public int FreeMinutes { get; set; }
        public int UsedMinutes { get; set; }

        public override decimal Payment()
        {
            if (UsedMinutes <= FreeMinutes)
                return 0;
            return (UsedMinutes - FreeMinutes) * CostPerMinute;
        }
    }

    public class TextMessage : Service
    {
        public decimal CostPerMessage { get; set; }
        public int FreeMessages { get; set; }
        public int SentMessages { get; set; }

        public override decimal Payment()
        {
            if (SentMessages <= FreeMessages)
                return 0;
            return (SentMessages - FreeMessages) * CostPerMessage;
        }
    }

    public class Internet : Service
    {
        public decimal CostPerMb { get; set; }
        public int FreeTraffic { get; set; }
        public int UsedTraffic { get; set; }

        public override decimal Payment()
        {
            if (UsedTraffic <= FreeTraffic)
                return 0;
            return (UsedTraffic - FreeTraffic) * CostPerMb;
        }
    }

    public enum OrganizationName
    {
        MTS,
        Beeline,
        Megafon
    }

    public class Operator : IEnumerable<Subscriber>
    {
        public OrganizationName OrgName { get; }
        public string INN { get; }
        public int AbonentCount => subscribers.Count;

        private readonly List<Subscriber> subscribers = new List<Subscriber>();

        public Operator(OrganizationName orgName, string inn, IEnumerable<Subscriber> initialSubscribers)
        {
            OrgName = orgName;
            INN = inn;

            foreach (var sub in initialSubscribers)
            {
                AddSubscriber(sub);
            }
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            if (subscriber == null)
                throw new ArgumentNullException(nameof(subscriber));

            if (!subscribers.Any(s => s.ContractNumber == subscriber.ContractNumber))
            {
                subscribers.Add(subscriber);
            }
        }

        public IEnumerator<Subscriber> GetEnumerator()
        {
            subscribers.Sort(); // Сортировка по фамилии и имени
            return subscribers.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}