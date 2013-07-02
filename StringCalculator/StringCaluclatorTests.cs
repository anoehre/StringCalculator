using NUnit.Framework;

namespace StringCalculator
{
    public class StringCalculatorTests
    {
        [Test]
        public void AddZero()
        {
            var sc = new StringCal();
            var sum=sc.Add("");

            Assert.AreEqual(0, sum);
        }
        
        [Test]
        public void AddOne()
        {
            var sc = new StringCal();
            var sum=sc.Add("1");

            Assert.AreEqual(1, sum);
        }
        
        [Test]
        public void AddTwoDigits()
        {
            var sc = new StringCal();
            var sum=sc.Add("1,2");

            Assert.AreEqual(3, sum);
        }
        
        [Test]
        public void AddFourDigits()
        {
            var sc = new StringCal();
            var sum=sc.Add("1,2,3,5");

            Assert.AreEqual(11, sum);
        }
        
        [Test]
        public void AddFourDigitsWithLineBreak()
        {
            var sc = new StringCal();
            var sum=sc.Add("1,2,3\n5");

            Assert.AreEqual(11, sum);
        }
        
        [Test]
        public void AddFourDigitsWithLineBreakFirstLineIsTheSpeperator()
        {
            var sc = new StringCal();
            var sum=sc.Add("//X\n1X2X3X5");

            Assert.AreEqual(11, sum);
        }

        [Test]
        public void AddFourDigitsWithLineBreakFirstLineIsTheSpeperatorWithMultipleChars()
        {
            var sc = new StringCal();
            var sum=sc.Add("//XXX\n1XXX2XXX3XXX5");

            Assert.AreEqual(11, sum);
        }
        
        [Test]
        public void AddFourDigitsWithLineBreakFirstLineIsTheSpeperatorWithMultipleCharsWithMultipleSeperators()
        {
            var sc = new StringCal();
            var sum=sc.Add("//XXX,yyy\n1XXX2yyy3XXX5");

            Assert.AreEqual(11, sum);
        }
        
        [Test]
        public void IgnoreNumbersBiggerThanThousand()
        {
            var sc = new StringCal();
            var sum=sc.Add("1,2,1000");

            Assert.AreEqual(3, sum);
        }




    }
}