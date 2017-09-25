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
                yield return new TestCaseData(new ConsoleOutput{ Multipler = 0, PrimeNumbers = null}, null);
                yield return new TestCaseData(new ConsoleOutput { Multipler = 1, PrimeNumbers = null }, null);
                yield return new TestCaseData(new ConsoleOutput { Multipler = 0, PrimeNumbers = new long[] { 0 } }, null);
                yield return new TestCaseData(new ConsoleOutput { Multipler = 1, PrimeNumbers = new long[] { 0 } }, new long[][] { new long[] { 0 } });
                yield return new TestCaseData(new ConsoleOutput { Multipler = 1, PrimeNumbers = new long[] { 2, 3, 5 }}, new long[][] { new long[] { 2, 3, 5 } });
                yield return new TestCaseData(new ConsoleOutput { Multipler = 2, PrimeNumbers = new long[] { 2, 3, 5 }}, new long[][] { new long[] { 2, 3, 5 }, new long[] { 4, 6, 10 } });
            }
        }

        private static IEnumerable<TestCaseData> OutOfMemoryTestData
        {
            get
            {
                yield return new TestCaseData(new SieveOfEratosthenes(), 1);
                yield return new TestCaseData(new SieveOfEratosthenes(), 100);
                yield return new TestCaseData(new SieveOfEratosthenes(), 1000);
                yield return new TestCaseData(new SieveOfEratosthenes(), 10000);
                yield return new TestCaseData(new SieveOfEratosthenes(), 20000);
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
        [TestCaseSource(nameof(OutOfMemoryTestData))]
        public void Should_not_throw_out_of_memmory_exception(IGenerator generator, int upperbound)
        {
            Assert.DoesNotThrow(() =>
                {
                    var input = new ConsoleInput(new string[] { upperbound.ToString() });
                    generator.GeneratePrimeNumbers<ConsoleOutput>(input);
                });
        }
    }
}