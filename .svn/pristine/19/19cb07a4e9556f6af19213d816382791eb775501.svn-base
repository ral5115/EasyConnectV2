using EasyTools.Framework.Data;
using EasyTools.Framework.Persistance;
using EasyTools.Infrastructure.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace EasyTools.Infrastructure.Repositories.Base
{

    public class BaseEXTFileOperaRepository : BaseRepository<EXTFileOpera>
    {

        public BaseEXTFileOperaRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(EXTFileOpera data, Boolean byId)
        {
            String dml = "Select a from EXTFileOpera as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (!String.IsNullOrWhiteSpace(data.Name))
                    dml += "             AND upper(a.Name) like :Name \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, EXTFileOpera data, Boolean byId)
        {
            if (byId)
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
            }
            else
            {
                if (data.Id != 0)
                    query.SetInt32("Id", data.Id);
                if (!String.IsNullOrWhiteSpace(data.Name))
                    query.SetString("Name", "%" + data.Name.ToUpper() + "%");
            }
        }

        public override void SaveOrUpdateDetails(EXTFileOpera data)
        {
        }

        public override void AddMoreDetailFindById(EXTFileOpera data)
        {
        }

        public override EXTFileOpera FindById(EXTFileOpera data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<EXTFileOpera>();
            if (data != null)
            {
                data = new EXTFileOpera(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<EXTFileOpera> FindAll(EXTFileOpera data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<EXTFileOpera>() select new EXTFileOpera(a, option)).ToList<EXTFileOpera>();
        }
    }
}