using System.Data;

namespace Infrastructure.ESanjeevani.InstituteMember.Migrations;

public interface IInstituteMemberConnectionFactory
{
    public IDbConnection GetConnection(string sessionId);
}