// -----------------------------------------------------------------------
// <copyright file="NinjectFixture.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.TestsBase
{
    using System;
    using System.Reflection;
    using System.Web.Compilation;

    using Ninject;

    using Trader.Web.App_Start;

    public class NinjectFixture : IDisposable
    {
        private const int PreStartInitStage_DuringPreStartInit = 1;

        public IKernel Kernel { get; private set; }

        public NinjectFixture()
        {
            // This instance is shared by many tests so no need to execute this code many times.
            if (Kernel != null)
            {
                return;
            }

            WebActivator.ActivationManager.AddAssembly(Assembly.GetAssembly(typeof(NinjectMVC3)));

            typeof(BuildManager).GetProperty("PreStartInitStage", BindingFlags.NonPublic | BindingFlags.Static)
                                .SetValue(null, PreStartInitStage_DuringPreStartInit, null);

            WebActivator.ActivationManager.RunPreStartMethods();
            Kernel = NinjectMVC3.GetKernel();
        }

        public void Dispose()
        {
            WebActivator.ActivationManager.RunShutdownMethods();
        }
    }
}
