using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;

namespace LogoFX.Client.Mvvm.ViewModel.Extensions.Tests
{    
    class TestBootstrapper : BootstrapperContainerBase<TestConductorViewModel,ExtendedSimpleContainerAdapter>
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
