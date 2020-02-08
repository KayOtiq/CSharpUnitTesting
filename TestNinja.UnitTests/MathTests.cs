using NUnit.Framework;
using System.Linq;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        //As part of using setup attribute, initialize  object under test
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            //the object will be reinitialized for each test
            //arrange
            _math = new Math();
        }
        [Test]
        public void Add_WhenCalled_ReturnsSumOfArguments()
        {
            //act
            var result = _math.Add(1, 2);

            //assert
            //Assert.AreEqual(3, result); //my initial code
            //Assert.That(result, Is.EqualTo(3)); //more english like test
            Assert.That(_math, Is.Not.Null); //not testing the result of the add method

        }

        [Test]
        //using TestCase attribute to provide different parameters to the test method
        //this is an advantage of using NUnit.  MSTest doesn't have this feature
        [TestCase(3, 1, 3)]
        [TestCase(2, 5, 5)]
        [TestCase(3, 3, 3)]
        public void Max_WhenCalled_ReturnsGreaterArg(int a, int b, int expectResult)
        {
            //act
            var results = _math.Max(a, b);

            //Assert
            Assert.That(results, Is.EqualTo(expectResult));
        }

        //by using the above, reduce code needed to test and 
        //combines the following three tests into one
        [Test]
        [Ignore("because refactored with WhenCalled")]
        public void Max_AGreaterThanB_ReturnsA()
        {
            //act
            var results = _math.Max(3, 1);

            //Assert
            Assert.That(results, Is.EqualTo(3));
        }

        [Test]
        public void Max_BGreaterThanA_ReturnsB()
        {
            //act
            var results = _math.Max(1, 5);

            //Assert
            Assert.That(results, Is.EqualTo(5));
        }

        [Test]
        public void Max_AEqualsB_ReturnsSame()
        {

            //act
            var results = _math.Max(2, 2);

            //Assert
            Assert.That(results, Is.EqualTo(2));
        }

        [Test]

        //**focus for this is on unit testing arrays and collections
        public void GetOddNumber_WhenLimitIsGreatherThanZero_ReturnsOddNumbersUpToLimit()

            // **My list of test cases
        //public void GetOddNumber_WhenLimitIsZero_ReturnsZero()
        //public void GetOddNumber_WhenLimitIsOne_ReturnsOne()
        //public void GetOddNumber_WhenLimitIsGreaterThan3_ReturnsArray()
        //public void GetOddNumber_WhenLimitIsOdd_ReturnsArrayWithLimitInt()
        //public void GetOddNumber_WhenLimitIsEven_ReturnsArrayWithLimitIntMinusOne()
        //public void GetOddNumber_WhenLimitIsNegative_ReturnsArrayWithLimitIntMinusOne()
        //public void GetOddNumber_WhenLimitIsPositive_ReturnsArrayWithLimitIntMinusOne()

        
        {

            //act
            var results = _math.GetOddNumbers(5);

            //Assert

            //Assert.That(results, Is.Not.Empty); //very general, shows there is something there, but doesn't show what the array contains

            //Assert.That(results.Count(), Is.EqualTo(3)); //checks for count

            //Assert.That(results, Does.Contain(1)); //checks the array contains certain or specific items, but not the order 
            //Assert.That(results, Does.Contain(3));
            //Assert.That(results, Does.Contain(5));

            //shortcut to the above is to check against another small array.  Doesn't check order, just the items are in the array
            Assert.That(results, Is.EquivalentTo(new[] { 1, 3, 5 }));


            ////to check the array order
            //Assert.That(results, Is.Ordered); 

            ////check the array has unique values
            //Assert.That(results, Is.Unique);


        }


    }
}
