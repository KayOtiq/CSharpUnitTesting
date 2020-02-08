using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {

        [Test]
        public void Log_WhenCalled_SetErrorToLastErrorProperty()
        {
            var logger = new ErrorLogger();

            // ** since this method doesn't return anything, there will not be a result var
            logger.Log("Sample error message");

            Assert.That(logger.LastError, Is.EqualTo("Sample error message"));
            // ** go back into the code, comment out "LastError" to confirm this test validates the correct thing.  If it fails, then this is a good test **
        }

        // ** this method should also throw an exception if 
        //null
        //"" empty string 
        //"  "whitespace
        //So this will be a parameterized test

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Log_InvalidError_ThrowArgNullException(string error)
        {
            var logger = new ErrorLogger();

            // ** Test method that throw an assertion by using a 'Delegate'
            // ** This uses a lambda expession (covered in advanced C#)
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

            // ** if testing for an exception not listed, then use
            //Assert.That(() => logger.Log(error), Throws.TypeOf<DivideByZeroException>);


        }


    }
}
