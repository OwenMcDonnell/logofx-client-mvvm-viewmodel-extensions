using LogoFX.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    /// <summary>
    /// Middleware that's responsible for registering <see cref="IViewModelCreatorService"/> into the ioc container adapter.
    /// </summary>    
    /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>    
    public class RegisterViewModelCreatorServiceMiddleware<TIocContainerAdapter> :
        IMiddleware<IBootstrapperWithContainerAdapter<TIocContainerAdapter>>         
        where TIocContainerAdapter : class, IIocContainer
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerAdapter<TIocContainerAdapter> Apply(
            IBootstrapperWithContainerAdapter<TIocContainerAdapter> @object)
        {
            @object.Registrator.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            return @object;
        }
    }
}
