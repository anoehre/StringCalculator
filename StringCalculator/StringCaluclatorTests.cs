using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator2013_07_02
{
    public class StringCaluclatorTests
    {
        [Test]
        public void AddEmptyString()
        {
            var calc = new StringCalculator();
            var result = calc.Add(null);
            Assert.AreEqual(0, result);
        }
        
        [Test]
        public void AddOneNumber()
        {
            var calc = new StringCalculator();
            var result = calc.Add("5");
            Assert.AreEqual(5, result);
        }
        
        [Test]
        public void AddTwoNumbers()
        {
            var calc = new StringCalculator();
            var result = calc.Add("5,2");
            Assert.AreEqual(7, result);
        }

        [Test]
        public void AddThreeNumbers()
        {
            var calc = new StringCalculator();
            var result = calc.Add("5,2,3");
            Assert.AreEqual(10, result);
        }

        [Test]
        public void AddThreeNumbersWithDifferentSeperators()
        {
            var calc = new StringCalculator();
            var result = calc.Add("5,2\n3");
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void AddThreeNumbersWithCustomizedSeperator()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//;\n5;2\n3");
            Assert.AreEqual(10, result);
        }
        
        [Test]
        public void AddThreeNumbersWithCustomizedMulticharseperator()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//#+-\n5#+-2#+-3#+-20");
            Assert.AreEqual(30, result);
        }
        
        [Test]
        public void IgnoreNUmbersBigger1000()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//#+-\n5#+-2#+-3#+-20#+-1002");
            Assert.AreEqual(30, result);
        }
        
        [Test]
        public void AllowMultipleCustomDelimiters()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//#+-,ABC,XYZ\n5#+-2ABC3#+-20XYZ1002");
            Assert.AreEqual(30, result);
        }
        
        [Test]
        public void IgnoreWronIntegers()
        {
            var calc = new StringCalculator();
            var result = calc.Add("//#+-,ABC,XYZ\n5#+-2.2ABC3#+-20XYZ1002");
            Assert.AreEqual(28, result);
        }
    }
}
