using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Ribbons.Data
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Creates a one-to-many relationship between <typeparamref name="TParent"/> and <typeparamref name="TChildren"/>
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <typeparam name="TChildren"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="children"></param>
        /// <param name="parent"></param>
        /// <param name="foreignKey"></param>
        /// <param name="deleteBehavior"></param>
        /// <returns></returns>
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
        /// Creates a one-to-one relationship between <typeparamref name="TParent"/> and <typeparamref name="TChild"/>
        /// </summary>
        /// <typeparam name="TParent"></typeparam>
        /// <typeparam name="TChild"></typeparam>
        /// <param name="modelBuilder"></param>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <param name="foreignKey"></param>
        /// <param name="deleteBehavior"></param>
        /// <returns></returns>
        public static ModelBuilder HasOneToOne<TParent, TChild>(
            this ModelBuilder modelBuilder, 
            Expression<Func<TParent, TChild>> child, 
            Expression<Func<TChild, TParent>> parent, 
            Expression<Func<TChild, object>> foreignKey, 
            DeleteBehavior deleteBehavior = DeleteBehavior.Cascade) where TParent : class where TChild : class
        {
            modelBuilder
                .Entity<TParent>()
                .HasOne(child)
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

        public static ModelBuilder HasData<TEntity>(this ModelBuilder modelBuilder, TEntity data) where TEntity : class
        {
            modelBuilder
                .Entity<TEntity>()
                .HasData(data);

            return modelBuilder;
        }
    }
}
