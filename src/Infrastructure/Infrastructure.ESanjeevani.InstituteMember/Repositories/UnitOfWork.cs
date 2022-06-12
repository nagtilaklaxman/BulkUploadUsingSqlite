using System.Data;
using Domain.ESanjeevani.InstituteMember.Repositories;
using Domain.ESanjeevani.InstituteMember.Repository;
using Infrastructure.ESanjeevani.InstituteMember.Migrations;

namespace Infrastructure.ESanjeevani.InstituteMember.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly IInstituteMemberConnectionFactory _connectionFactory;
    private IDbConnection _connection;
    private IDbTransaction _transaction;

    private IInstituteMemberBulkEntityRepository _bulkEntities;
    private readonly IMemberRepository _members;
    private readonly IInstituteRepository _institutes;

    public UnitOfWork(IInstituteMemberConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public Task<bool> SetSession(string sessionId)
    {
        _connection = _connectionFactory.GetConnection(sessionId);
        return Task.FromResult(true);
    }

    public void StartTransaction()
    {
        if (_connection is not null)
        {
            _transaction = _connection.BeginTransaction();
            _connection.Open();
        }
    }

    public void Commit()
    {
        if (_transaction is not null && _connection is not null)
        {
            _transaction.Commit();
            _connection.Close();
        }
    }

    public void RollBack()
    {
        if (_transaction is not null && _connection is not null)
        {
            _transaction.Rollback();
            _connection.Close();
        }
    }

    public IInstituteMemberBulkEntityRepository BulkEntities => _bulkEntities = _bulkEntities ?? new InstituteMemberBulkEntityRepository(_connection);

    public void Dispose()
    {
        if (_transaction is not null && _connection is not null)
        {
            _transaction.Dispose();
            _connection.Dispose();
        }
    }
}