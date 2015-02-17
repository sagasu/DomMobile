// -----------------------------------------------------------------------
// <copyright file="ContinuationTaskHelp.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using NUnit.Framework;

namespace Web.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    [TestFixture]
    public class ContinuationTaskHelp
    {
        [Test]
        public void TestContinuation()
        {
            // The antecedent task. Can also be created with Task.Factory.StartNew.
            Task<DayOfWeek> taskA = new Task<DayOfWeek>(() => DateTime.Today.DayOfWeek);

            // The continuation. Its delegate takes the antecedent task
            // as an argument and can return a different type.
            Task<string> continuation = taskA.ContinueWith((antecedent) =>
            {
                return String.Format("Today is {0}.",
                                    antecedent.Result);
            });

            // Start the antecedent.
            taskA.Start();

            // Use the contuation's result.
            Console.WriteLine(continuation.Result);
        }
    }
}
