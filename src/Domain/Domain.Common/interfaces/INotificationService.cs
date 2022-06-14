namespace Domain.Common.interfaces;

public interface INotificationService<in T> where T :class
{
    public Task Notify(T data);
}