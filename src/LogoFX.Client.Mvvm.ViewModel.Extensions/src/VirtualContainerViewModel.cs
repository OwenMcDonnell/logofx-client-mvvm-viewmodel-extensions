using Caliburn.Micro;
using LogoFX.Client.Mvvm.ViewModel.Contracts;

namespace LogoFX.Client.Mvvm.ViewModel.Extensions
{
    public abstract class VirtualContainerViewModel<TModel, TViewModel> : Conductor<TViewModel>, IModelWrapper<TModel>, IHaveSubViewModel
        where TViewModel : class, IModelWrapper<TModel>
    {
        #region Fields

        private bool _isSubViewModelVisible;
        private TViewModel _subViewModel;

        #endregion

        #region Constructors

        protected VirtualContainerViewModel(TModel model)
        {
            Model = model;
        }

        #endregion

        #region Public Properties

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }

        public TViewModel SubViewModel
        {
            get { return GetSubViewModel(); }
        }
        
        #endregion
        
        #region Protected

        protected abstract TViewModel CreateSubViewModel();

        #endregion

        #region Private

        private TViewModel GetSubViewModel()
        {
            return _subViewModel ?? (_subViewModel = CreateSubViewModel());
        }

        private void UpdateSubModel()
        {
            ActivateItem(IsSubViewModelVisible ? GetSubViewModel() : null);
        }

        #endregion

        #region Overrides

        protected override void OnActivate()
        {
            base.OnActivate();

            if (IsSubViewModelVisible)
            {
                UpdateSubModel();
            }
        }

        #endregion

        #region IModelWrapper<TModel>

        object IModelWrapper.Model => Model;

        public TModel Model { get; private set; }

        #endregion

        #region IHaveSubViewModel

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

        #endregion
    }
}