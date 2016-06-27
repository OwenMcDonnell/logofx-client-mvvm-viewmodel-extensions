using LogoFX.Bootstrapping;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    /// <summary>
    /// Middleware that's responsible for registering <see cref="IViewModelCreatorService"/> into the ioc container registrator.
    /// </summary>
    public class RegisterViewModelCreatorServiceMiddleware :
        IMiddleware<IBootstrapperWithContainerRegistrator>
    {
        /// <summary>
        /// Applies the middleware on the specified object.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public IBootstrapperWithContainerRegistrator Apply(
            IBootstrapperWithContainerRegistrator @object)
        {
            @object.Registrator.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            return @object;
        }
    }
}
