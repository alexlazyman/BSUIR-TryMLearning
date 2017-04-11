using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TryMLearning.Persistence.Interfaces;

namespace TryMLearning.Persistence.Helpers
{
    public static class DbContextExtensions
    {
        public static TEntity SafeUpdate<TContext, TEntity>(this TContext context, TEntity entity)
            where TContext : DbContext
            where TEntity : class, IDbEntity
        {
            var existingEntity = context.Set<TEntity>().Local.FirstOrDefault(a => a.Id == entity.Id);
            if (existingEntity == null)
            {
                context.Set<TEntity>().Attach(entity);
            }
            else
            {
                var entry = context.Entry(existingEntity);
                entry.CurrentValues.SetValues(entity);
            }

            return existingEntity ?? entity;
        }

        public static void SafeDelete<TContext, TEntity>(this TContext context, TEntity entity)
            where TContext : DbContext
            where TEntity : class, IDbEntity
        {
            var existingEntity = context.Set<TEntity>().Local.FirstOrDefault(a => a.Id == entity.Id);
            context.Entry(existingEntity ?? entity).State = EntityState.Deleted;
        }
    }
}