using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ribbons.Data
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder HasOneToMany<TParent, TChildren>(
            this ModelBuilder modelBuilder, 
            Expression<Func<TParent, IEnumerable<TChildren>>> children,
            Expression<Func<TChildren, TParent>> parent,
            Expression<Func<TChildren, object>> foreignKey,
            DeleteBehavior deleteBehavior = DeleteBehavior.Cascade) where TParent : class where TChildren : class
        {
            modelBuilder
                .Entity<TParent>()
                .HasMany(children)
                .WithOne(parent)
                .HasForeignKey(foreignKey)
                .OnDelete(deleteBehavior);

            return modelBuilder;
        }

        /// <summary>
        /// Enforces a non-filtered unique index
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <returns></returns>
        public static ModelBuilder HasUniqueIndex<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, object>> index) where TEntity : class
        {
            modelBuilder
                .Entity<TEntity>()
                .HasIndex(index)
                .IsUnique()
                .HasFilter(null);

            return modelBuilder;
        }
    }
}
