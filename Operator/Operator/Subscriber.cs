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
                   $"Тип оплаты: {PaymentType}, Сумма на личном счёте: {AccountBalance:C}";
        }
    }
    public enum PaymentTypeCl
    {
        Predoplata,
        Credit
    }
}
