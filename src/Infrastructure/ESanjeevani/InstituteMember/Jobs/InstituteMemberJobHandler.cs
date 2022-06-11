using Core.ESanjeevani.InstituteMember.Repository;
using Core.interfaces.Repository;
using Infrastructure.Jobs;
using Microsoft.Extensions.Logging;

namespace Infrastructure.ESanjeevani.InstituteMember.Jobs
{
    public class InstituteMemberJobHandler
    {
        private readonly ILogger<InstituteMemberJobHandler> _logger;
     

        public InstituteMemberJobHandler(ILogger<InstituteMemberJobHandler> logger)
        {
            _logger = logger;

        }
    }

    public class InstituteMemberJobData
    {
        public string SessionId { get; set; }
        public string FilePath { get; set; }
        public int RecordsReceived { get; set; }
        public int RecordsValid { get; set; }
        public int RecordsInvalid { get; set; }
        public InstituteMemberTaskStatus  Status { get; set; }
        public string Message { get; set; }
    }

    public enum InstituteMemberTaskStatus
    {
        FileReceived,
        DataReceived,
        DataProcessed,
        DataValidated,
        Completed
    }
}

