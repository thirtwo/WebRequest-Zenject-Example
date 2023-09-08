using UnityEngine;
namespace thirtwo.UI
{
    /// <summary>
    /// We use window as a view class for MVVM
    /// </summary>
    public abstract partial class Window : MonoBehaviour
    {
        private ViewModel _viewModel;
        public ViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                _viewModel = value ?? throw new System.Exception("ViewModel should be regiestered to DI");
                _viewModel.OnDisplay += Display;
                _viewModel.OnDisplay += Hide;
            }
        }

        #region Unity Callbacks 

        protected virtual void OnDestroy()
        {
            _viewModel.OnDisplay -= Display;
            _viewModel.OnDisplay -= Hide;
        }
        #endregion

        #region Class Functions
        protected virtual void Hide() => gameObject.SetActive(false);
        protected virtual void Display() => gameObject.SetActive(true);
        #endregion
    }
}
