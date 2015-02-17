using Microsoft.Practices.ServiceLocation;
using Ninject.Extensions.Logging;
using NinjectAdapter;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Trader.Web.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Trader.Web.App_Start.NinjectMVC3), "Stop")]

namespace Trader.Web.App_Start
{
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using FluentValidation;
    using FluentValidation.Mvc;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Mvc;
    using Ninject.Web.Mvc.FluentValidation;

    using Ninject.Extensions.Logging.Log4net;

    using Trader.AdvertUrlService;
    using Trader.Model;
    using Trader.Services;
    using Trader.Solr;
    using Trader.Web.Automapper;
    using Trader.Web.Helpers;
    using Trader.Web.Validators;

    public static class NinjectMVC3 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        private static IKernel _kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings { LoadExtensions = false };

            var kernel = new StandardKernel(settings, new INinjectModule[] { new Log4NetModule() });

            var ninjectValidatorFactory = new NinjectValidatorFactory(kernel);
            ModelValidatorProviders.Providers.Add(new FluentValidationModelValidatorProvider(ninjectValidatorFactory));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;

            // Set resource file
            DefaultModelBinder.ResourceClassKey = "Messages";

            RegisterServices(kernel);

            _kernel = kernel;

            log4net.Config.XmlConfigurator.Configure();

            // setup service locator
            var locator = new NinjectServiceLocator(kernel);
            ServiceLocator.SetLocatorProvider(() => locator);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISolrService>().To(typeof(SolrService)).InSingletonScope();
            kernel.Bind<IDiacriticService>().To(typeof(DiacriticService)).InSingletonScope();
            kernel.Bind<IAutoMapperConfig>().To(typeof(AutoMapperConfig)).InSingletonScope();
            kernel.Bind<IPictureService>().To(typeof(PictureService)).InSingletonScope();
            kernel.Bind<IAutoMapperModule>().To<AutoMapperConfigSolr>().InSingletonScope();
            kernel.Bind<IConfigurationService>().To<ConfigurationService>().InSingletonScope();
            kernel.Bind<ICityProvider>().To<CityProvider>().InSingletonScope();
            kernel.Bind<IDateTimeService>().To<DateTimeService>().InSingletonScope();
            kernel.Bind<IPhoneService>().To<PhoneService>().InSingletonScope();
            kernel.Bind<IEmailService>().To<EmailService>().InSingletonScope();
            kernel.Bind<IDbService>().To<DbService>().InSingletonScope();

            kernel.Load<FluentValidatorModule>();
            kernel.Load<AutoMapperModule>();
            kernel.Load<ServiceMapperModule>();
        }

        public static IKernel GetKernel()
        {
            return _kernel;
        }
    }

    public class FluentValidatorModule : NinjectModule
    {
        public override void Load()
        {
            AssemblyScanner.FindValidatorsInAssemblyContaining<EmailViewModelValidator>().ForEach(match => Bind(match.InterfaceType).To(match.ValidatorType));
        }
    }


    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Get<IAutoMapperConfig>().ConfigureAutoMapper();
            Kernel.Get<AutoMapperUrlMaps>().ConfigureAutoMapper();
            Kernel.Get<IAutoMapperModule>().Configure();
        }
    }

    public class ServiceMapperModule : NinjectModule
    {
        public override void Load()
        {
            ServiceMapper.Configure(this);
        }
    }

    /// <summary>
    /// Not finished assembly scanner to fire all automappermodules, assembly scan code needed, so Assembly is not passed as a parameter
    /// </summary>
    public static class ConfigureAutoMapperModules
    {
        public static void Configure(Assembly assembly)
        {
            foreach (IAutoMapperModule autoMapperModule in assembly.GetExportedTypes().OfType<IAutoMapperModule>())
            {
                autoMapperModule.Configure();
            }
        }

    }
}
