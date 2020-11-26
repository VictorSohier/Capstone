using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Capstone.Infrastructure.Interfaces
{
    public delegate void OnWriteEventHandler<T>(T obj, object sender);
    public delegate void OnWriteManyEventHandler<T>(ICollection<T> objs, object sender);
    public delegate void OnReadEventHandler<T>(object sender);

    public delegate Task OnWriteEventHandlerAsync<T>(T obj, object sender);
    public delegate Task OnWriteManyEventHandlerAsync<T>(ICollection<T> objs, object sender);
    public delegate Task OnReadEventHandlerAsync<T>(object sender);

    public interface IRepository<T> where T : class
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

        public void Write(T Entity);
        public Task WriteAsync(T Entity);
        public void WriteMany(ICollection<T> Entity);
        public void WriteMany(params T[] Entity);
        public Task WriteManyAsync(ICollection<T> Entity);
        public Task WriteManyAsync(params T[] Entity);
        public IQueryable<T> ReadAll();
        public IQueryable<T> ReadFiltered(Func<T, bool> predicate);
        public Task<IQueryable<T>> ReadFilteredAsync(Func<T, bool> predicate);
        public void Update(T Entity);
        public void Delete(T Entity);
        public void DeleteMany(ICollection<T> Entities);
        public void DeleteMany(params T[] Entities);
    }
}
