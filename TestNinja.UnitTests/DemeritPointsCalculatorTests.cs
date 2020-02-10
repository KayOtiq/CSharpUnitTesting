using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _points;

        [SetUp]
        public void SetUp()
        {
            _points = new DemeritPointsCalculator();
        }
        //CalculateDemeritPoints_WhenSpeedLessThanLimit_ReturnZero()
        //whenSpeedEqualsSpeedLimit_ReturnZero()
        //WhenSpeedIsLessThanZero_ReturnOutOfRangeException()
        //WhenSpeedIsGreaterThan300_ReturnOutOfRangeException()

        [Test]
        [TestCase(0,0)]
        [TestCase(60, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(71, 1)]
        [TestCase(75, 2)]
        //Will get a point for every 5 km over speed limit
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResults)
        {
            var result = _points.CalculateDemeritPoints(speed);
            Assert.That(result, Is.EqualTo(expectedResults));

        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_WhenSpeedIsOutOfRange_ThrowOutOfRangeException(int speed)
        {

            // since this is throwing an exception test, need to run as a lambda and include as part of assertion
            // ** will include the act as part of the assert
            // ** also need to identify exception by type since not listed
            Assert.That(() => _points.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
           
          

        }


    }
}
