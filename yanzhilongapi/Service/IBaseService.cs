using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yanzhilong.Service
{
    public interface IBaseService<T>
    {
        void AddEntry(T entity);

        void AddEntrys(IList<T> entities);

        void DeleteEntry(T entity);

        void DeleteEntrys(IList<T> entity);

        void UpdateEntry(T entity);

        void UpdateEntrys(IList<T> entities);

        IEnumerable<T> GetEntrys(T entity);

        IEnumerable<T> GetEntrys(T entity, int page, int pageSize);

        IEnumerable<T> GetEntrys(Object parameterObject, int page, int pageSize);

        IEnumerable<T> GetEntrys(int skip, int take, T entity);

        IEnumerable<T> GetEntrys(int skip, int take, Object parameterObject);

        T GetEntry(T entity);

        T GetEntry(Object parameterObject);

        int GetCount(T entity);

        int GetCount(Object parameterObject);
    }
}
