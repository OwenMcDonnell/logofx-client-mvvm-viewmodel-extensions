using LogoFX.Bootstrapping;
using Solid.Practices.IoC;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    /// <summary>
    /// Bootstrapper extensions.
    /// </summary>
    public static class BootstrapperContainerExtensions
    {
        /// <summary>
        /// Uses the view model creator service middleware.
        /// </summary>
        /// <param name="bootstrapperContainer">The bootstrapper container.</param>
        /// <returns></returns>
        public static IBootstrapperWithContainerRegistrator
            UseViewModelCreatorService(this IBootstrapperWithContainerRegistrator bootstrapperContainer)
        {
            return bootstrapperContainer.Use(
                new RegisterViewModelCreatorServiceMiddleware());            
        }

        /// <summary>
        /// Uses the shutdown middleware.
        /// </summary>        
        /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>
        /// <param name="bootstrapper">The bootstrapper container.</param>
        /// <returns></returns>
        public static IBootstrapperWithContainerRegistrator
            UseShutdown<TIocContainerAdapter>
            (this IBootstrapperWithContainerRegistrator bootstrapper)
            where TIocContainerAdapter : class, IIocContainer
        {
            return bootstrapper.Use(
                new ShutdownMiddleware());
        }
    }
}