using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator
{
    public class Subscriber
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
            return $"Имя абонента: {Name} {Surname}, Телефонный номер: {PhoneNumber}, " +
                   $"Номер договора: {ContractNumber}, Название тарифа: {TarifName}, " +
                   $"Тип оплаты: {PaymentType}, Сумма на личном счёте: {AccountBalance}";
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
            {
                return 0;
            }
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
            {
                return 0;
            }
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
            {
                return 0;
            }
            return (UsedTraffic - FreeTraffic) * CostPerMb;
        }
    }
}