using Domain.Common.Entities;

namespace Domain.Common.interfaces;

public interface IJobRecordCommand
{
    public string ModuleName { get; set; }
    public JobRecord JobRecord { get; set; }
}