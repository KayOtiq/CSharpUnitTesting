using NUnit.Framework;
using TestNinja.Fundamentals;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNinja.UnitTests
{
    [TestFixture()]
    public class StackTests
    {

        private Fundamentals.Stack<string> _stack;
   
        [SetUp]
        public void SetUp()
        {
            _stack = new Fundamentals.Stack<string>();
        }

        [Test]
        public void Count_WhenZero_ReturnsEmptyStack()
        {
            // **Repeating so moved to setup
            //var stack = new Fundamentals.Stack<string>();
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Peek_WhenCountIsZero_ThrowInvalidOperationException()
        {
            // **Repeating so moved to setup
            //var stack = new Fundamentals.Stack<string>();
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void Pop_WhenCountIsZero_ThrowInvalidOperationException()
        {
            // **Repeating so moved to setup
            //var stack = new Fundamentals.Stack<string>();
            Assert.That(() => _stack.Pop(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test()]
        public void Push_WhenCalled_ObjectAddedToStack()
        {
            // **Repeating so moved to setup
            //var stack = new Fundamentals.Stack<string>();
            _stack.Push("Test String");
            Assert.That(_stack.Count, Is.EqualTo(1));
            
        }

        [Test()]
        public void Push_WhenArgIsNull_ThrowsNullException()
        {
            // **Repeating so moved to setup
            //var stack = new Fundamentals.Stack<string>();
            Assert.That(() => _stack.Push(null), Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test()]
        public void Peek_WhenCalled_ReturnsTopOfStack()
        {
            _stack.Push("Test String");
            _stack.Push("Test String 2");
            Assert.That(_stack.Peek(), Is.EqualTo("Test String 2"));

        }
        [Test()]
        public void Peek_WhenCalled_DoesNotDeleteObject()
        {
            _stack.Push("Test String");
            _stack.Push("Test String 2");
            _stack.Push("Test String 3");
            _stack.Peek();
            Assert.That(_stack.Count, Is.EqualTo(3));

        }

        [Test()]
        public void Pop_WhenCalled_ReturnsTopOfStack()
        {
            _stack.Push("Test String 1");
            _stack.Push("Test String 2");
            Assert.That(_stack.Pop(), Is.EqualTo("Test String 2"));
        }

        [Test()]
        public void Pop_WhenCalled_TopObjectRemovedFromStack()
        {
            _stack.Push("Test String 1");
            _stack.Push("Test String 2");
            _stack.Pop();
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test()]
        public void Count_WhenNotZero_ReturnsStackCount()
        {
            _stack.Push("Test String 1");
            _stack.Push("Test String 2");
            Assert.That(_stack.Count, Is.EqualTo(2));
        }
    }
}