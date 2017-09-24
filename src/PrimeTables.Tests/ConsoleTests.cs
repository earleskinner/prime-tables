using NUnit.Framework;

namespace PrimeTables.Tests
{
    using System;
    using System.Collections.Generic;

    using PrimeTables.Console;

    [TestFixture]
    public class ConsoleTests
    {
        private static IEnumerable<TestCaseData> InvalidConsoleInputData
        {
            get
            {
                yield return new TestCaseData(string.Empty);
                yield return new TestCaseData((-1).ToString());
                yield return new TestCaseData(0.ToString());
                yield return new TestCaseData(int.MaxValue.ToString());
                yield return new TestCaseData(long.MaxValue.ToString());
            }
        }

        private static IEnumerable<TestCaseData> ValidConsoleInputData
        {
            get
            {
                yield return new TestCaseData(1.ToString());
                yield return new TestCaseData(1.1.ToString());
                yield return new TestCaseData(100.ToString());
                yield return new TestCaseData((int.MaxValue - 1).ToString());
            }
        }

        private static IEnumerable<TestCaseData> ExpectedConsoleOutput
        {
            get
            {
                yield return new TestCaseData(new ConsoleOutput(0, null), null);
                yield return new TestCaseData(new ConsoleOutput(1, null), null);
                yield return new TestCaseData(new ConsoleOutput(0, new long[]{ 0 }), null);
                yield return new TestCaseData(new ConsoleOutput(1, new long[] { 0 }), new long[,] { {0,0}  });
                yield return new TestCaseData(new ConsoleOutput(1, new long[] { 2, 3, 5 }), new long[,] { { 0, 0 }, { 0, 2 }, { 0, 3 }, { 0, 5 } });
                yield return new TestCaseData(new ConsoleOutput(2, new long[] { 2, 3, 5 }), new long[,] { { 0, 2 }, { 0, 3 }, { 0, 5 }, { 1, 4 }, { 1, 6 }, { 1, 10 } });
            }
        }

        [Test]
        [TestCaseSource(nameof(InvalidConsoleInputData))]
        public void Should_throw_argument_exception_for_console_input(string args)
        {
            Assert.Throws(Is.TypeOf<ArgumentException>(),
            () =>
            {
                var input = new ConsoleInput(args.Split(' '));
            });
        }

        [Test]
        [TestCaseSource(nameof(ValidConsoleInputData))]
        public void Should_not_throw_argument_exception_for_console_input(string args)
        {
            Assert.DoesNotThrow(() => {
                var input = new ConsoleInput(args.Split(' '));
            });
        }

        [Test]
        [TestCaseSource(nameof(ExpectedConsoleOutput))]
        public void Should_match_expected_console_output(ConsoleOutput output, long[,] expectedPrimeTable)
        {
            var actualPrimeTable = output.CreatePrimeTable();
            Assert.AreEqual(actualPrimeTable, expectedPrimeTable);
        }
    }
}