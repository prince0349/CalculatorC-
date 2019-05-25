using NUnit.Framework;

  namespace UnitTesting.GettingStarted.Tests
  {
      [TestFixture]
      public class HelloNunit
      {
          [Test]
          public void TestHelloNunit()
          {
              Assert.That(true, Is.False);
          }
      }
  }
  

using CalculatorExercise.Contracts;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace CalculatorExercise.Tests
{
    [TestClass]
    public class CalculationTests
    {

        /// <summary>
        /// Used for testing of adding two numbers
        /// </summary>
        [TestMethod]
        public void TestAddNumbers()
        {
            var mockCalculator = new Mock<ICalculator>();

            mockCalculator.Setup(x => x.Addition(10, 20)).Returns(30);

            double result = mockCalculator.Object.Addition(10, 20);
            Assert.AreEqual(result, 30);
        }
		
		//Verify ALL
		
		[TestMethod]
        public void TestAddNumbers()
        {
            var mockCalculator = new Mock<ICalculator>();

            mockCalculator.Setup(x => x.Addition(10, 20)).Returns(30);

            double result = mockCalculator.Object.Addition(10, 20);
            Assert.AreEqual(result, 30);
        }

        /// <summary>
        /// Used for testing of division of two numbers
        /// </summary>
        [TestMethod]
        public void TestDivideNumbers()
        {
            var mockCalculator = new Mock<ICalculator>();

            mockCalculator.Setup(x => x.Division(10, 5)).Returns(2);

            double result = mockCalculator.Object.Division(10, 5);
            Assert.AreEqual(result, 2);
        }

        /// <summary>
        /// Used for testing of division of two numbers, second number must be zero for testing divide by zero
        /// </summary>
        [TestMethod]
        public void TestDivideByZero()
        {
            var mockCalculator = new Mock<ICalculator>();

            mockCalculator.Setup(x => x.Division(10, 0)).Returns(0);

            double result = mockCalculator.Object.Division(10, 0);
            Assert.AreEqual(result, 0);
        }
    }
}


namespace UnitTesting.GettingStarted.Tests
{
    [TestFixture]
    public class CreditDecisionTests
    {
        Mock<ICreditDecisionService>  mockCreditDecisionService;

        CreditDecision systemUnderTest;

        [TestCase(100, "Declined")]
        [TestCase(549, "Declined")]
        [TestCase(550, "Maybe")]
        [TestCase(674, "Maybe")]
        [TestCase(675, "We look forward to doing business with you!")]
        public void MakeCreditDecision_Always_ReturnsExpectedResult(int creditScore, string expectedResult)
        {
            mockCreditDecisionService = new Mock<ICreditDecisionService>(MockBehavior.Strict);
            mockCreditDecisionService.Setup(p => p.GetDecision(creditScore)).Returns(expectedResult);


            systemUnderTest = new CreditDecision(mockCreditDecisionService.Object);
            var result = systemUnderTest.MakeCreditDecision(creditScore);

            Assert.That(result, Is.EqualTo(expectedResult));

            mockCreditDecisionService.VerifyAll();
        }
    }
}