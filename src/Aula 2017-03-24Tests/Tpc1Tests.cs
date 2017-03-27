using Aula2017_03_20.tpc1;
using NUnit.Framework;


namespace Tpc1Tests
{
    [TestFixture]
    public class Tpc1Tests
    {
        [SetUp]
        public void SetUp()
        {

        
        }

        [Test]
        public void shouldCreateAStudentCallingOneArgumentConstructor()
        {
            // Arrange

            
            // Act
            Student s = StudentCreator.Create(123);

            // Assert
            Assert.NotNull(s);
            Assert.AreEqual(123, s.Number);

        }

        [Test]
        public void shouldCreateAStudentCallingTwoArgumentConstructor()
        {
            // Arrange


            // Act
            Student s = StudentCreator.Create(123, "Mitroglu");

            // Assert
            Assert.NotNull(s);
            Assert.AreEqual(123, s.Number);
            Assert.AreEqual("Mitroglu", s.Name);

        }
    }
}