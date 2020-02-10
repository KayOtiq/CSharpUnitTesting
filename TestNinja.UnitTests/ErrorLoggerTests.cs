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
        private ErrorLogger _logger;
        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetErrorToLastErrorProperty()
        {
            //var logger = new ErrorLogger(); //moved to setup

            // ** since this method doesn't return anything, there will not be a result var
            _logger.Log("Sample error message");

            Assert.That(_logger.LastError, Is.EqualTo("Sample error message"));
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
            //var logger = new ErrorLogger(); //moved to setup

            // ** Test method that throw an assertion by using a 'Delegate'
            // ** This uses a lambda expession (covered in advanced C#)
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);

            // ** if testing for an exception not listed, then use
            //Assert.That(() => logger.Log(error), Throws.TypeOf<DivideByZeroException>);


        }

        //Testing methods that rais an event
        //verify log method raises the error log event witha new guid
        [Test]
        public void Log_ValidError_RaisesErrorLogEvent()
        {
            // Arrange
            var id = Guid.Empty;
            // ** before acting, subscribe to the event
            //sender is source of the event, args is the event arguments
            // this lambda event represents the event handler
            // when the error log is raised, this function will be executed
            _logger.ErrorLogged += (sender, args) => { id = args; };

            // Act
            _logger.Log("Sample error message");
             
            // Asserta
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));


        }

    }
}
