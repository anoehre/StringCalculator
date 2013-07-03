using System;
using NUnit.Framework;

namespace StringCalculator
{
    public class StringClaculatorTests
    {
        [Test]
        public void AddNull()
        {
            var calc = new StringCalc();
            var result = calc.Add(null);
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void AddOneNumber()
        {
            var calc = new StringCalc();
            var result = calc.Add("5");
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void AddTwoNumbers()
        {
            var calc = new StringCalc();
            var result = calc.Add("5,4");
            Assert.AreEqual(9, result);
        }
        
        [Test]
        public void AddThreeNumbers()
        {
            var calc = new StringCalc();
            var result = calc.Add("5,4,1");
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void AddThreeNumbersWithLineBreak()
        {
            var calc = new StringCalc();
            var result = calc.Add("5,4\n1");
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void AddThreeNumbersWithCustomSeperator()
        {
            var calc = new StringCalc();
            var result = calc.Add("//+\n5,4+1");
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void AlertWhenNegativeNumbersIncluded()
        {
            var calc = new StringCalc();
            var ex=Assert.Throws<Exception>(() => calc.Add("//+\n5,-4+-1"));
            Console.WriteLine(ex.Message);
        }

        [Test]
        public void CatchInvalidIntegers()
        {
            var calc = new StringCalc();
            var result = calc.Add("//+\n5.22,4+1");
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void IgnoreValuesBiggerThanTousand()
        {
            var calc = new StringCalc();
            var result = calc.Add("//+\n1001,4+1");
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void SupportMultiCharDelimiter()
        {
            var calc = new StringCalc();
            var result = calc.Add("//-+-\n5-+-4-+-1");
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void SupportMultipleMultiCharDelimiter()
        {
            var calc = new StringCalc();
            var result = calc.Add("//-+-,(())\n5-+-4-+-1(())11");
            Assert.AreEqual(21, result);
        }
    }
}