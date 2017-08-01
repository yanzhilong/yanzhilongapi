using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using yanzhilong.Domain;
using yanzhilong.Repository;

namespace yanzhilong.Service
{
    public class BrowsingService : IBaseService<Browsing>
    {
        private readonly IRepository<Browsing> _Repository;

        public BrowsingService(IRepository<Browsing> Repository)
        {
            this._Repository = Repository;
        }
        
        public void AddEntry(Browsing entity)
        {
            _Repository.Insert("InsertBrowsing", entity);
        }

        public void AddEntrys(IList<Browsing> entities)
        {
            _Repository.Insert("InsertBrowsing", entities);
        }

        public void DeleteEntry(Browsing entity)
        {
            _Repository.Delete("DeleteBrowsing", entity);
        }

        public void DeleteEntrys(IList<Browsing> entity)
        {
            _Repository.Delete("DeleteBrowsing", entity);
        }

        public int GetCount(Browsing entity)
        {
            throw new NotImplementedException();
        }

        public int GetCount(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public Browsing GetEntry(Browsing entity)
        {
            return _Repository.GetByCondition("SelectBrowsingByCondition", entity);
        }

        public Browsing GetEntry(object parameterObject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Browsing> GetEntrys(Browsing entity)
        {
            return _Repository.GetList("SelectBrowsingByCondition", entity);
        }

        public IEnumerable<Browsing> GetEntrys(Browsing entity, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Browsing> GetEntrys(object parameterObject, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Browsing> GetEntrys(int skip, int take, Browsing entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Browsing> GetEntrys(int skip, int take, object parameterObject)
        {
            throw new NotImplementedException();
        }

        public void UpdateEntry(Browsing entity)
        {
            _Repository.Update("UpdateBrowsing", entity);
        }

        public void UpdateEntrys(IList<Browsing> entities)
        {
            _Repository.Update("UpdateBrowsing", entities);
        }
    }
}