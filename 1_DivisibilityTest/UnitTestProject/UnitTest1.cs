using Divisibility;
using System;
using Xunit;

namespace _1_DivisibilityTest
{
    public class UnitTest1
    {
        private readonly Program _ps;

        public UnitTest1()
        {
            _ps = new Program();
        }

        [Fact]
        public void DivTest()
        {

            string result = _ps.Division("7987984949494998400000");
            Assert.Equal(expected: "Buzz", actual: result);

        }
        [Fact]
        public void DivTest2()
        {

            string result = _ps.Division("79879849494949984000000000000000");
            Assert.Equal(expected: "Buzz", actual: result);

        }
        [Fact]
        public void DivTest4()
        {

            string result = _ps.Division("333333333300000000000000000");
            Assert.Equal(expected: "FizzBuzz", actual: result);
        }
        [Fact]
        public void DivTest5()
        {

            string result = _ps.Division("1111111113333333333333");
            Assert.Equal(expected: "Fizz", actual: result);
        }
        [Fact]
        public void DivTest6()
        {

            string result = _ps.Division("111111111333333333333300000000000000000000000000000");
            Assert.Equal(expected: "FizzBuzz", actual: result);
        }

        [Fact]
        public void DivTest7()
        {
            string result = _ps.Division("111111111333333333333300000000000000000000000000000999999999990000000000666666666666663333333333333333300000000000");
            Assert.Equal(expected: "FizzBuzz", actual: result);
        }

        [Fact]
        public void DivTest8()
        {
            string result = _ps.Division("");
            Assert.Equal(expected: "Fail", actual: result);
        }

        [Fact]
        public void DivTest9()
        {
            string result = _ps.Division("2");
            Assert.Equal(expected: "Fail", actual: result);
        }

        [Fact]
        public void DivTest10()
        {
            string result = _ps.Division(null);
            Assert.Equal(expected: "Fail", actual: result);
        }
    }
}
