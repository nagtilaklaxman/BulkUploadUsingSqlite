using Domain.Common.Entities;
using MediatR;

namespace Application.Job.Events;

public class JobReceived : INotification
{
    public JobRecord JobRecord { get; set; }
}