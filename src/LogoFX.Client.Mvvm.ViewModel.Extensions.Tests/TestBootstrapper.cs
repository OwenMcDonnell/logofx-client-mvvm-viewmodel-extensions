using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;

namespace LogoFX.Client.Mvvm.ViewModel.Extensions.Tests
{    
    class TestBootstrapper : BootstrapperContainerBase<TestConductorViewModel,ExtendedSimpleContainerAdapter>
    {
        public TestBootstrapper(ExtendedSimpleContainerAdapter container)
            :base(container, new BootstrapperContainerCreationOptions
            {
                UseApplication = false
            })
        {
            
        }
    }
}
