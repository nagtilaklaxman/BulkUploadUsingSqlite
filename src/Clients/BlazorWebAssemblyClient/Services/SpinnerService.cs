using System;
namespace BlazorWebAssemblyClient.Services
{
    public interface ISpinnerService
    {
        event Action OnShow;
        event Action OnHide;

        void Show();
        void Hide();
    }
    public class SpinnerService : ISpinnerService
    {
        public event Action OnShow;
        public event Action OnHide;

        public void Show()
        {
            if (OnShow is not null)
            {
                foreach (Action action in OnShow.GetInvocationList())
                    action?.Invoke();
            }
        }

        public void Hide()
        {
            if (OnHide is not null)
            {
                foreach (Action action in OnHide.GetInvocationList())
                    action?.Invoke();
            }
        }
    }
}

