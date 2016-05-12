using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Solid.Bootstrapping;
using Solid.Practices.IoC;

namespace LogoFX.Client.Mvvm.ViewModel.Extensions.Tests
{    
    class TestBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<TestConductorViewModel>, IHaveContainerResolver
    {
        private static readonly ExtendedSimpleContainerAdapter _container = new ExtendedSimpleContainerAdapter();

        public TestBootstrapper()
            :base(_container, new BootstrapperCreationOptions
            {
                UseApplication = false                
            })
        {                   
        }

        public IIocContainerResolver Resolver => _container;
    }
}
