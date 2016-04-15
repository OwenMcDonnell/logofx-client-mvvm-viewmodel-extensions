using LogoFX.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    /// <summary>
    /// Middleware that's responsible for registering <see cref="IViewModelCreatorService"/> into the ioc container adapter.
    /// </summary>
    /// <typeparam name="TRootObject">The type of the root object.</typeparam>
    /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>    
    public class RegisterViewModelCreatorServiceMiddleware<TRootObject, TIocContainerAdapter> :
        IMiddleware<IBootstrapperWithContainerAdapter<TRootObject, TIocContainerAdapter>> 
        where TRootObject : class 
        where TIocContainerAdapter : class, IIocContainer, IIocContainerAdapter, IBootstrapperAdapter, new()
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<TRootObject, TIocContainerAdapter> Apply(
            IBootstrapperWithContainerAdapter<TRootObject, TIocContainerAdapter> @object)
        {
            @object.ContainerAdapter.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            return @object;
        }
    }
}
