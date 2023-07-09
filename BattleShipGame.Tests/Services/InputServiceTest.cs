using BattleShipGame.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BattleShipGame.Tests.Services
{
    public class InputServiceTest
    {

        [Theory]
        [ClassData(typeof(ValidateInputTestData))]
        public void ValidateInput_ShouldReturnTrueOnValidInput(bool expected, string input) 
        {
            IInputService sut = new InputService();
            var resutl = sut.ValidateInput(input, out int x, out int y);
            Assert.Equal(expected, resutl);
        }

        private class ValidateInputTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    true, "A5"
                };
                yield return new object[]
                {
                    false, "A11"
                };
                yield return new object[]
                {
                    true, "A1"
                };
                yield return new object[]
                {
                    false, "A0"
                };
                yield return new object[]
                {
                    false, "Z0"
                };
                yield return new object[]
                {
                    false, "K9"
                };
                yield return new object[]
                {
                    false, "M4"
                };
                yield return new object[]
                {
                    true, "J9"
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
