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

    public class BaseCONStructureAssociationRepository : BaseRepository<CONStructureAssociation>
    {

        public BaseCONStructureAssociationRepository(IUnitOfWork context) : base(context)
        {
        }

        public override String GetQuery(CONStructureAssociation data, Boolean byId)
        {
            String dml = "Select a from CONStructureAssociation as a where 1=1 ";
            if (byId)
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
            }
            else
            {
                if (data.Id != 0)
                    dml += "             AND a.Id = :Id \n";
                if (data.MainStructureId != 0)
                    dml += "             AND a.MainStructureId = :MainStructureId \n";
                if (data.ChildStructureId != 0)
                    dml += "             AND a.ChildStructureId = :ChildStructureId \n";

            }
            return dml;
        }

        public override void SetQueryParameters(IQuery query, CONStructureAssociation data, Boolean byId)
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
                if (data.MainStructureId != 0)
                    query.SetInt32("MainStructureId", data.MainStructureId);
                if (data.ChildStructureId != 0)
                    query.SetInt32("ChildStructureId", data.ChildStructureId);
            }
        }

        public override void SaveOrUpdateDetails(CONStructureAssociation data)
        {
        }

        public override void AddMoreDetailFindById(CONStructureAssociation data)
        {
        }

        public override CONStructureAssociation FindById(CONStructureAssociation data)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, true));
            SetQueryParameters(query, data, true);
            data = query.UniqueResult<CONStructureAssociation>();
            if (data != null)
            {
                data = new CONStructureAssociation(data, Options.Me);
                AddMoreDetailFindById(data);
            }
            return data;
        }

        public override List<CONStructureAssociation> FindAll(CONStructureAssociation data, Options option)
        {
            IQuery query = work.Session.CreateQuery(GetQuery(data, false));
            SetQueryParameters(query, data, false);
            if (data.HasPaging)
            {
                query.SetFirstResult((data.PageSize * data.CurrentPage) - data.PageSize);
                query.SetMaxResults(data.PageSize);
            }
            return (from a in query.List<CONStructureAssociation>() select new CONStructureAssociation(a, option)).ToList<CONStructureAssociation>();
        }

    }
}