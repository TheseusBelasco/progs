using NUnit.Framework;
using Operator;
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
    }
}