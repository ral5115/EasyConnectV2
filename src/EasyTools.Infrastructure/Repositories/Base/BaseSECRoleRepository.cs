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

    public class BaseSECRoleRepository : BaseRepository<SECRole>
    {

        public BaseSECRoleRepository(IUnitOfWork context)
            : base(context)
        {
        }

        public override String GetQuery(SECRole data, Boolean byId)
        {
            String dml = "Select a from SECRole as a where 1=1 ";
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

        public override void SetQueryParameters(IQuery query, SECRole data, Boolean byId)
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


        public override void SaveOrUpdateDetails(SECRole data)
        {
        }

        public override void AddMoreDetailFindById(SECRole data)
        {
        }

        public override SECRole FindById(SECRole data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<SECRole>();
            if (data != null)
            {
                data = new SECRole(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<SECRole> FindAll(SECRole data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<SECRole>() select new SECRole(a, option)).ToList<SECRole>();
        }
    }
}