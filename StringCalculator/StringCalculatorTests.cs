#region

using System;
using NUnit.Framework;

#endregion

namespace StringCalculator
{
    public class StringCalculatorTests
    {
        [Test]
        public void AddNull()
        {
            var c = new StringClac();
            var x = c.Add(null);
            Assert.AreEqual(0, x);
        }

        [Test]
        public void AddOneNumber()
        {
            var c = new StringClac();
            var x = c.Add("1");
            Assert.AreEqual(1, x);
        }

        [Test]
        public void AddTwoNumbers()
        {
            var c = new StringClac();
            var x = c.Add("1,3");
            Assert.AreEqual(4, x);
        }

        [Test]
        public void AddTThreeNumbers()
        {
            var c = new StringClac();
            var x = c.Add("1,3,10");
            Assert.AreEqual(14, x);
        }

        [Test]
        public void AddThreeNumbersWithLinebreak()
        {
            var c = new StringClac();
            var x = c.Add("1,3\n10");
            Assert.AreEqual(14, x);
        }

        [Test]
        public void AddThreeNumbersWithCustomDelimiter()
        {
            var c = new StringClac();
            var x = c.Add("//;\n1,3;10");
            Assert.AreEqual(14, x);
        }

        [Test]
        public void ExceptionThrownWhenNegative()
        {
            var c = new StringClac();
            var x = Assert.Throws<Exception>(() => c.Add("//;\n1,-3;10"));
            Console.WriteLine(x.Message);
        }

        [Test]
        public void NumbersGreater1000Ignored()
        {
            var c = new StringClac();
            var x = c.Add("//;\n1,1001;10");
            Assert.AreEqual(11, x);
        }

        [Test]
        public void DelimiterWithAnyFormat()
        {
            var c = new StringClac();
            var x = c.Add("//ABC\n1,1001ABC10");
            Assert.AreEqual(11, x);
        }

        [Test]
        public void MultipleDelimiterWithAnyFormat()
        {
            var c = new StringClac();
            var x = c.Add("//ABC,CBA\n1CBA1001ABC10");
            Assert.AreEqual(11, x);
        }
    }
}