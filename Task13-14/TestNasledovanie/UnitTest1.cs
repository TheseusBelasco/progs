using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OperatorName;
using System.Xml.Linq;

namespace TestOperat
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorTest()
        {
            var subscriber = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var calls = new Calls
            {
                Abonent = subscriber,
                CostPerMinute = 1.5m,
                FreeMinutes = 100,
                UsedMinutes = 150
            };
            decimal payment = calls.Payment();
            Assert.That(payment, Is.EqualTo(75.0m));
        }

        [Test]
        public void TextMessage_Payment_CalculatesCorrectly()
        {
            var subscriber = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var textMessage = new TextMessage
            {
                Abonent = subscriber,
                CostPerMessage = 0.5m,
                FreeMessages = 50,
                SentMessages = 60
            };
            decimal payment = textMessage.Payment();
            Assert.That(payment, Is.EqualTo(5.0m));
        }

        [Test]
        public void Internet_Payment_CalculatesCorrectly()
        {
            var subscriber = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var internet = new Internet
            {
                Abonent = subscriber,
                CostPerMb = 0.1m,
                FreeTraffic = 1000,
                UsedTraffic = 1200
            };
            decimal payment = internet.Payment();
            Assert.That(payment, Is.EqualTo(20.0m));
        }

        [Test]
        public void Calls_Payment_FreeMinutes_NoCharge()
        {
            var subscriber = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var calls = new Calls
            {
                Abonent = subscriber,
                CostPerMinute = 1.5m,
                FreeMinutes = 100,
                UsedMinutes = 80
            };
            decimal payment = calls.Payment();
            Assert.That(payment, Is.EqualTo(0.0m));
        }

        [Test]
        public void TextMessage_Payment_FreeMessages_NoCharge()
        {
            var subscriber = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var textMessage = new TextMessage
            {
                Abonent = subscriber,
                CostPerMessage = 0.5m,
                FreeMessages = 50,
                SentMessages = 40
            };
            decimal payment = textMessage.Payment();
            Assert.That(payment, Is.EqualTo(0.0m));
        }

        [Test]
        public void Internet_Payment_FreeTraffic_NoCharge()
        {
            var subscriber = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var internet = new Internet
            {
                Abonent = subscriber,
                CostPerMb = 0.1m,
                FreeTraffic = 1000,
                UsedTraffic = 800
            };
            decimal payment = internet.Payment();
            Assert.That(payment, Is.EqualTo(0.0m));
        }

        [Test]
        public void Operator_AbonentCount_ReturnsCorrectCount()
        {
            var subscriber1 = new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
            var subscriber2 = new Subscriber("Магнус", "Чейз", "98765", "5678", "Premium", PaymentTypeCl.Credit, 0);
            var subscriber3 = new Subscriber("Алиса", "Селезнёва", "88005", "1111", "Ultra", PaymentTypeCl.Predoplata, 200);

            var op = new Operator(OrganizationName.MTS, "1234567890", new List<Subscriber> { subscriber1, subscriber2, subscriber3 });

            Assert.That(op.AbonentCount, Is.EqualTo(3));
        }

        [Test]
        public void Operator_IEnumerable_ReturnsSortedSubscribers()
        {
            var subscriber1 = new Subscriber("Боба", "Фетт", "88007", "2222", "Pro", PaymentTypeCl.Credit, 50);
            var subscriber2 = new Subscriber("Чарли", "Чаплин", "88009", "3333", "Standard", PaymentTypeCl.Predoplata, 150);
            var subscriber3 = new Subscriber("Алиса", "Селезнёва", "88005", "1111", "Ultra", PaymentTypeCl.Predoplata, 200);

            var op = new Operator(OrganizationName.MTS, "1234567890", new List<Subscriber> { subscriber1, subscriber2, subscriber3 });

            var result = op.ToList();

            Assert.That(result[0].Surname, Is.EqualTo("Фетт"));
            Assert.That(result[1].Surname, Is.EqualTo("Чаплин"));
            Assert.That(result[2].Surname, Is.EqualTo("Селезнёва"));
        }
    }
}