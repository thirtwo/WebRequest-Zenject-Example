using System;
namespace thirtwo.UI
{
    public abstract class ViewModel
    {
        public event Action OnDisplay;
        public event Action OnHide;
    }
}
