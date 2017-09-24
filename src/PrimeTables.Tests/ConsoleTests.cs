using NUnit.Framework;

namespace PrimeTables.Tests
{
    using System;
    using System.Collections.Generic;

    using PrimeTables.Computation;
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
                yield return new TestCaseData(1.1.ToString());
                yield return new TestCaseData(int.MaxValue.ToString());
                yield return new TestCaseData(long.MaxValue.ToString());
            }
        }

        private static IEnumerable<TestCaseData> ValidConsoleInputData
        {
            get
            {
                yield return new TestCaseData(1.ToString());
                yield return new TestCaseData(100.ToString());
                yield return new TestCaseData((int.MaxValue - 1).ToString());
            }
        }

        private static IEnumerable<TestCaseData> ExpectedPrimeTables
        {
            get
            {
                yield return new TestCaseData(new ConsoleOutput(0, null), null);
                yield return new TestCaseData(new ConsoleOutput(1, null), null);
                yield return new TestCaseData(new ConsoleOutput(0, new long[] { 0 }), null);
                yield return new TestCaseData(new ConsoleOutput(1, new long[] { 0 }), new long[][] { new long[] { 0 } });
                yield return new TestCaseData(new ConsoleOutput(1, new long[] { 2, 3, 5 }), new long[][] { new long[] { 2, 3, 5 } });
                yield return new TestCaseData(new ConsoleOutput(2, new long[] { 2, 3, 5 }), new long[][] { new long[] { 2, 3, 5 }, new long[] { 4, 6, 10 } });
            }
        }

        private static IEnumerable<TestCaseData> OutOfMemoryTestData
        {
            get
            {
                yield return new TestCaseData(0);
                yield return new TestCaseData(100);
                yield return new TestCaseData(1000);
                yield return new TestCaseData(10000);
                yield return new TestCaseData(50000);
                // Caution: Do not try to run the below tests
                // They will cripple any machine
                //yield return new TestCaseData(100000);
                //yield return new TestCaseData(int.MaxValue);
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
        [TestCaseSource(nameof(ExpectedPrimeTables))]
        public void Should_match_expected_prime_tables(ConsoleOutput output, long[][] expectedPrimeTable)
        {
            var actualPrimeTable = output.CreatePrimeTable();
            Assert.AreEqual(actualPrimeTable, expectedPrimeTable);
        }

        [Test]
        [TestCaseSource(nameof(OutOfMemoryTestData))]
        public void Should_not_throw_out_of_memmory_exception(int upperbound)
        {
            Assert.DoesNotThrow(() => {
                    var generator = new PrimeNumberGenerator(upperbound);
                    var output = new ConsoleOutput(upperbound, generator.GeneratePrimeNumbers());
                    var table = output.CreatePrimeTable();
                });
        }
    }
}