using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    //Describing how to unit test to verify a specific type is returned
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _controller;

        [SetUp]
        public void SetUp()
        {
            //the object will be reinitialized for each test
            //arrange
            _controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IDIsZero_ReturnNotFound()
        {
            //var controller = new CustomerController();
            var result = _controller.GetCustomer(0);

            //Assert.That(result, Is.EqualTo("NotFound")); <- nope

            //Result is exactly a NotFound object
            Assert.That(result, Is.TypeOf<NotFound>()); //this will be the most used 

            //Result can be NotFound or one of it's derivatives
           // Assert.That(result, Is.InstanceOf<NotFound>());
        }

        //my test
        [Test]
        public void GetCustomer_IDIsNotZero_ReturnOK()
        {
            var result = _controller.GetCustomer(1);



            Assert.That(result, Is.TypeOf<Ok>()); 
        }

    }
}
