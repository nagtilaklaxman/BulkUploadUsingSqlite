using System;
namespace BlazorWebAssemblyClient.models
{
    public class Envelope<T>
    {
        public T Result { get; set; } = default(T);
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string InvalidField { get; set; }
        public DateTime TimeGenerated { get; set; }

    }
}

