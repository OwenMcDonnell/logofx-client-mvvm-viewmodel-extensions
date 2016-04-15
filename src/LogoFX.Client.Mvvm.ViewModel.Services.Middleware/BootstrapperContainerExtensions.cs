using LogoFX.Bootstrapping;
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
        /// <typeparam name="TRootObject">The type of the root object.</typeparam>
        /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>
        /// <param name="bootstrapperContainer">The bootstrapper container.</param>
        /// <returns></returns>
        public static IBootstrapperWithContainerAdapter<TRootObject, TIocContainerAdapter> 
            UseViewModelCreatorService<TRootObject, TIocContainerAdapter>
            (this IBootstrapperWithContainerAdapter<TRootObject, TIocContainerAdapter> bootstrapperContainer)
            where TRootObject : class
            where TIocContainerAdapter : class, IIocContainer, IIocContainerAdapter, IBootstrapperAdapter, new()
        {
            return bootstrapperContainer.Use(
                new RegisterViewModelCreatorServiceMiddleware<TRootObject, TIocContainerAdapter>());            
        }        
    }
}