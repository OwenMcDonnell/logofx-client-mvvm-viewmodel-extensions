using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;

namespace LogoFX.Client.Mvvm.ViewModel.Services
{
    class RegisterViewModelCreatorServiceMiddleware<TRootViewModel, TIocContainerAdapter> :
        IMiddleware<BootstrapperContainerBase<TRootViewModel, TIocContainerAdapter>> 
        where TRootViewModel : class 
        where TIocContainerAdapter : class, IIocContainer, IIocContainerAdapter, IBootstrapperAdapter, new()
    {
        public BootstrapperContainerBase<TRootViewModel, TIocContainerAdapter> Apply(
            BootstrapperContainerBase<TRootViewModel, TIocContainerAdapter> @object)
        {
            @object.ContainerAdapter.RegisterSingleton<IViewModelCreatorService, ViewModelCreatorService>();
            return @object;
        }
    }   
}
