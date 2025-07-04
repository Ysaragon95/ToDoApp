﻿using ToDo.Domain.Interfaces.Repositories;
using ToDo.Infrastructure.Persistence.Context;

namespace ToDo.Infrastructure.Common
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
