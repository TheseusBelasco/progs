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
            var tom = CreateTestPerson();

            Assert.That(tom.Name, Is.EqualTo("Том"));
            Assert.That(tom.Surname, Is.EqualTo("Маршалл"));
            Assert.That(tom.PhoneNumber, Is.EqualTo("89912"));
            Assert.That(tom.ContractNumber, Is.EqualTo("1234"));
            Assert.That(tom.TarifName, Is.EqualTo("Newbie"));
            Assert.That(tom.PaymentType, Is.EqualTo(PaymentTypeCl.Predoplata));
            Assert.That(tom.AccountBalance, Is.EqualTo(100));
        }

        private Subscriber CreateTestPerson()
        {
            return new Subscriber("Том", "Маршалл", "89912", "1234", "Newbie", PaymentTypeCl.Predoplata, 100);
        }
    }
}