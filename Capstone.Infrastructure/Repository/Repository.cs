using Capstone.Infrastructure.Interfaces;
using Capstone.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public event OnWriteEventHandler<T> ScopedOnWriteEvent;
        public event OnWriteManyEventHandler<T> ScopedOnWriteManyEvent;
        public event OnReadEventHandler<T> ScopedOnReadEvent;
        public event OnWriteEventHandler<T> ScopedOnUpdateEvent;
        public event OnWriteEventHandler<T> ScopedOnDeleteEvent;
        public event OnWriteManyEventHandler<T> ScopedOnDeleteManyEvent;

        public event OnWriteEventHandlerAsync<T> ScopedOnWriteEventAsync;
        public event OnWriteManyEventHandlerAsync<T> ScopedOnWriteManyEventAsync;
        public event OnReadEventHandlerAsync<T> ScopedOnReadEventAsync;
        public event OnWriteEventHandlerAsync<T> ScopedOnDeleteEventAsync;
        public event OnWriteManyEventHandlerAsync<T> ScopedOnDeleteManyEventAsync;

        public static event OnWriteEventHandler<T> StaticOnWriteEvent;
        public static event OnWriteManyEventHandler<T> StaticOnWriteManyEvent;
        public static event OnReadEventHandler<T> StaticOnReadEvent;
        public static event OnWriteEventHandler<T> StaticOnUpdateEvent;
        public static event OnWriteEventHandler<T> StaticOnDeleteEvent;
        public static event OnWriteManyEventHandler<T> StaticOnDeleteManyEvent;

        public static event OnWriteEventHandlerAsync<T> StaticOnWriteEventAsync;
        public static event OnWriteManyEventHandlerAsync<T> StaticOnWriteManyEventAsync;
        public static event OnReadEventHandlerAsync<T> StaticOnReadEventAsync;
        public static event OnWriteEventHandlerAsync<T> StaticOnDeleteEventAsync;
        public static event OnWriteManyEventHandlerAsync<T> StaticOnDeleteManyEventAsync;

        private DbSet<T> _dbSet { get; set; }

        public Repository(CapstoneDBContext context)
        {
            _dbSet = context.Set<T>();

            ScopedOnWriteEventAsync += context.VoidEventSaveChangesAsync;
            ScopedOnWriteManyEventAsync += context.VoidEventSaveChangesAsync;
            ScopedOnUpdateEvent += context.VoidEventSaveChanges;
            ScopedOnDeleteEventAsync += context.VoidEventSaveChangesAsync;
            ScopedOnDeleteManyEventAsync += context.VoidEventSaveChangesAsync;
            
            ScopedOnWriteEvent += context.VoidEventSaveChanges;
            ScopedOnWriteManyEvent += context.VoidEventSaveChanges;
            ScopedOnUpdateEvent += context.VoidEventSaveChanges;
            ScopedOnDeleteEvent += context.VoidEventSaveChanges;
            ScopedOnDeleteManyEvent += context.VoidEventSaveChanges;
        }

        public void Delete(T Entity)
        {
            _dbSet.Remove(Entity);
            if (StaticOnDeleteEvent != null)
                StaticOnDeleteEvent?.Invoke(Entity, this);
            if (ScopedOnDeleteEvent != null)
                ScopedOnDeleteEvent?.Invoke(Entity, this);
        }

        public void DeleteMany(params T[] Entities)
        {
            _dbSet.RemoveRange(Entities);
            if (StaticOnDeleteManyEvent != null)
                StaticOnDeleteManyEvent?.Invoke(Entities, this);
            if (ScopedOnDeleteManyEvent != null)
                ScopedOnDeleteManyEvent?.Invoke(Entities, this);
        }

        public void DeleteMany(ICollection<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
            if (StaticOnDeleteManyEvent != null)
                StaticOnDeleteManyEvent?.Invoke(Entities, this);
            if (ScopedOnDeleteManyEvent != null)
                ScopedOnDeleteManyEvent?.Invoke(Entities, this);
        }

        public async Task DeleteAsync(T Entity)
        {
            _dbSet.Remove(Entity);
            if (StaticOnDeleteEventAsync != null)
                StaticOnDeleteEventAsync?.Invoke(Entity, this);
            if (ScopedOnDeleteEventAsync != null)
                ScopedOnDeleteEventAsync?.Invoke(Entity, this);
        }

        public async Task DeleteManyAsync(params T[] Entities)
        {
            _dbSet.RemoveRange(Entities);
            if (StaticOnDeleteManyEventAsync != null)
                StaticOnDeleteManyEventAsync?.Invoke(Entities, this);
            if (ScopedOnDeleteManyEventAsync != null)
                ScopedOnDeleteManyEventAsync?.Invoke(Entities, this);
        }

        public async Task DeleteManyAsync(ICollection<T> Entities)
        {
            _dbSet.RemoveRange(Entities);
            if (StaticOnDeleteManyEventAsync != null)
                StaticOnDeleteManyEventAsync?.Invoke(Entities, this);
            if (ScopedOnDeleteManyEventAsync != null)
                ScopedOnDeleteManyEventAsync?.Invoke(Entities, this);
        }

        public IQueryable<T> ReadAll()
        {
            IQueryable<T> list = _dbSet;
            if (StaticOnReadEvent != null)
                StaticOnReadEvent?.Invoke(this);
            if (ScopedOnReadEventAsync != null)
                ScopedOnReadEvent?.Invoke(this);
            return list;
        }

        public IQueryable<T> ReadFiltered(Func<T, bool> predicate)
        {
            IQueryable<T> list = _dbSet.Where(predicate).AsQueryable();
            if (StaticOnReadEvent != null)
                StaticOnReadEvent?.Invoke(this);
            if (ScopedOnReadEventAsync != null)
                ScopedOnReadEvent?.Invoke(this);
            return list;
        }

        public async Task<IQueryable<T>> ReadFilteredAsync(Func<T, bool> predicate)
        {
            IQueryable<T> list = _dbSet.Where(predicate).AsQueryable();
            if (StaticOnReadEventAsync != null)
                await StaticOnReadEventAsync?.Invoke(this);
            if (ScopedOnReadEventAsync != null)
                await ScopedOnReadEventAsync?.Invoke(this);
            return list;
        }

        public void Update(T Entity)
        {
            _dbSet.Add(Entity);
            StaticOnUpdateEvent?.Invoke(Entity, this);
            ScopedOnUpdateEvent?.Invoke(Entity, this);
        }

        public void Write(T Entity)
        {
            _dbSet.Add(Entity);
            StaticOnWriteEvent?.Invoke(Entity, this);
            ScopedOnWriteEvent?.Invoke(Entity, this);
        }

        public async Task WriteAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
            await StaticOnWriteEventAsync?.Invoke(Entity, this);
            await ScopedOnWriteEventAsync?.Invoke(Entity, this);
        }

        public void WriteMany(ICollection<T> Entity)
        {
            _dbSet.AddRange(Entity);
            StaticOnWriteManyEvent?.Invoke(Entity, this);
            ScopedOnWriteManyEvent?.Invoke(Entity, this);
        }

        public async Task WriteManyAsync(ICollection<T> Entity)
        {
            await _dbSet.AddRangeAsync(Entity);
            await StaticOnWriteManyEventAsync?.Invoke(Entity, this);
            await ScopedOnWriteManyEventAsync?.Invoke(Entity, this);
        }

        public void WriteMany(params T[] Entity)
        {
            _dbSet.AddRange(Entity);
            StaticOnWriteManyEvent?.Invoke(Entity, this);
            ScopedOnWriteManyEvent?.Invoke(Entity, this);
        }

        public async Task WriteManyAsync(params T[] Entity)
        {
            await _dbSet.AddRangeAsync(Entity);
            await StaticOnWriteManyEventAsync?.Invoke(Entity, this);
            await ScopedOnWriteManyEventAsync?.Invoke(Entity, this);
        }
    }
}
