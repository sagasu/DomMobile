// -----------------------------------------------------------------------
// <copyright file="TestBase.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.TestsBase
{
    using System;

    using Ninject;

    using Xunit;

    public class TestBase //: IUseFixture<NinjectFixture>
    {
        public static IKernel Kernel { get; set; }

        public TestBase()
        {
            if (Kernel == null)
            {
                var ninjectFixture = new NinjectFixture();
                Kernel = ninjectFixture.Kernel;
            }
        }

        //public void SetFixture(NinjectFixture data)
        //{
        //    Console.WriteLine("Running SetFixture");
        //    Kernel = data.Kernel;
        //}
    }
}
