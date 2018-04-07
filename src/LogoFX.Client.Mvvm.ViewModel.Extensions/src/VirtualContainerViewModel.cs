using Caliburn.Micro;
using LogoFX.Client.Mvvm.ViewModel.Contracts;

namespace iXCapture.Processing.ViewModels
{
    public abstract class VirtualContainerViewModel<TModel, TViewModel> : Conductor<TViewModel>, IModelWrapper<TModel>, IHaveSubViewModel
        where TViewModel : class, IModelWrapper<TModel>
    {
        private bool _isSubViewModelVisible;
        private TViewModel _subViewModel;

        protected VirtualContainerViewModel(TModel model)
        {
            Model = model;
        }

        object IModelWrapper.Model => Model;

        public TModel Model { get; private set; }

        public bool IsSubViewModelVisible
        {
            get => _isSubViewModelVisible;
            set
            {
                if (Set(ref _isSubViewModelVisible, value))
                {
                    UpdateSubModel();
                }
            }
        }

        protected abstract TViewModel CreateSubViewModel();

        private TViewModel GetSubViewModel()
        {
            return _subViewModel ?? (_subViewModel = CreateSubViewModel());
        }

        private void UpdateSubModel()
        {
            ActivateItem(IsSubViewModelVisible ? GetSubViewModel() : null);
        }
    }
}