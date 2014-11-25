using System;
using NUnit.Framework;

namespace Blogn.Tests
{
    [TestFixture]
    public class ContractTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void IsNotNull_WhenParameterIsNotNull_DoesNotThrowException()
        {
            const string parameter = "";
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotNull(parameter, name));
        }

        [Test]
        public void IsNotNull_WhenParameterIsNull_ThrowsArgumentNullException()
        {
            const string parameter = null;
            const string name = "parameter";

            Assert.Throws<ArgumentNullException>(() => Contract.IsNotNull(parameter, name));
        }

        [Test]
        public void IsNotNull_WhenParameterIsNullAndParameterNameIsNotNull_ThrownExceptionMessageContainsParameterName()
        {
            const string parameter = null;
            const string name = "parameter";

            ArgumentNullException exception =
                Assert.Throws<ArgumentNullException>(() => Contract.IsNotNull(parameter, name));

            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsNotEmpty_WhenParameterIsNotEmpty_DoesNotThrowException()
        {
            const string parameter = "value";
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotEmpty(parameter, name));
        }

        [Test]
        public void IsNotEmpty_WhenParameterIsEmpty_ThrowsArgumentException()
        {
            const string parameter = "";
            const string name = "parameter";

            Assert.Throws<ArgumentException>(() => Contract.IsNotEmpty(parameter, name));
        }

        [Test]
        public void IsNotEmpty_WhenParameterIsEmptyAndParameterNameIsNotNull_ThrownExceptionMessageContainsParameterName()
        {
            const string parameter = "";
            const string name = "parameter";

            ArgumentException exception = Assert.Throws<ArgumentException>(() => Contract.IsNotEmpty(parameter, name));

            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsNotEmpty_WhenParameterIsEmptyAndParameterNameIsNull_ThrownMessageContainsUnknownParameter()
        {
            const string parameter = "";
            const string name = null;
            const string expected = "Unknown Parameter (null)";

            ArgumentException exception = Assert.Throws<ArgumentException>(() => Contract.IsNotEmpty(parameter, name));

            Assert.IsTrue(exception.Message.Contains(expected));
        }

        [Test]
        public void IsNotEmptyOrWhiteSpace_WhenParameterIsNotEmptyOrWhiteSpace_DoesNotThrowException()
        {
            const string parameter = "ABC";
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotEmptyOrWhiteSpace(parameter, name));
        }

        [Test]
        public void IsNotEmptyOrWhiteSpace_WhenParameterIsEmpty_ThrowsArgumentException()
        {
            const string parameter = "";
            const string name = "parameter";

            Assert.Throws<ArgumentException>(() => Contract.IsNotEmptyOrWhiteSpace(parameter, name));
        }

        [Test]
        public void IsNotEmptyOrWhiteSpace_WhenParameterIsWhiteSpace_ThrowsArgumentException()
        {
            const string parameter = " ";
            const string name = "parameter";

            Assert.Throws<ArgumentException>(() => Contract.IsNotEmptyOrWhiteSpace(parameter, name));
        }

        [Test]
        public void IsNotEmptyOrWhiteSpace_WhenExceptionIsThrownAndNameIsNotNull_ExceptionContainsParameterName()
        {
            const string parameter = "";
            const string name = "parameter";

            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => Contract.IsNotEmptyOrWhiteSpace(parameter, name));

            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsNotEmptyOrWhiteSpace_WhenExceptionIsThrownAndNameIsNull_ExceptionContainsUnknownParameter()
        {
            const string parameter = "";
            const string name = null;
            const string expected = "Unknown Parameter (null)";
            ArgumentException exception =
                Assert.Throws<ArgumentException>(() => Contract.IsNotEmptyOrWhiteSpace(parameter, name));

            Assert.IsTrue(exception.Message.Contains(expected));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenParameterIsEmpty_ThrowsArgumentException()
        {
            const string parameter = "";
            const string name = "parameter";

            Assert.Throws<ArgumentException>(() => Contract.IsNotNullOrEmpty(parameter, name));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenParameterIsNull_ThrowsArgumentNullException()
        {
            const string parameter = null;
            const string name = "parameter";

            Assert.Throws<ArgumentNullException>(() => Contract.IsNotNullOrEmpty(parameter, name));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenParameterIsNotNullOrEmpty_DoesNotThrowException()
        {
            const string parameter = "data";
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotNullOrEmpty(parameter, name));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenArgumentExceptionIsThrownAndParamterNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            const string parameter = "";
            const string name = "parameter";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => Contract.IsNotNullOrEmpty(parameter, name));

            Assert.IsTrue(ex.Message.Contains(name));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenArgumentNullExceptionIsThrownAndParamterNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            const string parameter = null;
            const string name = "parameter";

            ArgumentNullException ex =
                Assert.Throws<ArgumentNullException>(() => Contract.IsNotNullOrEmpty(parameter, name));

            Assert.IsTrue(ex.Message.Contains(name));
        }

        [Test]
        public void IsNotNullOrEmpty_WhenArgumentExceptionIsThrownAndParamterNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const string parameter = "";
            const string name = null;
            const string expected = "Unknown Parameter (null)";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => Contract.IsNotNullOrEmpty(parameter, name));

            Assert.IsTrue(ex.Message.Contains(expected));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenParameterIsWhiteSpace_ThrowsArgumentException()
        {
            const string parameter = "  ";
            const string name = "parameter";

            Assert.Throws<ArgumentException>(() => Contract.IsNotNullOrWhiteSpace(parameter, name));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenParameterIsNull_ThrowsArgumentNullException()
        {
            const string parameter = null;
            const string name = "parameter";

            Assert.Throws<ArgumentNullException>(() => Contract.IsNotNullOrWhiteSpace(parameter, name));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenParameterIsNotNullOrWhiteSpace_DoesNotThrowException()
        {
            const string parameter = "data";
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotNullOrWhiteSpace(parameter, name));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenArgumentExceptionIsThrownAndParamterNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            const string parameter = "  ";
            const string name = "parameter";

            ArgumentException ex =
                Assert.Throws<ArgumentException>(() => Contract.IsNotNullOrWhiteSpace(parameter, name));

            Assert.IsTrue(ex.Message.Contains(name));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenArgumentNullExceptionIsThrownAndParamterNameIsNotNull_ExceptionMessageContainsArgumentName()
        {
            const string parameter = null;
            const string name = "parameter";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => Contract.IsNotNullOrWhiteSpace(parameter, name));

            Assert.IsTrue(ex.Message.Contains(name));
        }

        [Test]
        public void IsNotNullOrWhiteSpace_WhenArgumentExceptionIsThrownAndParamterNameIsNull_ExceptionMessageContainsUnknownArgument()
        {
            const string parameter = "  ";
            const string name = null;
            const string expected = "Unknown Parameter (null)";

            ArgumentException exception =Assert.Throws<ArgumentException>(() => Contract.IsNotNullOrWhiteSpace(parameter, name));

            Assert.IsTrue(exception.Message.Contains(expected));
        }

        [Test]
        public void IsGreaterThan_WhenParameterIsGreaterThanExpected_DoesNotThrowException()
        {
            const int parameter = 4;
            const int expected = 2;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsGreaterThan(parameter, expected, name));

        }

        [Test]
        public void IsGreaterThan_WhenParameterIsLessThanExpected_ThrowsArgumentOutOfRangeException()
        {
            DateTime parameter = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThan(parameter, expected, name));
        }

        [Test]
        public void IsGreaterThan_WhenParameterIsEqualToExpected_ThrowsArgumentOutOfRangeException()
        {
            const float parameter = 2.0f;
            const float expected = 2.0f;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThan(parameter, expected, name));
        }

        [Test]
        public void IsGreaterThan_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsParameterName()
        {
            DateTime parameter = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThan(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsGreaterThan_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            DateTime parameter = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThan(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenParameterIsGreaterThanExpected_DoesNotThrowException()
        {
            const int parameter = 4;
            const int expected = 2;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsGreaterThanOrEqualTo(parameter, expected, name));

        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenParameterIsLessThanExpected_ThrowsArgumentOutOfRangeException()
        {
            DateTime parameter = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThanOrEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenParameterIsEqualToExpected_DoesNotThrowException()
        {
            const float parameter = 2.0f;
            const float expected = 2.0f;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsGreaterThanOrEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsParameterName()
        {
            DateTime parameter = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThanOrEqualTo(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsGreaterThanOrEqualTo_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            DateTime parameter = new DateTime(2000, 1, 1);
            DateTime expected = new DateTime(2012, 1, 1);
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsGreaterThan(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsLessThan_WhenParameterIsLessThanExpected_DoesNotThrowException()
        {
            const int parameter = 2;
            const int expected = 4;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsLessThan(parameter, expected, name));
        }

        [Test]
        public void IsLessThan_WhenParameterIsGreaterThanExpected_ThrowsArgumentOutOfRangeException()
        {
            DateTime parameter = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThan(parameter, expected, name));
        }

        [Test]
        public void IsLessThan_WhenParameterIsEqualToExpected_ThrowsArgumentOutOfRangeException()
        {
            const float parameter = 2.0f;
            const float expected = 2.0f;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThan(parameter, expected, name));
        }

        [Test]
        public void IsLessThan_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsParameterName()
        {
            DateTime parameter = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThan(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsLessThan_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            DateTime parameter = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThan(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenParameterIsLessThanExpected_DoesNotThrowException()
        {
            const int parameter = 2;
            const int expected = 4;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsLessThanOrEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenParameterIsGreaterThanExpected_ThrowsArgumentOutOfRangeException()
        {
            DateTime parameter = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThanOrEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenParameterIsEqualToExpected_DoesNotThrowException()
        {
            const float parameter = 2.0f;
            const float expected = 2.0f;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsLessThanOrEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenExceptionIsThrownAndNameIsNotNull_ExceptionMessageContainsParameterName()
        {
            DateTime parameter = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThanOrEqualTo(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsLessThanOrEqualTo_WhenExceptionIsThrownAndNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            DateTime parameter = new DateTime(2012, 1, 1);
            DateTime expected = new DateTime(2000, 1, 1);
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsLessThan(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsEqualTo_WhenParameterAndExpectedAreEqual_DoesNotThrowException()
        {
            const int parameter = 2;
            const int expected = 2;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsEqualTo_WhenParameterAndExpectedAreNotEqual_ThrowsArgumentOutOfRangeException()
        {
            const decimal parameter = 2.00M;
            const decimal expected = 3.00M;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsEqualTo_WhenExceptionIsThrownAndParameterNameIsNotNull_ExceptionMessageContainsParameterName()
        {
            const decimal parameter = 2.00M;
            const decimal expected = 3.00M;
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsEqualTo(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsEqualTo_WhenExceptionIsThrownAndParameterNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            const decimal parameter = 2.00M;
            const decimal expected = 3.00M;
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsEqualTo(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsNotEqualTo_WhenParameterAndExpectedAreNotEqual_DoesNotThrowException()
        {
            const int parameter = 2;
            const int expected = 3;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsNotEqualTo_WhenParameterAndExpectedAreEqual_ThrowsArgumentOutOfRangeException()
        {
            const decimal parameter = 2.00M;
            const decimal expected = 2.00M;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotEqualTo(parameter, expected, name));
        }

        [Test]
        public void IsNotEqualTo_WhenExceptionIsThrownAndParameterNameIsNotNull_ExceptionMessageContainsParameterName()
        {
            const decimal parameter = 2.00M;
            const decimal expected = 2.00M;
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotEqualTo(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsNotEqualTo_WhenExceptionIsThrownAndParameterNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            const decimal parameter = 2.00M;
            const decimal expected = 2.00M;
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotEqualTo(parameter, expected, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsInRange_WhenParameterIsInTheSpecifiedRange_DoesNotThrowException()
        {
            const int parameter = 5;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsInRange(parameter, start, end, name));
        }

        [Test]
        public void IsInRange_WhenParameterEqualsStartOfRange_DoesNotThrowException()
        {
            const int parameter = 3;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsInRange(parameter, start, end, name));
        }

        [Test]
        public void IsInRange_WhenParameterEqualsEndOfRange_DoesNotThrowException()
        {
            const int parameter = 7;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsInRange(parameter, start, end, name));
        }

        [Test]
        public void IsInRange_WhenParameterIsNotInTheSpecifiedRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRange(parameter, start, end, name));
        }

        [Test]
        public void IsInRange_WhenExceptionIsThrownAndParameterNameIsNotNull_ExceptionMessageContainsName()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRange(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsInRange_WhenExceptionIsThrownAndParameterNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRange(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsInRangeExclusive_WhenParameterIsInTheSpecifiedRange_DoesNotThrowException()
        {
            const int parameter = 5;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenParameterEqualsStartOfRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 3;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenParameterEqualsEndOfRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 7;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenParameterIsNotInTheSpecifiedRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsInRangeExclusive_WhenExceptionIsThrownAndParameterNameIsNotNull_ExceptionMessageContainsName()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRangeExclusive(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsInRangeExclusive_WhenExceptionIsThrownAndParameterNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsInRangeExclusive(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsNotInRange_WhenParameterIsInTheSpecifiedRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 5;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRange(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenParameterEqualsStartOfRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 3;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRange(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenParameterEqualsEndOfRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 7;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRange(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenParameterIsNotInTheSpecifiedRange_DoesNotThrowException()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotInRange(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRange_WhenExceptionIsThrownAndParameterNameIsNotNull_ExceptionMessageContainsName()
        {
            const int parameter = 8;
            const int start = 5;
            const int end = 10;
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRange(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsNotInRange_WhenExceptionIsThrownAndParameterNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            const int parameter = 8;
            const int start = 5;
            const int end = 10;
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRange(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenParameterIsInTheSpecifiedRange_ThrowsArgumentOutOfRangeException()
        {
            const int parameter = 5;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenParameterEqualsStartOfRange_DoesNotThrowException()
        {
            const int parameter = 3;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenParameterEqualsEndOfRange_DoesNotThrowException()
        {
            const int parameter = 7;
            const int start = 3;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenParameterIsNotInTheSpecifiedRange_DoesNotThrowException()
        {
            const int parameter = 5;
            const int start = 10;
            const int end = 7;
            const string name = "parameter";

            Assert.DoesNotThrow(() => Contract.IsNotInRangeExclusive(parameter, start, end, name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenExceptionIsThrownAndParameterNameIsNotNull_ExceptionMessageContainsName()
        {
            const int parameter = 8;
            const int start = 5;
            const int end = 10;
            const string name = "parameter";

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRangeExclusive(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains(name));
        }

        [Test]
        public void IsNotInRangeExclusive_WhenExceptionIsThrownAndParameterNameIsNull_ExceptionMessageContainsUnknownParameter()
        {
            const int parameter = 8;
            const int start = 5;
            const int end = 10;
            const string name = null;

            ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(() => Contract.IsNotInRangeExclusive(parameter, start, end, name));
            Assert.IsTrue(exception.Message.Contains("Unknown Parameter (null)"));
        }

        [Test]
        public void Requires_WhenConditionIsTrue_DoesNotThrowException()
        {
            const string message = "Custom Exception Message";
            Assert.DoesNotThrow(() => Contract.Requires(true, message));
        }

        [Test]
        public void Requires_WhenConditionIsFalse_ThrowsArgumentException()
        {
            const string message = "Custom Exception Message";
            Assert.Throws<ArgumentException>(() => Contract.Requires(false, message));
        }

        [Test]
        public void Requires_WhenExceptionThrowsAndMessageIsNotNull_ExceptionMessageIsMessage()
        {
            const string message = "Custom Exception Message";
            ArgumentException exception = Assert.Throws<ArgumentException>(() => Contract.Requires(false, message));
            Assert.AreEqual(exception.Message, message);
        }

        [Test]
        public void Requires_WhenExceptionThrownAndMessageIsNull_ExceptionMessageIsRequirementFailed()
        {
            const string message = null;
            const string expectedMessage = "The expected requirement was not met.";
            ArgumentException exception = Assert.Throws<ArgumentException>(() => Contract.Requires(false, message));
            Assert.AreEqual(exception.Message, expectedMessage);

        }
    }
}
