using Domain.Common.interfaces;

namespace Application.Job;

public delegate IJobRecordCommand  ModuleJobHandlerResolver(string moduleName);

public static class ModuleNames
{
    public static class Esanjeevani
    {
        public const string InstituteMember = "module.esanjeevani.institutemember";
    }
}