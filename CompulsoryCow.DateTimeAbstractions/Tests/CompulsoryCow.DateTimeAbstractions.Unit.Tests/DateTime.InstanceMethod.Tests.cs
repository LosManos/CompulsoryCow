using FluentAssertions;
using System.Globalization;
using Xunit;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public partial class DateTimeTests
    {
        #region Add tests.

        [Fact]
        public void Add_ShouldMimicSystem()
        {
            var anyTimeSpanTicks = 100;
            var anyDateTimeTicks = 200;

            var anyTimeSpan = new Abstractions.TimeSpan(anyTimeSpanTicks);
            var sut = new Abstractions.DateTime(anyDateTimeTicks);

            var anySystemTimeSpan = new System.TimeSpan(anyTimeSpanTicks);
            var anySystemDateTime = new System.DateTime(anyDateTimeTicks);
            var expectedResult = anySystemDateTime.Add(anySystemTimeSpan); ;

            //  Act.
            var res = sut.Add(anyTimeSpan);

            //  Assert.
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void Add_ShouldThrownIfOutOfRange()
        {
            var subtract = new Abstractions.TimeSpan(-1);
            var add = new Abstractions.TimeSpan(1);

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.Add(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.Add(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddDays tests.

        [Fact]
        public void AddDays_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyDays = 5.5d;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddDays(anyDays);

            //  Assert.
            var expectedResult = systemDateTime.AddDays(anyDays);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddDays_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddDays(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddDays(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddHours tests.

        [Fact]
        public void AddHours_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyHours = 5.5d;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddHours(anyHours);

            //  Assert.
            var expectedResult = systemDateTime.AddHours(anyHours);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddHours_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddHours(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddHours(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddMilliseconds tests.

        [Fact]
        public void AddMilliseconds_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyMilliseconds = 5.5d;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddMilliseconds(anyMilliseconds);

            //  Assert.
            var expectedResult = systemDateTime.AddMilliseconds(anyMilliseconds);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddMilliseconds_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddMilliseconds(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddMilliseconds(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddMinutes tests.

        [Fact]
        public void AddMinutes_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyMinutes = 5.5d;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddMinutes(anyMinutes);

            //  Assert.
            var expectedResult = systemDateTime.AddMinutes(anyMinutes);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddMinutes_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddMinutes(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddMinutes(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddMonths tests.

        [Fact]
        public void AddMonths_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyMonths = 5;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddMonths(anyMonths);

            //  Assert.
            var expectedResult = systemDateTime.AddMonths(anyMonths);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddMonths_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddMonths(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddMonths(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddSeconds tests.

        [Fact]
        public void AddSeconds_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anySeconds = 5.5d;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddSeconds(anySeconds);

            //  Assert.
            var expectedResult = systemDateTime.AddSeconds(anySeconds);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddSeconds_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddSeconds(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddSeconds(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddTicks tests.

        [Fact]
        public void AddTicks_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyTicks = 5;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddTicks(anyTicks);

            //  Assert.
            var expectedResult = systemDateTime.AddTicks(anyTicks);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddTicks_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddTicks(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddTicks(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region AddYears tests.

        [Fact]
        public void AddYears_ShouldMimicSystem()
        {
            var anyDateTimeYears = 200;
            var anyYears = 5;

            var sut = new Abstractions.DateTime(anyDateTimeYears);
            var systemDateTime = new System.DateTime(anyDateTimeYears);

            //  Act.
            var res = sut.AddYears(anyYears);

            //  Assert.
            var expectedResult = systemDateTime.AddYears(anyYears);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddYears_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddYears(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddYears(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region CompareTo(DateTime value) tests.

        [Fact]
        public void CompareTo_DateTime_ShouldMimicSystem()
        {
            var lowerTicks = 1;
            var sameTicks = 2;
            var higherTicks = 3;

            var sameSystemDate = new System.DateTime(sameTicks);
            var expectedHigher = sameSystemDate.CompareTo(new System.DateTime(lowerTicks));
            var expectedSame = sameSystemDate.CompareTo(new System.DateTime(sameTicks));
            var expectedLower = sameSystemDate.CompareTo(new System.DateTime(higherTicks));
            var expectedForNull = sameSystemDate.CompareTo(null);
            expectedLower.Should().Be(-1, "Sanity check we know the result");
            expectedSame.Should().Be(0, "Sanity check we know the result");
            expectedHigher.Should().Be(1, "Sanity check we know the result");
            expectedForNull.Should().Be(1, "Sanity check we know the result");

            var sut = new Abstractions.DateTime(sameTicks);

            //  Act.
            var actualHigher = sut.CompareTo(new Abstractions.DateTime(lowerTicks));
            var actualSame = sut.CompareTo(new Abstractions.DateTime(sameTicks));
            var actualLower = sut.CompareTo(new Abstractions.DateTime(higherTicks));
            var actualForNull = sut.CompareTo(null);

            //  Assert.
            actualHigher.Should().Be(expectedHigher);
            actualSame.Should().Be(expectedSame);
            actualLower.Should().Be(expectedLower);
            actualForNull.Should().Be(expectedForNull);
        }

        // There are not exceptions thrown by CompareTo(DateTime).

        #endregion

        #region CompareTo(object value) tests.

        [Fact]
        public void CompareTo_Object_ShouldMimicSystem()
        {
            var lowerTicks = 1;
            var sameTicks = 2;
            var higherTicks = 3;

            var sameSystemDate = new System.DateTime(sameTicks);
            var expectedHigher = sameSystemDate.CompareTo(new System.DateTime(lowerTicks) as object);
            var expectedSame = sameSystemDate.CompareTo(new System.DateTime(sameTicks) as object);
            var expectedLower = sameSystemDate.CompareTo(new System.DateTime(higherTicks) as object);
            var expectedForNull = sameSystemDate.CompareTo(null as object);
            expectedLower.Should().Be(-1, "Sanity check we know the result");
            expectedSame.Should().Be(0, "Sanity check we know the result");
            expectedHigher.Should().Be(1, "Sanity check we know the result");
            expectedForNull.Should().Be(1, "Sanity check we know the result");

            var sut = new Abstractions.DateTime(sameTicks);

            //  Act.
            var actualHigher = sut.CompareTo(new Abstractions.DateTime(lowerTicks) as object);
            var actualSame = sut.CompareTo(new Abstractions.DateTime(sameTicks) as object);
            var actualLower = sut.CompareTo(new Abstractions.DateTime(higherTicks) as object);
            var actualForNull = sut.CompareTo(null as object);

            //  Assert.
            actualHigher.Should().Be(expectedHigher);
            actualSame.Should().Be(expectedSame);
            actualLower.Should().Be(expectedLower);
            actualForNull.Should().Be(expectedForNull);
        }

        [Fact]
        public void CompareToObject_Should_ThrowForNonDateTimeArgument()
        {
            object nonDate = "2019-09-26 18:47:48";
            var date = new Abstractions.DateTime(1);

            //  Act.
            var res = Record.Exception(() =>
            {
                date.CompareTo(nonDate);
            });

            res.Should().BeOfType<System.ArgumentException>();
        }

        #endregion

        #region Equals(object value) tests.

        [Fact]
        public void EqualsObject_Should_MimicSystem()
        {
            new Abstractions.DateTime(1).Equals(null as object)
                .Should()
                .Be(new System.DateTime(1).Equals(null as object));

            new Abstractions.DateTime(1).Equals(new Abstractions.DateTime(1) as object)
                .Should()
                .Be(new System.DateTime(1).Equals(new System.DateTime(1) as object));

            new Abstractions.DateTime(1).Equals(new Abstractions.DateTime(2) as object)
                .Should()
                .Be(new System.DateTime(1).Equals(new System.DateTime(2) as object));
        }

        #endregion

        #region Equals(object value) tests.

        [Fact]
        public void EqualsDateTime_Should_MimicSystem()
        {
            new Abstractions.DateTime(1).Equals(null as object)
                .Should()
                .Be(new System.DateTime(1).Equals(null as object));

            new Abstractions.DateTime(1).Equals(new Abstractions.DateTime(1))
                .Should()
                .Be(new System.DateTime(1).Equals(new System.DateTime(1)));

            new Abstractions.DateTime(1).Equals(new Abstractions.DateTime(2))
                .Should()
                .Be(new System.DateTime(1).Equals(new System.DateTime(2)));
        }

        #endregion

        #region GetDateTimeFormatsCharIFormatProvider test methods.

        [Fact]
        public void GetDateTimeFormatsCharIFormatProvider_should_MimicSystem()
        {
            var anyDate = new Abstractions.DateTime(2009, 7, 28, 5, 23, 15);
            var anySystemDate = new System.DateTime(anyDate.Ticks, anyDate.Kind);
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);

            var expectedResult = anySystemDate.GetDateTimeFormats('d', culture);
            expectedResult.Should().Equal(new[]
            {
                "28/07/2009",
                "28/07/09",
                "28.07.09",
                "28-07-09",
                "2009-07-28",
            }, "Sanity check we have setup the test correctly");

            //  Act.
            // Get the short date formats using the "fr-FR" culture.
            var res = anyDate.GetDateTimeFormats('d', culture);

            //  Assert.
            res.Should().Equal(expectedResult);
        }

        [Fact]
        public void GetDateTimeFormatsCharIFormatProvider_should_ThrowExceptions()
        {
            var anyDate = new Abstractions.DateTime(2009, 7, 28, 5, 23, 15);
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);

            //  Act.
            // Use an invalid format.
            var res = Record.Exception(() =>
            {
                anyDate.GetDateTimeFormats('a', culture);
            });

            res.Should().BeOfType<System.FormatException>();
        }

        #endregion  // GetDateTimeFormatsCharIformatProvider test methods.

        #region GetDateTimeFormats(char format) test methods.

        [Fact]
        public void GetDateTimeFormatsChar_should_MimicSystem()
        {
            var anyDate = new Abstractions.DateTime(2009, 7, 28, 5, 23, 15);
            var anySystemDate = new System.DateTime(anyDate.Ticks, anyDate.Kind);

            var expectedResult = anySystemDate.GetDateTimeFormats('d');
            // We cannot check for the exact result because it depends on the environment.

            //  Act.
            var res = anyDate.GetDateTimeFormats('d');

            //  Assert.
            res.Should().Equal(expectedResult);
        }

        [Fact]
        public void GetDateTimeFormatsChar_should_ThrowExceptions()
        {
            var anyDate = new Abstractions.DateTime(2009, 7, 28, 5, 23, 15);

            //  Act.
            // Use an invalid format.
            var res = Record.Exception(() =>
            {
                anyDate.GetDateTimeFormats('a');
            });

            res.Should().BeOfType<System.FormatException>();
        }

        #endregion  //  GetDateTimeFormats(char format) gets methods

        #region GetDateTimeFormats(char format) test methods.

        [Fact]
        public void GetDateTimeFormats_should_MimicSystem()
        {
            var anyDate = new Abstractions.DateTime(2009, 7, 28, 5, 23, 15);
            var anySystemDate = new System.DateTime(anyDate.Ticks, anyDate.Kind);

            var expectedResult = anySystemDate.GetDateTimeFormats();
            // We cannot check for the exact result because it depends on the environment.

            //  Act.
            var res = anyDate.GetDateTimeFormats();

            //  Assert.
            res.Should().Equal(expectedResult);
        }

        #endregion  //  GetDateTimeFormats(char format) gets methods

        #region GetDateTimeFormatsCharIFormatProvider test methods.

        [Fact]
        public void GetDateTimeFormatsIFormatProvider_should_MimicSystem()
        {
            var anyDate = new Abstractions.DateTime(2009, 7, 28, 5, 23, 15);
            var anySystemDate = new System.DateTime(anyDate.Ticks, anyDate.Kind);
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);

            var expectedResult = anySystemDate.GetDateTimeFormats(culture);

            //  Act.
            // Get the short date formats using the "fr-FR" culture.
            var res = anyDate.GetDateTimeFormats(culture);

            //  Assert.
            res.Should().Equal(expectedResult);
        }

        #endregion  // GetDateTimeFormatsCharIformatProvider test methods.

        #region  GetHashCode() tests.

        [Fact]
        public void GetHashCode_Should_MimicSystem()
        {
            var anyTicks = 42;
            var expected = (new System.DateTime(anyTicks)).GetHashCode();

            //  Act.
            var actual = new Abstractions.DateTime(anyTicks).GetHashCode();

            //  Assert.
            actual.Should().Be(expected);
        }

        #endregion  // GetHashCode() tests.

        #region GetTypeCode() tests.

        [Fact]
        public void GetTypeCode_should_MimicSystem()
        {
            var anyTicks = 43;
            var expected = new System.DateTime(anyTicks).GetTypeCode();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).GetTypeCode();

            //  Assert.
            res.Should().Be(expected);
        }

        #endregion  // GetTypecode() tests.

        #region IsDaylightSavingTime tests.

        [Fact]
        public void IsDaylightSavingTime_should_MimicSystem()
        {
            var anyTicks = 43;
            var expected = new System.DateTime(anyTicks).IsDaylightSavingTime();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).IsDaylightSavingTime();

            //  Assert.
            res.Should().Be(expected);
        }

        #endregion  //  IsDaylightSavingTime tests.

        #region TimeSpan Subtract(DateTime value) tests.

        [Fact]
        public void SubtractDateTime_should_MimicSystem()
        {
            var anyLargerTicks = 1234;
            var anyLesserTicks = 34;
            var expected = new System.DateTime(anyLargerTicks)
                .Subtract(new System.DateTime(anyLesserTicks));

            //  Act.
            var result = new Abstractions.DateTime(anyLargerTicks)
                .Subtract(new Abstractions.DateTime(anyLesserTicks));

            //  Assert.
            AssertEquals(expected, result);
        }

        [Fact]
        public void SubtractDateTime_should_ThrowForOutOfRange()
        {
            //  Act.
            var result = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue
                    .Subtract(new Abstractions.DateTime(11119999, 1, 1));
            });

            // It should throw an exception for both too low and too high
            // but I have not found a way to execute both.

            //  Assert.
            result.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SetSubtractDateTime_should_SetAndReset()
        {
            var anyLargerTicks = 1234;
            var anyLesserTicks = 34;
            var expected = new System.DateTime(anyLargerTicks)
                .Subtract(new System.DateTime(anyLesserTicks));
            var sut = new Abstractions.DateTime(anyLargerTicks);
            var result = sut
                .Subtract(new Abstractions.DateTime(anyLesserTicks));
            AssertEquals(expected, result, "Sanity check we know what we are testing.");

            //  Act.
            sut.SetSubtractDateTime(() => new Abstractions.TimeSpan(333));

            //  Assert.
            sut.Subtract(new Abstractions.DateTime(anyLesserTicks))
                .Should().Be(new Abstractions.TimeSpan(333));

            //  Act.
            sut.SetSubtractDateTime(null);

            //  Assert.
            sut.Subtract(new Abstractions.DateTime(anyLesserTicks))
                .Should().Be(result);
        }

        #endregion  //  TimeSpan Subtract(DateTime value) tests.

        #region Subtract(TimeSpan value) tests.

        [Fact]
        public void SubtractTimeSpan_should_MimicSystem()
        {
            var anyLargerTicks = 1234;
            var anyLesserTicks = 34;
            var expected = new System.DateTime(anyLargerTicks)
                .Subtract(new System.TimeSpan(anyLesserTicks));

            //  Act.
            var result = new Abstractions.DateTime(anyLargerTicks)
                .Subtract(new Abstractions.TimeSpan(anyLesserTicks));

            //  Assert.
            result.Should().Be(expected);
        }

        [Fact]
        public void SubtractTimeSpan_should_ThrowForOutOfRange()
        {
            //  Act.
            var result = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue
                    .Subtract(new Abstractions.TimeSpan(11119999, 1, 1, 0, 0));
            });

            // It should throw an exception for both too low and too high
            // but I have not found a way to execute both.

            //  Assert.
            result.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SetSubtractTimeSpan_should_SetAndReset()
        {
            var anyLargerTicks = 1234;
            var anyLesserTicks = 34;
            var expected = new System.DateTime(anyLargerTicks)
                .Subtract(new System.TimeSpan(anyLesserTicks));
            var sut = new Abstractions.DateTime(anyLargerTicks);
            var result = sut
                .Subtract(new Abstractions.TimeSpan(anyLesserTicks));
            AssertEquals(expected, result, because: "Sanity check we know what we are testing.");

            //  Act.
            sut.SetSubtractTimeSpan(() => new Abstractions.DateTime(333));

            //  Assert.
            sut.Subtract(new Abstractions.TimeSpan(anyLesserTicks))
                .Should().Be(new Abstractions.DateTime(333));

            //  Act.
            sut.SetSubtractTimeSpan(null);

            //  Assert.
            sut.Subtract(new Abstractions.TimeSpan(anyLesserTicks))
                .Should().Be(result);
        }

        #endregion  //  Subtract(TimeSpan value) tests.

        #region ToBinary() tests.

        [Fact]
        public void ToBinary_should_MimicSystem()
        {
            var anyTicks = 424242;
            var expected = new System.DateTime(anyTicks).ToBinary();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToBinary();

            //  Assert.
            Assert.Equal(expected, res);
        }

        [Fact]
        public void SetToBinary_should_SetAndReset()
        {
            var anyTicks = 424242;
            var sut = new Abstractions.DateTime(anyTicks);
            var actual = sut.ToBinary();
            var expected = new System.DateTime(anyTicks).ToBinary();
            actual.Should().Be(expected, "Sanity check we know what we are testing.");
            long fakeValue = 12;

            //  Act.
            sut.SetToBinary(() => fakeValue);

            //  Assert.
            sut.ToBinary().Should().Be(fakeValue);

            //  Act.
            sut.SetToBinary(null);

            //  Assert.
            sut.ToBinary().Should().Be(expected);
        }

        #endregion  //  ToBinary() tests.

        #region ToFileTime() tests.

        [Fact]
        public void ToFileTime_should_MimicSystem()
        {
            var anyTicks = new System.DateTime(2019, 10, 06).Ticks;
            var expected = new System.DateTime(anyTicks).ToFileTime();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToFileTime();

            //  Assert.
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ToFileTime_should_ThrowForWayWayBeforeTheFirstDigitalFile()
        {
            var tooEarlyDateTime = Abstractions.DateTime.SpecifyKind(
                new Abstractions.DateTime(1601, 01, 01),
                System.DateTimeKind.Utc)
                .AddSeconds(-1);

            //  Act.
            var res = Record.Exception(() =>
            {
                tooEarlyDateTime.ToFileTime();
            });

            //  Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SetToFileTime_should_SetAndReset()
        {
            var anyTicks = new System.DateTime(1601, 01, 02).Ticks;
            var sut = new Abstractions.DateTime(anyTicks);
            var actual = sut.ToFileTime();
            var expected = new System.DateTime(anyTicks).ToFileTime();
            actual.Should().Be(expected, "Sanity check we know what we are testing.");
            long fakeValue = 12;

            //  Act.
            sut.SetToFileTime(() => fakeValue);

            //  Assert.
            sut.ToFileTime().Should().Be(fakeValue);

            //  Act.
            sut.SetToFileTime(null);

            //  Assert.
            sut.ToFileTime().Should().Be(expected);
        }

        #endregion  //  ToFileTime() tests.

        #region ToFileTimeUtc() tests.

        [Fact]
        public void ToFileTimeUtc_should_MimicSystem()
        {
            var anyTicks = new System.DateTime(2019, 10, 06).Ticks;
            var expected = new System.DateTime(anyTicks).ToFileTimeUtc();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToFileTimeUtc();

            //  Assert.
            Assert.Equal(expected, res);
        }

        [Fact]
        public void ToFileTimeUtc_should_ThrowForWayWayBeforeTheFirstDigitalFile()
        {
            //  Act.
            var res = Record.Exception(() =>
            {
                new Abstractions.DateTime(1601, 01, 01)
                    .AddSeconds(-1)
                    .ToFileTimeUtc();
            });

            //  Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SetToFileTimeUtc_should_SetAndReset()
        {
            var anyTicks = new System.DateTime(1601, 01, 02).Ticks;
            var sut = new Abstractions.DateTime(anyTicks);
            var actual = sut.ToFileTimeUtc();
            var expected = new System.DateTime(anyTicks).ToFileTimeUtc();
            actual.Should().Be(expected, "Sanity check we know what we are testing.");
            long fakeValue = 12;

            //  Act.
            sut.SetToFileTimeUtc(() => fakeValue);

            //  Assert.
            sut.ToFileTimeUtc().Should().Be(fakeValue);

            //  Act.
            sut.SetToFileTimeUtc(null);

            //  Assert.
            sut.ToFileTimeUtc().Should().Be(expected);
        }

        #endregion  //  ToFileTimeUtc() tests.

        #region ToLocalTime() tests.

        [Fact]
        public void ToLocalTime_should_MimicSystem()
        {
            var anyTicks = new System.DateTime(2019, 10, 06).Ticks;
            var expected = new System.DateTime(anyTicks).ToLocalTime();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToLocalTime();

            //  Assert.
            AssertEquals(expected, res);
        }

        [Fact]
        public void SetToLocalTime_should_SetAndReset()
        {
            var anyTicks = new System.DateTime(1601, 01, 02).Ticks;
            var sut = new Abstractions.DateTime(anyTicks);
            var actual = sut.ToLocalTime();
            var expected = new System.DateTime(anyTicks).ToLocalTime();
            actual.Should().Be(expected, "Sanity check we know what we are testing.");
            var fakeValue = new Abstractions.DateTime(12);

            //  Act.
            sut.SetToLocalTime(() => fakeValue);

            //  Assert.
            sut.ToLocalTime().Should().Be(fakeValue);

            //  Act.
            sut.SetToLocalTime(null);

            //  Assert.
            sut.ToLocalTime().Should().Be(expected);
        }

        #endregion  //  ToLocalTime() tests.

        #region ToLongDateString tests.

        [Fact]
        public void ToLongDateString_MimicSystem()
        {
            var anyTicks = 1234;
            var expected = new System.DateTime(anyTicks).ToLongDateString();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToLongDateString();

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void SetToLongDateString_SetAndReset()
        {
            var anyTicks = 1235;
            var system = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            system.ToLongDateString().Should()
                .Be(sut.ToLongDateString(),
                "Sanity check we know what we are testing.");
            var fake = "whatever";

            //  Act.
            sut.SetToLongDateString(() => fake);

            //  Assert.
            sut.ToLongDateString().Should().Be(fake);

            //  Act.
            sut.SetToLongDateString(null);

            //  Assert.
            sut.ToLongDateString().Should()
                .Be(system.ToLongDateString());
        }

        #endregion  //  ToLongDateString tests.

        #region ToLongTimeString tests.

        [Fact]
        public void ToLongTimeString_MimicSystem()
        {
            var anyTicks = 1234;
            var expected = new System.DateTime(anyTicks).ToLongTimeString();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToLongTimeString();

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void SetToLongTimeString_SetAndReset()
        {
            var anyTicks = 1235;
            var system = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            system.ToLongTimeString().Should()
                .Be(sut.ToLongTimeString(),
                "Sanity check we know what we are testing.");
            var fake = "whatever";

            //  Act.
            sut.SetToLongTimeString(() => fake);

            //  Assert.
            sut.ToLongTimeString().Should().Be(fake);

            //  Act.
            sut.SetToLongTimeString(null);

            //  Assert.
            sut.ToLongTimeString().Should()
                .Be(system.ToLongTimeString());
        }

        #endregion  //  ToLongDateString tests.

        #region ToOADate tests.

        [Fact]
        public void ToOADate_MimicSystem()
        {
            var anyTicks = 1234;
            var expected = new System.DateTime(anyTicks).ToOADate();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToOADate();

            //  Assert.
            res.Should().Be(expected);
        }

        // I see no way to make ToOADate throw an exception, the OverflowException as documentation says.

        [Fact]
        public void ToOADate_SetAndReset()
        {
            var anyTicks = 1235;
            var system = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            system.ToOADate().Should()
                .Be(sut.ToOADate(),
                "Sanity check we know what we are testing.");
            var fake = 123.234;

            //  Act.
            sut.SetToOADate(() => fake);

            //  Assert.
            sut.ToOADate().Should().Be(fake);

            //  Act.
            sut.SetToOADate(null);

            //  Assert.
            sut.ToOADate().Should()
                .Be(system.ToOADate());
        }

        #endregion  //  ToLongDateString tests.

        #region ToLongDateString tests.

        [Fact]
        public void ToShortDateString_MimicSystem()
        {
            var anyTicks = 1234;
            var expected = new System.DateTime(anyTicks).ToShortDateString();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToShortDateString();

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void SetToShortDateString_SetAndReset()
        {
            var anyTicks = 1235;
            var system = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            system.ToShortDateString().Should()
                .Be(sut.ToShortDateString(),
                "Sanity check we know what we are testing.");
            var fake = "whatever";

            //  Act.
            sut.SetToShortDateString(() => fake);

            //  Assert.
            sut.ToShortDateString().Should().Be(fake);

            //  Act.
            sut.SetToShortDateString(null);

            //  Assert.
            sut.ToShortDateString().Should()
                .Be(system.ToShortDateString());
        }

        #endregion  //  ToLongDateString tests.

        #region ToLongTimeString tests.

        [Fact]
        public void ToShortTimeString_MimicSystem()
        {
            var anyTicks = 1234;
            var expected = new System.DateTime(anyTicks).ToShortTimeString();

            //  Act.
            var res = new Abstractions.DateTime(anyTicks).ToShortTimeString();

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void SetToShortTimeString_SetAndReset()
        {
            var anyTicks = 1235;
            var system = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            system.ToShortTimeString().Should()
                .Be(sut.ToShortTimeString(),
                "Sanity check we know what we are testing.");
            var fake = "whatever";

            //  Act.
            sut.SetToShortTimeString(() => fake);

            //  Assert.
            sut.ToShortTimeString().Should().Be(fake);

            //  Act.
            sut.SetToShortTimeString(null);

            //  Assert.
            sut.ToShortTimeString().Should()
                .Be(system.ToShortTimeString());
        }

        #endregion  //  ToLongDateString tests.

        #region ToString(string format) tests.

        [Fact]
        public void ToStringString_MimicSystem()
        {
            var anyTicks = 123456;
            var anyFormat = "u";
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString(anyFormat);

            //  Act.
            var res = sut.ToString(anyFormat);

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void ToStringString_ThrowIfInvalidArgument()
        {
            var anyTicks = 123456;
            var anyNotValidFormat = "x";
            var sut = new Abstractions.DateTime(anyTicks);

            //  Act.
            var res = Record.Exception(() =>
            {
                sut.ToString(anyNotValidFormat);
            });

            //  Assert.
            res.Should().BeOfType<System.FormatException>();
        }

        //  I have found no way to force the ArgumentOutOfRangeException
        //  for datetime outside valid range.

        [Fact]
        public void SetToStringString_SetAndReset()
        {
            var anyTicks = 123456;
            var anyFormat = "u";
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString(anyFormat);
            sut.ToString(anyFormat).Should().Be(expected, "Sanity test we know what we are testing.");
            var fake = "any fake";

            //  Act.
            sut.SetToStringString(() => fake);

            //  Assert.
            sut.ToString(anyFormat).Should().Be(fake);

            //  Act.
            sut.SetToStringString(null);

            //  Assert.
            sut.ToString(anyFormat).Should().Be(expected);
        }

        #endregion  //  ToString(string format) tests.

        #region ToString(IFormatProvider provider) tests.

        [Fact]
        public void ToStringIFormatProvider_MimicSystem()
        {
            var anyTicks = 123456;
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString(culture);

            //  Act.
            var res = sut.ToString(culture);

            //  Assert.
            res.Should().Be(expected);
        }

        //  I have found no way to force the ArgumentOutOfRangeException
        //  for datetime outside valid range.

        [Fact]
        public void SetToStringIFormatProvider_SetAndReset()
        {
            var anyTicks = 123456;
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString(culture);
            sut.ToString(culture).Should().Be(expected, "Sanity test we know what we are testing.");
            var fake = "any fake";

            //  Act.
            sut.SetToStringIFormatProvider(() => fake);

            //  Assert.
            sut.ToString(culture).Should().Be(fake);

            //  Act.
            sut.SetToStringIFormatProvider(null);

            //  Assert.
            sut.ToString(culture).Should().Be(expected);
        }

        #endregion  //  ToString(IFormatProvider provider) tests.

        #region ToString() tests.

        [Fact]
        public void ToString_MimicSystem()
        {
            // Warning: This test reacts to the current culture and may change between environments.
            var anyTicks = 123456;
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString();

            //  Act.
            var res = sut.ToString();

            //  Assert.
            res.Should().Be(expected);
        }

        //  I have found no way to force the ArgumentOutOfRangeException
        //  for datetime outside valid range.

        [Fact]
        public void SetToString_SetAndReset()
        {
            var anyTicks = 123456;
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString();
            sut.ToString().Should().Be(expected, "Sanity test we know what we are testing.");
            var fake = "any fake";

            //  Act.
            sut.SetToString(() => fake);

            //  Assert.
            sut.ToString().Should().Be(fake);

            //  Act.
            sut.SetToString(null);

            //  Assert.
            sut.ToString().Should().Be(expected);
        }

        #endregion  //  ToString() tests.

        #region ToString(IFormatProvider provider) tests.

        [Fact]
        public void ToStringStringIFormatProvider_MimicSystem()
        {
            var anyTicks = 123456;
            var anyFormat = "u";
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString(anyFormat, culture);

            //  Act.
            var res = sut.ToString(anyFormat, culture);

            //  Assert.
            res.Should().Be(expected);
        }

        [Theory]
        [InlineData("ö", "Length of 1 but unknow format specifier.")]
        public void ToStringStringIFormatProvider_ThrowForBadIndata(string format, string because)
        {
            // The dotnet standard 2.0 documentation says ToString can throw an exception for not valid 
            // custom format pattern. I have found no way to execute this so that case is not tested.
            // Exceptions:
            //   T:System.FormatException:
            //     The length of format is 1, and it is not one of the format specifier characters
            //     defined for System.Globalization.DateTimeFormatInfo. -or- format does not contain
            //     a valid custom format pattern.
            var anyTicks = 1234567;
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);
            var sut = new Abstractions.DateTime(anyTicks);

            //  Act.
            var res = Record.Exception(() =>
            {
                sut.ToString(format, culture);
            });

            //  Assert.
            res.Should().BeOfType<System.FormatException>(because);
        }

        // The dotnet standard 2.0 documentation says ToString can throw an exception
        // for datetime outside min/max. I have found no way to execut this so that case is not tested.
        //   T:System.ArgumentOutOfRangeException:
        //     The date and time is outside the range of dates supported by the calendar used
        //     by provider.

        [Fact]
        public void SetToStringStringIFormatProvider_SetAndReset()
        {
            var anyTicks = 123456;
            var anyFormat = "u";
            System.IFormatProvider culture = new CultureInfo("fr-FR", true);
            var systemDateTime = new System.DateTime(anyTicks);
            var sut = new Abstractions.DateTime(anyTicks);
            var expected = systemDateTime.ToString(anyFormat, culture);
            sut.ToString(anyFormat, culture).Should().Be(expected, "Sanity test we know what we are testing.");
            var fake = "any fake";

            //  Act.
            sut.SetToStringStringIFormatProvider(() => fake);

            //  Assert.
            sut.ToString(anyFormat, culture).Should().Be(fake);

            //  Act.
            sut.SetToStringStringIFormatProvider(null);

            //  Assert.
            sut.ToString(anyFormat, culture).Should().Be(expected);
        }

        #endregion  //  ToString(IFormatProvider provider) tests.

        #region ToUniversalTime() tests.

        // The dotnet standard 2.0 documentation says Max and Min is returned
        // if indata is outside limits. I have found no way to execute this  so it is not tested.

        // The test(s) involve DateTimeKind.Local which is dependent on system settings.
        // This means the test(s) might change depending on environment.

        // Summary:
        //     Converts the value of the current System.DateTime object to Coordinated Universal
        //     Time (UTC).
        //
        // Returns:
        //     An object whose System.DateTime.Kind property is System.DateTimeKind.Utc, and
        //     whose value is the UTC equivalent to the value of the current System.DateTime
        //     object, or System.DateTime.MaxValue if the converted value is too large to be
        //     represented by a System.DateTime object, or System.DateTime.MinValue if the converted
        //     value is too small to be represented by a System.DateTime object.

        [Fact]
        public void ToUniversalTime_MimicSystem()
        {
            var anyTicks = 123456;
            var anyDateTimeKindExceptUtc = System.DateTimeKind.Local;
            var systemDateTime = new System.DateTime(anyTicks, anyDateTimeKindExceptUtc);
            var sut = new Abstractions.DateTime(anyTicks, anyDateTimeKindExceptUtc);
            var expected = systemDateTime.ToUniversalTime();

            //  Act.
            var res = sut.ToUniversalTime();

            //  Assert.
            res.Should().Be(expected);
        }

        [Fact]
        public void SetToUniversalTime_SetAndReset()
        {
            var anyTicks = 123456;
            var anySystemDateTimeKindExceptionUtc = System.DateTimeKind.Local;
            var systemDateTime = new System.DateTime(anyTicks, anySystemDateTimeKindExceptionUtc);
            var sut = new Abstractions.DateTime(anyTicks, anySystemDateTimeKindExceptionUtc);
            var expected = systemDateTime.ToUniversalTime();
            sut.ToUniversalTime().Should().Be(expected, "Sanity test we know what we are testing.");
            var fake = new Abstractions.DateTime(anyTicks + 1, System.DateTimeKind.Unspecified);

            //  Act.
            sut.SetToUniversalTime(() => fake);

            //  Assert.
            sut.ToUniversalTime().Should().Be(fake);

            //  Act.
            sut.SetToUniversalTime(null);

            //  Assert.
            sut.ToUniversalTime().Should().Be(expected);
        }

        #endregion  //  ToUniversalTime() tests.
    }
}
