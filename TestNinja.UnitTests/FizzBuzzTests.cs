using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        [TestCase(1,"1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        public void GetOuput_WhenCalled_ReturnsExpectedResults(int a, String expectedResult )
        {
            //arrange
            // ** Because this is a static class, don't need to arrange
            //var _fizzBuzz = new FizzBuzz();

            //act
            var result = FizzBuzz.GetOutput(a);

            //assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
