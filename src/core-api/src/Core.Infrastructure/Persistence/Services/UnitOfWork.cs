using Core.Application.Common.Interfaces.Persistance;
using Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Storage;

namespace Core.Infrastructure.Persistence.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainDbContext _dbContext;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction already started.");
            }

            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction started.");
            }

            try
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("No transaction started.");
            }

            await _transaction.RollbackAsync();
            await DisposeTransactionAsync();
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        private async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}