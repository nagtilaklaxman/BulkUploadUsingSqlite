using System.Net;
using System.Net.Http.Json;
using System.Text;
using BlazorWebAssemblyClient.models;
using Newtonsoft.Json;

namespace BlazorWebAssemblyClient.Services
{
    public interface IHttpApiService
    {
        Task<T> Get<T>(string apiEndPoint) where T : class;
        Task<bool> Post<T>(string apiEndPoint, T data) where T : class;
        Task<bool> Post<T>(string apiEndPoint, T data, string successMessge, string errorMessage) where T : class;
        Task<R> Post<T, R>(string apiEndPoint, T data, string successMessge = null, string errorMessage = null) where T : class where R : class;
        Task<T> UploadFile<T>(string apiEndPoint, MultipartFormDataContent multiContent);
        Task<bool> Put<T>(string apiEndPoint, T data) where T : class;
        Task<bool> Delete(string apiEndPoint);
    }
    public class HttpApiService : IHttpApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IMessageBoxService _messageBoxService;
        private readonly ISpinnerService _spinnerService;

        public HttpApiService(HttpClient httpClient, ISpinnerService spinnerService, IMessageBoxService messageBoxService)
        {
            _httpClient = httpClient;
            _spinnerService = spinnerService;
            _messageBoxService = messageBoxService;
        }

        public async Task<T> Get<T>(string apiEndPoint) where T : class
        {
            var result = await _httpClient.GetAsync(apiEndPoint);

            var resultContent = await result.Content.ReadFromJsonAsync<Envelope<T>>();
            return resultContent?.Result;
        }

        public async Task<bool> Post<T>(string apiEndPoint, T data) where T : class
        {
            return await Post<T>(apiEndPoint, data, "Data saved successfully", "There is problem in saving the data");
        }

        public async Task<bool> Post<T>(string apiEndPoint, T data, string successMessge, string errorMessage) where T : class
        {
            var isSuccess = false;
            try
            {
                _spinnerService.Show();
                var json = JsonConvert.SerializeObject(data);
                var result = await _httpClient.PostAsync(apiEndPoint, new StringContent(json, Encoding.UTF8, "application/json"));

                var resultContent = await result.Content.ReadFromJsonAsync<Envelope<T>>();
                _spinnerService.Hide();

                if (result.IsSuccessStatusCode)
                {
                    await _messageBoxService.ShowSuccess("Congratulations !", successMessge);
                }
                else
                {
                    var message = resultContent?.ErrorMessage;
                    await _messageBoxService.ShowError(string.IsNullOrWhiteSpace(message) ? errorMessage : message);
                }

            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine("Looks like the server is taking too long to respond, please recheck again in sometime.");
                Console.WriteLine(ex.Message);
                _spinnerService.Hide();
                await _messageBoxService.ShowInfo("Request Timeout", "Looks like the server is taking too long to respond, please recheck again in sometime.");
            }
            finally
            {
                _spinnerService.Hide();
            }
            return isSuccess;
        }

        public async Task<R> Post<T, R>(string apiEndPoint, T data, string successMessge = null, string errorMessage = null) where T : class where R : class
        {
            _spinnerService.Show();
            var json = JsonConvert.SerializeObject(data);
            var result = await _httpClient.PostAsync(apiEndPoint, new StringContent(json, Encoding.UTF8, "application/json"));
            _spinnerService.Hide();

            var resultContent = await result.Content.ReadFromJsonAsync<Envelope<R>>();

            if (result.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(successMessge))
            {
                await _messageBoxService.ShowSuccess(successMessge, "Congratulations !");
            }
            else if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                await _messageBoxService.ShowError(errorMessage);
            }

            return resultContent?.Result;

        }

        public async Task<T> UploadFile<T>(string apiEndPoint, MultipartFormDataContent multiContent)
        {
            _spinnerService.Show();
            var result = await _httpClient.PostAsync(apiEndPoint, multiContent);
            _spinnerService.Hide();

            var resultContent = await result.Content.ReadFromJsonAsync<Envelope<T>>();

            if (!result.IsSuccessStatusCode)
            {
                var message = resultContent?.ErrorMessage ?? "There is problem in uploading the file";
                await _messageBoxService.ShowError(message);
            }
            else
            {
                await _messageBoxService.ShowSuccess("Congratulations!", " File uploaded successfully");
            }

            var returnType = resultContent == null ? default(T) : resultContent.Result;

            return returnType;
        }

        public async Task<bool> Put<T>(string apiEndPoint, T data) where T : class
        {
            _spinnerService.Show();
            var json = JsonConvert.SerializeObject(data);
            var result = await _httpClient.PutAsync(apiEndPoint, new StringContent(json, Encoding.UTF8, "application/json"));
            _spinnerService.Hide();

            var resultContent = await result.Content.ReadFromJsonAsync<Envelope<T>>();
            if (!result.IsSuccessStatusCode)
            {
                var message = resultContent?.ErrorMessage ?? "There is problem in updating data";
                await _messageBoxService.ShowError(message);
            }
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string apiEndPoint)
        {
            var result = await _httpClient.DeleteAsync(apiEndPoint);

            if (result.IsSuccessStatusCode)
                await _messageBoxService.ShowSuccess("Data deleted successfully", "Congratulations !");
            else
                await _messageBoxService.ShowError("There is problem in deleting the data");

            return result.IsSuccessStatusCode;
        }

    }
    public class ValidateHeaderHandler : DelegatingHandler
    {
        // can be used to add headers while calling api
        public ValidateHeaderHandler()
        {

        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return await base.SendAsync(request, cancellationToken);
        }
    }
}

