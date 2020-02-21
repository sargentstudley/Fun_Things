namespace participant.participantapi.DataStore
{
    using System;
    using System.Linq.Expressions;
    using System.Collections.Generic;    public interface IRepository<T> : IDisposable
    {
        void Delete(Expression<Func<T, bool>> expression);
        void Delete(T item);
        void DeleteAll();
        T Single(Expression<Func<T, bool>> expression);
        System.Linq.IQueryable<T> All();
        System.Linq.IQueryable<T> All(int page, int pageSize);
        T Add(T item);
        IEnumerable<T> Add(IEnumerable<T> items);
    }
}