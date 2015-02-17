// -----------------------------------------------------------------------
// <copyright file="ServiceMapper.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.Services
{
    using Ninject.Modules;

    /// <summary>
    /// So other project do not need to implement Trader.Mailing and it's dependencies
    /// </summary>
    public class ServiceMapper 
    {
        public static void Configure(NinjectModule serviceMapperModule)
        {
            serviceMapperModule.Bind<IPlatformMailingConfigFacade>().To<PlatformMailingConfig>();
        }
    }
}
