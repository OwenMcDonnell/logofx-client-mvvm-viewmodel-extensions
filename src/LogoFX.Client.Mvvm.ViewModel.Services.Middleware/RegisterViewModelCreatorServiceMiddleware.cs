using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    /// <summary>
    /// Middleware that's responsbile for registering <see cref="IViewModelCreatorService"/> into the ioc container adapter.
    /// </summary>
    /// <typeparam name="TRootViewModel">The type of the root view model.</typeparam>
    /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>    
    public class RegisterViewModelCreatorServiceMiddleware<TRootViewModel, TIocContainerAdapter> :
        IMiddleware<IBootstrapperWithContainerAdapter<TRootViewModel, TIocContainerAdapter>> 
        where TRootViewModel : class 
        where TIocContainerAdapter : class, IIocContainer, IIocContainerAdapter, IBootstrapperAdapter, new()
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<TRootViewModel, TIocContainerAdapter> Apply(
            IBootstrapperWithContainerAdapter<TRootViewModel, TIocContainerAdapter> @object)
        {
            @object.ContainerAdapter.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            return @object;
        }
    }   
}
