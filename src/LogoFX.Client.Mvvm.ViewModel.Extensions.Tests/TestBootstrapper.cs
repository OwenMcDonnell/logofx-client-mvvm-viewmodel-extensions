using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;

namespace LogoFX.Client.Mvvm.ViewModel.Extensions.Tests
{    
    class TestBootstrapper : BootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<TestConductorViewModel>
    {
        public TestBootstrapper()
            :base(new ExtendedSimpleContainerAdapter(), new BootstrapperCreationOptions
            {
                UseApplication = false                
            })
        {                   
        }
    }
}
