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
        /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>
        /// <param name="bootstrapperContainer">The bootstrapper container.</param>
        /// <returns></returns>
        public static IBootstrapperWithContainerAdapter<TIocContainerAdapter> 
            UseViewModelCreatorService<TIocContainerAdapter>
            (this IBootstrapperWithContainerAdapter<TIocContainerAdapter> bootstrapperContainer)            
            where TIocContainerAdapter : class, IIocContainer
        {
            return bootstrapperContainer.Use(
                new RegisterViewModelCreatorServiceMiddleware<TIocContainerAdapter>());            
        }

        /// <summary>
        /// Uses the shutdown middleware.
        /// </summary>        
        /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>
        /// <param name="bootstrapperContainer">The bootstrapper container.</param>
        /// <returns></returns>
        public static IBootstrapperWithContainerAdapter<TIocContainerAdapter>
            UseShutdown<TIocContainerAdapter>
            (this IBootstrapperWithContainerAdapter<TIocContainerAdapter> bootstrapperContainer)
            where TIocContainerAdapter : class, IIocContainer
        {
            return bootstrapperContainer.Use(
                new ShutdownMiddleware<TIocContainerAdapter>());
        }
    }
}