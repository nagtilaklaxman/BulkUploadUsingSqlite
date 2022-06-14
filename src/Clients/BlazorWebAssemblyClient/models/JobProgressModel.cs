namespace BlazorWebAssemblyClient.models;

public class JobProgressModel
{
    public string SessionId { get; set; }
    public string Status { get; set; }
    public string Message { get; set; }
    public string ModuleName { get; set; }
}