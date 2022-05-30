using System;
using CurrieTechnologies.Razor.SweetAlert2;

namespace BlazorWebAssemblyClient.Services
{
    public interface IMessageBoxService
    {
        Task<bool> ShowMessage(string title, string text);
        Task<bool> ShowInfo(string title, string text);
        Task<bool> ShowWarning(string title, string text);
        Task<bool> ShowConfirmation(string buttonText, string text);
        Task<bool> ShowSuccess(string title, string text);
        Task<bool> ShowError(string text);
    }
    public class MessageBoxService : IMessageBoxService
    {
        private readonly SweetAlertService _swal;

        public MessageBoxService(SweetAlertService swal)
        {
            _swal = swal;
        }

        public async Task<bool> ShowConfirmation(string buttonText, string text)
        {
            var confirmation = await _swal.FireAsync(new SweetAlertOptions()
            {
                Title = "Are you sure?",
                Html = text,
                Icon = "warning",
                ShowCancelButton = true,
                ConfirmButtonColor = "#3085d6",
                CancelButtonColor = "#d33",
                ConfirmButtonText = buttonText
            });

            return confirmation.IsConfirmed;
        }

        public async Task<bool> ShowError(string text)
        {
            await _swal.FireAsync(new SweetAlertOptions()
            {
                Title = "Oops...",
                Html = text,
                Icon = "error"
            });

            return true;
        }

        public async Task<bool> ShowMessage(string title, string text)
        {
            await _swal.FireAsync(new SweetAlertOptions()
            {
                Title = title,
                Html = text
            });

            return true;
        }

        public async Task<bool> ShowSuccess(string title, string text)
        {
            await _swal.FireAsync(new SweetAlertOptions()
            {
                Title = title,
                Html = text,
                Position = "center",
                Icon = "success",
                ShowConfirmButton = false,
                Timer = 2000
            });

            return true;
        }

        public async Task<bool> ShowWarning(string title, string text)
        {
            await _swal.FireAsync(new SweetAlertOptions()
            {
                Title = title,
                Html = text,
                Icon = "warning"
            });

            return true;
        }

        public async Task<bool> ShowInfo(string title, string text)
        {
            await _swal.FireAsync(new SweetAlertOptions()
            {
                Title = title,
                Html = text,
                Icon = "info"
            });

            return true;
        }
    }
}

