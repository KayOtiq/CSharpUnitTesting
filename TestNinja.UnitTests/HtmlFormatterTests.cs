using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{ 
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_EncloseStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();
            var result = formatter.FormatAsBold("The Test String");

            //specific - verifying exact string and formatting.  could break if anything changes
            //can add ".IgnoreCase" to remove case sensitivity
            Assert.That(result, Is.EqualTo("<strong>The Test String</strong>").IgnoreCase);

            //too general because could return a string "<strong>"
            Assert.That(result, Does.StartWith("<strong>"));



        }

       
    }
}
