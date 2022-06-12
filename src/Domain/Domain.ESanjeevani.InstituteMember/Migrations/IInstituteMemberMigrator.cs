namespace Domain.ESanjeevani.InstituteMember.Migrations;

public interface IInstituteMemberMigrator
{
    public Task<bool> MigrateDatabaseAsync(string sessionId);
}