using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
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
        /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>
        /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>
        /// <param name="bootstrapperContainer">The bootstrapper container.</param>
        /// <returns></returns>
        public static IBootstrapperWithContainerAdapter<TRootViewModel, TIocContainerAdapter> 
            UseViewModelCreatorService<TRootViewModel, TIocContainerAdapter>
            (this IBootstrapperWithContainerAdapter<TRootViewModel, TIocContainerAdapter> bootstrapperContainer)
            where TRootViewModel : class
            where TIocContainerAdapter : class, IIocContainer, IIocContainerAdapter, IBootstrapperAdapter, new()
        {
            return bootstrapperContainer.Use(
                new RegisterViewModelCreatorServiceMiddleware<TRootViewModel, TIocContainerAdapter>());            
        }        
    }
}