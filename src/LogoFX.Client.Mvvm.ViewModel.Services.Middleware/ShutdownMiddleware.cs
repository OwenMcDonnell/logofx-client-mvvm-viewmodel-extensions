using LogoFX.Bootstrapping;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    /// <summary>
    /// Middleware that's responsible for registering 
    /// <see cref="IShutdownService"/> inside the ioc container adapter.
    /// </summary>
    /// <typeparam name="TIocContainerAdapter">The type of the ioc container adapter.</typeparam>    
    public class ShutdownMiddleware<TIocContainerAdapter> : 
        IMiddleware<IBootstrapperWithContainerAdapter<TIocContainerAdapter>>
        where TIocContainerAdapter : IIocContainer
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns/>
        public IBootstrapperWithContainerAdapter<TIocContainerAdapter>
            Apply(IBootstrapperWithContainerAdapter<TIocContainerAdapter> @object)
        {
            if (@object is IShutdownService)
            {
                @object.Registrator.RegisterInstance(typeof(IShutdownService), @object);
            }            
            return @object;
        }
    }
}