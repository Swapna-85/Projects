using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace KeypadTracer.Tests
{
    public class PhoneDigitValidatorTests
    {
        private PhoneDigitValidator _phoneDigitValidator;

        public PhoneDigitValidatorTests()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.Tests.json")
                .Build();
            _phoneDigitValidator = new PhoneDigitValidator(config);
        }



        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void ReturnsFalseForInvalidRowIndex(int row)
        {
            bool result = _phoneDigitValidator.IsDigitValid(row, 0);
            result.Should().BeFalse();
        }

        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        public void ReturnsFalseForInvalidColumnIndex(int column)
        {
            bool result = _phoneDigitValidator.IsDigitValid(0, column);
            result.Should().BeFalse();
        }

        [TestCase(3, 0)]
        [TestCase(3, 2)]
        public void ReturnsFalseForInvalidDigitAtGivenPosition(int row, int column)
        {
            bool result = _phoneDigitValidator.IsDigitValid(row, column);
            result.Should().BeFalse();
        }


        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 0)]
        [TestCase(2, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 1)]
        public void ReturnsTrueForValidDigitAtGivenPosition(int row, int column)
        {
            bool result = _phoneDigitValidator.IsDigitValid(row, column);
            result.Should().BeTrue();
        }
    }
}
